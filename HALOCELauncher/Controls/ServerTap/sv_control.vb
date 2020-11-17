Imports HALOCELauncher.HaloQuery
Imports HALOCELauncher.Core.SvManager.SvFormatManager
Imports HALOCELauncher.Core.GameTracker

Public Class sv_control

#Region " Properties "

    Private _Namesv As String = Nothing
    Private _IPAdress As String = Nothing
    Private _Map As String = Nothing
    Private _ListID As Integer = Nothing
    Private _Players As String = Nothing

    Public Property Players As String
        Get
            Return _Players
        End Get
        Set(value As String)
            _Players = value
        End Set
    End Property

    Public Property Map As String
        Get
            Return _Map
        End Get
        Set(value As String)
            _Map = value
        End Set
    End Property

    Public Property Namesv As String
        Get
            Return _Namesv
        End Get
        Set(value As String)
            _Namesv = value
        End Set
    End Property

    Public Property IPAdress As String
        Get
            Return _IPAdress
        End Get
        Set(value As String)
            _IPAdress = value
        End Set
    End Property

    Public Property ListID As Integer
        Get
            Return _ListID
        End Get
        Set(value As Integer)
            _ListID = value
        End Set
    End Property

    Private Sub UpdateValues()
        HostNamelbl.Text = _Namesv
        Playerslbl.Text = _Players
        Maplbl.Text = _Map
        Try
            If Not IPAdress = Nothing Then
                Dim GetINFO As New HaloServerInfo({IPAdress})
                Maplbl.Text = GetINFO.MapName
                Playerslbl.Text = GetINFO.PlayersCount & "/" & GetINFO.MaxPlayers
                Modelbl.Text = GetINFO.GameType
            End If
        Catch ex As Exception
            Modelbl.Text = "CTF"
        End Try
    End Sub

    Public Function IsSelectedSv() As Boolean
        If Me.BackColor = Color.Transparent Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function IsSelected() As Boolean
        Return IsMauseInControl
    End Function

    Private _Isfavorites As Boolean = False
    Public Property Isfavorites As Boolean
        Get
            Return _Isfavorites
        End Get
        Set(value As Boolean)
            _Isfavorites = value
        End Set
    End Property

    Public Sub UpdateSpecial()
        Playerslbl.Text = _Players
        Maplbl.Text = _Map
    End Sub

#End Region

    Private Sub UpdateEx()
        If _Isfavorites = True Then
            'Servers.UpdateFavoriteTable()
            UpdateAe = True
        End If
    End Sub

    Private Sub sv_control_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.BackColor = Color.Transparent
        Pinglbl.Text = ""
        If _Isfavorites = True Then
            ' Me.AnimaContextMenuStrip1.Items.Item(2).Visible = False
            ' Me.AnimaContextMenuStrip1.Items.Item(3).Visible = False
            Me.AddToFavoritesToolStripMenuItem.Visible = False
            Me.AddAllServersToFavoritesToolStripMenuItem.Visible = False
            Me.DeleteServerToolStripMenuItem.Visible = True
            Me.RefreshServerToolStripMenuItem.Visible = False ' BUG
        Else
            Me.AddToFavoritesToolStripMenuItem.Visible = True
            Me.AddAllServersToFavoritesToolStripMenuItem.Visible = False 'BUG (add all servers to favorites list)
            Me.DeleteServerToolStripMenuItem.Visible = False
            Me.RefreshServerToolStripMenuItem.Visible = False ' BUG
            ' Me.AnimaContextMenuStrip1.Items.Item(2).Visible = True
            ' Me.AnimaContextMenuStrip1.Items.Item(3).Visible = False
        End If
        Me.UpdateValues()
        HandlesSub()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub HandlesSub()

        AddHandler HostNamelbl.MouseHover, AddressOf HandleHover
        AddHandler HostNamelbl.MouseLeave, AddressOf HandleLeave
        AddHandler HostNamelbl.Click, AddressOf GunaButton1_Click
        AddHandler HostNamelbl.MouseDoubleClick, AddressOf HandleDoubleClick

        AddHandler Playerslbl.MouseHover, AddressOf HandleHover
        AddHandler Playerslbl.MouseLeave, AddressOf HandleLeave
        AddHandler Playerslbl.Click, AddressOf GunaButton1_Click
        AddHandler Playerslbl.MouseDoubleClick, AddressOf HandleDoubleClick

        AddHandler Modelbl.MouseHover, AddressOf HandleHover
        AddHandler Modelbl.MouseLeave, AddressOf HandleLeave
        AddHandler Modelbl.Click, AddressOf GunaButton1_Click
        AddHandler Modelbl.MouseDoubleClick, AddressOf HandleDoubleClick

        AddHandler Maplbl.MouseHover, AddressOf HandleHover
        AddHandler Maplbl.MouseLeave, AddressOf HandleLeave
        AddHandler Maplbl.Click, AddressOf GunaButton1_Click
        AddHandler Maplbl.MouseDoubleClick, AddressOf HandleDoubleClick

        AddHandler Pinglbl.MouseHover, AddressOf HandleHover
        AddHandler Pinglbl.MouseLeave, AddressOf HandleLeave
        AddHandler Pinglbl.Click, AddressOf GunaButton1_Click
        AddHandler Pinglbl.MouseDoubleClick, AddressOf HandleDoubleClick

    End Sub

    Private IsMauseInControl As Boolean = False
    Private Sub HandleHover(sender As Object, e As EventArgs)
        Me.BackColor = GunaButton1.OnHoverBaseColor
        Me.GunaButton1.BorderColor = Color.SpringGreen
        IsMauseInControl = True
    End Sub

    Private Sub HandleLeave(sender As Object, e As EventArgs)
        Me.GunaButton1.BorderColor = Color.Transparent
        Me.BackColor = GunaButton1.OnHoverBaseColor
        IsMauseInControl = False
    End Sub

    Private Sub HandleDoubleClick(sender As Object, e As EventArgs)
        ConnectServer(My.Settings.GameDefect)
    End Sub

    Private Sub GunaButton1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles GunaButton1.MouseDoubleClick
        ConnectServer(My.Settings.GameDefect)
    End Sub

    Private Sub GunaButton1_MouseHover(sender As Object, e As EventArgs) Handles GunaButton1.MouseHover
        ' IsMauseInControl = True
        Me.BackColor = GunaButton1.OnHoverBaseColor
    End Sub

    Private Sub GunaButton1_MouseLeave(sender As Object, e As EventArgs) Handles GunaButton1.MouseLeave
        Me.BackColor = Color.Transparent
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        ' Servers.GetAllInfo(_IPAdress)
        Me.BackColor = Color.FromArgb(40, Color.Black)
    End Sub


    Private Sub ConnectServer(ByVal TypeGame As Integer)
        If TypeGame = 0 Then
            If My.Settings.GameDirCE = "" Then
            Else
                Dim NewLauncher As New Core.Launcher(My.Settings.GameDirCE)
                NewLauncher.Launch(IPAdress)
            End If
        ElseIf TypeGame = 1 Then
            If My.Settings.GameDirCE = "" Then
            Else
                Dim NewLauncher As New Core.Launcher(My.Settings.GameDirPC)
                NewLauncher.Launch(IPAdress)
            End If
        End If
     End Sub

    Private WithEvents TimerMonitorCheck As New Timer With {.Enabled = True, .Interval = 1}

    Private Sub TimerMonitorCheck_Tick(sender As Object, e As EventArgs)
        If IsMauseInControl = True Then
            GunaButton1.BorderColor = Color.SpringGreen
        Else
            GunaButton1.BorderColor = Color.Transparent
        End If
        If My.Settings.GameDirCE = "" Then
            Me.AnimaContextMenuStrip1.Items.Item(0).Visible = False
        End If
        If My.Settings.GameDirPC = "" Then
            Me.AnimaContextMenuStrip1.Items.Item(1).Visible = False
        End If
        If IsMauseInControl = True Then
            If Continues = True Then
                BackgroundWorker1.RunWorkerAsync()
                Continues = False
            End If

            Pinglbl.Text = pingms
        End If
       
    End Sub

