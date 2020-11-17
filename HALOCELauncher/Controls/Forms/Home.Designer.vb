<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.Anuncio4 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaPanel8 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.HaloLaunchPC = New Guna.UI.WinForms.GunaButton()
        Me.GunaPanel9 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.HaloLaunchCE = New Guna.UI.WinForms.GunaButton()
        Me.Anuncio3 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaPanel3 = New Guna.UI.WinForms.GunaPanel()
        Me.Anuncio3Des = New Guna.UI.WinForms.GunaLabel()
        Me.Anuncio3Title = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel4 = New Guna.UI.WinForms.GunaPanel()
        Me.Anuncio3Icon = New Guna.UI.WinForms.GunaPanel()
        Me.Anuncio2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.Anuncio2Des = New Guna.UI.WinForms.GunaLabel()
        Me.Anuncio2Title = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel5 = New Guna.UI.WinForms.GunaPanel()
        Me.Anuncio2Icon = New Guna.UI.WinForms.GunaPanel()
        Me.Anuncio1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaPanel6 = New Guna.UI.WinForms.GunaPanel()
        Me.Anuncio1Des = New Guna.UI.WinForms.GunaLabel()
        Me.Anuncio1Title = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel7 = New Guna.UI.WinForms.GunaPanel()
        Me.Anuncio1Icon = New Guna.UI.WinForms.GunaPanel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GunaPanel1.SuspendLayout()
        Me.Anuncio4.SuspendLayout()
        Me.GunaPanel8.SuspendLayout()
        Me.GunaPanel9.SuspendLayout()
        Me.Anuncio3.SuspendLayout()
        Me.GunaPanel3.SuspendLayout()
        Me.Anuncio2.SuspendLayout()
        Me.GunaPanel2.SuspendLayout()
        Me.Anuncio1.SuspendLayout()
        Me.GunaPanel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GunaPanel1.Controls.Add(Me.Anuncio4)
        Me.GunaPanel1.Controls.Add(Me.Anuncio3)
        Me.GunaPanel1.Controls.Add(Me.Anuncio2)
        Me.GunaPanel1.Controls.Add(Me.Anuncio1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(818, 438)
        Me.GunaPanel1.TabIndex = 2
        '
        'Anuncio4
        '
        Me.Anuncio4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Anuncio4.Controls.Add(Me.GunaPanel8)
        Me.Anuncio4.Controls.Add(Me.GunaPanel9)
        Me.Anuncio4.Location = New System.Drawing.Point(611, 26)
        Me.Anuncio4.Name = "Anuncio4"
        Me.Anuncio4.Size = New System.Drawing.Size(185, 400)
        Me.Anuncio4.TabIndex = 3
        '
        'GunaPanel8
        '
        Me.GunaPanel8.BackgroundImage = CType(resources.GetObject("GunaPanel8.BackgroundImage"), System.Drawing.Image)
        Me.GunaPanel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GunaPanel8.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel8.Controls.Add(Me.HaloLaunchPC)
        Me.GunaPanel8.Location = New System.Drawing.Point(26, 204)
        Me.GunaPanel8.Name = "GunaPanel8"
        Me.GunaPanel8.Size = New System.Drawing.Size(138, 186)
        Me.GunaPanel8.TabIndex = 0
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.BackColor = System.Drawing.Color.ForestGreen
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel1.ForeColor = System.Drawing.Color.White
        Me.GunaLabel1.Location = New System.Drawing.Point(0, 5)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(57, 15)
        Me.GunaLabel1.TabIndex = 66
        Me.GunaLabel1.Text = "HALO PC"
        '
        'HaloLaunchPC
        '
        Me.HaloLaunchPC.AnimationHoverSpeed = 0.07!
        Me.HaloLaunchPC.AnimationSpeed = 0.03!
        Me.HaloLaunchPC.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.HaloLaunchPC.BorderColor = System.Drawing.Color.Black
        Me.HaloLaunchPC.DialogResult = System.Windows.Forms.DialogResult.None
        Me.HaloLaunchPC.FocusedColor = System.Drawing.Color.Empty
        Me.HaloLaunchPC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.HaloLaunchPC.ForeColor = System.Drawing.Color.White
        Me.HaloLaunchPC.Image = Nothing
        Me.HaloLaunchPC.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.HaloLaunchPC.ImageSize = New System.Drawing.Size(20, 20)
        Me.HaloLaunchPC.Location = New System.Drawing.Point(41, 159)
        Me.HaloLaunchPC.Name = "HaloLaunchPC"
        Me.HaloLaunchPC.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.HaloLaunchPC.OnHoverBorderColor = System.Drawing.Color.Black
        Me.HaloLaunchPC.OnHoverForeColor = System.Drawing.Color.White
        Me.HaloLaunchPC.OnHoverImage = Nothing
        Me.HaloLaunchPC.OnPressedColor = System.Drawing.Color.Black
        Me.HaloLaunchPC.Size = New System.Drawing.Size(60, 24)
        Me.HaloLaunchPC.TabIndex = 65
        Me.HaloLaunchPC.Text = "Launch"
        Me.HaloLaunchPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaPanel9
        '
        Me.GunaPanel9.BackgroundImage = CType(resources.GetObject("GunaPanel9.BackgroundImage"), System.Drawing.Image)
        Me.GunaPanel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GunaPanel9.Controls.Add(Me.GunaLabel2)
        Me.GunaPanel9.Controls.Add(Me.HaloLaunchCE)
        Me.GunaPanel9.Location = New System.Drawing.Point(26, 12)
        Me.GunaPanel9.Name = "GunaPanel9"
        Me.GunaPanel9.Size = New System.Drawing.Size(138, 186)
        Me.GunaPanel9.TabIndex = 1
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.BackColor = System.Drawing.Color.ForestGreen
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel2.ForeColor = System.Drawing.Color.White
        Me.GunaLabel2.Location = New System.Drawing.Point(0, 5)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(56, 15)
        Me.GunaLabel2.TabIndex = 67
        Me.GunaLabel2.Text = "HALO CE"
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
        Me.HaloLaunchCE.Location = New System.Drawing.Point(41, 159)
        Me.HaloLaunchCE.Name = "HaloLaunchCE"
        Me.HaloLaunchCE.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.HaloLaunchCE.OnHoverBorderColor = System.Drawing.Color.Black
        Me.HaloLaunchCE.OnHoverForeColor = System.Drawing.Color.White
        Me.HaloLaunchCE.OnHoverImage = Nothing
        Me.HaloLaunchCE.OnPressedColor = System.Drawing.Color.Black
        Me.HaloLaunchCE.Size = New System.Drawing.Size(60, 24)
        Me.HaloLaunchCE.TabIndex = 64
        Me.HaloLaunchCE.Text = "Launch"
        Me.HaloLaunchCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Anuncio3
        '
        Me.Anuncio3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Anuncio3.Controls.Add(Me.GunaPanel3)
        Me.Anuncio3.Controls.Add(Me.Anuncio3Icon)
        Me.Anuncio3.Location = New System.Drawing.Point(307, 278)
        Me.Anuncio3.Name = "Anuncio3"
        Me.Anuncio3.Size = New System.Drawing.Size(279, 148)
        Me.Anuncio3.TabIndex = 2
        '
        'GunaPanel3
        '
        Me.GunaPanel3.Controls.Add(Me.Anuncio3Des)
        Me.GunaPanel3.Controls.Add(Me.Anuncio3Title)
        Me.GunaPanel3.Controls.Add(Me.GunaPanel4)
        Me.GunaPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GunaPanel3.Location = New System.Drawing.Point(0, 113)
        Me.GunaPanel3.Name = "GunaPanel3"
        Me.GunaPanel3.Size = New System.Drawing.Size(279, 35)
        Me.GunaPanel3.TabIndex = 1
        '
        'Anuncio3Des
        '
        Me.Anuncio3Des.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Anuncio3Des.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Anuncio3Des.ForeColor = System.Drawing.Color.White
        Me.Anuncio3Des.Location = New System.Drawing.Point(15, 20)
        Me.Anuncio3Des.Name = "Anuncio3Des"
        Me.Anuncio3Des.Size = New System.Drawing.Size(231, 125)
        Me.Anuncio3Des.TabIndex = 7
        Me.Anuncio3Des.Text = "Des"
        Me.Anuncio3Des.Visible = False
        '
        'Anuncio3Title
        '
        Me.Anuncio3Title.AutoSize = True
        Me.Anuncio3Title.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Anuncio3Title.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Anuncio3Title.ForeColor = System.Drawing.Color.White
        Me.Anuncio3Title.Location = New System.Drawing.Point(14, 4)
        Me.Anuncio3Title.Name = "Anuncio3Title"
        Me.Anuncio3Title.Size = New System.Drawing.Size(28, 13)
        Me.Anuncio3Title.TabIndex = 6
        Me.Anuncio3Title.Text = "Title"
        Me.Anuncio3Title.Visible = False
        '
        'GunaPanel4
        '
        Me.GunaPanel4.Location = New System.Drawing.Point(3, 4)
        Me.GunaPanel4.Name = "GunaPanel4"
        Me.GunaPanel4.Size = New System.Drawing.Size(5, 28)
        Me.GunaPanel4.TabIndex = 0
        '
        'Anuncio3Icon
        '
        Me.Anuncio3Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Anuncio3Icon.Location = New System.Drawing.Point(3, 3)
        Me.Anuncio3Icon.Name = "Anuncio3Icon"
        Me.Anuncio3Icon.Size = New System.Drawing.Size(20, 20)
        Me.Anuncio3Icon.TabIndex = 2
        Me.Anuncio3Icon.Visible = False
        '
        'Anuncio2
        '
        Me.Anuncio2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Anuncio2.Controls.Add(Me.GunaPanel2)
        Me.Anuncio2.Controls.Add(Me.Anuncio2Icon)
        Me.Anuncio2.Location = New System.Drawing.Point(21, 278)
        Me.Anuncio2.Name = "Anuncio2"
        Me.Anuncio2.Size = New System.Drawing.Size(259, 148)
        Me.Anuncio2.TabIndex = 1
        '
        'GunaPanel2
        '
        Me.GunaPanel2.Controls.Add(Me.Anuncio2Des)
        Me.GunaPanel2.Controls.Add(Me.Anuncio2Title)
        Me.GunaPanel2.Controls.Add(Me.GunaPanel5)
        Me.GunaPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 113)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(259, 35)
        Me.GunaPanel2.TabIndex = 0
        '
        'Anuncio2Des
        '
        Me.Anuncio2Des.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Anuncio2Des.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Anuncio2Des.ForeColor = System.Drawing.Color.White
        Me.Anuncio2Des.Location = New System.Drawing.Point(15, 20)
        Me.Anuncio2Des.Name = "Anuncio2Des"
        Me.Anuncio2Des.Size = New System.Drawing.Size(231, 125)
        Me.Anuncio2Des.TabIndex = 5
        Me.Anuncio2Des.Text = "Des"
        Me.Anuncio2Des.Visible = False
        '
        'Anuncio2Title
        '
        Me.Anuncio2Title.AutoSize = True
        Me.Anuncio2Title.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Anuncio2Title.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Anuncio2Title.ForeColor = System.Drawing.Color.White
        Me.Anuncio2Title.Location = New System.Drawing.Point(14, 4)
        Me.Anuncio2Title.Name = "Anuncio2Title"
        Me.Anuncio2Title.Size = New System.Drawing.Size(28, 13)
        Me.Anuncio2Title.TabIndex = 4
        Me.Anuncio2Title.Text = "Title"
        Me.Anuncio2Title.Visible = False
        '
        'GunaPanel5
        '
        Me.GunaPanel5.Location = New System.Drawing.Point(3, 4)
        Me.GunaPanel5.Name = "GunaPanel5"
        Me.GunaPanel5.Size = New System.Drawing.Size(5, 28)
        Me.GunaPanel5.TabIndex = 1
        '
        'Anuncio2Icon
        '
        Me.Anuncio2Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Anuncio2Icon.Location = New System.Drawing.Point(3, 3)
        Me.Anuncio2Icon.Name = "Anuncio2Icon"
        Me.Anuncio2Icon.Size = New System.Drawing.Size(20, 20)
        Me.Anuncio2Icon.TabIndex = 3
        Me.Anuncio2Icon.Visible = False
        '
        'Anuncio1
        '
        Me.Anuncio1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Anuncio1.Controls.Add(Me.GunaPanel6)
        Me.Anuncio1.Controls.Add(Me.Anuncio1Icon)
        Me.Anuncio1.Location = New System.Drawing.Point(21, 26)
        Me.Anuncio1.Name = "Anuncio1"
        Me.Anuncio1.Size = New System.Drawing.Size(565, 231)
        Me.Anuncio1.TabIndex = 0
        '
        'GunaPanel6
        '
        Me.GunaPanel6.Controls.Add(Me.Anuncio1Des)
        Me.GunaPanel6.Controls.Add(Me.Anuncio1Title)
        Me.GunaPanel6.Controls.Add(Me.GunaPanel7)
        Me.GunaPanel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GunaPanel6.Location = New System.Drawing.Point(0, 196)
        Me.GunaPanel6.Name = "GunaPanel6"
        Me.GunaPanel6.Size = New System.Drawing.Size(565, 35)
        Me.GunaPanel6.TabIndex = 4
        '
        'Anuncio1Des
        '
        Me.Anuncio1Des.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Anuncio1Des.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Anuncio1Des.ForeColor = System.Drawing.Color.White
        Me.Anuncio1Des.Location = New System.Drawing.Point(15, 20)
        Me.Anuncio1Des.Name = "Anuncio1Des"
        Me.Anuncio1Des.Size = New System.Drawing.Size(536, 211)
        Me.Anuncio1Des.TabIndex = 5
        Me.Anuncio1Des.Text = "Des"
        Me.Anuncio1Des.Visible = False
        '
        'Anuncio1Title
        '
        Me.Anuncio1Title.AutoSize = True
        Me.Anuncio1Title.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Anuncio1Title.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Anuncio1Title.ForeColor = System.Drawing.Color.White
        Me.Anuncio1Title.Location = New System.Drawing.Point(14, 4)
        Me.Anuncio1Title.Name = "Anuncio1Title"
        Me.Anuncio1Title.Size = New System.Drawing.Size(28, 13)
        Me.Anuncio1Title.TabIndex = 4
        Me.Anuncio1Title.Text = "Title"
        Me.Anuncio1Title.Visible = False
        '
        'GunaPanel7
        '
        Me.GunaPanel7.Location = New System.Drawing.Point(3, 4)
        Me.GunaPanel7.Name = "GunaPanel7"
        Me.GunaPanel7.Size = New System.Drawing.Size(5, 28)
        Me.GunaPanel7.TabIndex = 1
        '
        'Anuncio1Icon
        '
        Me.Anuncio1Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Anuncio1Icon.Location = New System.Drawing.Point(3, 1)
        Me.Anuncio1Icon.Name = "Anuncio1Icon"
        Me.Anuncio1Icon.Size = New System.Drawing.Size(20, 20)
        Me.Anuncio1Icon.TabIndex = 5
        Me.Anuncio1Icon.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(818, 438)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Home"
        Me.Text = "Home"
        Me.GunaPanel1.ResumeLayout(False)
        Me.Anuncio4.ResumeLayout(False)
        Me.GunaPanel8.ResumeLayout(False)
        Me.GunaPanel8.PerformLayout()
        Me.GunaPanel9.ResumeLayout(False)
        Me.GunaPanel9.PerformLayout()
        Me.Anuncio3.ResumeLayout(False)
        Me.GunaPanel3.ResumeLayout(False)
        Me.GunaPanel3.PerformLayout()
        Me.Anuncio2.ResumeLayout(False)
        Me.GunaPanel2.ResumeLayout(False)
        Me.GunaPanel2.PerformLayout()
        Me.Anuncio1.ResumeLayout(False)
        Me.GunaPanel6.ResumeLayout(False)
        Me.GunaPanel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Anuncio1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Anuncio4 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Anuncio3 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Anuncio2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaPanel3 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaPanel4 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaPanel5 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Anuncio3Icon As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Anuncio2Icon As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Anuncio2Title As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Anuncio3Des As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Anuncio3Title As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Anuncio2Des As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel6 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Anuncio1Des As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Anuncio1Title As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel7 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Anuncio1Icon As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaPanel8 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaPanel9 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents HaloLaunchPC As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents HaloLaunchCE As Guna.UI.WinForms.GunaButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
