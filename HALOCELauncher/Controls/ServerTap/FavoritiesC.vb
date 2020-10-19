Imports HALOCELauncher.Core.GameTracker
Imports HALOCELauncher.Core.SvManager.SvFormatManager
Imports HALOCELauncher.Core.Utils.LogFuncs
Imports HALOCELauncher.HaloQuery

Public Class FavoritiesC

    Public ReadOnly Property ServerCounter As Integer
        Get
            Return PanelContainer.Controls.Count
        End Get
    End Property

    Private Sub FavoritiesC_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try : AddHandler Application.ThreadException, AddressOf Application_Exception_Handler _
                : Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, False) _
                    : Catch : End Try

        Me.BackColor = Color.FromArgb(40, Color.Black)
        ShowLoading(True)
        StartControls()
    End Sub

    Private Sub Application_Exception_Handler(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        Dim ex As Exception = CType(e.Exception, Exception)
        WriteLog(ex.Message, InfoType.Exception)
        ClearAll()
    End Sub

    Public Sub ClearAll()
        CurrentPage = 1
        ContinueListing = True
        PanelContainer.Controls.Clear()
        ShowLoading(True)
        ItemID = 0
        ItemsCount = 0
        Local_X = 0
        Local_Y = 2
    End Sub

    Private Sub ShowLoading(ByVal ShowL As Boolean)
        If ShowL = True Then
            Dim ControlLoader As New LoadingC
            ControlLoader.BackColor = Color.Transparent
            PanelContainer.Controls.Add(ControlLoader)
            Dim PointX As Integer = (PanelContainer.Width / 2) - (ControlLoader.Width - 90)
            Dim PointY As Integer = (PanelContainer.Height / 2) - (ControlLoader.Height - 20)
            ControlLoader.Location = New Point(PointX, PointY)
        Else
            For Each childControl In PanelContainer.Controls
                If TypeOf childControl Is LoadingC Then
                    PanelContainer.Controls.Remove(childControl)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Public Sub UpdateAll()
        ClearAll()
        If ExistsXmlServer() = True Then
            ServerStartListing()
        End If
    End Sub

    Private Sub StartControls()
        ScroolBar()
        If ExistsXmlServer() = True Then
            ServerStartListing()
        End If
    End Sub

    Dim CurrentPage As Integer = 1
    Dim ContinueListing As Boolean = True

    Private Sub ServerStartListing()
        Dim tsk As New Task(ServerLister, TaskCreationOptions.LongRunning)
        tsk.Start()
    End Sub

    Dim ServerLister As New Action(
    Sub()
        If ContinueListing = True Then
            ContinueListing = False
            ServerListerSub()
        End If
    End Sub)

    Private Sub ServerListerSub()
        On Error Resume Next

        Dim ResultDic As List(Of ServerType) = ReadXmlServers()

        For Each Result As ServerType In ResultDic

            Me.BeginInvoke(Sub()
                               ListServers(Result)
                           End Sub)
            CurrentPage += 1
        Next
        ContinueListing = True
        Me.BeginInvoke(Sub()
                           RedrawList()
                       End Sub)

        ShowLoading(False)
    End Sub

    Dim ItemID As Integer = 0

    Dim ItemsCount As Integer = 0
    Dim Local_X As Integer = 0
    Dim Local_Y As Integer = 2

    Private Sub ListServers(ByVal ServerInfoEx As ServerType)

        Dim NewItem As New sv_control
        NewItem.Isfavorites = True
        NewItem.Name = ItemID
        NewItem.IPAdress = ServerInfoEx.IPAdress
        NewItem.Namesv = ServerInfoEx.Name
        NewItem.Players = ServerInfoEx.Players
        NewItem.Map = ServerInfoEx.Map
        PanelContainer.Controls.Add(NewItem)

        For Each ControlAdd As Control In NewItem.Controls
            AddHandler ControlAdd.Click, AddressOf UserControl11_Click
        Next

        NewItem.Location = New Point(Local_X, Local_Y)
        ItemID += 1
        ItemsCount += 1

        If ItemsCount = 1 Then
            Local_X = 0
            Local_Y += 30
            ItemsCount = 0
        End If

    End Sub

    Private Sub RedrawList()
        ItemID = 0
        ItemsCount = 0
        Local_X = 0
        Local_Y = 2

        If CurrentPage > 2 Then
            If ContinueListing = True Then
                Dim LocalListEx As New List(Of sv_control)
                LocalListEx.Clear()
                For Each childControl In PanelContainer.Controls
                    If TypeOf childControl Is sv_control Then
                        LocalListEx.Add(childControl)
                    End If
                Next
                PanelContainer.Controls.Clear()
                For Each svC As sv_control In LocalListEx
                    PanelContainer.Controls.Add(svC)
                    svC.Location = New Point(Local_X, Local_Y)
                    ItemID += 1
                    ItemsCount += 1
                    If ItemsCount = 1 Then
                        Local_X = 0
                        Local_Y += 30
                        ItemsCount = 0
                    End If
                Next
            End If
        End If
    End Sub

#Region " Scrollbar "

    Dim vScrollHelperMain As Guna.UI.Lib.ScrollBar.PanelScrollHelper

    Private Sub ScroolBar()
        vScrollHelperMain = New Guna.UI.Lib.ScrollBar.PanelScrollHelper(PanelContainer, GunaVScrollBar1, False)
        vScrollHelperMain.UpdateScrollBar()
    End Sub

    Private Sub PanelContainer_Resize(sender As Object, e As EventArgs)
        If vScrollHelperMain IsNot Nothing Then vScrollHelperMain.UpdateScrollBar()
    End Sub

#End Region

#Region " SvPropertiesLoad "

    Dim _textToDisplay As String = String.Empty

    Private Sub UserControl11_Click(sender As Object, e As EventArgs)
        _textToDisplay = String.Empty
        LabelTextLog.Text = ""
        ListView1.Items.Clear()
        For Each childControl In PanelContainer.Controls
            If TypeOf childControl Is sv_control Then
                Dim GetBackgroung As Boolean = childControl.IsSelectedSv()
                If GetBackgroung = True Then

                    Try
                        Dim GetINFO As New HaloServerInfo({childControl.IPAdress.ToString})

                        For i As Integer = 0 To 2
                            If GetINFO.Ready = True Then
                                Exit For
                            End If
                            i -= 1
                        Next

                        childControl.Players = GetINFO.PlayersCount & "/" & GetINFO.MaxPlayers
                        childControl.Map = GetINFO.MapName
                        childControl.UpdateSpecial()
                        _textToDisplay += "----Team Info " & vbNewLine
                        _textToDisplay += " Red : " & GetINFO.RedTeamInfo.Score.ToString & " Blue : " & GetINFO.BlueTeamInfo.Score.ToString & vbNewLine

                        _textToDisplay += "----Server Info " & vbNewLine
                        _textToDisplay += " Version : " & GetINFO.GameVersion.ToString & vbNewLine & " Mode : " & GetINFO.Gamemode.ToString & vbNewLine
                        _textToDisplay += " Classic : " & GetINFO.GameClassic.ToString & " Type : " & GetINFO.GameType.ToString & vbNewLine
                        _textToDisplay += " Dedicated : " & CBool(GetINFO.Dedicated).ToString & vbNewLine
                        _textToDisplay += " Variant : " & GetINFO.GameVariant & vbNewLine
                        _textToDisplay += " Query ID : " & GetINFO.QueryID.ToString & "  SAPP : " & GetINFO.SAPPC.ToString & vbNewLine
                        _textToDisplay += " Next [Map] : " & GetINFO.NextMap.ToString & vbNewLine & " [Mode] : " & GetINFO.NextMode.ToString & vbNewLine

                        StartInfoProperties()

                        ' Dim LineCount As String() = _textToDisplay.Split(vbNewLine)

                        ' For Each LineEx As String In LineCount
                        '   ListBox1.Items.Add(LineEx)
                        ' Next

                        Dim x As Integer = 0

                        For Each PlayerA As Player In GetINFO.PlayersList
                            ListView1.Items.Add(PlayerA.Name)
                            ListView1.Items(x).SubItems.Add(PlayerA.Score)
                            ListView1.Items(x).ForeColor = PlayerA.Team.TeamColor
                            x += 1
                        Next
                    Catch ex As Exception
                        _textToDisplay += "Query Error, Please try later!" & vbNewLine
                        _textToDisplay += "" & vbNewLine
                        _textToDisplay += ex.Message
                        StartInfoProperties()
                    End Try

                End If
            End If
        Next
    End Sub


    Private _Showing As String = ""
    Private _avrchar As Integer = 0
    Private _AwaitTIme As Integer = 0
    Private _MaxAwaitTIme As Integer = 0
    Private ContinueAwait As Boolean = True

    Private Sub StartInfoProperties()
        _avrchar = 0
        _AwaitTIme = 0
        _MaxAwaitTIme = 100
        ContinueAwait = True
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If _AwaitTIme = _MaxAwaitTIme Then
                ContinueAwait = False
                If _Showing.Count < _textToDisplay.Count And _Showing.Count > 0 Then
                    _Showing = _textToDisplay.Substring(0, _Showing.Length + 1)
                ElseIf _Showing.Count < _textToDisplay.Count And _Showing.Count = 0 Then
                    _Showing = _textToDisplay.Substring(0, 1)
                ElseIf _Showing.Count < _avrchar Then
                    _Showing = " " + _Showing
                Else
                    _Showing = ""
                End If
                LabelTextLog.Text = _Showing
                If LabelTextLog.Text = _textToDisplay Then
                    Timer1.Enabled = False
                End If
            End If

            If ContinueAwait = True Then
                _AwaitTIme += 1
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Function NumberfitCharsInTextBox(tb As TextBox) As Integer
        Dim avgW As Integer = 0
        Dim avgH As Integer = 0
        Dim avg As Size
        For i As Integer = 65 To 90
            avg = TextRenderer.MeasureText(CChar(ChrW(i)).ToString(), LabelTextLog.Font)
            avgH += avg.Height
            avgW += avg.Width
        Next
        Return CInt((((45 * LabelTextLog.Width) / avgW) * ((45 * LabelTextLog.Height) / avgH)))
    End Function

#End Region




    Private Sub RefreshSeverListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshSeverListToolStripMenuItem.Click
        Me.UpdateAll()
    End Sub

End Class
