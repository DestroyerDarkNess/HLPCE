Imports HALOCELauncher.HaloQuery
Imports HALOCELauncher.HaloQuery.HaloServerInfo
Imports HALOCELauncher.Core.Helpers
Imports System.Runtime.InteropServices
Imports HALOCELauncher.Core.Utils
Imports System.Drawing.Imaging
Imports System.Net
Imports System.IO
Imports HALOCELauncher.Core.GameTracker
Imports HALOCELauncher.Core.Utils.LogFuncs
Imports HALOCELauncher.Destroyer.Protect


<Assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)> 

Public Class Form1

    Private HomeControl As Form = New Home With {.TopLevel = False}
    Private ServerControl As Servers = New Servers With {.TopLevel = False}
    Private ModsControl As Form = New Modsfrm With {.TopLevel = False}
    Private SettingsControl As Form = New Settingfrm With {.TopLevel = False}

    Private ImageDir As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\" & "Background"

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try : AddHandler Application.ThreadException, AddressOf Application_Exception_Handler _
                 : Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, False) _
                     : Catch : End Try

        Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)

        If IsAdministrator = True Then
            StartMonitorig()
        Else
            MsgBox("Please open with administrator rights!")
            End
        End If

        StartControls()
    End Sub

    Private Sub Application_Exception_Handler(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        Dim ex As Exception = CType(e.Exception, Exception)
        WriteLog(ex.Message, InfoType.Exception)
    End Sub

    Private Sub StartControls()
        EnabledDragger(PanelFX1)
        EnabledDragger(GunaPanel2)
        FontTheme(0)
        If IO.Directory.Exists(ImageDir) = False Then
            IO.Directory.CreateDirectory(ImageDir)
        End If
        BackG()
        LoadForms()
    End Sub

#Region " Load Forms "

    Private Sub LoadForms()
        AddShowForm(HomeControl)
        AddShowForm(ServerControl)
        AddShowForm(ModsControl)
        AddShowForm(SettingsControl)
    End Sub

    Public Sub AddShowForm(ByVal LocalForm As Form)
        PanelContainer.Controls.Add(LocalForm)
        LocalForm.Show()
    End Sub

    Private Sub nav_home_CheckedChanged(sender As Object, e As EventArgs) Handles nav_home.CheckedChanged
        If nav_home.Checked Then
            HomeControl.BringToFront()
        End If
    End Sub

    Dim LoadForm As Boolean = False

    Private Sub nav_servers_CheckedChanged(sender As Object, e As EventArgs) Handles nav_servers.CheckedChanged
        If nav_servers.Checked Then
            ServerControl.BringToFront()
            If LoadForm = False Then
                ServerControl.StartAll()
                LoadForm = True
            End If
        End If
    End Sub


    Private Sub nav_mods_CheckedChanged(sender As Object, e As EventArgs) Handles nav_mods.CheckedChanged
        If nav_mods.Checked Then
            ModsControl.BringToFront()
        End If
    End Sub

    Private Sub nav_settings_CheckedChanged(sender As Object, e As EventArgs) Handles nav_settings.CheckedChanged
        If nav_settings.Checked Then
            SettingsControl.BringToFront()
        End If
    End Sub

#End Region

#Region " BackgroudF "

    Private Function GenerateListImage() As List(Of Image)
        On Error Resume Next
        Dim LocalImages As New List(Of Image)
        Dim ImageFiles As IEnumerable(Of FileInfo) = FileDirSearcher.GetFiles(dirPath:=ImageDir,
                                                                         searchOption:=SearchOption.TopDirectoryOnly,
                                                                         fileNamePatterns:={"*"},
                                                                         fileExtPatterns:={"*.bmp", "*.jpeg", "*.jpg", "*.png"})
        For Each ImageFil As FileInfo In ImageFiles
            LocalImages.Add(Image.FromFile(ImageFil.FullName))
        Next
        Return LocalImages
    End Function

    Private Sub BackG()
        On Error Resume Next
        Dim BackgroundImageList As List(Of Image) = GenerateListImage()

        ' BackgroundImageList.Add(My.Resources.b1)
        ' BackgroundImageList.Add(My.Resources._1790160475_preview_HaloCollectionCover)

        If Not BackgroundImageList.Count = 0 Then
            Dim ImageSelect As Integer = GetRandomNum(0, BackgroundImageList.Count)
            Dim ImageSelected As Bitmap = BackgroundImageList(ImageSelect)
            If PanelFX1.BackgroundImage Is Nothing Then
                PanelFX1.BackgroundImage = ImageSelected
            Else
                Dim OldBitMap As Bitmap = New Bitmap(PanelFX1.BackgroundImage)
                If Not CompareImages(ImageSelected, OldBitMap) = True Then
                    PanelFX1.BackgroundImage = ImageSelected
                    UpdateAllBlur()
                End If
            End If
        End If

    End Sub

    Public Sub UpdateAllBlur()
        HomeControl.Refresh()
        ServerControl.Refresh()
        ModsControl.Refresh()
        SettingsControl.Refresh()
    End Sub

    ''' <summary>
    ''' The <see cref="TimeMeasurer"/> instance that measure time intervals.
    ''' </summary>
    Private WithEvents Clock As New TimeMeasurer With {.UpdateInterval = 100}
    Private SecondToChangeImage As Integer = 30

    Private Shadows Sub Load() Handles MyBase.Load

        Me.Clock.Start(SecondtoMilli(SecondToChangeImage)) ' Measure 1 minute

    End Sub

    Private Sub Clock_RemainingTimeFinished(ByVal sender As Object, ByVal e As TimeMeasurer.TimeMeasureEventArgs) _
    Handles Clock.RemainingTimeFinished

        If IsGameOpen() = False Then
            BackG()
        End If

        Me.Clock.Start(SecondtoMilli(SecondToChangeImage)) ' Measure 1 minute

    End Sub

    Private Function IsGameOpen() As Boolean
        Dim pName As String = IO.Path.GetFileNameWithoutExtension(My.Settings.GameDirCE)
        Dim psList() As Process
        Try
            psList = Process.GetProcesses()

            For Each p As Process In psList
                If (pName = p.ProcessName) Then
                    Return True
                End If
            Next p
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region " Font Aply "

    Dim HaloFont As New CustomFont(My.Resources.Halo)
    Dim HaloFont_Outline As New CustomFont(My.Resources.Halo_Outline)

    Private Sub Main_Disposed(sender As Object, e As System.EventArgs) Handles MyBase.Disposed
        HaloFont.Dispose()
        HaloFont_Outline.Dispose()
    End Sub

    Private Sub FontTheme(ByVal FontType As Integer)
        If FontType = 0 Then

        ElseIf FontType = 1 Then
            nav_home.Font = New Font(HaloFont.Font, 16.0!)
            nav_servers.Font = New Font(HaloFont.Font, 16.0!)
            nav_mods.Font = New Font(HaloFont.Font, 16.0!)
            nav_settings.Font = New Font(HaloFont.Font, 16.0!)
            nav_tools.Font = New Font(HaloFont.Font, 16.0!)
        ElseIf FontType = 2 Then
            nav_home.Font = New Font(HaloFont_Outline.Font, 16.0!)
            nav_servers.Font = New Font(HaloFont_Outline.Font, 16.0!)
            nav_mods.Font = New Font(HaloFont_Outline.Font, 16.0!)
            nav_settings.Font = New Font(HaloFont_Outline.Font, 16.0!)
            nav_tools.Font = New Font(HaloFont_Outline.Font, 16.0!)
        End If
        My.Settings.FontType = FontType
        My.Settings.Save()
    End Sub

#End Region

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()

        ' Test result.
        If result = Windows.Forms.DialogResult.OK Then
            Dim ImageDir As String = OpenFileDialog1.FileName
            Dim imageAAAA = Image.FromFile(ImageDir)
            Dim base64String As String = ConvertImageToBase64String(imageAAAA) 'Using Functions To Make the code tidier
            IO.File.WriteAllText("iMAGE.TXT", base64String)
            Dim byteArray = ConvertBase64ToByteArray(base64String) 'Using Functions To Make the code tidier
            Dim imageDDD = convertbytetoimage(byteArray) 'Using Functions To Make the code tidier
            ' PictureBox1.Image = imageDDD 'since we're using a small windows form app, we'll set back the image to a second picture box.
        End If


    End Sub

#Region " Monitor Mode "


    Public Structure ResultScan
        Shared ProcessResult As String = String.Empty
        Shared DebuggersResult As String = String.Empty
        Shared VMResult As String = String.Empty
        Shared Finish As Boolean = False
    End Structure

    Dim Enabling As Integer = 0

    Private Sub StartMonitorig()
        Destroyer.Exploits.OllyOldExploit()
        ResultScan.ProcessResult = String.Empty
        ResultScan.DebuggersResult = String.Empty
        ResultScan.VMResult = String.Empty
        ResultScan.Finish = False

        DestroyerProtect.MonitorAsync(Destroyer.AntiAnalysis.MainAnalysis.SearchType.FromNameandTitle, _
                              Destroyer.AntiDebug.MainDebug.DebugDetectionTypes.AllScanEgines, _
                              DestroyerProtect.VMScanType.By_Directory_Known)
        MonitorTimer1.Enabled = True
    End Sub

    Private Sub MonitorTimer1_Tick(sender As Object, e As EventArgs) Handles MonitorTimer1.Tick
        Dim Finispscan As DestroyerProtect.ResultType = DestroyerProtect.Process_scanner
        Dim FinisDbugscan As DestroyerProtect.ResultType = DestroyerProtect.Debugers_scanner
        Dim VMscanner As DestroyerProtect.ResultType = DestroyerProtect.VM_scanner
        Dim Mdirs As New Destroyer.MainDirScan

        If Finispscan = DestroyerProtect.ResultType.Danger Then
            ResultScan.ProcessResult = "[DANGER] Malicious Process has been Detected"
        ElseIf Finispscan = DestroyerProtect.ResultType.Secure Then
            ResultScan.ProcessResult = "[SECURE] Malicious Process Not Detected"
        End If

        If FinisDbugscan = DestroyerProtect.ResultType.Danger Then
            ResultScan.DebuggersResult = "[DANGER] Debuggers Detected"
        ElseIf FinisDbugscan = DestroyerProtect.ResultType.Secure Then
            ResultScan.DebuggersResult = "[SECURE] Debuggers not Detected"
        End If

        If VMscanner = DestroyerProtect.ResultType.Danger Then
            ResultScan.VMResult = "[DANGER] Virutal Machines Have Been Detected"
        ElseIf Finispscan = DestroyerProtect.ResultType.Secure Then
            ResultScan.VMResult = "[SECURE] No Virtual Machines Found"
        End If

        If Not ResultScan.ProcessResult = String.Empty Then
            Ending()
           ResultScan.Finish = True
            MonitorTimer1.Enabled = False
        End If

        If Not ResultScan.DebuggersResult = String.Empty Then
            Ending()
            ResultScan.Finish = True
            MonitorTimer1.Enabled = False
        End If

        If Mdirs.MaliciousDir() = True Then
            Ending()
            ResultScan.Finish = True
            MonitorTimer1.Enabled = False
        End If

        If Not ResultScan.VMResult = String.Empty Then
            Ending()
            ResultScan.Finish = True
            MonitorTimer1.Enabled = False
        End If

        If Enabling = 100 Then
            'Destroyer.AntiDump.MainDump.AntiDumpEnabled(Me)
        End If

        Enabling += 1
    End Sub

    Private Sub Ending()
       End
    End Sub

#End Region

    Private Sub GunaControlBox1_Click(sender As Object, e As EventArgs) Handles GunaControlBox1.Click
        End
    End Sub
End Class


