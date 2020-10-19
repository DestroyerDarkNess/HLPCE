<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddCustomServer
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
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton2 = New Guna.UI.WinForms.GunaButton()
        Me.NameTextbox = New Guna.UI.WinForms.GunaTextBox()
        Me.SuspendLayout()
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.ForeColor = System.Drawing.Color.White
        Me.GunaLabel1.Location = New System.Drawing.Point(12, 19)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(210, 14)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "Enter New Server HOST:PORT..."
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(76, 102)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Size = New System.Drawing.Size(60, 24)
        Me.GunaButton1.TabIndex = 2
        Me.GunaButton1.Text = "OK"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButton2
        '
        Me.GunaButton2.AnimationHoverSpeed = 0.07!
        Me.GunaButton2.AnimationSpeed = 0.03!
        Me.GunaButton2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton2.BorderColor = System.Drawing.Color.Black
        Me.GunaButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton2.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaButton2.ForeColor = System.Drawing.Color.White
        Me.GunaButton2.Image = Nothing
        Me.GunaButton2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton2.Location = New System.Drawing.Point(162, 102)
        Me.GunaButton2.Name = "GunaButton2"
        Me.GunaButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton2.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton2.OnHoverImage = Nothing
        Me.GunaButton2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton2.Size = New System.Drawing.Size(60, 24)
        Me.GunaButton2.TabIndex = 3
        Me.GunaButton2.Text = "Cancel"
        Me.GunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NameTextbox
        '
        Me.NameTextbox.BaseColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.NameTextbox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.NameTextbox.BorderSize = 1
        Me.NameTextbox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NameTextbox.FocusedBaseColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.NameTextbox.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.NameTextbox.FocusedForeColor = System.Drawing.Color.White
        Me.NameTextbox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NameTextbox.ForeColor = System.Drawing.Color.White
        Me.NameTextbox.Location = New System.Drawing.Point(39, 49)
        Me.NameTextbox.MaxLength = 30
        Me.NameTextbox.Name = "NameTextbox"
        Me.NameTextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.NameTextbox.Size = New System.Drawing.Size(238, 26)
        Me.NameTextbox.TabIndex = 45
        Me.NameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AddCustomServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(319, 138)
        Me.Controls.Add(Me.NameTextbox)
        Me.Controls.Add(Me.GunaButton2)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaLabel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddCustomServer"
        Me.Opacity = 0.9R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Add Server"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton2 As Guna.UI.WinForms.GunaButton
    Friend WithEvents NameTextbox As Guna.UI.WinForms.GunaTextBox
End Class
