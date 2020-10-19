Imports HALOCELauncher.HaloQuery
Imports System.Text.RegularExpressions

Namespace HaloQuery



    Public Class Player
        Private _ID As Integer = Nothing
        Private _Score As Integer = Nothing
        Private _Name As String = Nothing
        Private _Ping As Integer = Nothing
        Private _Team As New Team
        Public Sub New()

        End Sub
        Public Property ID As Integer
            Get
                Return _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property

        Public Property Score As Integer
            Get
                Return _Score
            End Get
            Set(value As Integer)
                _Score = value
            End Set
        End Property

        Public Property Ping As Integer
            Get
                Return _Ping
            End Get
            Set(value As Integer)
                _Ping = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return _Name
            End Get
            Set(value As String)
                _Name = value
            End Set
        End Property

        Public Property Team As Team
            Get
                Return _Team
            End Get
            Set(value As Team)
                _Team = value
            End Set
        End Property

    End Class

    Public Class Team
        Private _ID As Integer = Nothing
        Private _Score As Integer = Nothing
        Private _TeamColor As Color = Color.White

        Public Property ID As Integer
            Get
                Return _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property

        Public Property Score As Integer
            Get
                Return _Score
            End Get
            Set(value As Integer)
                _Score = value
            End Set
        End Property

        Public Property TeamColor As Color
            Get
                Return _TeamColor
            End Get
            Set(value As Color)
                _TeamColor = value
            End Set
        End Property
    End Class

    Public Class HaloServerInfo

#Region " Properties "

        Private _Ready As Boolean = False
        Public ReadOnly Property Ready As Boolean
            Get
                Return _Ready
            End Get
        End Property

        Public ReadOnly Property PlayersList As List(Of Player)
            Get
                Return GetPlayerList()
            End Get
        End Property

        Public ReadOnly Property RedTeamInfo As Team
            Get
                Return GameTeam.Red
            End Get
        End Property

        Public ReadOnly Property BlueTeamInfo As Team
            Get
                Return GameTeam.Blue
            End Get
        End Property

        Private _Hostname As String = String.Empty
        Public ReadOnly Property Hostname As String
            Get
                Return _Hostname
            End Get
        End Property

        Private _GameVer As String = String.Empty
        Public ReadOnly Property GameVersion As String
            Get
                Return _GameVer
            End Get
        End Property

        Private _HostPort As Integer = Nothing
        Public ReadOnly Property HostPort As Integer
            Get
                Return _HostPort
            End Get
        End Property

        Private _MaxPlayers As Integer = Nothing
        Public ReadOnly Property MaxPlayers As Integer
            Get
                Return _MaxPlayers
            End Get
        End Property

        Private _Password As Boolean = False
        Public ReadOnly Property Password As Boolean
            Get
                Return _Password
            End Get
        End Property

        Private _MapName As String = String.Empty
        Public ReadOnly Property MapName As String
            Get
                Return _MapName
            End Get
        End Property

        Private _Dedicated As Integer = Nothing
        Public ReadOnly Property Dedicated As Integer
            Get
                Return _Dedicated
            End Get
        End Property

        Private _Gamemode As String = String.Empty
        Public ReadOnly Property Gamemode As String
            Get
                Return _Gamemode
            End Get
        End Property

        Private _GameClassic As Integer = Nothing
        Public ReadOnly Property GameClassic As Integer
            Get
                Return _GameClassic
            End Get
        End Property

        Private _NumbPlayers As Integer = Nothing
        Public ReadOnly Property PlayersCount As Integer
            Get
                Return _NumbPlayers
            End Get
        End Property

        Private _GameType As String = String.Empty
        Public ReadOnly Property GameType As String
            Get
                Return _GameType
            End Get
        End Property

        Private _TeamPlay As Integer = Nothing
        Public ReadOnly Property TeamPlay As Integer
            Get
                Return _TeamPlay
            End Get
        End Property

        Private _GameVariant As String = String.Empty
        Public ReadOnly Property GameVariant As String
            Get
                Return _GameVariant
            End Get
        End Property

        Private _FragLimit As Integer = Nothing
        Public ReadOnly Property FragLimit As Integer
            Get
                Return _FragLimit
            End Get
        End Property

        Private _PlayerFlags As String = String.Empty
        Public ReadOnly Property PlayerFlags As String
            Get
                Return _PlayerFlags
            End Get
        End Property

        Private _GameFlags As String = String.Empty
        Public ReadOnly Property GameFlags As String
            Get
                Return _GameFlags
            End Get
        End Property

        Private _Final As String = String.Empty
        Public ReadOnly Property Final As String
            Get
                Return _Final
            End Get
        End Property

        Private _QueryID As String = String.Empty
        Public ReadOnly Property QueryID As String
            Get
                Return _QueryID
            End Get
        End Property

        Private _SAPPC As String = String.Empty
        Public ReadOnly Property SAPPC As String
            Get
                Return _SAPPC
            End Get
        End Property

        Private _SAPPFlags As String = String.Empty
        Public ReadOnly Property SAPPFlags As String
            Get
                Return _SAPPFlags
            End Get
        End Property

        Private _NextMap As String = String.Empty
        Public ReadOnly Property NextMap As String
            Get
                Return _NextMap
            End Get
        End Property

        Private _NextMode As String = String.Empty
        Public ReadOnly Property NextMode As String
            Get
                Return _NextMode
            End Get
        End Property

