<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modsfrm
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
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(818, 438)
        Me.GunaPanel1.TabIndex = 3
        '
        'Modsfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(818, 438)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Modsfrm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Modsfrm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
End Class
