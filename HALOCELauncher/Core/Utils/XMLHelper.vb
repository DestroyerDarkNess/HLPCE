' [ Song XML Writer Helper ]
'
' // By Elektro H@cker
'
' Example usage :
'
'Private Sub Test()
'
'    ' Set an XML file to create
'    Dim xmlfile As String = "C:\My XML File.xml"
'
'    ' Create the XmlWriter object
'    Dim XmlWriter As Xml.XmlTextWriter = _
'        New Xml.XmlTextWriter(xmlfile, System.Text.Encoding.Default) _
'        With {.Formatting = Xml.Formatting.Indented}
'
'    ' Write the Xml declaration.
'    XMLHelper.Write_Beginning(XmlWriter)
'    ' Output at this point:
'    ' <?xml version="1.0" encoding="Windows-1252"?>
'
'    ' Write a comment.
'    XMLHelper.Write_Comment(XmlWriter, "XML Songs Database", Xml.Formatting.Indented)
'    ' Output at this point:
'    ' <!--XML Songs Database-->
'
'    ' Write the root element.
'    XMLHelper.Write_Beginning_Root_Element(XmlWriter, "Songs", Xml.Formatting.Indented)
'    ' Output at this point:
'    ' <Songs>
'
'    ' Write the start of a song element.
'    XMLHelper.Write_Beginning_Root_Element(XmlWriter, "Song", Xml.Formatting.Indented)
'    ' Output at this point:
'    ' <Song>
'
'    ' Write a song element.
'    XMLHelper.Write_Elements(XmlWriter, { _
'                                         {"Name", "My Song file.mp3"}, _
'                                         {"Year", "2013"}, _
'                                         {"Genre", "Rock"} _
'                                        }, Xml.Formatting.None)        
'    ' Output at this point:
'    ' <Name>My Song file.mp3</Name><Year>2007</Year><Genre>Dance</Genre>
'
'    ' Write the end of a song element.
'    XMLHelper.Write_End_Root_Element(XmlWriter, Xml.Formatting.None)
'    ' Output at this point:
'    ' </Song>
'
'    ' Write the end of the Root element.
'    XMLHelper.Write_End_Root_Element(XmlWriter, Xml.Formatting.Indented)
'    ' Output at this point:
'    ' </Songs>
'
'    ' Write the xml end of file.
'    XMLHelper.Write_End(XmlWriter)
'
'    ' Start the file and exit
'    Process.Start(xmlfile) : Application.Exit()
'
'    ' Final output:
'    '
'    '<?xml version="1.0" encoding="Windows-1252"?>
'    '<!--XML Songs Database-->
'    '<Songs>
'    '  <Song><Name>My Song file.mp3</Name><Year>2007</Year><Genre>Dance</Genre></Song>
'    '</Songs>
'
'End Sub

Namespace Core.Utils

