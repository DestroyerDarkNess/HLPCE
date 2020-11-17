Imports System.Runtime.InteropServices
Imports System.Text

Public Class HaloCrashHook

#Region " Pinvokes "

    <DllImport("user32.dll", CharSet:=CharSet.Auto, EntryPoint:="FindWindow")> _
    Public Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Sub GetClassName(ByVal hWnd As System.IntPtr, ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer)
    End Sub

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function GetWindowText(ByVal hwnd As IntPtr, ByVal lpString As StringBuilder, ByVal cch As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function GetWindowTextLength(ByVal hwnd As IntPtr) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function IsWindowVisible(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

#End Region

#Region " Properties "

    Private Shared _ResultState As ResultType = ResultType.Indeterminate
    Public ReadOnly Property ResultState As ResultType
        Get
            Return _ResultState
        End Get
    End Property

    Private Shared _ResultText As String = String.Empty
    Public ReadOnly Property ResultText As String
        Get
            Return _ResultText
        End Get
    End Property

#End Region

#Region " Declare's "

    Private tmrFormMonitor As System.Windows.Forms.Timer = New System.Windows.Forms.Timer()
    Private children As List(Of MessageInfo)

    Private Delegate Function EnumCallBackDelegate(ByVal hwnd As IntPtr, ByVal lParam As IntPtr) As Integer
    Private Declare Function EnumChildWindows Lib "user32" (ByVal hWndParent As IntPtr, ByVal lpEnumFunc As EnumCallBackDelegate, ByVal lParam As IntPtr) As IntPtr
    Private Contador As Integer = 0

#End Region

#Region " Types "

    Public Enum ResultType
        Notify = 0
        Indeterminate = 1
        IError = 2
    End Enum

#End Region

    Public Sub New()
        AddHandler tmrFormMonitor.Tick, New System.EventHandler(AddressOf tmrFormMonitor_Tick)
        tmrFormMonitor.Interval = 1
        tmrFormMonitor.Enabled = True
    End Sub

    Private Sub tmrFormMonitor_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Dim hwnd = FindWindow("#32770", "Halo - Exception")
        Dim hwndtwo = FindWindow("#32770", "Exception!")
        Dim hwndtree = FindWindow("#32770", "Error!")
        If Not hwnd = IntPtr.Zero Then
            GetChildWindows(hwnd)
            For i = 0 To children.Count - 1
                If i = 6 Then
                    If IsWindowVisible(children(i).hWnd) = True Then
                        SetWindowState.SetWindowState(hwnd, SetWindowState.WindowState.Hide)
                        _ResultText = children(i).Text
                        _ResultState = ResultType.Notify
                    Else
                        _ResultText = String.Empty
                        _ResultState = ResultType.Indeterminate
                    End If
                End If
            Next
        Else
            _ResultText = String.Empty
            _ResultState = ResultType.Indeterminate
        End If

        If Not hwndtwo = IntPtr.Zero Then
            SetWindowState.SetWindowState(hwndtwo, SetWindowState.WindowState.Hide)
                _ResultState = ResultType.IError
        End If

        If Not hwndtree = IntPtr.Zero Then
             SetWindowState.SetWindowState(hwndtree, SetWindowState.WindowState.Hide)
                _ResultState = ResultType.IError
         End If
    End Sub

    Public Sub ResetClass()
        _ResultText = String.Empty
        _ResultState = ResultType.Indeterminate
    End Sub

    Private Sub GetChildWindows(ByVal hwnd As IntPtr)
        children = New List(Of MessageInfo)
        EnumChildWindows(hwnd, AddressOf EnumProc, Nothing)
    End Sub

    Private Function EnumProc(ByVal hwnd As IntPtr, ByVal lParam As IntPtr) As Int32
        If hwnd <> IntPtr.Zero Then
            children.Add(New MessageInfo(hwnd, Get_ClassName(hwnd), GetText(hwnd)))
        End If
        Return 1
    End Function

    Private Function Get_ClassName(ByVal hWnd As IntPtr) As String
        Dim sbClassName As New StringBuilder("", 256)
        Call GetClassName(hWnd, sbClassName, 256)
        Return sbClassName.ToString
    End Function

    Private Function GetText(ByVal hWnd As IntPtr) As String
        Dim length As Integer = GetWindowTextLength(hWnd)
        If length = 0 Then Return ""
        Dim sb As New StringBuilder("", length + 1)
        GetWindowText(hWnd, sb, sb.Capacity)
        Return sb.ToString()
    End Function

End Class

Public Class MessageInfo
    Public hWnd As IntPtr
    Public ClassName As String
    Public Text As String
    Public Sub New(hwnd As IntPtr, clsname As String, text As String)
        Me.hWnd = hwnd
        Me.ClassName = clsname
        Me.Text = text
    End Sub
End Class