#Region " TapStrip "

    Private Sub ConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem.Click
        ConnectServer(0)
    End Sub

    Private Sub ConnectWithHALOPCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectWithHALOPCToolStripMenuItem.Click
        ConnectServer(1)
    End Sub

    Private Sub AddToFavoritesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToFavoritesToolStripMenuItem.Click
        Dim SvTemList As New List(Of ServerType)
        Dim sv_tem As New ServerType With {.Name = _Namesv, .IPAdress = _IPAdress, .Players = _Players, .Map = _Map}

        If CheckDuplicateServerFromXML(sv_tem) = False Then

            SvTemList.Add(sv_tem)
            Dim ProcesingXML As Boolean = WritteXmlServers(SvTemList)
            If ProcesingXML = True Then
                UpdateEx()
            End If

        End If
       
    End Sub

    Private Sub DeleteServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteServerToolStripMenuItem.Click
        Dim sv_tem As New ServerType With {.Name = _Namesv, .IPAdress = _IPAdress, .Players = _Players, .Map = _Map}
        Dim ProcesingXML As Boolean = DeleteServerFromXML(sv_tem)
        If ProcesingXML = True Then
            UpdateEx()
        End If
    End Sub

    Private Sub RefreshServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshServerToolStripMenuItem.Click
        UpdateValues()
        ' Dim sv_tem As New ServerType With {.Name = _Namesv, .IPAdress = _IPAdress, .Players = _Players, .Map = _Map}
        ' Servers.GetAllInfo(_IPAdress)
    End Sub

    Private Sub CopyServerInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyServerInfoToolStripMenuItem.Click
        Dim HeaderString As String = "Halo Launcher for CE and PC!" & vbNewLine & "By EternalSoft" & vbNewLine
        Dim sv_Info_Cop As String = "Hostname : " & _Namesv & vbNewLine & "Ip Adress : " & _IPAdress & vbNewLine & "Players: " & _Players & vbNewLine & "Server Map : " & _Map
        Clipboard.SetText(HeaderString & sv_Info_Cop)
    End Sub


#End Region

    Private Sub CreateAndCopyServerInviteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateAndCopyServerInviteToolStripMenuItem.Click
        Clipboard.SetText(Core.Utils.Compression.CompressedData(_IPAdress))
    End Sub

    Private Sub AddAllServersToFavoritesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAllServersToFavoritesToolStripMenuItem.Click
        Servers.CallWriteAllServerTofavorites()
    End Sub


#Region " PingMSAsync "

    Public pingms As String = String.Empty
    Public Continues As Boolean = False

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        On Error Resume Next
        pingms = Medidorping(_IPAdress)
        Continues = True
    End Sub

    Private Function Medidorping(ByVal ip As String) As String
        Dim sw As New Stopwatch
        If My.Computer.Network.IsAvailable() Then
            sw.Start()
            My.Computer.Network.Ping(ip)
            sw.Stop()
            Medidorping = sw.ElapsedMilliseconds & " ms"
        Else
            Medidorping = "Error"
        End If
    End Function

#End Region
   
End Class
