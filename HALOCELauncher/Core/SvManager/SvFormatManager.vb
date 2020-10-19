Imports HALOCELauncher.Core.Utils
Imports HALOCELauncher.Core.GameTracker

Namespace Core.SvManager

    Public Class SvFormatManager

        Private Shared xmlfile As String = "HALOSV_List.xml"

        Public Shared UpdateAe As Boolean = False

        Public Shared Server_Config As String = <a><![CDATA[<?xml version="1.0" encoding="Windows-1252"?>
  <!--HALO Launcher Server Database-->
    <ServerDatabase>
       %Heart%
    </ServerDatabase>]]></a>.Value

        Public Shared Server_Estructure As String =
            <a><![CDATA[<server%Number%>
                        <Name>%sv_name%</Name>
                        <IpAddr>%sv_ip%</IpAddr>
                        <Players>%sv_player%</Players>
                        <Map>%sv_map%</Map>
                        </server%Number%>]]></a>.Value

        Public Shared Property xml_svlist As String
            Get
                Return xmlfile
            End Get
            Set(value As String)
                xmlfile = value
            End Set
        End Property

        Public Shared Function ExistsXmlServer() As Boolean
            Return IO.File.Exists(xmlfile)
        End Function

        Public Shared Function ReadXmlServers() As List(Of ServerType)
            Dim localsv As New List(Of ServerType)

            Dim xmlData As XDocument = XDocument.Parse(IO.File.ReadAllText(xmlfile))

            For Each signature As XElement In xmlData.Root.Elements
                Dim Lmsv As New ServerType
                Dim Hostname As String = signature.<Name>.Value
                Dim IpAddr As String = signature.<IpAddr>.Value
                Dim Players As String = signature.<Players>.Value
                Dim Mapsv As String = signature.<Map>.Value
                Lmsv.Name = Hostname
                Lmsv.IPAdress = IpAddr
                Lmsv.Players = Players
                Lmsv.Map = Mapsv

                localsv.Add(Lmsv)
            Next

            Return localsv

        End Function

        Public Shared Function UpdateFromExternal(ByVal ExternalFile As String)
            Try

                Dim ReadExternalServers As New List(Of ServerType)

                Dim xmlData As XDocument = XDocument.Parse(IO.File.ReadAllText(ExternalFile))

                For Each signature As XElement In xmlData.Root.Elements
                    Dim Lmsv As New ServerType
                    Dim Hostname As String = signature.<Name>.Value
                    Dim IpAddr As String = signature.<IpAddr>.Value
                    Dim Players As String = signature.<Players>.Value
                    Dim Mapsv As String = signature.<Map>.Value
                    Lmsv.Name = Hostname
                    Lmsv.IPAdress = IpAddr
                    Lmsv.Players = Players
                    Lmsv.Map = Mapsv

                    ReadExternalServers.Add(Lmsv)
                Next

                Dim localsv As New List(Of ServerType)

                If ExistsXmlServer() = True Then
                    localsv.AddRange(ReadXmlServers)
                End If

                localsv.AddRange(ReadExternalServers)
               
                localsv.Distinct()

                Dim ResultHeart As String = Server_Config
                Dim FinalEstructure As String = String.Empty

                Dim sv_Counter As Integer = 0

                For Each Sv_Temp As ServerType In localsv

                    Dim Estructuresv As String = Server_Estructure
                    Estructuresv = Replace(Estructuresv, "%Number%", sv_Counter)
                    Estructuresv = Replace(Estructuresv, "%sv_name%", Sv_Temp.Name)
                    Estructuresv = Replace(Estructuresv, "%sv_ip%", Sv_Temp.IPAdress)
                    Estructuresv = Replace(Estructuresv, "%sv_player%", Sv_Temp.Players)
                    Estructuresv = Replace(Estructuresv, "%sv_map%", Sv_Temp.Map)
                    FinalEstructure += Estructuresv & vbNewLine
                    sv_Counter += 1
                Next

                ResultHeart = Replace(ResultHeart, "%Heart%", FinalEstructure)

                If IO.File.Exists(xmlfile) Then
                    IO.File.Delete(xmlfile)
                End If

                IO.File.WriteAllText(xmlfile, ResultHeart)

           
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function


     

        Public Shared Function WritteXmlServers(ByVal Sv_TempEx As List(Of ServerType)) As Boolean
            Try

            Dim localsv As New List(Of ServerType)

            If ExistsXmlServer() = True Then
                localsv.AddRange(ReadXmlServers)
            End If

                localsv.AddRange(Sv_TempEx)

                Dim ResultHeart As String = Server_Config
                Dim FinalEstructure As String = String.Empty

                Dim sv_Counter As Integer = 0

                For Each Sv_Temp As ServerType In localsv

                    Dim Estructuresv As String = Server_Estructure
                    Estructuresv = Replace(Estructuresv, "%Number%", sv_Counter)
                    Estructuresv = Replace(Estructuresv, "%sv_name%", Sv_Temp.Name)
                    Estructuresv = Replace(Estructuresv, "%sv_ip%", Sv_Temp.IPAdress)
                    Estructuresv = Replace(Estructuresv, "%sv_player%", Sv_Temp.Players)
                    Estructuresv = Replace(Estructuresv, "%sv_map%", Sv_Temp.Map)
                    FinalEstructure += Estructuresv & vbNewLine
                    sv_Counter += 1
                Next

                ResultHeart = Replace(ResultHeart, "%Heart%", FinalEstructure)

                If IO.File.Exists(xmlfile) Then
                    IO.File.Delete(xmlfile)
                End If

                IO.File.WriteAllText(xmlfile, ResultHeart)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function DeleteServerFromXML(ByVal Sv_TempEx As ServerType) As Boolean
            Try

                Dim FilterProc As New List(Of ServerType)

                Dim localsv As New List(Of ServerType)

                If ExistsXmlServer() = True Then
                    localsv.AddRange(ReadXmlServers)
                End If

                
                For Each Sv_Filter As ServerType In localsv

                    If Not Sv_Filter.IPAdress = Sv_TempEx.IPAdress Then

                        FilterProc.Add(Sv_Filter)

                    End If

                Next

             

                Dim ResultHeart As String = Server_Config
                Dim FinalEstructure As String = String.Empty

                Dim sv_Counter As Integer = 0

                For Each Sv_Temp As ServerType In FilterProc

                    Dim Estructuresv As String = Server_Estructure
                    Estructuresv = Replace(Estructuresv, "%Number%", sv_Counter)
                    Estructuresv = Replace(Estructuresv, "%sv_name%", Sv_Temp.Name)
                    Estructuresv = Replace(Estructuresv, "%sv_ip%", Sv_Temp.IPAdress)
                    Estructuresv = Replace(Estructuresv, "%sv_player%", Sv_Temp.Players)
                    Estructuresv = Replace(Estructuresv, "%sv_map%", Sv_Temp.Map)
                    FinalEstructure += Estructuresv & vbNewLine
                    sv_Counter += 1
                Next

                ResultHeart = Replace(ResultHeart, "%Heart%", FinalEstructure)

                If IO.File.Exists(xmlfile) Then
                    IO.File.Delete(xmlfile)
                End If

                IO.File.WriteAllText(xmlfile, ResultHeart)
               
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function CheckDuplicateServerFromXML(ByVal Sv_TempEx As ServerType) As Boolean
            Try

                 Dim localsv As New List(Of ServerType)

                If ExistsXmlServer() = True Then
                    localsv.AddRange(ReadXmlServers)
                End If

                For Each Sv_Filter As ServerType In localsv

                    If Sv_Filter.IPAdress = Sv_TempEx.IPAdress Then

                        Return True

                    End If

                Next

                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function


    End Class

End Namespace

