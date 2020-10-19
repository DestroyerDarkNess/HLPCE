Imports System.Net
Imports System.IO
Imports HtmlAgilityPack
Imports System.Text.RegularExpressions


Namespace Core.GameTracker

    Public Class ServerType
        Private _Name As String = Nothing
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

        Public Property Name As String
            Get
                Return _Name
            End Get
            Set(value As String)
                _Name = value
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

    End Class

    Public Class GTAPI

        Public Sub New()

        End Sub

        Private HeaderTable As String = String.Empty

        Public Function GetServerList(Optional ByVal GameUrl As String = "https://www.gametracker.com/search/halo/#search") As List(Of ServerType)
            On Error Resume Next
            Dim ResultA As New List(Of ServerType)
            Dim HtmlDocumentString As String = GetHTMLPage(GameUrl)
            Dim htmldocEX As New HtmlAgilityPack.HtmlDocument


            If Not HtmlDocumentString = String.Empty Then

                htmldocEX.LoadHtml(HtmlDocumentString)

                For Each row As HtmlNode In htmldocEX.DocumentNode.SelectNodes("//table[@class='table_lst table_lst_srs']")
                    Dim cells As HtmlNodeCollection = row.SelectNodes(".//tr")

                    For i As Integer = 0 To cells.Count - 1

                        If i = 0 Then
                            'Header Table
                            HeaderTable = TableFilter(cells(i).InnerText)
                            'MsgBox(HeaderTable)
                        Else

                            Dim ServerInfostr As String = TableFilter(cells(i).InnerText, True)
                            Dim ServerReaderInfo As String() = ServerInfostr.Split("|")
                            Dim LocalServer As New ServerType
                            LocalServer.ListID = Num(ServerReaderInfo(0))
                            LocalServer.Name = ServerReaderInfo(1)
                            LocalServer.Players = ServerReaderInfo(2)
                            LocalServer.IPAdress = ServerReaderInfo(3)
                            LocalServer.Map = ServerReaderInfo(4)
                            If Not LocalServer.IPAdress = "Players" Then
                                ResultA.Add(LocalServer)
                            End If

                        End If

                    Next

                Next

                Return ResultA

            End If
            'Return Nothing
        End Function

#Region " Methods "

        Private Function GetHTMLPage(ByVal Url As String) As String
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12
            Dim cookieJar As CookieContainer = New CookieContainer()
            Dim request As HttpWebRequest = CType(WebRequest.Create(Url), HttpWebRequest)
            request.UseDefaultCredentials = True
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
            request.CookieContainer = cookieJar
            request.Accept = "text/html, application/xhtml+xml, */*"
            request.Referer = "https://www.gametracker.com/"
            request.Headers.Add("Accept-Language", "en-GB")
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)"
            request.Host = "www.gametracker.com"
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim htmlString As String = String.Empty

            Using reader = New StreamReader(response.GetResponseStream())
                htmlString = reader.ReadToEnd()
            End Using

            Return htmlString
        End Function

        Private Function TableFilter(ByVal subjectString As String, Optional Separator As Boolean = False) As String
            Dim SubjetFilter As String = subjectString.Replace("|", "")
            Dim FilterString As String = Regex.Replace(SubjetFilter, "^\s+$[\r\n]*", "", RegexOptions.Multiline)
            Dim ResultStr As String = String.Empty
            Dim reader = New StringReader(FilterString)
            While True
                Dim line = reader.ReadLine()
                If line Is Nothing Then
                    Exit While
                Else
                    If Separator = True Then
                        ResultStr += RemoveWhitespace(line) & "|"
                    Else
                        ResultStr += RemoveWhitespace(line) & "    "
                    End If
                End If
            End While
            Return ResultStr
        End Function

        Private Function Num(ByVal value As String) As Integer
            Dim returnVal As String = String.Empty
            Dim collection As MatchCollection = Regex.Matches(value, "\d+")
            For Each m As Match In collection
                returnVal += m.ToString()
            Next
            Return Convert.ToInt32(returnVal)
        End Function

        Private Function RemoveWhitespace(fullString As String) As String
            Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
        End Function

#End Region


    End Class



End Namespace

