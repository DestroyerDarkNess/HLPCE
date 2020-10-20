<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.LabelTextLog = New Guna.UI.WinForms.GunaLabel()
        Me.GunaControlBox1 = New Guna.UI.WinForms.GunaControlBox()
        Me.GunaPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.Enabled = False
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = CType(resources.GetObject("GunaButton1.Image"), System.Drawing.Image)
        Me.GunaButton1.ImageSize = New System.Drawing.Size(30, 30)
        Me.GunaButton1.Location = New System.Drawing.Point(-2, 12)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Size = New System.Drawing.Size(245, 36)
        Me.GunaButton1.TabIndex = 0
        Me.GunaButton1.Text = "HALO CE/PC Launcher"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'GunaPanel1
        '
        Me.GunaPanel1.Controls.Add(Me.LabelTextLog)
        Me.GunaPanel1.Location = New System.Drawing.Point(19, 77)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(432, 175)
        Me.GunaPanel1.TabIndex = 1
        '
        'LabelTextLog
        '
        Me.LabelTextLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTextLog.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LabelTextLog.ForeColor = System.Drawing.Color.White
        Me.LabelTextLog.Location = New System.Drawing.Point(0, 0)
        Me.LabelTextLog.Name = "LabelTextLog"
        Me.LabelTextLog.Size = New System.Drawing.Size(432, 175)
        Me.LabelTextLog.TabIndex = 2
        Me.LabelTextLog.Text = "----------Delete"
        Me.LabelTextLog.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GunaControlBox1
        '
        Me.GunaControlBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaControlBox1.AnimationHoverSpeed = 0.07!
        Me.GunaControlBox1.AnimationSpeed = 0.03!
        Me.GunaControlBox1.BackColor = System.Drawing.Color.Transparent
        Me.GunaControlBox1.IconColor = System.Drawing.Color.White
        Me.GunaControlBox1.IconSize = 15.0!
        Me.GunaControlBox1.Location = New System.Drawing.Point(453, 0)
        Me.GunaControlBox1.Name = "GunaControlBox1"
        Me.GunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GunaControlBox1.OnHoverIconColor = System.Drawing.Color.White
        Me.GunaControlBox1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaControlBox1.Size = New System.Drawing.Size(31, 24)
        Me.GunaControlBox1.TabIndex = 5
        '
        'AboutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(483, 267)
        Me.Controls.Add(Me.GunaControlBox1)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Controls.Add(Me.GunaButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "AboutForm"
        Me.TopMost = True
        Me.GunaPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents LabelTextLog As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaControlBox1 As Guna.UI.WinForms.GunaControlBox
End Class
