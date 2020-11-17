Imports HALOCELauncher.Core.Utils
Imports System.Net
Imports System.Text
Imports HALOCELauncher.Core.Utils.LogFuncs

Public Class Toolsfrm

    Private Sub Toolsfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        'Dim Aplyblur1 As New GetBlurBitmap(Me.Anuncio1)


        MyBase.Refresh()
    End Sub

    Private Sub StartC()
        On Error Resume Next
        For Each signature As XElement In xmlData.Root.Elements
            Dim Title As String = signature.<Title>.Value
            Dim IconDir As String = signature.<Icon>.Value
            Dim Description As String = signature.<Description>.Value
            Dim LinkUrl As String = signature.<Link>.Value
            ListBox1.Items.Add(Title)

        Next
        ' DownloadAsync("https://raw.githubusercontent.com/DestroyerDarkNess/Halo-SyncHack/master/LauncherInfo.txt")
    End Sub

#Region "ADS"

    Private Anuncio1_Image As Boolean = False
    Private Anuncio2_Image As Boolean = False
    Private Anuncio3_Image As Boolean = False
    Private Anuncio4_Image As Boolean = False

    Dim xmlData As XDocument = <?xml version="1.0"?>
                               <Home>
                                   <Plugin>
                                       <Title>Halo CE MauseFix</Title>
                                       <Icon></Icon>
                                       <Description></Description>
                                       <Link></Link>
                                   </Plugin>
                                   <Plugin>
                                       <Title>Halo CE Fov</Title>
                                       <Icon></Icon>
                                       <Description></Description>
                                       <Link></Link>
                                   </Plugin>
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

        End Try
    End Sub

    Private Sub ReadXML(ByVal XmlString As String)
        On Error Resume Next
        Dim element As XDocument = XDocument.Parse(XmlString)
        xmlData = element
        For Each signature As XElement In xmlData.Root.Elements
            Dim Title As String = signature.<Title>.Value
            Dim IconDir As String = signature.<Icon>.Value
            Dim Description As String = signature.<Description>.Value
            Dim LinkUrl As String = signature.<Link>.Value
            ListBox1.Items.Add(Title)

        Next

    End Sub


#End Region


End Class