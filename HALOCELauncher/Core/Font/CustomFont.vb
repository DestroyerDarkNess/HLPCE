#Region " Use Custom Text-Font "

' [ Use Custom Text-Font ]
'
' Instructions :
' 1. Add a .TTF font to the resources
' 2. Add the class
' 3. Use it
'
' Examples:
' Label1.Font = New Font(GameFont.Font, 10.0!)
' Label1.Text = "This is your custom font !!"

'Dim MyFont As New CustomFont(My.Resources.kakakaka)

'Private Sub Main_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
'   MyFont.Dispose()
'End Sub

' CustomFont.vb
#Region " CustomFont Class "

Imports System.Drawing
Imports System.Drawing.Text
Imports System.Runtime.InteropServices

''' <summary>
''' Represents a custom font not installed on the user's system.
''' </summary>
Public NotInheritable Class CustomFont
    Implements IDisposable

    Private fontCollection As New PrivateFontCollection()
    Private fontPtr As IntPtr

#Region "Constructor"
    ''' <summary>
    ''' Creates a new custom font using the specified font data.
    ''' </summary>
    ''' <param name="fontData">The font data representing the font.</param>
    Public Sub New(ByVal fontData() As Byte)
        'Create a pointer to the font data and copy the
        'font data into the location in memory pointed to
        fontPtr = Marshal.AllocHGlobal(fontData.Length)
        Marshal.Copy(fontData, 0, fontPtr, fontData.Length)

        'Add the font to the shared collection of fonts:
        fontCollection.AddMemoryFont(fontPtr, fontData.Length)
    End Sub
#End Region

#Region "Destructor"
    'Free the font in unmanaged memory, dispose of
    'the font collection and suppress finalization
    Public Sub Dispose() Implements IDisposable.Dispose
        Marshal.FreeHGlobal(fontPtr)
        fontCollection.Dispose()

        GC.SuppressFinalize(Me)
    End Sub

    'Free the font in unmanaged memory
    Protected Overrides Sub Finalize()
        Marshal.FreeHGlobal(fontPtr)
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' Gets the font family of the custom font.
    ''' </summary>
    Public ReadOnly Property Font() As FontFamily
        Get
            Return fontCollection.Families(0)
        End Get
    End Property
#End Region

End Class

#End Region

#End Region