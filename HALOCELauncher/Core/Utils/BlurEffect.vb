Imports System.Runtime.InteropServices

Namespace Core.Utils

    Public Class BlurEffect

        <DllImport("gdi32")> _
        Public Shared Function CreateEllipticRgn(ByVal X1 As Integer, ByVal Y1 As Integer, ByVal witdth As Integer, ByVal Height As Integer) As Integer
        End Function

        <DllImport("dwmapi.dll")> _
        Private Shared Sub DwmEnableBlurBehindWindow(ByVal hwnd As IntPtr, ByRef blurBehind As DWM_BLURBEHIND)
        End Sub

        Public Structure DwmBlurbehind
            Public DwFlags As Integer
            Public FEnable As Boolean
            Public HRgnBlur As IntPtr
            Public FTransitionOnMaximized As Boolean
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Structure DWM_BLURBEHIND
            Public dwFlags As DWM_BB
            Public fEnable As Boolean
            Public hRgnBlur As IntPtr
            Public fTransitionOnMaximized As Boolean
        End Structure

        Enum DWM_BB
            Enable = 1
            BlurRegion = 2
            TransitionMaximized = 4
        End Enum

        Private ControlA As Control = Nothing

        Public Sub New(ByVal ApliControl As Control)
            ControlA = ApliControl
            Dim HandleControl As IntPtr = ApliControl.Handle
            If Not HandleControl = IntPtr.Zero Then
                Dim hr = CreateEllipticRgn(0, 0, ApliControl.Width, ApliControl.Height)
                Dim dbb = New DWM_BLURBEHIND With {
                    .FEnable = True,
                    .DwFlags = 1,
                    .HRgnBlur = hr,
                    .FTransitionOnMaximized = False
                }

                DwmEnableBlurBehindWindow(ApliControl.Handle, dbb)
                ' AddHandler ApliControl.Paint, AddressOf Paint_Arg
            Else
                MsgBox("Handle Error = " & HandleControl.ToString)
            End If
        End Sub

        Private Sub Paint_Arg(ByVal sender As Object, ByVal args As System.Windows.Forms.PaintEventArgs)
            args.Graphics.FillRectangle(New SolidBrush(Color.Black), New Rectangle(0, 0, ControlA.Width, ControlA.Height))
        End Sub

    End Class

End Namespace

