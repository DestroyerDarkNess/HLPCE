Imports HALOCELauncher.Core.Utils

Public Class CrashDialog

#Region " No Windows Focus "

    Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
        Get
            Return True
        End Get
    End Property

    Private Const WS_EX_TOPMOST As Integer = &H8

    Private Const WS_THICKFRAME As Integer = &H40000
    Private Const WS_CHILD As Integer = &H40000000
    Private Const WS_EX_NOACTIVATE As Integer = &H8000000
    Private Const WS_EX_TOOLWINDOW As Integer = &H80

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim createParamsA As CreateParams = MyBase.CreateParams
            createParamsA.ExStyle = createParamsA.ExStyle Or WS_EX_TOPMOST Or WS_EX_NOACTIVATE Or WS_EX_TOOLWINDOW
            Return createParamsA
        End Get
    End Property

#End Region

    Private Sub ExHaloError_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Aplyblur1 As New GetBlurBitmap(Me.GunaElipsePanel1)
    End Sub

    Private Sub CloseGame(ByVal ProcName As String)
        On Error Resume Next
        Dim proc = Process.GetProcessesByName(ProcName)
        For i As Integer = 0 To proc.Count - 1
            proc(i).Kill()
        Next i
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        CloseGame("haloce")
        CloseGame("halo")
        Me.Close()
    End Sub

    Private Sub HaloLaunchCE_Click(sender As Object, e As EventArgs) Handles HaloLaunchCE.Click
        CloseGame("haloce")
        CloseGame("halo")
        Dim NewLauncher As New Core.Launcher(My.Settings.OldGameDir)
        NewLauncher.Launch(My.Settings.OldIPAdress)
        Me.Close()
    End Sub

End Class