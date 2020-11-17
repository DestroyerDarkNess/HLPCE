Imports HALOCELauncher.Core.Helpers
Imports HALOCELauncher.Core.Utils
Imports System.Net
Imports System.Text
Imports HALOCELauncher.Core.Utils.LogFuncs

Public Class Home

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try : AddHandler Application.ThreadException, AddressOf Application_Exception_Handler _
              : Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, False) _
                  : Catch : End Try

        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
       Me.BackColor = Color.Transparent
        Me.Refresh()
        StartC()
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

    Public Overrides Sub Refresh()
        If Anuncio1_Image = False Then
            Dim Aplyblur1 As New GetBlurBitmap(Me.Anuncio1)
        End If
        If Anuncio2_Image = False Then
            Dim Aplyblur2 As New GetBlurBitmap(Me.Anuncio2)
        End If
        If Anuncio3_Image = False Then
            Dim Aplyblur3 As New GetBlurBitmap(Me.Anuncio3)
        End If
        If Anuncio4_Image = False Then
            Dim Aplyblur4 As New GetBlurBitmap(Me.Anuncio4)
        End If
        MyBase.Refresh()
    End Sub

    Private Sub StartC()
        On Error Resume Next
        Me.GunaPanel2.BackColor = Color.FromArgb(40, Color.Black)
        Me.GunaPanel3.BackColor = Color.FromArgb(40, Color.Black)
        Me.GunaPanel4.BackColor = Color.FromArgb(40, Color.White)
        Me.GunaPanel5.BackColor = Color.FromArgb(40, Color.White)
        DownloadAsync("https://raw.githubusercontent.com/DestroyerDarkNess/Halo-SyncHack/master/LauncherInfo.txt")
    End Sub

#Region "ADS"

    Private Anuncio1_Image As Boolean = False
    Private Anuncio2_Image As Boolean = False
    Private Anuncio3_Image As Boolean = False
    Private Anuncio4_Image As Boolean = False

    Dim xmlData As XDocument = <?xml version="1.0"?>
                               <Home>
                                   <Anuncio1>
                                       <Title>NO Internet Connection!</Title>
                                       <Icon></Icon>
                                       <Image></Image>
                                       <Description></Description>
                                       <Link></Link>
                                   </Anuncio1>
                                   <Anuncio2>
                                       <Title>NO Internet Connection!</Title>
                                       <Icon></Icon>
                                       <Image></Image>
                                       <Description></Description>
                                       <Link></Link>
                                   </Anuncio2>
                                   <Anuncio3>
                                       <Title>NO Internet Connection!</Title>
                                       <Icon></Icon>
                                       <Image></Image>
                                       <Description></Description>
                                       <Link></Link>
                                   </Anuncio3>
                                   <Anuncio4>
                                       <Title>NO Internet Connection!</Title>
                                       <Icon></Icon>
                                       <Image></Image>
                                       <Description></Description>
                                       <Link></Link>
                                   </Anuncio4>
                               </Home>

    Public Sub DownloadAsync(ByVal adress As String)
        Dim Client As WebClient = New WebClient()
        Client.DownloadStringAsync(New Uri(adress))
        AddHandler Client.DownloadStringCompleted, AddressOf DownloadComplete
    End Sub

    Public Sub DownloadComplete(sender As Object, e As DownloadStringCompletedEventArgs)
        Try
            Dim ClientData As String = e.Result
            If Not ClientData = "" Then
                ReadXML(ClientData)
            End If
        Catch ex As Exception
            ReadXML(xmlData.ToString)
            Anuncio1Title.ForeColor = Color.Red
            Anuncio2Title.ForeColor = Color.Red
            Anuncio3Title.ForeColor = Color.Red
            Dim ExeptionEX As String = ex.Message
            Anuncio1Des.Text = ExeptionEX
            Anuncio2Des.Text = ExeptionEX
            Anuncio3Des.Text = ExeptionEX
            Anuncio1Des.Visible = True
            Anuncio2Des.Visible = True
            Anuncio3Des.Visible = True
        End Try
     End Sub

    Private Sub ReadXML(ByVal XmlString As String)
        On Error Resume Next
        Dim element As XDocument = XDocument.Parse(XmlString)
        xmlData = element
        Dim Str As New StringBuilder
        For Each signature As XElement In xmlData.Root.Elements
            Dim Anuncement As String = signature.Name.ToString
            Dim Title As String = signature.<Title>.Value
            Dim IconDir As String = signature.<Icon>.Value
            Dim ImageDir As String = signature.<Image>.Value
            Dim Description As String = signature.<Description>.Value
            Dim LinkUrl As String = signature.<Link>.Value
            If Anuncement = "Anuncio1" Then

                If Not Title = "" Then
                    Anuncio1Title.Text = Title
                    Anuncio1Title.Visible = True
                End If
                If Not ImageDir = "" Then
                    Anuncio1.BackgroundImage = GetImageDecripted(ImageDir)
                    Anuncio1_Image = True
                End If
                If Not IconDir = "" Then
                    Anuncio1Icon.BackgroundImage = GetImageDecripted(IconDir)
                    Anuncio1Icon.Visible = True
                End If
                If Not Description = "" Then
                    Anuncio1Des.Text = Description
                    Anuncio1Des.Visible = True
                End If
                If Not LinkUrl = "" Then
                    Anuncio1Link = LinkUrl
                    Anuncio1.Cursor = Cursors.Hand
                End If

            ElseIf Anuncement = "Anuncio2" Then
                If Not Title = "" Then
                    Anuncio2Title.Text = Title
                    Anuncio2Title.Visible = True
                End If
                If Not ImageDir = "" Then
                    Anuncio2.BackgroundImage = GetImageDecripted(ImageDir)
                    Anuncio2_Image = True
                End If
                If Not IconDir = "" Then
                    Anuncio2Icon.BackgroundImage = GetImageDecripted(IconDir)
                    Anuncio2Icon.Visible = True
                End If
                If Not Description = "" Then
                    Anuncio2Des.Text = Description
                    Anuncio2Des.Visible = True
                End If
                If Not LinkUrl = "" Then
                    Anuncio2Link = LinkUrl
                    Anuncio2.Cursor = Cursors.Hand
                End If
            ElseIf Anuncement = "Anuncio3" Then
                If Not Title = "" Then
                    Anuncio3Title.Text = Title
                    Anuncio3Title.Visible = True
                End If
                If Not ImageDir = "" Then
                    Anuncio3.BackgroundImage = GetImageDecripted(ImageDir)
                    Anuncio3_Image = True
                End If
                If Not IconDir = "" Then
                    Anuncio3Icon.BackgroundImage = GetImageDecripted(IconDir)
                    Anuncio3Icon.Visible = True
                End If
                If Not Description = "" Then
                    Anuncio3Des.Text = Description
                    Anuncio3Des.Visible = True
                End If
                If Not LinkUrl = "" Then
                    Anuncio3Link = LinkUrl
                    Anuncio3.Cursor = Cursors.Hand
                End If
            ElseIf Anuncement = "Anuncio4" Then

            End If

        Next

    End Sub

    Private Sub OpenAnuncePanel(ByVal Pads As Control)
        Dim Max As Integer = 148
        Dim Min As Integer = 35
        If Pads.Height = Min Then
            For i As Integer = 0 To 2
                If Pads.Height = Max Then
                    Exit For
                End If
                Pads.Height += 1
                i -= 1
            Next
        Else
            For i As Integer = 0 To 2
                If Pads.Height = Min Then
                    Exit For
                End If
                Pads.Height -= 1
                i -= 1
            Next
        End If
    End Sub

    Private Sub OpenAnunce1Panel()
        Dim Max As Integer = 231
        Dim Min As Integer = 35
        If GunaPanel6.Height = Min Then
            For i As Integer = 0 To 2
                If GunaPanel6.Height = Max Then
                    Exit For
                End If
                GunaPanel6.Height += 1
                i -= 1
            Next
        Else
            For i As Integer = 0 To 2
                If GunaPanel6.Height = Min Then
                    Exit For
                End If
                GunaPanel6.Height -= 1
                i -= 1
            Next
        End If
    End Sub

    Private Function GetImageDecripted(ByVal stringBase64 As String) As Image
       Dim byteArray = ConvertBase64ToByteArray(stringBase64)
        Return convertbytetoimage(byteArray)
    End Function

