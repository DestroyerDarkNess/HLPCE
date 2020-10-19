Imports System.Drawing.Imaging

Namespace Core.Utils

    Public Class GetBlurBitmap


        Private imagebitmap As Bitmap
        Private graphicsvariable As Graphics

        Public Sub New(ByVal Cblur As Control)
            Cblur.BackgroundImage = Nothing
            Dim b As Bitmap = GenerateBitmap(Cblur)
            BlurBitmap(b)
            Cblur.BackgroundImageLayout = ImageLayout.Stretch
            Cblur.BackgroundImage = b
            Cblur.Refresh()
            Cblur.Update()
        End Sub

#Region " Methods "

        Private Function GenerateBitmap(ByVal ControlA As Control) As Bitmap
            Dim width As Integer = ControlA.Size.Width
            Dim height As Integer = ControlA.Size.Height
            Dim bm As New Bitmap(width, height)
            ControlA.DrawToBitmap(bm, New Rectangle(0, 0, width, height))
            Return bm
        End Function

        Private Sub BlurBitmap(ByRef image As Bitmap, Optional ByVal BlurForce As Integer = 2)
            Dim g As Graphics = Graphics.FromImage(image)
            Dim att As New ImageAttributes
            Dim m As New ColorMatrix
            m.Matrix33 = 0.4
            att.SetColorMatrix(m)
            For x = -1 To BlurForce
                For y = -1 To BlurForce
                    g.DrawImage(image, New Rectangle(x, y, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, att)
                Next
            Next
            att.Dispose()
            g.Dispose()
        End Sub

#End Region

    End Class

End Namespace
