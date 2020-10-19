Imports HALOCELauncher.Core.GameTracker
Imports HALOCELauncher.HaloQuery
Imports HALOCELauncher.Core.SvManager.SvFormatManager
Imports HALOCELauncher.Core.Helpers

Public Class AddCustomServer

    Private Sub AddCustomServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = CenterForm(Form1, Me, Me.Location)
        If Not My.Computer.Clipboard.ContainsImage() = True Then
            NameTextbox.Text = My.Computer.Clipboard.GetText()
        End If
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If Not NameTextbox.Text = "" Then
            Dim SvTemList As New List(Of ServerType)
            Dim sv_tem As ServerType = GetCorrectFormat(NameTextbox.Text)

            If CheckDuplicateServerFromXML(sv_tem) = False Then

                SvTemList.Add(sv_tem)
                Dim ProcesingXML As Boolean = WritteXmlServers(SvTemList)
                If ProcesingXML = True Then
                    UpdateEx()
                End If

            End If
            Me.Close()
        End If
    End Sub

    Private Sub UpdateEx()
        Servers.UpdateFavoriteTable()
    End Sub

    Private Function GetCorrectFormat(ByVal IpAdd As String) As ServerType
        Dim sv_tem As New ServerType
        Try
            Dim GetINFO As New HaloServerInfo({IpAdd})
            sv_tem.Name = GetINFO.Hostname
            sv_tem.Players = GetINFO.PlayersCount & "/" & GetINFO.MaxPlayers
            sv_tem.Map = GetINFO.MapName
        Catch ex As Exception
            sv_tem.Name = "Query Error"
            sv_tem.Map = "Query Error"
            sv_tem.Players = "-/-"
            sv_tem.IPAdress = IpAdd
            Return sv_tem
        End Try
        Return Nothing
    End Function

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        Me.Close()
    End Sub

End Class