#Region " XML Helper "

    Class XMLHelper

        ''' <summary>
        ''' Writes the Xml beginning declaration.
        ''' </summary>
        Shared Sub Write_Beginning(ByVal XmlWriter As Xml.XmlTextWriter)

            Try
                XmlWriter.WriteStartDocument()

            Catch ex As InvalidOperationException
                Dim errormsg As String = "This is not the first write method called after the constructor. "
                Throw New Exception(errormsg & Environment.NewLine & ex.StackTrace)
                ' MessageBox.Show(errormsg)

            Catch ex As Exception
                Throw New Exception(ex.Message & Environment.NewLine & ex.StackTrace)

            End Try

        End Sub

        ''' <summary>
        ''' Writes a comment.
        ''' </summary>
        Shared Sub Write_Comment(ByVal XmlWriter As Xml.XmlTextWriter, _
                                      ByVal Comment As String, _
                                      Optional ByVal Indentation As Xml.Formatting = Xml.Formatting.Indented)

            Try
                XmlWriter.Formatting = Indentation
                XmlWriter.WriteComment(Comment)
                XmlWriter.Formatting = Not Indentation

            Catch ex As ArgumentException
                Dim errormsg As String = "The text would result in a non-well formed XML document"
                Throw New Exception(errormsg & Environment.NewLine & ex.StackTrace)
                ' MessageBox.Show(errormsg)

            Catch ex As InvalidOperationException
                Dim errormsg As String = "The ""WriteState"" property is Closed"
                Throw New Exception(errormsg & Environment.NewLine & ex.StackTrace)
                ' MessageBox.Show(errormsg)

            Catch ex As Exception
                Throw New Exception(ex.Message & Environment.NewLine & ex.StackTrace)

            End Try

        End Sub

        ''' <summary>
        ''' Writes the beginning of a root element.
        ''' </summary>
        Shared Sub Write_Beginning_Root_Element(ByVal XmlWriter As Xml.XmlTextWriter, _
                                                     ByVal Element As String, _
                                                     Optional ByVal Indentation As Xml.Formatting = Xml.Formatting.Indented)

            Try
                XmlWriter.Formatting = Indentation
                XmlWriter.WriteStartElement(Element)
                XmlWriter.Formatting = Not Indentation

            Catch ex As System.Text.EncoderFallbackException
                Dim errormsg As String = "There is a character in the buffer that is a valid XML character but is not valid for the output encoding."
                Throw New Exception(errormsg & Environment.NewLine & ex.StackTrace)
                ' MessageBox.Show(errormsg)

            Catch ex As InvalidOperationException
                Dim errormsg As String = "The XmlTextWriter is closed or An XmlTextWriter method was called before a previous asynchronous operation finished."
                Throw New Exception(errormsg & Environment.NewLine & ex.StackTrace)
                ' MessageBox.Show(errormsg)

            Catch ex As Exception
                Throw New Exception(ex.Message & Environment.NewLine & ex.StackTrace)

            End Try

        End Sub

        ''' <summary>
        ''' Writes the end of a root element.
        ''' </summary>
        Shared Sub Write_End_Root_Element(ByVal XmlWriter As Xml.XmlTextWriter, _
                                               Optional ByVal Indentation As Xml.Formatting = Xml.Formatting.Indented)

            Try
                XmlWriter.Formatting = Indentation
                XmlWriter.WriteEndElement()
                XmlWriter.Formatting = Not Indentation

            Catch ex As System.Text.EncoderFallbackException
                Dim errormsg As String = "There is a character in the buffer that is a valid XML character but is not valid for the output encoding."
                Throw New Exception(errormsg & Environment.NewLine & ex.StackTrace)
                ' MessageBox.Show(errormsg)

            Catch ex As InvalidOperationException
                Dim errormsg As String = "The XmlTextWriter is closed or An XmlTextWriter method was called before a previous asynchronous operation finished."
                Throw New Exception(errormsg & Environment.NewLine & ex.StackTrace)
                ' MessageBox.Show(errormsg)

            Catch ex As Exception
                Throw New Exception(ex.Message & Environment.NewLine & ex.StackTrace)

            End Try

        End Sub

        ''' <summary>
        ''' Writes an element.
        ''' </summary>
        Shared Sub Write_Element(ByVal XmlWriter As Xml.XmlTextWriter, _
                                      ByVal StartElement As String, _
                                      ByVal Element As String, _
                                      Optional ByVal Indentation As Xml.Formatting = Xml.Formatting.Indented)

            Try
                XmlWriter.Formatting = Indentation
                XmlWriter.WriteStartElement(StartElement)
                XmlWriter.WriteString(Element)
                XmlWriter.WriteEndElement()
                XmlWriter.Formatting = Not Indentation

            Catch ex As System.Text.EncoderFallbackException
                Dim errormsg As String = "There is a character in the buffer that is a valid XML character but is not valid for the output encoding."
                Throw New Exception(errormsg & Environment.NewLine & ex.StackTrace)
                ' MessageBox.Show(errormsg)

            Catch ex As InvalidOperationException
                Dim errormsg As String = "The XmlTextWriter is closed or An XmlTextWriter method was called before a previous asynchronous operation finished."
                Throw New Exception(errormsg & Environment.NewLine & ex.StackTrace)
                ' MessageBox.Show(errormsg)

            Catch ex As Exception
                Throw New Exception(ex.Message & Environment.NewLine & ex.StackTrace)

            End Try

        End Sub

        ''' <summary>
        ''' Writes multiple elements.
        ''' </summary>
        Shared Sub Write_Elements(ByVal XmlWriter As Xml.XmlTextWriter, _
                                       ByVal Elements As String(,), _
                                       Optional ByVal Indentation As Xml.Formatting = Xml.Formatting.Indented)

            Try

                XmlWriter.Formatting = Indentation

                For x As Integer = 0 To Elements.GetUpperBound(0)
                    XmlWriter.WriteStartElement(Elements(x, 0))
                    XmlWriter.WriteString(Elements(x, 1))
                    XmlWriter.WriteEndElement()
                Next

                XmlWriter.Formatting = Not Indentation

            Catch ex As System.Text.EncoderFallbackException
                Dim errormsg As String = "There is a character in the buffer that is a valid XML character but is not valid for the output encoding."
                Throw New Exception(errormsg & Environment.NewLine & ex.StackTrace)
                ' MessageBox.Show(errormsg)

            Catch ex As InvalidOperationException
                Dim errormsg As String = "The XmlTextWriter is closed or An XmlTextWriter method was called before a previous asynchronous operation finished."
                Throw New Exception(errormsg & Environment.NewLine & ex.StackTrace)
                ' MessageBox.Show(errormsg)

            Catch ex As Exception
                Throw New Exception(ex.Message & Environment.NewLine & ex.StackTrace)

            End Try

        End Sub

        ''' <summary>
        ''' Writes the xml end of file.
        ''' </summary>
        Shared Sub Write_End(ByVal XmlWriter As Xml.XmlTextWriter)

            Try
                XmlWriter.WriteEndDocument()
                XmlWriter.Close()

            Catch ex As ArgumentException
                Dim errormsg As String = "The XML document is invalid."
                Throw New Exception(errormsg & Environment.NewLine & ex.StackTrace)
                ' MessageBox.Show(errormsg)

            Catch ex As Exception
                Throw New Exception(ex.Message & Environment.NewLine & ex.StackTrace)

            End Try

        End Sub

    End Class

#End Region

End Namespace