#End Region

#Region " Structures "

#Region " PlayerStructure "

        Public Structure Players
            Public Shared Player1 As New Player
            Public Shared Player2 As New Player
            Public Shared Player3 As New Player
            Public Shared Player4 As New Player
            Public Shared Player5 As New Player
            Public Shared Player6 As New Player
            Public Shared Player7 As New Player
            Public Shared Player8 As New Player
            Public Shared Player9 As New Player
            Public Shared Player10 As New Player
            Public Shared Player11 As New Player
            Public Shared Player12 As New Player
            Public Shared Player13 As New Player
            Public Shared Player14 As New Player
            Public Shared Player15 As New Player
            Public Shared Player16 As New Player
        End Structure

#End Region

#Region " TeamStructure "

        Private Structure GameTeam
            Public Shared Red As New Team With {.ID = 0, .TeamColor = Color.Red}
            Public Shared Blue As New Team With {.ID = 1, .TeamColor = Color.Blue}
        End Structure

#End Region

#End Region

        Public Sub New(ByVal argsEx As String())
            _Ready = False
            Dim ServerInfo As Boolean = GetServerInfo(argsEx)
            _Ready = True
        End Sub

        Public Function GetServerInfo(ByVal Argumentos As String()) As Boolean
            ' Try
            Dim server = GetHaloServerFromArgs(Argumentos)

            For Each record In server.GetDictionaryResponse()
                Select Case record.Key
                    'Players ID / NAME / SCORE / PING
                    '
                    '--------Name And ID
                    Case "player_0" : Players.Player1.Name = record.Value : Players.Player1.ID = 0
                    Case "player_1" : Players.Player2.Name = record.Value : Players.Player2.ID = 1
                    Case "player_2" : Players.Player3.Name = record.Value : Players.Player3.ID = 2
                    Case "player_3" : Players.Player4.Name = record.Value : Players.Player4.ID = 3
                    Case "player_4" : Players.Player5.Name = record.Value : Players.Player5.ID = 4
                    Case "player_5" : Players.Player6.Name = record.Value : Players.Player6.ID = 5
                    Case "player_6" : Players.Player7.Name = record.Value : Players.Player7.ID = 6
                    Case "player_7" : Players.Player8.Name = record.Value : Players.Player8.ID = 7
                    Case "player_8" : Players.Player9.Name = record.Value : Players.Player9.ID = 8
                    Case "player_9" : Players.Player10.Name = record.Value : Players.Player10.ID = 9
                    Case "player_10" : Players.Player11.Name = record.Value : Players.Player11.ID = 10
                    Case "player_11" : Players.Player12.Name = record.Value : Players.Player12.ID = 11
                    Case "player_12" : Players.Player13.Name = record.Value : Players.Player13.ID = 12
                    Case "player_13" : Players.Player14.Name = record.Value : Players.Player14.ID = 13
                    Case "player_14" : Players.Player15.Name = record.Value : Players.Player15.ID = 14
                    Case "player_15" : Players.Player16.Name = record.Value : Players.Player16.ID = 15
                        '
                        '--------Score
                    Case "score_0" : Players.Player1.Score = Num(record.Value)
                    Case "score_1" : Players.Player2.Score = Num(record.Value)
                    Case "score_2" : Players.Player3.Score = Num(record.Value)
                    Case "score_3" : Players.Player4.Score = Num(record.Value)
                    Case "score_4" : Players.Player5.Score = Num(record.Value)
                    Case "score_5" : Players.Player6.Score = Num(record.Value)
                    Case "score_6" : Players.Player7.Score = Num(record.Value)
                    Case "score_7" : Players.Player8.Score = Num(record.Value)
                    Case "score_8" : Players.Player9.Score = Num(record.Value)
                    Case "score_9" : Players.Player10.Score = Num(record.Value)
                    Case "score_10" : Players.Player11.Score = Num(record.Value)
                    Case "score_11" : Players.Player12.Score = Num(record.Value)
                    Case "score_12" : Players.Player13.Score = Num(record.Value)
                    Case "score_13" : Players.Player14.Score = Num(record.Value)
                    Case "score_14" : Players.Player15.Score = Num(record.Value)
                    Case "score_15" : Players.Player16.Score = Num(record.Value)
                        '
                        '--------Ping
                    Case "ping_0" : Players.Player1.Ping = record.Value
                    Case "ping_1" : Players.Player2.Ping = record.Value
                    Case "ping_2" : Players.Player3.Ping = record.Value
                    Case "ping_3" : Players.Player4.Ping = record.Value
                    Case "ping_4" : Players.Player5.Ping = record.Value
                    Case "ping_5" : Players.Player6.Ping = record.Value
                    Case "ping_6" : Players.Player7.Ping = record.Value
                    Case "ping_7" : Players.Player8.Ping = record.Value
                    Case "ping_8" : Players.Player9.Ping = record.Value
                    Case "ping_9" : Players.Player10.Ping = record.Value
                    Case "ping_10" : Players.Player11.Ping = record.Value
                    Case "ping_11" : Players.Player12.Ping = record.Value
                    Case "ping_12" : Players.Player13.Ping = record.Value
                    Case "ping_13" : Players.Player14.Ping = record.Value
                    Case "ping_14" : Players.Player15.Ping = record.Value
                    Case "ping_15" : Players.Player16.Ping = record.Value
                        '
                        '--------Team
                    Case "team_0" : If record.Value = GameTeam.Red.ID Then : Players.Player1.Team = GameTeam.Red : Else : Players.Player1.Team = GameTeam.Blue : End If
                    Case "team_1" : If record.Value = GameTeam.Red.ID Then : Players.Player2.Team = GameTeam.Red : Else : Players.Player2.Team = GameTeam.Blue : End If
                    Case "team_2" : If record.Value = GameTeam.Red.ID Then : Players.Player3.Team = GameTeam.Red : Else : Players.Player3.Team = GameTeam.Blue : End If
                    Case "team_3" : If record.Value = GameTeam.Red.ID Then : Players.Player4.Team = GameTeam.Red : Else : Players.Player4.Team = GameTeam.Blue : End If
                    Case "team_4" : If record.Value = GameTeam.Red.ID Then : Players.Player5.Team = GameTeam.Red : Else : Players.Player5.Team = GameTeam.Blue : End If
                    Case "team_5" : If record.Value = GameTeam.Red.ID Then : Players.Player6.Team = GameTeam.Red : Else : Players.Player6.Team = GameTeam.Blue : End If
                    Case "team_6" : If record.Value = GameTeam.Red.ID Then : Players.Player7.Team = GameTeam.Red : Else : Players.Player7.Team = GameTeam.Blue : End If
                    Case "team_7" : If record.Value = GameTeam.Red.ID Then : Players.Player8.Team = GameTeam.Red : Else : Players.Player8.Team = GameTeam.Blue : End If
                    Case "team_8" : If record.Value = GameTeam.Red.ID Then : Players.Player9.Team = GameTeam.Red : Else : Players.Player9.Team = GameTeam.Blue : End If
                    Case "team_9" : If record.Value = GameTeam.Red.ID Then : Players.Player10.Team = GameTeam.Red : Else : Players.Player10.Team = GameTeam.Blue : End If
                    Case "team_10" : If record.Value = GameTeam.Red.ID Then : Players.Player11.Team = GameTeam.Red : Else : Players.Player11.Team = GameTeam.Blue : End If
                    Case "team_11" : If record.Value = GameTeam.Red.ID Then : Players.Player12.Team = GameTeam.Red : Else : Players.Player12.Team = GameTeam.Blue : End If
                    Case "team_12" : If record.Value = GameTeam.Red.ID Then : Players.Player13.Team = GameTeam.Red : Else : Players.Player13.Team = GameTeam.Blue : End If
                    Case "team_13" : If record.Value = GameTeam.Red.ID Then : Players.Player14.Team = GameTeam.Red : Else : Players.Player14.Team = GameTeam.Blue : End If
                    Case "team_14" : If record.Value = GameTeam.Red.ID Then : Players.Player15.Team = GameTeam.Red : Else : Players.Player15.Team = GameTeam.Blue : End If
                    Case "team_15" : If record.Value = GameTeam.Red.ID Then : Players.Player16.Team = GameTeam.Red : Else : Players.Player16.Team = GameTeam.Blue : End If
                        '
                        '
                        'Team ID and Score
                    Case "team_t0" : If record.Value = "Red" Then : GameTeam.Red.ID = 0 : GameTeam.Blue.ID = 1 : End If
                    Case "team_t1" : If record.Value = "Blue" Then : GameTeam.Blue.ID = 1 : GameTeam.Red.ID = 0 : End If
                    Case "score_t0" : If GameTeam.Red.ID = 0 Then : GameTeam.Red.Score = record.Value : Else : GameTeam.Blue.Score = record.Value : End If
                    Case "score_t1" : If GameTeam.Blue.ID = 1 Then : GameTeam.Blue.Score = record.Value : Else : GameTeam.Red.Score = record.Value : End If
                        '
                    Case "hostname" : If record.Value = "" Then : _Hostname = "Erro to get" : Else : _Hostname = record.Value.ToString : End If
                    Case "gamever" : _GameVer = record.Value
                    Case "hostport" : _HostPort = Num(record.Value)
                    Case "maxplayers" : _MaxPlayers = Val(record.Value)
                    Case "password" : _Password = CBool(record.Value)
                    Case "mapname" : _MapName = record.Value
                    Case "dedicated" : _Dedicated = record.Value
                    Case "gamemode" : _Gamemode = record.Value
                    Case "game_classic" : _GameClassic = record.Value
                    Case "numplayers" : _NumbPlayers = Val(record.Value)
                    Case "gametype" : _GameType = record.Value
                    Case "teamplay" : _TeamPlay = Val(record.Value)
                    Case "gamevariant" : _GameVariant = record.Value
                    Case "fraglimit" : _FragLimit = Val(record.Value)
                    Case "player_flags" : _PlayerFlags = record.Value
                    Case "game_flags" : _GameFlags = record.Value
                    Case "final" : _Final = record.Value
                    Case "queryid" : _QueryID = record.Value
                    Case "sapp" : _SAPPC = record.Value
                    Case "sapp_flags" : _SAPPFlags = record.Value
                    Case "nextmap" : _NextMap = record.Value
                    Case "nextmode" : _NextMode = record.Value

                End Select
            Next

            Return True
            ' Catch ex As Exception
            '   Throw New Exception(ex.Message)
            'End Try
            Return False
        End Function