#End Region

#Region " Anuncio 1 "

    Private Anuncio1Link As String = String.Empty

    Private Sub Anuncio1_Click(sender As Object, e As EventArgs) Handles Anuncio1.Click
        If Not Anuncio1Link = String.Empty Then
            Process.Start(Anuncio1Link)
        End If
    End Sub

    Private Sub Anuncio1Title_Click(sender As Object, e As EventArgs) Handles Anuncio1Title.Click
        OpenAnunce1Panel()
    End Sub

    Private Sub Anuncio1Des_Click(sender As Object, e As EventArgs) Handles Anuncio1Des.Click
        OpenAnunce1Panel()
    End Sub

#End Region

#Region " Anuncio 2 "

    Private Anuncio2Link As String = String.Empty

    Private Sub Anuncio2_Click(sender As Object, e As EventArgs) Handles Anuncio2.Click
        If Not Anuncio2Link = String.Empty Then
            Process.Start(Anuncio2Link)
        End If
    End Sub

    Private Sub Anuncio2Title_Click(sender As Object, e As EventArgs) Handles Anuncio2Title.Click
        OpenAnuncePanel(GunaPanel2)
    End Sub

    Private Sub Anuncio2Des_Click(sender As Object, e As EventArgs) Handles Anuncio2Des.Click
        OpenAnuncePanel(GunaPanel2)
    End Sub

#End Region

#Region " Anuncio 3 "

    Private Anuncio3Link As String = String.Empty

    Private Sub Anuncio3_Click(sender As Object, e As EventArgs) Handles Anuncio3.Click
        If Not Anuncio3Link = String.Empty Then
            Process.Start(Anuncio3Link)
        End If
    End Sub

    Private Sub Anuncio3Title_Click(sender As Object, e As EventArgs) Handles Anuncio3Title.Click
        OpenAnuncePanel(GunaPanel3)
    End Sub

    Private Sub Anuncio3Des_Click(sender As Object, e As EventArgs) Handles Anuncio3Des.Click
        OpenAnuncePanel(GunaPanel3)
    End Sub

#End Region

    
    Private Sub HaloLaunchCE_Click(sender As Object, e As EventArgs) Handles HaloLaunchCE.Click
        Dim NewLauncher As New Core.Launcher(My.Settings.GameDirCE)
        NewLauncher.Launch()
    End Sub

    Private Sub HaloLaunchPC_Click(sender As Object, e As EventArgs) Handles HaloLaunchPC.Click
        Dim NewLauncher As New Core.Launcher(My.Settings.GameDirCE)
        NewLauncher.Launch()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If My.Settings.GameDirCE = "" Then
            HaloLaunchCE.Enabled = False
        Else
            HaloLaunchCE.Enabled = True
        End If
        If My.Settings.GameDirCE = "" Then
            HaloLaunchPC.Enabled = False
        Else
            HaloLaunchPC.Enabled = True
        End If
    End Sub

End Class