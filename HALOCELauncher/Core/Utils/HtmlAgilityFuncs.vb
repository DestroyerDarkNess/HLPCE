Namespace Core.Utils

    Public Class HtmlAgilityFuncs

        ' Get Html XPaths
        ' By Elektro
        '
        ' Example Usage:
        '
        ' Dim Document As New HtmlAgilityPack.HtmlDocument
        ' Document.LoadHtml(IO.File.ReadAllText("C:\File.html"))
        ' Dim XpathList As List(Of String) = GetHtmlXPaths(Document)
        ' ListBox1.Items.AddRange((From XPath As String In XpathList Select XPath).ToArray)

        ''' <summary>
        ''' Gets all the XPath expressions of an <see cref="HtmlAgilityPack.HtmlDocument"/> document.
        ''' </summary>
        ''' <param name="Document">Indicates the <see cref="HtmlAgilityPack.HtmlDocument"/> document.</param>
        ''' <returns>List(Of System.String).</returns>
        Public Shared Function GetHtmlXPaths(ByVal Document As HtmlAgilityPack.HtmlDocument) As List(Of String)

            Dim XPathList As New List(Of String)
            Dim XPath As String = String.Empty

            For Each Child As HtmlAgilityPack.HtmlNode In Document.DocumentNode.ChildNodes

                If Child.NodeType = HtmlAgilityPack.HtmlNodeType.Element Then
                    GetHtmlXPaths(Child, XPathList, XPath)
                End If

            Next Child

            Return XPathList

        End Function

        ''' <summary>
        ''' Gets all the XPath expressions of an <see cref="HtmlAgilityPack.HtmlNode"/>.
        ''' </summary>
        ''' <param name="Node">Indicates the <see cref="HtmlAgilityPack.HtmlNode"/>.</param>
        ''' <param name="XPathList">Indicates a ByReffered XPath list as a <see cref="List(Of String)"/>.</param>
        ''' <param name="XPath">Indicates the current XPath.</param>
        Private Shared Sub GetHtmlXPaths(ByVal Node As HtmlAgilityPack.HtmlNode,
                                  ByRef XPathList As List(Of String),
                                  Optional ByVal XPath As String = Nothing)

            XPath &= Node.XPath.Substring(Node.XPath.LastIndexOf("/"c))

            Const ClassNameFilter As String = "[@class='{0}']"
            Dim ClassName As String = Node.GetAttributeValue("class", String.Empty)

            If Not String.IsNullOrEmpty(ClassName) Then
                XPath &= String.Format(ClassNameFilter, ClassName)
            End If

            If Not XPathList.Contains(XPath) Then
                XPathList.Add(XPath)
            End If

            For Each Child As HtmlAgilityPack.HtmlNode In Node.ChildNodes

                If Child.NodeType = HtmlAgilityPack.HtmlNodeType.Element Then
                    GetHtmlXPaths(Child, XPathList, XPath)
                End If

            Next Child

        End Sub

    End Class

End Namespace

