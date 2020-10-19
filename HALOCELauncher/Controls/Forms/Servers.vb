Imports HALOCELauncher.Core.Utils
Imports HALOCELauncher.Core.SvManager.SvFormatManager
Imports HALOCELauncher.Core.GameTracker
Imports HALOCELauncher.Core.Helpers
Imports HALOCELauncher.HaloQuery.HaloServerInfo
Imports HALOCELauncher.HaloQuery

Public Class Servers

    Private FavoritesControl As FavoritiesC = New FavoritiesC
    Private InternetControl As InternetC = New InternetC
    Public Property LoadA As Boolean = False

    Private Sub Servers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent
        Me.Refresh()
       ' StartAll()
    End Sub

    Public Sub UpdateFavoriteTable()
        FavoritesControl.UpdateAll()
    End Sub

    Public Function CallWriteAllServerTofavorites() As Boolean
        InternetControl.WriteAllServerTofavorites()
        FavoritesControl.UpdateAll()
    End Function

    Public Overrides Sub Refresh()
        Dim Aplyblur1 As New GetBlurBitmap(Me.HeaderInfo)
        Dim Aplyblur2 As New GetBlurBitmap(Me.GunaPanel4)
        MyBase.Refresh()
    End Sub

#Region " Parent Dragger "

    Private Dragger As ControlDragger = ControlDragger.Empty

    Private Sub InitializeDrag()

        Me.Dragger = New ControlDragger(Me, Form1)
        Me.Dragger = New ControlDragger(GunaPanel4, Form1)
        Me.Dragger = New ControlDragger(GunaPanel2, Form1)
        Me.Dragger = New ControlDragger(HeaderInfo, Form1)

        For Each Cdrag As Control In HeaderInfo.Controls
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

    Public Sub StartAll()
        LoadForms()
    End Sub

    Private Sub LoadForms()
        AddShowForm(FavoritesControl)
        AddShowForm(InternetControl)
    End Sub


    Public Sub AddShowForm(ByVal LocalForm As Control)
        PanelContainer.Controls.Add(LocalForm)
        LocalForm.Location = New Point(0, 0)
    End Sub

    Private Sub nav_home_CheckedChanged(sender As Object, e As EventArgs) Handles nav_home.CheckedChanged
        If nav_home.Checked Then
            FavoritesControl.BringToFront()
            FavoritesTap()
        End If
    End Sub

    Private Sub FavoritesTap()
        RefreshServerListToolStripMenuItem.Visible = False
        DeleteAllServersToFavoritesToolStripMenuItem.Visible = True
        ImportFavoritesListToolStripMenuItem.Enabled = True
        AddAllServersToFavoritesToolStripMenuItem.Visible = False
        If ExistsXmlServer() = True Then
            ExportFavoritesListToolStripMenuItem.Enabled = True
        End If
    End Sub

    Dim LoadServers As Boolean = False
    Private Sub nav_servers_CheckedChanged(sender As Object, e As EventArgs) Handles nav_servers.CheckedChanged
        If nav_servers.Checked Then
            InternetControl.BringToFront()
            ServersTap()
            If LoadServers = False Then
                InternetControl.StartControls()
                LoadServers = True
            End If
        End If
    End Sub

    Private Sub ServersTap()
        DeleteAllServersToFavoritesToolStripMenuItem.Visible = False
        AddAllServersToFavoritesToolStripMenuItem.Visible = True
        RefreshServerListToolStripMenuItem.Visible = True
        ImportFavoritesListToolStripMenuItem.Enabled = False
        ExportFavoritesListToolStripMenuItem.Enabled = False
    End Sub

#Region " File TapStrip "

    Private Sub ExportFavoritesListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportFavoritesListToolStripMenuItem.Click
        Dim SaveXmlNew As String = save("HALO SERVERS", "Halo Launcher Database (*.xml)|*.xml")
        If Not SaveXmlNew = "Error" Then
            IO.File.Copy(xml_svlist, SaveXmlNew)
        End If
    End Sub

    Private Sub ImportFavoritesListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportFavoritesListToolStripMenuItem.Click
        Dim OpenXmlNew As String = open("Halo Launcher Database (*.xml)|*.xml")
        If Not OpenXmlNew = "Error" Then
            Dim AddNewServers As Boolean = UpdateFromExternal(OpenXmlNew)
            If AddNewServers = True Then
                UpdateFavoriteTable()
            End If
        End If
    End Sub

#End Region

#Region " Server TapStrip "

    Private Sub AddCustomServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddCustomServerToolStripMenuItem.Click
        AddCustomServer.ShowDialog()
    End Sub

    Private Sub DeleteAllServersToFavoritesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteAllServersToFavoritesToolStripMenuItem.Click
        If IO.File.Exists(xml_svlist) = True Then
            IO.File.Delete(xml_svlist)
        End If
        FavoritesControl.UpdateAll()
    End Sub

    Private Sub AddAllServersToFavoritesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAllServersToFavoritesToolStripMenuItem.Click
        CallWriteAllServerTofavorites()
    End Sub

    Private Sub ConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem.Click
        FavoritesControl.UpdateAll()
    End Sub

    Private Sub RefreshServerListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshServerListToolStripMenuItem.Click
        InternetControl.UpdateAll()
    End Sub

#End Region

#Region " Help TapStrip "

    Private Sub HelpTopicsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpTopicsToolStripMenuItem.Click
        Process.Start("https://opencarnage.net/index.php?/topic/8139-halo-launcher-for-pc-and-ce-hlpce-realses/")
    End Sub

    Private Sub OpencarnagenetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpencarnagenetToolStripMenuItem.Click
        Process.Start("https://opencarnage.net/")
    End Sub

    Private Sub HALOFixesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HALOFixesToolStripMenuItem.Click
        Process.Start("https://halo-fixes.forumotion.com/forum")
    End Sub

    Private Sub UnknowncheatsmeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnknowncheatsmeToolStripMenuItem.Click
        Process.Start("https://www.unknowncheats.me/")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutForm.ShowDialog()
    End Sub

#End Region


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim FavoritesCount As Integer = FavoritesControl.ServerCounter
        HeaderInformationLbl.Text = "Favorite Servers: " & FavoritesCount
        If UpdateAe = True Then
            FavoritesControl.UpdateAll()
            UpdateAe = False
        End If
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If Not NameTextbox.Text = "" Then
            Dim IPAdress As String = Core.Utils.Compression.DecompressData(NameTextbox.Text)
            Dim TyperGame As Integer = My.Settings.GameDefect
            If TyperGame = 0 Then
                Dim NewLauncher As New Core.Launcher(My.Settings.GameDirCE)
                NewLauncher.Launch(IPAdress)
            ElseIf TyperGame = 1 Then
                Dim NewLauncher As New Core.Launcher(My.Settings.GameDirPC)
                NewLauncher.Launch(IPAdress)
            End If
        End If
    End Sub


End Class