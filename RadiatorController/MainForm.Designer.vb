<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.FirstOn = New System.Windows.Forms.Button()
        Me.FirstOff = New System.Windows.Forms.Button()
        Me.SecondOn = New System.Windows.Forms.Button()
        Me.SecondOff = New System.Windows.Forms.Button()
        Me.AllOn = New System.Windows.Forms.Button()
        Me.AllOff = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ReadStatus = New System.Windows.Forms.Button()
        Me.FirstAndSecondOn = New System.Windows.Forms.Button()
        Me.FirstAndSecondOff = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FirstOn
        '
        Me.FirstOn.AutoSize = True
        Me.FirstOn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FirstOn.Location = New System.Drawing.Point(3, 3)
        Me.FirstOn.Name = "FirstOn"
        Me.FirstOn.Size = New System.Drawing.Size(53, 23)
        Me.FirstOn.TabIndex = 0
        Me.FirstOn.Text = "First On"
        Me.FirstOn.UseVisualStyleBackColor = True
        '
        'FirstOff
        '
        Me.FirstOff.AutoSize = True
        Me.FirstOff.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FirstOff.Location = New System.Drawing.Point(62, 3)
        Me.FirstOff.Name = "FirstOff"
        Me.FirstOff.Size = New System.Drawing.Size(53, 23)
        Me.FirstOff.TabIndex = 1
        Me.FirstOff.Text = "First Off"
        Me.FirstOff.UseVisualStyleBackColor = True
        '
        'SecondOn
        '
        Me.SecondOn.AutoSize = True
        Me.SecondOn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SecondOn.Location = New System.Drawing.Point(121, 3)
        Me.SecondOn.Name = "SecondOn"
        Me.SecondOn.Size = New System.Drawing.Size(71, 23)
        Me.SecondOn.TabIndex = 2
        Me.SecondOn.Text = "Second On"
        Me.SecondOn.UseVisualStyleBackColor = True
        '
        'SecondOff
        '
        Me.SecondOff.AutoSize = True
        Me.SecondOff.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SecondOff.Location = New System.Drawing.Point(198, 3)
        Me.SecondOff.Name = "SecondOff"
        Me.SecondOff.Size = New System.Drawing.Size(71, 23)
        Me.SecondOff.TabIndex = 3
        Me.SecondOff.Text = "Second Off"
        Me.SecondOff.UseVisualStyleBackColor = True
        '
        'AllOn
        '
        Me.AllOn.AutoSize = True
        Me.AllOn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AllOn.Location = New System.Drawing.Point(275, 3)
        Me.AllOn.Name = "AllOn"
        Me.AllOn.Size = New System.Drawing.Size(45, 23)
        Me.AllOn.TabIndex = 4
        Me.AllOn.Text = "All On"
        Me.AllOn.UseVisualStyleBackColor = True
        '
        'AllOff
        '
        Me.AllOff.AutoSize = True
        Me.AllOff.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AllOff.Location = New System.Drawing.Point(326, 3)
        Me.AllOff.Name = "AllOff"
        Me.AllOff.Size = New System.Drawing.Size(45, 23)
        Me.AllOff.TabIndex = 5
        Me.AllOff.Text = "All Off"
        Me.AllOff.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.FirstOn)
        Me.FlowLayoutPanel1.Controls.Add(Me.FirstOff)
        Me.FlowLayoutPanel1.Controls.Add(Me.SecondOn)
        Me.FlowLayoutPanel1.Controls.Add(Me.SecondOff)
        Me.FlowLayoutPanel1.Controls.Add(Me.AllOn)
        Me.FlowLayoutPanel1.Controls.Add(Me.AllOff)
        Me.FlowLayoutPanel1.Controls.Add(Me.ReadStatus)
        Me.FlowLayoutPanel1.Controls.Add(Me.FirstAndSecondOn)
        Me.FlowLayoutPanel1.Controls.Add(Me.FirstAndSecondOff)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(237, 66)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(392, 234)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'ReadStatus
        '
        Me.ReadStatus.AutoSize = True
        Me.ReadStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ReadStatus.Location = New System.Drawing.Point(3, 32)
        Me.ReadStatus.Name = "ReadStatus"
        Me.ReadStatus.Size = New System.Drawing.Size(76, 23)
        Me.ReadStatus.TabIndex = 6
        Me.ReadStatus.Text = "Read Status"
        Me.ReadStatus.UseVisualStyleBackColor = True
        '
        'FirstAndSecondOn
        '
        Me.FirstAndSecondOn.AutoSize = True
        Me.FirstAndSecondOn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FirstAndSecondOn.Location = New System.Drawing.Point(85, 32)
        Me.FirstAndSecondOn.Name = "FirstAndSecondOn"
        Me.FirstAndSecondOn.Size = New System.Drawing.Size(115, 23)
        Me.FirstAndSecondOn.TabIndex = 7
        Me.FirstAndSecondOn.Text = "First And Second On"
        Me.FirstAndSecondOn.UseVisualStyleBackColor = True
        '
        'FirstAndSecondOff
        '
        Me.FirstAndSecondOff.AutoSize = True
        Me.FirstAndSecondOff.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FirstAndSecondOff.Location = New System.Drawing.Point(206, 32)
        Me.FirstAndSecondOff.Name = "FirstAndSecondOff"
        Me.FirstAndSecondOff.Size = New System.Drawing.Size(115, 23)
        Me.FirstAndSecondOff.TabIndex = 8
        Me.FirstAndSecondOff.Text = "First And Second Off"
        Me.FirstAndSecondOff.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 430)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FirstOn As System.Windows.Forms.Button
    Friend WithEvents FirstOff As System.Windows.Forms.Button
    Friend WithEvents SecondOn As System.Windows.Forms.Button
    Friend WithEvents SecondOff As System.Windows.Forms.Button
    Friend WithEvents AllOn As System.Windows.Forms.Button
    Friend WithEvents AllOff As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ReadStatus As System.Windows.Forms.Button
    Friend WithEvents FirstAndSecondOn As System.Windows.Forms.Button
    Friend WithEvents FirstAndSecondOff As System.Windows.Forms.Button

End Class
