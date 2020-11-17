<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrashDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CrashDialog))
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.HaloLaunchCE = New Guna.UI.WinForms.GunaButton()
        Me.GunaElipsePanel1 = New Guna.UI.WinForms.GunaElipsePanel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.BoosterToolTip1 = New HALOCELauncher.BoosterToolTip()
        Me.GunaPanel1.SuspendLayout()
        Me.GunaElipsePanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel1.Location = New System.Drawing.Point(12, 9)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(131, 15)
        Me.GunaLabel1.TabIndex = 0
        Me.GunaLabel1.Text = "Fatal Exception or Error!"
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackgroundImage = CType(resources.GetObject("GunaPanel1.BackgroundImage"), System.Drawing.Image)
        Me.GunaPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GunaPanel1.Controls.Add(Me.GunaButton1)
        Me.GunaPanel1.Controls.Add(Me.HaloLaunchCE)
        Me.GunaPanel1.Controls.Add(Me.GunaElipsePanel1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(298, 149)
        Me.GunaPanel1.TabIndex = 1
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
        Me.GunaButton1.Location = New System.Drawing.Point(152, 94)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Size = New System.Drawing.Size(60, 24)
        Me.GunaButton1.TabIndex = 66
        Me.GunaButton1.Text = "No"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'HaloLaunchCE
        '
        Me.HaloLaunchCE.AnimationHoverSpeed = 0.07!
        Me.HaloLaunchCE.AnimationSpeed = 0.03!
        Me.HaloLaunchCE.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.HaloLaunchCE.BorderColor = System.Drawing.Color.Black
        Me.HaloLaunchCE.DialogResult = System.Windows.Forms.DialogResult.None
        Me.HaloLaunchCE.FocusedColor = System.Drawing.Color.Empty
        Me.HaloLaunchCE.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.HaloLaunchCE.ForeColor = System.Drawing.Color.White
        Me.HaloLaunchCE.Image = Nothing
        Me.HaloLaunchCE.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.HaloLaunchCE.ImageSize = New System.Drawing.Size(20, 20)
        Me.HaloLaunchCE.Location = New System.Drawing.Point(62, 94)
        Me.HaloLaunchCE.Name = "HaloLaunchCE"
        Me.HaloLaunchCE.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.HaloLaunchCE.OnHoverBorderColor = System.Drawing.Color.Black
        Me.HaloLaunchCE.OnHoverForeColor = System.Drawing.Color.White
        Me.HaloLaunchCE.OnHoverImage = Nothing
        Me.HaloLaunchCE.OnPressedColor = System.Drawing.Color.Black
        Me.HaloLaunchCE.Size = New System.Drawing.Size(60, 24)
        Me.HaloLaunchCE.TabIndex = 65
        Me.HaloLaunchCE.Text = "Yes"
        Me.HaloLaunchCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.BoosterToolTip1.SetToolTip(Me.HaloLaunchCE, "Reset the game, and if it was connected to any server. This will reconnect you to" & _
        " the Game.")
        '
        'GunaElipsePanel1
        '
        Me.GunaElipsePanel1.BackColor = System.Drawing.Color.Transparent
        Me.GunaElipsePanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GunaElipsePanel1.BaseColor = System.Drawing.Color.Transparent
        Me.GunaElipsePanel1.Controls.Add(Me.GunaLabel3)
        Me.GunaElipsePanel1.ForeColor = System.Drawing.Color.Transparent
        Me.GunaElipsePanel1.Location = New System.Drawing.Point(82, 62)
        Me.GunaElipsePanel1.Name = "GunaElipsePanel1"
        Me.GunaElipsePanel1.Size = New System.Drawing.Size(116, 26)
        Me.GunaElipsePanel1.TabIndex = 3
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.ForeColor = System.Drawing.Color.Red
        Me.GunaLabel3.Location = New System.Drawing.Point(3, 1)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(114, 25)
        Me.GunaLabel3.TabIndex = 2
        Me.GunaLabel3.Text = "Play Again?"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel2.ForeColor = System.Drawing.Color.Red
        Me.GunaLabel2.Location = New System.Drawing.Point(69, 35)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(143, 15)
        Me.GunaLabel2.TabIndex = 1
        Me.GunaLabel2.Text = "Gathering Exeption Data..."
        '
        'BoosterToolTip1
        '
        Me.BoosterToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.BoosterToolTip1.OwnerDraw = True
        '
        'CrashDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 149)
        Me.Controls.Add(Me.GunaPanel1)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CrashDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CrashDialog"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.GunaElipsePanel1.ResumeLayout(False)
        Me.GunaElipsePanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaElipsePanel1 As Guna.UI.WinForms.GunaElipsePanel
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents HaloLaunchCE As Guna.UI.WinForms.GunaButton
    Friend WithEvents BoosterToolTip1 As HALOCELauncher.BoosterToolTip
End Class
