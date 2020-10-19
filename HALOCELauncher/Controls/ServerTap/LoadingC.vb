Public Class LoadingC

    Dim Retorn As Boolean = False
    Dim Xmove As Integer = 0
    Dim Pcolor As Integer = 0
    Dim ColorRetorn As Boolean = False

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If ColorRetorn = False Then
            Pcolor += 1
            Progress.BackColor = Color.FromArgb(Pcolor, Pcolor, Pcolor)
            If Pcolor = 255 Then
                ColorRetorn = True
            End If
        ElseIf ColorRetorn = True Then
            Pcolor -= 1
            Progress.BackColor = Color.FromArgb(Pcolor, Pcolor, Pcolor)
            If Pcolor = 0 Then
                ColorRetorn = False
            End If
        End If

        If Retorn = False Then
            Xmove += 1
            Progress.Location = New Point(Xmove, 0)
            If Xmove = 195 Then
                Retorn = True
            End If
        ElseIf Retorn = True Then
            Xmove -= 1
            Progress.Location = New Point(Xmove, 0)
            If Xmove = 0 Then
                Retorn = False
            End If
        End If
        
    End Sub

End Class
