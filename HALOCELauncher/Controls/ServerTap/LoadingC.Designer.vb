<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadingC
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
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Progress = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.AnimaProgressBar1 = New HALOCELauncher.AnimaProgressBar()
        Me.GunaPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GunaPanel1.Controls.Add(Me.Panel1)
        Me.GunaPanel1.Controls.Add(Me.AnimaProgressBar1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(263, 67)
        Me.GunaPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Progress)
        Me.Panel1.Location = New System.Drawing.Point(26, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(206, 15)
        Me.Panel1.TabIndex = 1
        '
        'Progress
        '
        Me.Progress.Location = New System.Drawing.Point(0, 0)
        Me.Progress.Name = "Progress"
        Me.Progress.Size = New System.Drawing.Size(11, 14)
        Me.Progress.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'AnimaProgressBar1
        '
        Me.AnimaProgressBar1.BorderColors = System.Drawing.Color.SpringGreen
        Me.AnimaProgressBar1.Location = New System.Drawing.Point(25, 23)
        Me.AnimaProgressBar1.Name = "AnimaProgressBar1"
        Me.AnimaProgressBar1.Size = New System.Drawing.Size(208, 18)
        Me.AnimaProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.AnimaProgressBar1.TabIndex = 0
        '
        'LoadingC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.GunaPanel1)
        Me.Name = "LoadingC"
        Me.Size = New System.Drawing.Size(263, 67)
        Me.GunaPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Progress As System.Windows.Forms.Panel
    Friend WithEvents AnimaProgressBar1 As HALOCELauncher.AnimaProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
