Imports System.Runtime.InteropServices

Public Class WindowHook

#Region " Pinvokes "

    <DllImport("user32.dll", CharSet:=CharSet.Auto, EntryPoint:="FindWindow")> _
    Public Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function

    Public Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer

#End Region

#Region " Properties "

    Private Shared _ResultState As ResultType = ResultType.Indeterminate
    Public ReadOnly Property ResultState As ResultType
        Get
            Return _ResultState
        End Get
    End Property

    Private Shared _GameLocationPoint As Point = New Point(0, 0)
    Public ReadOnly Property GameLocationPoint As Point
        Get
            Return _GameLocationPoint
        End Get
    End Property

    Private Shared _GameSizePoint As Size = New Size(0, 0)
    Public ReadOnly Property GameSizePoint As Size
        Get
            Return _GameSizePoint
        End Get
    End Property

#End Region

#Region " Types/Structures "

    Public Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Public Enum ResultType
        HookingSuccessful = 0
        HookingError = 1
        Indeterminate = 2
    End Enum

#End Region

    Public ReadOnly hWnd As IntPtr
    Public ReadOnly pHandle As IntPtr
    Public ReadOnly processID As Integer
    Public ReadOnly window_loc As RECT
    Public Const ProcessNameCE As String = "haloce"
    Public Const ProcessNamePC As String = "halo"

    Private tmrFormMonitor As System.Windows.Forms.Timer = New System.Windows.Forms.Timer()

    Public Sub New()
        Try
            Dim proc As Process() = Process.GetProcessesByName(ProcessNameCE)
            If proc.Count = 0 Then
                proc = Process.GetProcessesByName(ProcessNamePC)
            End If
            Dim windowname As String = proc(0).MainWindowTitle
            hWnd = FindWindow(vbNullString, windowname)
            GetWindowThreadProcessId(hWnd, processID)
            GetWindowRect(hWnd, window_loc)
            If hWnd = 0 Then
                _ResultState = ResultType.HookingError
            Else
                AddHandler tmrFormMonitor.Tick, New System.EventHandler(AddressOf tmrFormMonitor_Tick)
                tmrFormMonitor.Interval = 100
                tmrFormMonitor.Enabled = True
            End If
        Catch ex As Exception
            _ResultState = ResultType.HookingError
        End Try
    End Sub

    Private Sub tmrFormMonitor_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim LocationGame As System.Drawing.Point = New System.Drawing.Point(window_loc.Left, window_loc.Top) 'Location
            _GameLocationPoint = LocationGame
            Dim SizeGame = New Size(window_loc.Right - window_loc.Left, window_loc.Bottom - window_loc.Top) 'Size
            _GameSizePoint = SizeGame
            _ResultState = ResultType.HookingSuccessful
        Catch ex As Exception
            _ResultState = ResultType.HookingError
        End Try
    End Sub

End Class
