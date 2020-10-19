Imports System.Drawing
Imports System.Windows.Forms

'********************************************************************************
'*                  Created by Predrag Gruevski (obi1kenobi)                    *
'*                      Originally published on VBForums                        *
'*                                02.01.2010                                    *
'*            Feel free to use this code for any use you see fit,               *
'*       just please do not alter this info box and credit me for the code.     *
'********************************************************************************

Public Class TransparentListView
    Inherits ListView

#Region " Consts "

    Const CLR_NONE As Integer = -1
    Const LVM_FIRST As Integer = &H1000
    Const LVM_GETBKCOLOR As Integer = LVM_FIRST + 0
    Const LVM_SETBKCOLOR As Integer = LVM_FIRST + 1
    Const WM_HSCROLL As Integer = &H114
    Const WM_VSCROLL As Integer = &H115
    Const SBM_SETSCROLLINFO As Integer = &HE9

#End Region

#Region " APIs "

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

#End Region

#Region " Variables "

    Private WithEvents tmr As New Timer
    Private stp As New Stopwatch
    Private _redrawOnMouseMove As Boolean
    Private _interval As Integer = 300
    Private _highlightColor As Color
    Private _errorColor As Color
    Private itemHeight As Integer

#End Region

#Region " Constructors "

    ''' <summary>
    ''' Creates a new TransparentListView object.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Me.OwnerDraw = True
        Me.DoubleBuffered = True
        Me.Font = New Font("Calibri", 11, FontStyle.Regular, GraphicsUnit.Point)
        tmr.Interval = _interval
    End Sub

#End Region

#Region " Properties "

    ''' <summary>
    ''' The color to use when a certain ListViewItem has unresolved issues.
    ''' </summary>
    Public Property ErrorTextColor() As Color
        Get
            Return _errorColor
        End Get
        Set(ByVal value As Color)
            _errorColor = value
        End Set
    End Property

    ''' <summary>
    ''' The color to use when highlighting an item.
    ''' </summary>
    Public Property HighlightColor() As Color
        Get
            Return _highlightColor
        End Get
        Set(ByVal value As Color)
            _highlightColor = value
        End Set
    End Property

    ''' <summary>
    ''' The intervals at which to redraw the control when scrolling. Higher values are reccomended for less powerful CPUs.
    ''' Decrease this value if experiencing choppy redraws during scrolling. Values below 5-6ms may result in extreme CPU use.
    ''' </summary>
    Public Property RedrawInterval() As Integer
        Get
            Return _interval
        End Get
        Set(ByVal value As Integer)
            If value <= 0 Then
                _interval = 15 '15ms should result in appx. 60 refreshes per second (60Hz) - only when required
                tmr.Interval = 15
            Else
                _interval = value
                tmr.Interval = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' True if the control should be redrawn when the mouse is moved, otherwise False.
    ''' </summary>
    ''' <remarks>There have been some issues with the Set method, so it's temporarily disabled and has no effect.</remarks>
    Public Property RedrawOnMouseMove() As Boolean
        Get
            Return _redrawOnMouseMove
        End Get
        Set(ByVal value As Boolean)
            '_redrawOnMouseMove = value
        End Set
    End Property

#End Region

#Region " Methods "

