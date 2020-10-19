Imports System.IO
Imports System.Security.Principal


Namespace Core

    Public Class Helpers

        Public Shared ReadOnly Property IsAdministrator As Boolean
            Get
                Return New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)
            End Get
        End Property

        Public Shared Sub RUNAdmin(ByVal Appdir As String)
             Dim startInfo = New ProcessStartInfo(Appdir)
            startInfo.RedirectStandardOutput = True
            startInfo.RedirectStandardError = True
            startInfo.UseShellExecute = False
            startInfo.Verb = "runas"
            Process.Start(startInfo)
            End
        End Sub

        Public Shared Sub EnabledDragger(ByVal ControlEx As Control)
            Dim NewDragControl As New Guna.UI.WinForms.GunaDragControl
            NewDragControl.TargetControl = ControlEx
        End Sub

        Public Shared Function SecondtoMilli(ByVal second As Integer) As Integer
            Return (second * 1000)
        End Function

        Public Shared Function GetRandomNum(Optional ByVal minimum As Integer = 0, Optional ByVal Maximum As Integer = 0) As Integer
            Dim random As New Random()
            If Maximum = 0 Then
                Return random.Next()
            Else
                Return random.Next(minimum, Maximum)
            End If
        End Function

        Public Shared Function CompareImages(ByVal img1 As Bitmap, ByVal img2 As Bitmap) As Boolean
            Dim i As Integer
            Dim j As Integer

            For i = 0 To img1.Width - 1
                For j = 0 To img2.Height - 1
                    If img1.GetPixel(i, j) <> img2.GetPixel(i, j) Then
                        Return False
                    End If
                Next
            Next
            Return True
        End Function

        Public Shared Function open(Optional Custom_Filter As String = "Executables (*.exe)|*.exe") As String
            Using openFileDialog As OpenFileDialog = New OpenFileDialog()
                Dim openFileDialog2 As OpenFileDialog = openFileDialog
                openFileDialog2.AddExtension = True
                openFileDialog2.AutoUpgradeEnabled = True
                openFileDialog2.CheckPathExists = True
                openFileDialog2.Title = "Selec File"
                openFileDialog2.Filter = Custom_Filter
                openFileDialog2.FileName = ""
                openFileDialog2.RestoreDirectory = True
                If openFileDialog.ShowDialog() = DialogResult.OK Then
                    Return openFileDialog.FileName
                End If
            End Using
            Return "Error"
        End Function

        Public Shared Function save(Optional Custom_Filename As String = " ", Optional Custom_Filter As String = "Executables (*.exe)|*.exe") As String
            Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
                Dim saveFileDialog2 As SaveFileDialog = saveFileDialog
                saveFileDialog2.AddExtension = True
                saveFileDialog2.AutoUpgradeEnabled = True
                saveFileDialog2.CheckPathExists = True
                saveFileDialog2.FileName = Custom_Filename
                saveFileDialog2.Filter = Custom_Filter
                saveFileDialog2.FilterIndex = 2
                saveFileDialog2.RestoreDirectory = True
                saveFileDialog2.Title = "Select a file destination to save"
                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    Return saveFileDialog.FileName
                End If
            End Using
            Return "Error"
        End Function

#Region " Base64 Functions "

        Public Shared Function ConvertImageToBase64String(ByVal ImageL As Image) As String
            Using ms As New MemoryStream()
                ImageL.Save(ms, System.Drawing.Imaging.ImageFormat.Png) 'We load the image from first PictureBox in the MemoryStream
                Dim obyte = ms.ToArray() 'We tranform it to byte array..

                Return Convert.ToBase64String(obyte) 'We then convert the byte array to base 64 string.
            End Using
        End Function

        Public Shared Function ConvertBase64ToByteArray(base64 As String) As Byte()
            Return Convert.FromBase64String(base64) 'Convert the base64 back to byte array.
        End Function

        'Here's the part of your code (which works)
        Public Shared Function convertbytetoimage(ByVal BA As Byte())
            Dim ms As MemoryStream = New MemoryStream(BA)
            Dim image = System.Drawing.Image.FromStream(ms)
            Return image
        End Function

#End Region

#Region " CenterForm function "

        Public Shared Function CenterForm(ByVal ParentForm As Form, ByVal Form_to_Center As Form, ByVal Form_Location As Point) As Point
            Dim FormLocation As New Point
            FormLocation.X = (ParentForm.Left + (ParentForm.Width - Form_to_Center.Width) / 2) ' set the X coordinates.
            FormLocation.Y = (ParentForm.Top + (ParentForm.Height - Form_to_Center.Height) / 2) ' set the Y coordinates.
            Return FormLocation ' return the Location to the Form it was called from.
        End Function

#End Region

    End Class

End Namespace

