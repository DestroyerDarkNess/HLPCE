Imports System.IO

Namespace Core.CrashManager

    Public Class DxNotify

#Region " Structure "

        Public Structure GameSize
            Shared X As Integer = 5
            Shared Y As Integer = 5
            Shared InfoNumber As Integer = 0
        End Structure

        Public Structure LabelZoneText
            Shared Text As String = ""
            Shared X As Integer = 50
            Shared Y As Integer = 50
            Shared FontColor As Color = Color.Red
            Shared TextSize As Integer = 10
            Shared TextStyle As String = "Arial"
            Shared InfoNumber As Integer = -1
            Shared bBold As Boolean = False
        End Structure

#End Region

        Public Sub New(ByVal TextNoty As String)
            Dim ProcCE As String = My.Settings.GameDirCE
            Dim ProcPC As String = My.Settings.GameDirCE

            Dim Procxd As Process()

            Dim ContinueP As Boolean = False

            If Not ProcCE = "" Then
                Procxd = Process.GetProcessesByName(ProcCE)
                ContinueP = True
            End If

            If Not ContinueP = True Then
                If Not ProcPC = "" Then
                    Procxd = Process.GetProcessesByName(ProcPC)
                    ContinueP = True
                End If
            End If

            If Not Procxd.Count = 0 Then
                Dim GameResolutionScreen As New Point

                DX9OverlayAPI.DX9Overlay.SetParam("process", Procxd.FirstOrDefault.ProcessName & ".exe")


                LabelZoneText.InfoNumber = DX9OverlayAPI.DX9Overlay.TextCreate(LabelZoneText.TextStyle, LabelZoneText.TextSize, LabelZoneText.bBold, False, LabelZoneText.X, LabelZoneText.Y, colorFormat(LabelZoneText.FontColor), LabelZoneText.Text, False, True)
                LabelZoneText.Text = GetCorrectString(TextNoty)

                GameResolutionScreen = DX9OverlayAPI.DX9Overlay.GetScreenSpecsOverlay()

                GameSize.X = GameResolutionScreen.X
                GameSize.Y = GameResolutionScreen.Y

                LabelZoneText.X = Val((GameSize.X / 2) - (10))
                LabelZoneText.Y = Val(10) 'Val((GameSize.Y - 30)) 'GameSize.Y  '

                DX9OverlayAPI.DX9Overlay.TextSetString(LabelZoneText.InfoNumber, LabelZoneText.Text)
                DX9OverlayAPI.DX9Overlay.TextSetPos(LabelZoneText.InfoNumber, LabelZoneText.X, LabelZoneText.Y)

                For i As Integer = 0 To 100
                    DX9OverlayAPI.DX9Overlay.DestroyAllVisual()
                Next

            End If
          

        End Sub

        Private Function GetCorrectString(ByVal textinfo As String) As String
            Dim ResultText As String = String.Empty
           Dim Letters As String = String.Empty
            Dim Limit As Integer = 0

            For na = 0 To Len(textinfo) - 1
                If Letters = String.Empty Then
                    Letters = textinfo.Chars(na)
                Else
                    Letters = Letters & textinfo.Chars(na)
                End If
                If Len(Letters) = 30 Then
                    ResultText += Letters & vbNewLine
                    Letters = String.Empty
                End If
            Next na

            ResultText += Letters
            Letters = String.Empty

            Return ResultText
        End Function

        Private Function colorFormat(ByVal c As Color) As Integer
            Return c.ToArgb
        End Function

    End Class

End Namespace

