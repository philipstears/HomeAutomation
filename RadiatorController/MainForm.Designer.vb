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
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FirstOn
        '
        Me.FirstOn.Location = New System.Drawing.Point(3, 3)
        Me.FirstOn.Name = "FirstOn"
        Me.FirstOn.Size = New System.Drawing.Size(75, 23)
        Me.FirstOn.TabIndex = 0
        Me.FirstOn.Text = "First On"
        Me.FirstOn.UseVisualStyleBackColor = True
        '
        'FirstOff
        '
        Me.FirstOff.Location = New System.Drawing.Point(84, 3)
        Me.FirstOff.Name = "FirstOff"
        Me.FirstOff.Size = New System.Drawing.Size(75, 23)
        Me.FirstOff.TabIndex = 1
        Me.FirstOff.Text = "First Off"
        Me.FirstOff.UseVisualStyleBackColor = True
        '
        'SecondOn
        '
        Me.SecondOn.Location = New System.Drawing.Point(165, 3)
        Me.SecondOn.Name = "SecondOn"
        Me.SecondOn.Size = New System.Drawing.Size(75, 23)
        Me.SecondOn.TabIndex = 2
        Me.SecondOn.Text = "Second On"
        Me.SecondOn.UseVisualStyleBackColor = True
        '
        'SecondOff
        '
        Me.SecondOff.Location = New System.Drawing.Point(246, 3)
        Me.SecondOff.Name = "SecondOff"
        Me.SecondOff.Size = New System.Drawing.Size(75, 23)
        Me.SecondOff.TabIndex = 3
        Me.SecondOff.Text = "Second Off"
        Me.SecondOff.UseVisualStyleBackColor = True
        '
        'AllOn
        '
        Me.AllOn.Location = New System.Drawing.Point(3, 32)
        Me.AllOn.Name = "AllOn"
        Me.AllOn.Size = New System.Drawing.Size(75, 23)
        Me.AllOn.TabIndex = 4
        Me.AllOn.Text = "All On"
        Me.AllOn.UseVisualStyleBackColor = True
        '
        'AllOff
        '
        Me.AllOff.Location = New System.Drawing.Point(84, 32)
        Me.AllOff.Name = "AllOff"
        Me.AllOff.Size = New System.Drawing.Size(75, 23)
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
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(237, 66)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(392, 234)
        Me.FlowLayoutPanel1.TabIndex = 6
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FirstOn As System.Windows.Forms.Button
    Friend WithEvents FirstOff As System.Windows.Forms.Button
    Friend WithEvents SecondOn As System.Windows.Forms.Button
    Friend WithEvents SecondOff As System.Windows.Forms.Button
    Friend WithEvents AllOn As System.Windows.Forms.Button
    Friend WithEvents AllOff As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel

End Class
