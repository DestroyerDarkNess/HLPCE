<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sv_control
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
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.HostNamelbl = New Guna.UI.WinForms.GunaLabel()
        Me.AnimaContextMenuStrip1 = New HALOCELauncher.AnimaContextMenuStrip()
        Me.ConnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnectWithHALOPCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddToFavoritesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAllServersToFavoritesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyServerInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateAndCopyServerInviteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GunaElipse2 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.Playerslbl = New Guna.UI.WinForms.GunaLabel()
        Me.GunaElipse3 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.Pinglbl = New Guna.UI.WinForms.GunaLabel()
        Me.GunaElipse4 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.Modelbl = New Guna.UI.WinForms.GunaLabel()
        Me.Maplbl = New Guna.UI.WinForms.GunaLabel()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.AnimaContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me.HostNamelbl
        '
        'HostNamelbl
        '
        Me.HostNamelbl.AutoSize = True
        Me.HostNamelbl.BackColor = System.Drawing.Color.Transparent
        Me.HostNamelbl.ContextMenuStrip = Me.AnimaContextMenuStrip1
        Me.HostNamelbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.HostNamelbl.ForeColor = System.Drawing.Color.White
        Me.HostNamelbl.Location = New System.Drawing.Point(3, 5)
        Me.HostNamelbl.Name = "HostNamelbl"
        Me.HostNamelbl.Size = New System.Drawing.Size(64, 15)
        Me.HostNamelbl.TabIndex = 1
        Me.HostNamelbl.Text = "HostName"
        '
        'AnimaContextMenuStrip1
        '
        Me.AnimaContextMenuStrip1.BackColor = System.Drawing.Color.White
        Me.AnimaContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.AnimaContextMenuStrip1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.AnimaContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectToolStripMenuItem, Me.ConnectWithHALOPCToolStripMenuItem, Me.ToolStripSeparator1, Me.AddToFavoritesToolStripMenuItem, Me.AddAllServersToFavoritesToolStripMenuItem, Me.DeleteServerToolStripMenuItem, Me.RefreshServerToolStripMenuItem, Me.ToolStripSeparator2, Me.CopyServerInfoToolStripMenuItem, Me.CreateAndCopyServerInviteToolStripMenuItem})
        Me.AnimaContextMenuStrip1.Name = "AnimaContextMenuStrip1"
        Me.AnimaContextMenuStrip1.Size = New System.Drawing.Size(233, 192)
        '
        'ConnectToolStripMenuItem
        '
        Me.ConnectToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem"
        Me.ConnectToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ConnectToolStripMenuItem.Text = "Connect with HALO CE"
        '
        'ConnectWithHALOPCToolStripMenuItem
        '
        Me.ConnectWithHALOPCToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ConnectWithHALOPCToolStripMenuItem.Name = "ConnectWithHALOPCToolStripMenuItem"
        Me.ConnectWithHALOPCToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ConnectWithHALOPCToolStripMenuItem.Text = "Connect with HALO PC"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(229, 6)
        '
        'AddToFavoritesToolStripMenuItem
        '
        Me.AddToFavoritesToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.AddToFavoritesToolStripMenuItem.Name = "AddToFavoritesToolStripMenuItem"
        Me.AddToFavoritesToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.AddToFavoritesToolStripMenuItem.Text = "Add to Favorites"
        '
        'AddAllServersToFavoritesToolStripMenuItem
        '
        Me.AddAllServersToFavoritesToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.AddAllServersToFavoritesToolStripMenuItem.Name = "AddAllServersToFavoritesToolStripMenuItem"
        Me.AddAllServersToFavoritesToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.AddAllServersToFavoritesToolStripMenuItem.Text = "Add All Servers To favorites"
        '
        'DeleteServerToolStripMenuItem
        '
        Me.DeleteServerToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.DeleteServerToolStripMenuItem.Name = "DeleteServerToolStripMenuItem"
        Me.DeleteServerToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.DeleteServerToolStripMenuItem.Text = "Delete Server"
        '
        'RefreshServerToolStripMenuItem
        '
        Me.RefreshServerToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.RefreshServerToolStripMenuItem.Name = "RefreshServerToolStripMenuItem"
        Me.RefreshServerToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.RefreshServerToolStripMenuItem.Text = "Refresh server"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(229, 6)
        '
        'CopyServerInfoToolStripMenuItem
        '
        Me.CopyServerInfoToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.CopyServerInfoToolStripMenuItem.Name = "CopyServerInfoToolStripMenuItem"
        Me.CopyServerInfoToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.CopyServerInfoToolStripMenuItem.Text = "Copy server Info"
        '
        'CreateAndCopyServerInviteToolStripMenuItem
        '
        Me.CreateAndCopyServerInviteToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.CreateAndCopyServerInviteToolStripMenuItem.Name = "CreateAndCopyServerInviteToolStripMenuItem"
        Me.CreateAndCopyServerInviteToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.CreateAndCopyServerInviteToolStripMenuItem.Text = "Create and Copy Server Invite "
        '
        'GunaElipse2
        '
        Me.GunaElipse2.TargetControl = Me.Playerslbl
        '
        'Playerslbl
        '
        Me.Playerslbl.AutoSize = True
        Me.Playerslbl.BackColor = System.Drawing.Color.Transparent
        Me.Playerslbl.ContextMenuStrip = Me.AnimaContextMenuStrip1
        Me.Playerslbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Playerslbl.ForeColor = System.Drawing.Color.White
        Me.Playerslbl.Location = New System.Drawing.Point(267, 5)
        Me.Playerslbl.Name = "Playerslbl"
        Me.Playerslbl.Size = New System.Drawing.Size(44, 15)
        Me.Playerslbl.TabIndex = 2
        Me.Playerslbl.Text = "Players"
        '
        'GunaElipse3
        '
        Me.GunaElipse3.TargetControl = Me.Pinglbl
        '
        'Pinglbl
        '
        Me.Pinglbl.AutoSize = True
        Me.Pinglbl.BackColor = System.Drawing.Color.Transparent
        Me.Pinglbl.ContextMenuStrip = Me.AnimaContextMenuStrip1
        Me.Pinglbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Pinglbl.ForeColor = System.Drawing.Color.White
        Me.Pinglbl.Location = New System.Drawing.Point(336, 5)
        Me.Pinglbl.Name = "Pinglbl"
        Me.Pinglbl.Size = New System.Drawing.Size(29, 15)
        Me.Pinglbl.TabIndex = 3
        Me.Pinglbl.Text = "0ms"
        '
        'GunaElipse4
        '
        Me.GunaElipse4.TargetControl = Me.Modelbl
        '
        'Modelbl
        '
        Me.Modelbl.AutoSize = True
        Me.Modelbl.BackColor = System.Drawing.Color.Transparent
        Me.Modelbl.ContextMenuStrip = Me.AnimaContextMenuStrip1
        Me.Modelbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Modelbl.ForeColor = System.Drawing.Color.White
        Me.Modelbl.Location = New System.Drawing.Point(497, 5)
        Me.Modelbl.Name = "Modelbl"
        Me.Modelbl.Size = New System.Drawing.Size(38, 15)
        Me.Modelbl.TabIndex = 4
        Me.Modelbl.Text = "Mode"
        '
        'Maplbl
        '
        Me.Maplbl.AutoSize = True
        Me.Maplbl.BackColor = System.Drawing.Color.Transparent
        Me.Maplbl.ContextMenuStrip = Me.AnimaContextMenuStrip1
        Me.Maplbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Maplbl.ForeColor = System.Drawing.Color.White
        Me.Maplbl.Location = New System.Drawing.Point(396, 5)
        Me.Maplbl.Name = "Maplbl"
        Me.Maplbl.Size = New System.Drawing.Size(33, 15)
        Me.Maplbl.TabIndex = 5
        Me.Maplbl.Text = "MAP"
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BorderColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BorderSize = 1
        Me.GunaButton1.ContextMenuStrip = Me.AnimaContextMenuStrip1
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(0, 0)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.SpringGreen
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 1
        Me.GunaButton1.Size = New System.Drawing.Size(578, 25)
        Me.GunaButton1.TabIndex = 0
        '
        'BackgroundWorker1
        '
        '
        'sv_control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.Maplbl)
        Me.Controls.Add(Me.Modelbl)
        Me.Controls.Add(Me.Pinglbl)
        Me.Controls.Add(Me.Playerslbl)
        Me.Controls.Add(Me.HostNamelbl)
        Me.Controls.Add(Me.GunaButton1)
        Me.Name = "sv_control"
        Me.Size = New System.Drawing.Size(578, 25)
        Me.AnimaContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents HostNamelbl As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Playerslbl As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Pinglbl As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Modelbl As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaElipse2 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaElipse3 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents GunaElipse4 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents Maplbl As Guna.UI.WinForms.GunaLabel
    Friend WithEvents AnimaContextMenuStrip1 As HALOCELauncher.AnimaContextMenuStrip
    Friend WithEvents ConnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AddToFavoritesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyServerInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddAllServersToFavoritesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateAndCopyServerInviteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConnectWithHALOPCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker

End Class
