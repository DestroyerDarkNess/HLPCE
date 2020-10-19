Imports System.Collections.Generic
Imports System.Text
Imports System.Net.Sockets

Namespace HaloQuery
    Public Class HaloServer
        Private socket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp) With {
            .ReceiveTimeout = 1000
        }
        Public ServerHost As String
        Public ServerPort As Integer

        Public Sub New(ByVal host As String, ByVal port As Integer)
            Me.ServerHost = host
            Me.ServerPort = port
        End Sub

        Public Function GetRawResponse() As String
             socket.Connect(Me.ServerHost, Me.ServerPort)
                Dim buffer As Byte() = Encoding.[Default].GetBytes("\status\")
                Dim received As Integer = 0
                socket.Send(buffer)
                buffer = New Byte(4095) {}
                received = socket.Receive(buffer)
                socket.Close()
                Return Encoding.[Default].GetString(buffer, 0, received)
       End Function

        Public Function GetDictionaryResponse(Optional ByVal rawResponse As String = Nothing) As Dictionary(Of String, String)
            If rawResponse Is Nothing Then rawResponse = Me.GetRawResponse()
            Dim dataPart As String() = rawResponse.Split("\"c)
            Dim parsedResponse As Dictionary(Of String, String) = New Dictionary(Of String, String)()

            For i As Integer = 1 To dataPart.Length - 1 Step 2
                parsedResponse.Add(dataPart(i), dataPart(i + 1))
            Next

            Return parsedResponse
        End Function

    End Class
End Namespace
