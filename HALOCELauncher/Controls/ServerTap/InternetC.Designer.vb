<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InternetC
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GunaVScrollBar1 = New Guna.UI.WinForms.GunaVScrollBar()
        Me.GunaPanel6 = New Guna.UI.WinForms.GunaPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelTextLog = New Guna.UI.WinForms.GunaLabel()
        Me.ListView1 = New HALOCELauncher.TransparentListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PanelContainer = New HALOCELauncher.PanelFX()
        Me.AnimaContextMenuStrip1 = New HALOCELauncher.AnimaContextMenuStrip()
        Me.RefreshSeverListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GunaPanel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.AnimaContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaVScrollBar1
        '
        Me.GunaVScrollBar1.LargeChange = 10
        Me.GunaVScrollBar1.Location = New System.Drawing.Point(584, 0)
        Me.GunaVScrollBar1.Maximum = 100
        Me.GunaVScrollBar1.Name = "GunaVScrollBar1"
        Me.GunaVScrollBar1.Radius = 0
        Me.GunaVScrollBar1.ScrollIdleColor = System.Drawing.Color.Transparent
        Me.GunaVScrollBar1.Size = New System.Drawing.Size(8, 330)
        Me.GunaVScrollBar1.TabIndex = 33
        Me.GunaVScrollBar1.ThumbColor = System.Drawing.Color.White
        Me.GunaVScrollBar1.ThumbHoverColor = System.Drawing.Color.Gray
        Me.GunaVScrollBar1.ThumbPressedColor = System.Drawing.Color.Gray
        '
        'GunaPanel6
        '
        Me.GunaPanel6.Controls.Add(Me.Panel1)
        Me.GunaPanel6.Controls.Add(Me.GunaVScrollBar1)
        Me.GunaPanel6.Controls.Add(Me.PanelContainer)
        Me.GunaPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaPanel6.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel6.Name = "GunaPanel6"
        Me.GunaPanel6.Size = New System.Drawing.Size(785, 330)
        Me.GunaPanel6.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LabelTextLog)
        Me.Panel1.Controls.Add(Me.ListView1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(594, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(191, 330)
        Me.Panel1.TabIndex = 35
        '
        'LabelTextLog
        '
        Me.LabelTextLog.BackColor = System.Drawing.Color.Transparent
        Me.LabelTextLog.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LabelTextLog.ForeColor = System.Drawing.Color.White
        Me.LabelTextLog.Location = New System.Drawing.Point(-3, 117)
        Me.LabelTextLog.Name = "LabelTextLog"
        Me.LabelTextLog.Size = New System.Drawing.Size(191, 213)
        Me.LabelTextLog.TabIndex = 12
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView1.ErrorTextColor = System.Drawing.Color.White
        Me.ListView1.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.ListView1.ForeColor = System.Drawing.Color.White
        Me.ListView1.HighlightColor = System.Drawing.Color.Empty
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.OwnerDraw = True
        Me.ListView1.RedrawInterval = 300
        Me.ListView1.RedrawOnMouseMove = False
        Me.ListView1.Size = New System.Drawing.Size(188, 114)
        Me.ListView1.TabIndex = 11
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Player"
        Me.ColumnHeader1.Width = 115
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Score"
        Me.ColumnHeader2.Width = 53
        '
        'PanelContainer
        '
        Me.PanelContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelContainer.BackColor = System.Drawing.Color.Transparent
        Me.PanelContainer.ContextMenuStrip = Me.AnimaContextMenuStrip1
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(607, 330)
        Me.PanelContainer.TabIndex = 34
        '
        'AnimaContextMenuStrip1
        '
        Me.AnimaContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.AnimaContextMenuStrip1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.AnimaContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshSeverListToolStripMenuItem})
        Me.AnimaContextMenuStrip1.Name = "AnimaContextMenuStrip1"
        Me.AnimaContextMenuStrip1.Size = New System.Drawing.Size(166, 26)
        '
        'RefreshSeverListToolStripMenuItem
        '
        Me.RefreshSeverListToolStripMenuItem.Name = "RefreshSeverListToolStripMenuItem"
        Me.RefreshSeverListToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.RefreshSeverListToolStripMenuItem.Text = "Refresh Sever List"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'InternetC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Gray
        Me.Controls.Add(Me.GunaPanel6)
        Me.Name = "InternetC"
        Me.Size = New System.Drawing.Size(785, 330)
        Me.GunaPanel6.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.AnimaContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GunaVScrollBar1 As Guna.UI.WinForms.GunaVScrollBar
    Friend WithEvents PanelContainer As HALOCELauncher.PanelFX
    Friend WithEvents GunaPanel6 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As HALOCELauncher.TransparentListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LabelTextLog As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents AnimaContextMenuStrip1 As HALOCELauncher.AnimaContextMenuStrip
    Friend WithEvents RefreshSeverListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