#Region " Methods "

        Private Function Num(ByVal value As String) As Integer
            If value = "" Then
                Return 8080
            Else
                Dim returnVal As String = String.Empty
                Dim collection As MatchCollection = Regex.Matches(value, "\d+")
                For Each m As Match In collection
                    returnVal += m.ToString()
                Next
                Return Convert.ToInt32(returnVal)
            End If
        End Function

        Private Function GetHaloServerFromArgs(ByVal args As String()) As HaloServer
            Dim serverArgs = args
            Dim host As String
            Dim port As Integer
            If args.Length = 1 Then serverArgs = args(0).Split(":"c)

            If serverArgs.Length = 0 OrElse serverArgs.Length > 2 Then
                ' TextBox1.Text += "haloq (host[:port] | host [port])" & vbNewLine
                MsgBox("error")
            End If

            host = serverArgs(0)

            If serverArgs.Length = 1 Then
                port = 2302
            Else
                port = Integer.Parse(serverArgs(1))
            End If

            Return New HaloServer(host, port)
        End Function

        Private Function GetPlayerList() As List(Of Player)
            Dim PlayerList As New List(Of Player)
            PlayerList.Add(Players.Player1)
            PlayerList.Add(Players.Player2)
            PlayerList.Add(Players.Player3)
            PlayerList.Add(Players.Player4)
            PlayerList.Add(Players.Player5)
            PlayerList.Add(Players.Player6)
            PlayerList.Add(Players.Player7)
            PlayerList.Add(Players.Player8)
            PlayerList.Add(Players.Player9)
            PlayerList.Add(Players.Player10)
            PlayerList.Add(Players.Player11)
            PlayerList.Add(Players.Player12)
            PlayerList.Add(Players.Player13)
            PlayerList.Add(Players.Player14)
            PlayerList.Add(Players.Player15)
            PlayerList.Add(Players.Player16)
            Return PlayerList
        End Function

#End Region

    End Class
End Namespace

