<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MonitorTimer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelFX1 = New HALOCELauncher.PanelFX()
        Me.GunaControlBox2 = New Guna.UI.WinForms.GunaControlBox()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaVSeparator1 = New Guna.UI.WinForms.GunaVSeparator()
        Me.GunaPictureBox2 = New Guna.UI.WinForms.GunaPictureBox()
        Me.GunaCirclePictureBox1 = New Guna.UI.WinForms.GunaCirclePictureBox()
        Me.GunaControlBox1 = New Guna.UI.WinForms.GunaControlBox()
        Me.PanelContainer = New Guna.UI.WinForms.GunaPanel()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.nav_settings = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.nav_tools = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.nav_mods = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.nav_servers = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.nav_home = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.CrashMonitor = New System.Windows.Forms.Timer(Me.components)
        Me.PanelFX1.SuspendLayout()
        CType(Me.GunaPictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GunaCirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MonitorTimer1
        '
        '
        'PanelFX1
        '
        Me.PanelFX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.PanelFX1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelFX1.Controls.Add(Me.GunaControlBox2)
        Me.PanelFX1.Controls.Add(Me.GunaButton1)
        Me.PanelFX1.Controls.Add(Me.GunaVSeparator1)
        Me.PanelFX1.Controls.Add(Me.GunaPictureBox2)
        Me.PanelFX1.Controls.Add(Me.GunaCirclePictureBox1)
        Me.PanelFX1.Controls.Add(Me.GunaControlBox1)
        Me.PanelFX1.Controls.Add(Me.PanelContainer)
        Me.PanelFX1.Controls.Add(Me.GunaPanel2)
        Me.PanelFX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelFX1.Location = New System.Drawing.Point(0, 0)
        Me.PanelFX1.Name = "PanelFX1"
        Me.PanelFX1.Size = New System.Drawing.Size(842, 495)
        Me.PanelFX1.TabIndex = 0
        '
        'GunaControlBox2
        '
        Me.GunaControlBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaControlBox2.AnimationHoverSpeed = 0.07!
        Me.GunaControlBox2.AnimationSpeed = 0.03!
        Me.GunaControlBox2.BackColor = System.Drawing.Color.Transparent
        Me.GunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox
        Me.GunaControlBox2.IconColor = System.Drawing.Color.White
        Me.GunaControlBox2.IconSize = 15.0!
        Me.GunaControlBox2.Location = New System.Drawing.Point(774, 0)
        Me.GunaControlBox2.Name = "GunaControlBox2"
        Me.GunaControlBox2.OnHoverBackColor = System.Drawing.Color.SpringGreen
        Me.GunaControlBox2.OnHoverIconColor = System.Drawing.Color.White
        Me.GunaControlBox2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaControlBox2.Size = New System.Drawing.Size(31, 24)
        Me.GunaControlBox2.TabIndex = 10
        '
        'GunaButton1
        '
        Me.GunaButton1.Animated = True
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.GunaButton1.BorderColor = System.Drawing.Color.White
        Me.GunaButton1.BorderSize = 1
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(597, 11)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 15
        Me.GunaButton1.Size = New System.Drawing.Size(86, 28)
        Me.GunaButton1.TabIndex = 9
        Me.GunaButton1.Text = "Upgrade"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButton1.Visible = False
        '
        'GunaVSeparator1
        '
        Me.GunaVSeparator1.BackColor = System.Drawing.Color.Transparent
        Me.GunaVSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GunaVSeparator1.LineColor = System.Drawing.Color.SpringGreen
        Me.GunaVSeparator1.Location = New System.Drawing.Point(689, 9)
        Me.GunaVSeparator1.Name = "GunaVSeparator1"
        Me.GunaVSeparator1.Size = New System.Drawing.Size(10, 32)
        Me.GunaVSeparator1.TabIndex = 8
        Me.GunaVSeparator1.Visible = False
        '
        'GunaPictureBox2
        '
        Me.GunaPictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.GunaPictureBox2.BaseColor = System.Drawing.Color.White
        Me.GunaPictureBox2.Image = CType(resources.GetObject("GunaPictureBox2.Image"), System.Drawing.Image)
        Me.GunaPictureBox2.Location = New System.Drawing.Point(743, 20)
        Me.GunaPictureBox2.Name = "GunaPictureBox2"
        Me.GunaPictureBox2.Size = New System.Drawing.Size(12, 12)
        Me.GunaPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.GunaPictureBox2.TabIndex = 7
        Me.GunaPictureBox2.TabStop = False
        Me.GunaPictureBox2.Visible = False
        '
        'GunaCirclePictureBox1
        '
        Me.GunaCirclePictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.GunaCirclePictureBox1.BaseColor = System.Drawing.Color.White
        Me.GunaCirclePictureBox1.Image = CType(resources.GetObject("GunaCirclePictureBox1.Image"), System.Drawing.Image)
        Me.GunaCirclePictureBox1.Location = New System.Drawing.Point(705, 9)
        Me.GunaCirclePictureBox1.Name = "GunaCirclePictureBox1"
        Me.GunaCirclePictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.GunaCirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.GunaCirclePictureBox1.TabIndex = 6
        Me.GunaCirclePictureBox1.TabStop = False
        Me.GunaCirclePictureBox1.UseTransfarantBackground = False
        Me.GunaCirclePictureBox1.Visible = False
        '
        'GunaControlBox1
        '
        Me.GunaControlBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaControlBox1.AnimationHoverSpeed = 0.07!
        Me.GunaControlBox1.AnimationSpeed = 0.03!
        Me.GunaControlBox1.BackColor = System.Drawing.Color.Transparent
        Me.GunaControlBox1.IconColor = System.Drawing.Color.White
        Me.GunaControlBox1.IconSize = 15.0!
        Me.GunaControlBox1.Location = New System.Drawing.Point(811, 0)
        Me.GunaControlBox1.Name = "GunaControlBox1"
        Me.GunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GunaControlBox1.OnHoverIconColor = System.Drawing.Color.White
        Me.GunaControlBox1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaControlBox1.Size = New System.Drawing.Size(31, 24)
        Me.GunaControlBox1.TabIndex = 4
        '
        'PanelContainer
        '
        Me.PanelContainer.BackColor = System.Drawing.Color.Transparent
        Me.PanelContainer.Location = New System.Drawing.Point(12, 45)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(818, 438)
        Me.PanelContainer.TabIndex = 3
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GunaPanel2.Controls.Add(Me.nav_settings)
        Me.GunaPanel2.Controls.Add(Me.nav_tools)
        Me.GunaPanel2.Controls.Add(Me.nav_mods)
        Me.GunaPanel2.Controls.Add(Me.nav_servers)
        Me.GunaPanel2.Controls.Add(Me.nav_home)
        Me.GunaPanel2.Location = New System.Drawing.Point(11, 11)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(568, 28)
        Me.GunaPanel2.TabIndex = 2
        '
        'nav_settings
        '
        Me.nav_settings.Animated = True
        Me.nav_settings.AnimationHoverSpeed = 0.07!
        Me.nav_settings.AnimationSpeed = 0.03!
        Me.nav_settings.BaseColor = System.Drawing.Color.Transparent
        Me.nav_settings.BorderColor = System.Drawing.Color.Black
        Me.nav_settings.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton
        Me.nav_settings.CheckedBaseColor = System.Drawing.Color.Transparent
        Me.nav_settings.CheckedBorderColor = System.Drawing.Color.Black
        Me.nav_settings.CheckedForeColor = System.Drawing.Color.White
        Me.nav_settings.CheckedImage = Nothing
        Me.nav_settings.CheckedLineColor = System.Drawing.Color.MediumSpringGreen
        Me.nav_settings.DialogResult = System.Windows.Forms.DialogResult.None
        Me.nav_settings.Dock = System.Windows.Forms.DockStyle.Left
        Me.nav_settings.FocusedColor = System.Drawing.Color.Empty
        Me.nav_settings.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.nav_settings.ForeColor = System.Drawing.Color.White
        Me.nav_settings.Image = Nothing
        Me.nav_settings.ImageSize = New System.Drawing.Size(20, 20)
        Me.nav_settings.LineBottom = 2
        Me.nav_settings.LineColor = System.Drawing.Color.Transparent
        Me.nav_settings.Location = New System.Drawing.Point(448, 0)
        Me.nav_settings.Name = "nav_settings"
        Me.nav_settings.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.nav_settings.OnHoverBorderColor = System.Drawing.Color.Black
        Me.nav_settings.OnHoverForeColor = System.Drawing.Color.White
        Me.nav_settings.OnHoverImage = Nothing
        Me.nav_settings.OnHoverLineColor = System.Drawing.Color.MediumSpringGreen
        Me.nav_settings.OnPressedColor = System.Drawing.Color.Black
        Me.nav_settings.OnPressedDepth = 0
        Me.nav_settings.Size = New System.Drawing.Size(112, 28)
        Me.nav_settings.TabIndex = 3
        Me.nav_settings.Text = "Settings"
        Me.nav_settings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nav_tools
        '
        Me.nav_tools.Animated = True
        Me.nav_tools.AnimationHoverSpeed = 0.07!
        Me.nav_tools.AnimationSpeed = 0.03!
        Me.nav_tools.BaseColor = System.Drawing.Color.Transparent
        Me.nav_tools.BorderColor = System.Drawing.Color.Black
        Me.nav_tools.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton
        Me.nav_tools.CheckedBaseColor = System.Drawing.Color.Transparent
        Me.nav_tools.CheckedBorderColor = System.Drawing.Color.Black
        Me.nav_tools.CheckedForeColor = System.Drawing.Color.White
        Me.nav_tools.CheckedImage = Nothing
        Me.nav_tools.CheckedLineColor = System.Drawing.Color.MediumSpringGreen
        Me.nav_tools.DialogResult = System.Windows.Forms.DialogResult.None
        Me.nav_tools.Dock = System.Windows.Forms.DockStyle.Left
        Me.nav_tools.FocusedColor = System.Drawing.Color.Empty
        Me.nav_tools.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.nav_tools.ForeColor = System.Drawing.Color.White
        Me.nav_tools.Image = Nothing
        Me.nav_tools.ImageSize = New System.Drawing.Size(20, 20)
        Me.nav_tools.LineBottom = 2
        Me.nav_tools.LineColor = System.Drawing.Color.Transparent
        Me.nav_tools.Location = New System.Drawing.Point(336, 0)
        Me.nav_tools.Name = "nav_tools"
        Me.nav_tools.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.nav_tools.OnHoverBorderColor = System.Drawing.Color.Black
        Me.nav_tools.OnHoverForeColor = System.Drawing.Color.White
        Me.nav_tools.OnHoverImage = Nothing
        Me.nav_tools.OnHoverLineColor = System.Drawing.Color.MediumSpringGreen
        Me.nav_tools.OnPressedColor = System.Drawing.Color.Black
        Me.nav_tools.OnPressedDepth = 0
        Me.nav_tools.Size = New System.Drawing.Size(112, 28)
        Me.nav_tools.TabIndex = 4
        Me.nav_tools.Text = "Tools"
        Me.nav_tools.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nav_tools.Visible = False
        '
        'nav_mods
        '
        Me.nav_mods.Animated = True
        Me.nav_mods.AnimationHoverSpeed = 0.07!
        Me.nav_mods.AnimationSpeed = 0.03!
        Me.nav_mods.BaseColor = System.Drawing.Color.Transparent
        Me.nav_mods.BorderColor = System.Drawing.Color.Black
        Me.nav_mods.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton
        Me.nav_mods.CheckedBaseColor = System.Drawing.Color.Transparent
        Me.nav_mods.CheckedBorderColor = System.Drawing.Color.Black
        Me.nav_mods.CheckedForeColor = System.Drawing.Color.White
        Me.nav_mods.CheckedImage = Nothing
        Me.nav_mods.CheckedLineColor = System.Drawing.Color.MediumSpringGreen
        Me.nav_mods.DialogResult = System.Windows.Forms.DialogResult.None
        Me.nav_mods.Dock = System.Windows.Forms.DockStyle.Left
        Me.nav_mods.FocusedColor = System.Drawing.Color.Empty
        Me.nav_mods.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.nav_mods.ForeColor = System.Drawing.Color.White
        Me.nav_mods.Image = Nothing
        Me.nav_mods.ImageSize = New System.Drawing.Size(20, 20)
        Me.nav_mods.LineBottom = 2
        Me.nav_mods.LineColor = System.Drawing.Color.Transparent
        Me.nav_mods.Location = New System.Drawing.Point(224, 0)
        Me.nav_mods.Name = "nav_mods"
        Me.nav_mods.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.nav_mods.OnHoverBorderColor = System.Drawing.Color.Black
        Me.nav_mods.OnHoverForeColor = System.Drawing.Color.White
        Me.nav_mods.OnHoverImage = Nothing
        Me.nav_mods.OnHoverLineColor = System.Drawing.Color.MediumSpringGreen
        Me.nav_mods.OnPressedColor = System.Drawing.Color.Black
        Me.nav_mods.OnPressedDepth = 0
        Me.nav_mods.Size = New System.Drawing.Size(112, 28)
        Me.nav_mods.TabIndex = 2
        Me.nav_mods.Text = "Mods"
        Me.nav_mods.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nav_mods.Visible = False
        '
        'nav_servers
        '
        Me.nav_servers.Animated = True
        Me.nav_servers.AnimationHoverSpeed = 0.07!
        Me.nav_servers.AnimationSpeed = 0.03!
        Me.nav_servers.BaseColor = System.Drawing.Color.Transparent
        Me.nav_servers.BorderColor = System.Drawing.Color.Black
        Me.nav_servers.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton
        Me.nav_servers.CheckedBaseColor = System.Drawing.Color.Transparent
        Me.nav_servers.CheckedBorderColor = System.Drawing.Color.Black
        Me.nav_servers.CheckedForeColor = System.Drawing.Color.White
        Me.nav_servers.CheckedImage = Nothing
        Me.nav_servers.CheckedLineColor = System.Drawing.Color.MediumSpringGreen
        Me.nav_servers.DialogResult = System.Windows.Forms.DialogResult.None
        Me.nav_servers.Dock = System.Windows.Forms.DockStyle.Left
        Me.nav_servers.FocusedColor = System.Drawing.Color.Empty
        Me.nav_servers.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.nav_servers.ForeColor = System.Drawing.Color.White
        Me.nav_servers.Image = Nothing
        Me.nav_servers.ImageSize = New System.Drawing.Size(20, 20)
        Me.nav_servers.LineBottom = 2
        Me.nav_servers.LineColor = System.Drawing.Color.Transparent
        Me.nav_servers.Location = New System.Drawing.Point(112, 0)
        Me.nav_servers.Name = "nav_servers"
        Me.nav_servers.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.nav_servers.OnHoverBorderColor = System.Drawing.Color.Black
        Me.nav_servers.OnHoverForeColor = System.Drawing.Color.White
        Me.nav_servers.OnHoverImage = Nothing
        Me.nav_servers.OnHoverLineColor = System.Drawing.Color.MediumSpringGreen
        Me.nav_servers.OnPressedColor = System.Drawing.Color.Black
        Me.nav_servers.OnPressedDepth = 0
        Me.nav_servers.Size = New System.Drawing.Size(112, 28)
        Me.nav_servers.TabIndex = 1
        Me.nav_servers.Text = "Servers"
        Me.nav_servers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nav_home
        '
        Me.nav_home.Animated = True
        Me.nav_home.AnimationHoverSpeed = 0.07!
        Me.nav_home.AnimationSpeed = 0.03!
        Me.nav_home.BaseColor = System.Drawing.Color.Transparent
        Me.nav_home.BorderColor = System.Drawing.Color.Black
        Me.nav_home.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton
        Me.nav_home.Checked = True
        Me.nav_home.CheckedBaseColor = System.Drawing.Color.Transparent
        Me.nav_home.CheckedBorderColor = System.Drawing.Color.Black
        Me.nav_home.CheckedForeColor = System.Drawing.Color.White
        Me.nav_home.CheckedImage = Nothing
        Me.nav_home.CheckedLineColor = System.Drawing.Color.MediumSpringGreen
        Me.nav_home.DialogResult = System.Windows.Forms.DialogResult.None
        Me.nav_home.Dock = System.Windows.Forms.DockStyle.Left
        Me.nav_home.FocusedColor = System.Drawing.Color.Empty
        Me.nav_home.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.nav_home.ForeColor = System.Drawing.Color.White
        Me.nav_home.Image = Nothing
        Me.nav_home.ImageSize = New System.Drawing.Size(20, 20)
        Me.nav_home.LineBottom = 2
        Me.nav_home.LineColor = System.Drawing.Color.Transparent
        Me.nav_home.Location = New System.Drawing.Point(0, 0)
        Me.nav_home.Name = "nav_home"
        Me.nav_home.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.nav_home.OnHoverBorderColor = System.Drawing.Color.Black
        Me.nav_home.OnHoverForeColor = System.Drawing.Color.White
        Me.nav_home.OnHoverImage = Nothing
        Me.nav_home.OnHoverLineColor = System.Drawing.Color.MediumSpringGreen
        Me.nav_home.OnPressedColor = System.Drawing.Color.Black
        Me.nav_home.OnPressedDepth = 0
        Me.nav_home.Size = New System.Drawing.Size(112, 28)
        Me.nav_home.TabIndex = 0
        Me.nav_home.Text = "Home"
        Me.nav_home.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CrashMonitor
        '
        Me.CrashMonitor.Enabled = True
        Me.CrashMonitor.Interval = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(842, 495)
        Me.Controls.Add(Me.PanelFX1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HLPCE"
        Me.PanelFX1.ResumeLayout(False)
        Me.PanelFX1.PerformLayout()
        CType(Me.GunaPictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GunaCirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelFX1 As HALOCELauncher.PanelFX
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents nav_home As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents nav_servers As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents nav_tools As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents nav_settings As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents nav_mods As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents GunaControlBox1 As Guna.UI.WinForms.GunaControlBox
    Friend WithEvents PanelContainer As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaVSeparator1 As Guna.UI.WinForms.GunaVSeparator
    Friend WithEvents GunaPictureBox2 As Guna.UI.WinForms.GunaPictureBox
    Friend WithEvents GunaCirclePictureBox1 As Guna.UI.WinForms.GunaCirclePictureBox
    Friend WithEvents GunaControlBox2 As Guna.UI.WinForms.GunaControlBox
    Friend WithEvents MonitorTimer1 As System.Windows.Forms.Timer
    Friend WithEvents CrashMonitor As System.Windows.Forms.Timer

End Class
