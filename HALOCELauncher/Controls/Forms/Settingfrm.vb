Imports HALOCELauncher.Core.Utils.LogFuncs
Imports HALOCELauncher.Core.Helpers
Imports HALOCELauncher.Core.Utils

Public Class Settingfrm

    Private Sub Settingfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try : AddHandler Application.ThreadException, AddressOf Application_Exception_Handler _
           : Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, False) _
               : Catch : End Try
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent
        Me.Refresh()
        StartC()
    End Sub

    Public Overrides Sub Refresh()
        Dim Aplyblur As New GetBlurBitmap(Me.Panel1)
        Dim Aplyblur1 As New GetBlurBitmap(Me.GunaPanel2)
        MyBase.Refresh()
    End Sub

    Private Sub Application_Exception_Handler(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        Dim ex As Exception = CType(e.Exception, Exception)
        WriteLog(ex.Message, InfoType.Exception)
    End Sub

#Region " Parent Dragger "

    Private Dragger As ControlDragger = ControlDragger.Empty

    Private Sub InitializeDrag()
        Me.Dragger = New ControlDragger(Me, Form1)
        Me.Dragger = New ControlDragger(GunaPanel1, Form1)
        For Each Cdrag As Control In GunaPanel1.Controls
            Me.Dragger = New ControlDragger(Cdrag, Form1)
        Next
        For Each Cdraga As Control In GunaPanel3.Controls
            Me.Dragger = New ControlDragger(Cdraga, Form1)
        Next
        For Each Cdraga As Control In GunaPanel3.Controls
            Me.Dragger = New ControlDragger(Cdraga, Form1)
        Next
        For Each Cdragb As Control In GunaPanel4.Controls
            Me.Dragger = New ControlDragger(Cdragb, Form1)
        Next
        For Each Cdragc As Control In GunaPanel5.Controls
            Me.Dragger = New ControlDragger(Cdragc, Form1)
        Next
        Me.Dragger.Enabled = True
    End Sub

    Private Sub AlternateDrag()
        Dragger.Enabled = Not Dragger.Enabled
    End Sub

    Private Sub FinishDrag()
        Dragger.Dispose()
    End Sub

    Private Sub Drag() Handles MyBase.Shown
        Me.InitializeDrag()
    End Sub

#End Region

    Private Sub StartC()
        GunaPanel1.BackColor = Color.FromArgb(40, Color.Black)
        GunaPanel3.BackColor = Color.FromArgb(40, Color.Black)
        GunaPanel4.BackColor = Color.FromArgb(40, Color.Black)
        GunaPanel5.BackColor = Color.FromArgb(40, Color.Black)
        GunaComboBox1.StartIndex = My.Settings.LaunchMode
        GunaComboBox2.StartIndex = My.Settings.GameDefect
        If My.Settings.GameDirCE = "" Then
            CEdirTextbox.Text = GenerateCEDir()
            If Not CEdirTextbox.Text = "" Then
                SaveCEGamePath(CEdirTextbox.Text)
            End If
        Else
            CEdirTextbox.Text = My.Settings.GameDirCE
        End If
        If My.Settings.GameDirPC = "" Then
            PCdirTextBox1.Text = GeneratePCDir()
            If Not PCdirTextBox1.Text = "" Then
                SavePCGamePath(PCdirTextBox1.Text)
            End If
        Else
            PCdirTextBox1.Text = My.Settings.GameDirPC
        End If
        GunaGoogleSwitch1.Checked = My.Settings.MultiLauncher
        GunaCheckBox1.Checked = My.Settings.ConsoleC
        GunaCheckBox2.Checked = My.Settings.ScreenshotC
        GunaCheckBox3.Checked = My.Settings.devC
        GunaCheckBox4.Checked = My.Settings.SoundC
        GunaCheckBox5.Checked = My.Settings.VideoC
        GunaCheckBox6.Checked = My.Settings.GammaC
        GunaCheckBox7.Checked = My.Settings.JoystickC
        GunaCheckBox8.Checked = My.Settings.SafeModeC
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Dim OpenGameDir As String = open("Haloce.exe [Executable] (*.exe)|*.exe")
        If Not OpenGameDir = "Error" Then
            CEdirTextbox.Text = OpenGameDir
            SaveCEGamePath(CEdirTextbox.Text)
        End If
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        Dim OpenGameDir As String = open("Halo.exe [Executable] (*.exe)|*.exe")
        If Not OpenGameDir = "Error" Then
            PCdirTextBox1.Text = OpenGameDir
            SavePCGamePath(CEdirTextbox.Text)
        End If
    End Sub

    Private Function GenerateCEDir() As String
        Dim GameDir1 As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\" & "Microsoft Games\Halo Custom Edition\haloce.exe"

        If IO.File.Exists(GameDir1) = True Then
            Return GameDir1
        End If

        Dim RegeditGamedir As String = "HKLM\software\Microsoft\Microsoft Games\Halo CE"
        Dim RegeditKey As String = "EXE Path"

        If RegEdit.ExistValue(RegeditGamedir, RegeditKey) = True Then
            Dim Data1 As String = RegEdit.GetValue(RegeditGamedir, RegeditKey)
            Return Data1
        End If

        Return Nothing
    End Function

    Private Function GeneratePCDir() As String
        Dim GameDir2 As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\" & "Microsoft Games\Halo\halo.exe"
        If IO.File.Exists(GameDir2) = True Then
            Return GameDir2
        End If

        Dim RegeditGamedir2 As String = "HKLM\software\Microsoft\Microsoft Games\Halo"
        Dim RegeditKey As String = "EXE Path"

        If RegEdit.ExistValue(RegeditGamedir2, RegeditKey) = True Then
            Dim Data2 As String = RegEdit.GetValue(RegeditGamedir2, RegeditKey)
            Return Data2
        End If

        Return Nothing
    End Function

    Private Sub SaveCEGamePath(ByVal DirA As String)
        My.Settings.GameDirCE = DirA
        My.Settings.Save()
    End Sub

    Private Sub SavePCGamePath(ByVal DirA As String)
        My.Settings.GameDirPC = DirA
        My.Settings.Save()
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        System.Diagnostics.Process.Start("https://www.paypal.me/SalvadorKrilewski")
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        AboutForm.ShowDialog()
    End Sub

    Private Sub GunaCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox1.CheckedChanged
        If GunaCheckBox1.Checked = True Then
            My.Settings.ConsoleC = True
        Else
            My.Settings.ConsoleC = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub GunaCheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox2.CheckedChanged
        If GunaCheckBox2.Checked = True Then
            My.Settings.ScreenshotC = True
        Else
            My.Settings.ScreenshotC = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub GunaCheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox3.CheckedChanged
        'dev
        If GunaCheckBox3.Checked = True Then
            My.Settings.devC = True
        Else
            My.Settings.devC = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub GunaCheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox6.CheckedChanged
        'no gamma
        If GunaCheckBox6.Checked = True Then
            My.Settings.GammaC = True
        Else
            My.Settings.GammaC = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub GunaCheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox4.CheckedChanged
        ' no sound
        If GunaCheckBox4.Checked = True Then
            My.Settings.SoundC = True
        Else
            My.Settings.SoundC = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub GunaCheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox5.CheckedChanged
        'no video
        If GunaCheckBox5.Checked = True Then
            My.Settings.VideoC = True
        Else
            My.Settings.VideoC = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub GunaCheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox7.CheckedChanged
        ' no joystic
        If GunaCheckBox7.Checked = True Then
            My.Settings.JoystickC = True
        Else
            My.Settings.JoystickC = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub GunaCheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox8.CheckedChanged
        'safe mode
        If GunaCheckBox8.Checked = True Then
            My.Settings.SafeModeC = True
        Else
            My.Settings.SafeModeC = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox1.SelectedIndexChanged
        Dim Slect As Integer = GunaComboBox1.SelectedIndex
        Select Case Slect
            Case 0 : My.Settings.LaunchMode = Slect : GunaButton6.Visible = True
            Case 1 : My.Settings.LaunchMode = Slect : GunaButton6.Visible = True
            Case 2 : My.Settings.LaunchMode = Slect : GunaButton6.Visible = False
        End Select
        My.Settings.Save()
    End Sub

    Private Sub GunaComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox2.SelectedIndexChanged
        Dim Slect As Integer = GunaComboBox2.SelectedIndex
        Select Case Slect
            Case 0 : My.Settings.GameDefect = Slect
            Case 1 : My.Settings.GameDefect = Slect
        End Select
        My.Settings.Save()
    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click
        My.Settings.Reset()
    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click
        Dim LchangeWindow As New Core.Launcher
        Dim procs As Process() = Process.GetProcesses()

        Dim ProcessNameEX As String = IO.Path.GetFileNameWithoutExtension(LchangeWindow.GameProc)
        Dim processcount As Integer = procs.Count
        For Each proc As Process In procs

            If proc.ProcessName = "haloce" Then
                Dim FakeFullSc As Boolean = LchangeWindow.FullScreenEmulation("haloce")
            ElseIf proc.ProcessName = "halo" Then
                Dim FakeFullSc As Boolean = LchangeWindow.FullScreenEmulation("halo")
            End If
        Next
    End Sub

    Private Sub GunaGoogleSwitch1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaGoogleSwitch1.CheckedChanged
        My.Settings.MultiLauncher = GunaGoogleSwitch1.Checked
        My.Settings.Save()
    End Sub
End Class