#Region " Overriden Methods "

    Protected Overrides Sub OnMouseWheel(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseWheel(e)
        OnListViewScrolled(EventArgs.Empty)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Me.Items.Count > 0 Then
            Dim clickedItem As ListViewItem = Me.GetItemAt(5, e.Y)
            If (clickedItem IsNot Nothing) Then
                clickedItem.Selected = True
                clickedItem.Focused = True
                'Else
                'Dim bnd As Integer = Me.Items.Count - 1
                'For i As Integer = 0 To bnd
                ' clickedItem = Me.Items(bnd)
                ' If clickedItem.Bounds.Contains(5, e.Y) Then
                ' clickedItem.Selected = True
                ' clickedItem.Focused = True
                ' Exit For
                'End If
                '    Next
            End If
        End If
        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        Me.Refresh()
        MyBase.OnResize(e)
    End Sub

    <DebuggerStepThrough()> _
    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawListViewItemEventArgs)

        If Not (e.State And ListViewItemStates.Selected) = 0 OrElse e.Item.Selected Then
            Using br As New Drawing.SolidBrush(_highlightColor)

                'Using br As New Drawing2D.LinearGradientBrush(e.Bounds, Color.FromArgb(200, Color.LightSkyBlue.R, Color.LightSkyBlue.B, Color.LightSkyBlue.G), Color.FromArgb(230, Color.Yellow.R, Color.Yellow.B, Color.Yellow.G), Drawing2D.LinearGradientMode.Vertical)
                ' Draw the background for a selected item.
                e.Graphics.FillRectangle(br, e.Bounds)
                'e.DrawFocusRectangle()   'Disabled focus rectangle since it was off-center
            End Using
            'Else
            ' Draw the background for an unselected item.
        End If

        'Dim sf As New StringFormat()
        'Dim index As Integer
        'Dim clr As Color
        '
        '       index = SmallImageList.Images.IndexOfKey(e.Item.ImageKey)
        '       e.Graphics.DrawImage(SmallImageList.Images.Item(index), New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, 16, 16))
        '       Using br As New SolidBrush(clr)
        ' e.Graphics.DrawString(e.Item.Text, Me.Font, br, New Rectangle(e.Bounds.X + SmallImageList.ImageSize.Width + 4, e.Bounds.Y, e.Bounds.Width - SmallImageList.ImageSize.Width - 4, e.Bounds.Height), sf)
        ' End Using

        'If Not DirectCast(e.Item.Tag, Users.FileData).FileExists Then
        'Using br2 As New Drawing.SolidBrush(Color.FromArgb(100, 255, 0, 0))
        ' e.Graphics.FillRectangle(br2, e.Bounds)
        ' End Using
        'End If

        ' Draw the item text for views other than the Details view.
        If Not Me.View = View.Details Then
            e.DrawText()
        End If
        MyBase.OnDrawItem(e)
    End Sub

    '<DebuggerStepThrough()> _
    Protected Overrides Sub OnDrawSubItem(ByVal e As System.Windows.Forms.DrawListViewSubItemEventArgs)
        'Dim flags As TextFormatFlags = TextFormatFlags.Left

        Dim sf As New StringFormat()
        Dim clr As Color
        Dim index As Integer

        Try

            sf.LineAlignment = StringAlignment.Far
            ' Store the column text alignment, letting it default
            ' to Left if it has not been set to Center or Right.
            Select Case e.Header.TextAlign
                Case HorizontalAlignment.Center
                    sf.Alignment = StringAlignment.Center
                Case HorizontalAlignment.Right
                    sf.Alignment = StringAlignment.Far
            End Select

            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            If e.Item.ForeColor <> _errorColor Then
                clr = Me.ForeColor
            Else
                clr = _errorColor
            End If

            'Dim lv As ListViewItem = e.Item
            'Dim tmp As String
            '
            '            For Each t As ListViewItem.ListViewSubItem In e.Item.SubItems
            ' tmp = t.Text
            ' Next

            Using br As New SolidBrush(clr)
                If e.Item.Text = e.SubItem.Text Then
                    If SmallImageList IsNot Nothing Then
                        index = SmallImageList.Images.IndexOfKey(e.Item.ImageKey)
                        If index <> -1 Then
                            e.Graphics.DrawImage(SmallImageList.Images.Item(index), New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, 16, 16))
                            e.Graphics.DrawString(e.Item.Text, Me.Font, br, New Rectangle(e.Bounds.X + SmallImageList.ImageSize.Width + 4, e.Bounds.Y, e.Bounds.Width - SmallImageList.ImageSize.Width - 4, e.Bounds.Height), sf)
                        Else
                            e.Graphics.DrawString(e.Item.Text, Me.Font, br, New Rectangle(e.Bounds.X + 4, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height), sf)
                        End If
                    Else
                        e.Graphics.DrawString(e.Item.Text, Me.Font, br, New Rectangle(e.Bounds.X + 4, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height), sf)
                    End If
                Else
                    'e.DrawText()
                    e.Graphics.DrawString(e.SubItem.Text, Me.Font, br, e.Bounds, sf)
                End If
            End Using

            'e.DrawText(flags)

        Finally
            sf.Dispose()
        End Try

        'MyBase.OnDrawSubItem(e)
    End Sub

    <DebuggerStepThrough()> _
    Protected Overrides Sub OnDrawColumnHeader(ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs)
        Dim sf As New StringFormat()
        Try

            ' Store the column text alignment, letting it default
            ' to Left if it has not been set to Center or Right.
            sf.LineAlignment = StringAlignment.Center
            Select Case e.Header.TextAlign
                Case HorizontalAlignment.Center
                    sf.Alignment = StringAlignment.Center
                Case HorizontalAlignment.Right
                    sf.Alignment = StringAlignment.Far
            End Select

            ' Draw the standard header background.
            e.DrawBackground()

            ' Draw the header text.
            Dim headerFont As New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            Try
                e.Graphics.DrawString(e.Header.Text, headerFont, _
                    Brushes.Black, e.Bounds, sf)
            Finally
                headerFont.Dispose()
            End Try

        Finally
            sf.Dispose()
        End Try

        'MyBase.OnDrawColumnHeader(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If _redrawOnMouseMove Then
            Dim item As ListViewItem = Me.GetItemAt(e.X, e.Y)
            If item IsNot Nothing Then 'AndAlso item.Tag Is Nothing Then
                Me.Invalidate(item.Bounds)
                'item.Tag = "tagged"
            End If
        End If
        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnInvalidated(ByVal e As System.Windows.Forms.InvalidateEventArgs)
        'Related to the use of Tag and RedrawOnMouseMove properties.

        'For Each item As ListViewItem In Me.Items
        'If item Is Nothing Then Return
        'item.Tag = Nothing
        'Next
        MyBase.OnInvalidated(e)
    End Sub

    Protected Overrides Sub OnColumnWidthChanged(ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs)
        Me.Invalidate()
        MyBase.OnColumnWidthChanged(e)
    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        MyBase.OnHandleCreated(e)
        SendMessage(Me.Handle.ToInt32, LVM_SETBKCOLOR, 0, CLR_NONE)
    End Sub

    <DebuggerStepThrough()> _
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_VSCROLL
                OnListViewScrolled(EventArgs.Empty)
            Case WM_HSCROLL
                OnListViewScrolled(EventArgs.Empty)
            Case SBM_SETSCROLLINFO
                OnListViewScrolled(EventArgs.Empty)
        End Select
        MyBase.WndProc(m)
    End Sub

#End Region

#Region " Custom Methods "

    Protected Overridable Sub OnListViewScrolled(ByVal e As EventArgs)
        If stp.IsRunning Then
            If stp.ElapsedMilliseconds > _interval Then
                stp = Stopwatch.StartNew
                Me.Invalidate()
            End If
        Else
            stp.Start()
        End If
        tmr.Stop()
        tmr.Start()
        RaiseEvent ListViewScrolled(Me, e)
    End Sub

#End Region

#End Region

#Region " Event Handlers "

    Private Sub tmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmr.Tick
        Me.Invalidate()
        tmr.Enabled = False
    End Sub

#End Region

#Region " Events "

    Public Event ListViewScrolled(ByVal sender As Object, ByVal e As EventArgs)

#End Region

End Class
