Imports HALOCELauncher.Core.Helpers

Public Class AboutForm

    Private WelcomeMessage As String = "----------Delete"

    Public Shared ReadOnly _textToDisplay As String =
<a><![CDATA[ Create By EternalSoft
             HALO Launcher for CE and PC | Version 1.0.3
                
             Contact Info : 
                 Email: s4lsalsoft@gmail.com
                 Discord: Destroyer#8328
                 Facebook: www.facebook.com/salvador.osvaldo.1


             Tanks for Using!
]]></a>.Value

    Private _Showing As String = ""
    Private _avrchar As Integer = 0
    Private _AwaitTIme As Integer = 0
    Private _MaxAwaitTIme As Integer = 5
    Private ContinueAwait As Boolean = True

    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LabelTextLog.Text = WelcomeMessage
        Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
        Me.Location = CenterForm(Form1, Me, Me.Location)
        EnabledDragger(LabelTextLog)
        EnabledDragger(Me)
        EnabledDragger(GunaButton1)
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

   
End Class
