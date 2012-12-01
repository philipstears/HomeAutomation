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
        Me.txtDesiredTemp0 = New System.Windows.Forms.TextBox()
        Me.numCurrentTemp0 = New System.Windows.Forms.NumericUpDown()
        Me.picLampOff0 = New System.Windows.Forms.PictureBox()
        Me.picLampOn0 = New System.Windows.Forms.PictureBox()
        Me.lblCurrentStatus0 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDesiredTemp1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDesiredTemp2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDesiredTemp3 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TimeTrack = New System.Windows.Forms.TrackBar()
        Me.TimeLabel = New System.Windows.Forms.Label()
        CType(Me.numCurrentTemp0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLampOff0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLampOn0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeTrack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDesiredTemp0
        '
        Me.txtDesiredTemp0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesiredTemp0.Location = New System.Drawing.Point(261, 22)
        Me.txtDesiredTemp0.Name = "txtDesiredTemp0"
        Me.txtDesiredTemp0.Size = New System.Drawing.Size(47, 29)
        Me.txtDesiredTemp0.TabIndex = 0
        Me.txtDesiredTemp0.Text = "10"
        '
        'numCurrentTemp0
        '
        Me.numCurrentTemp0.DecimalPlaces = 1
        Me.numCurrentTemp0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.numCurrentTemp0.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numCurrentTemp0.Location = New System.Drawing.Point(262, 234)
        Me.numCurrentTemp0.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numCurrentTemp0.Minimum = New Decimal(New Integer() {10, 0, 0, -2147483648})
        Me.numCurrentTemp0.Name = "numCurrentTemp0"
        Me.numCurrentTemp0.Size = New System.Drawing.Size(71, 29)
        Me.numCurrentTemp0.TabIndex = 1
        Me.numCurrentTemp0.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'picLampOff0
        '
        Me.picLampOff0.Image = Global.RadiatorInteractiveTest.My.Resources.Resources.LampOffAgain
        Me.picLampOff0.Location = New System.Drawing.Point(262, 280)
        Me.picLampOff0.Name = "picLampOff0"
        Me.picLampOff0.Size = New System.Drawing.Size(24, 29)
        Me.picLampOff0.TabIndex = 3
        Me.picLampOff0.TabStop = False
        '
        'picLampOn0
        '
        Me.picLampOn0.Image = Global.RadiatorInteractiveTest.My.Resources.Resources.LampOn
        Me.picLampOn0.Location = New System.Drawing.Point(262, 280)
        Me.picLampOn0.Name = "picLampOn0"
        Me.picLampOn0.Size = New System.Drawing.Size(24, 27)
        Me.picLampOn0.TabIndex = 2
        Me.picLampOn0.TabStop = False
        '
        'lblCurrentStatus0
        '
        Me.lblCurrentStatus0.AutoSize = True
        Me.lblCurrentStatus0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentStatus0.Location = New System.Drawing.Point(261, 323)
        Me.lblCurrentStatus0.Name = "lblCurrentStatus0"
        Me.lblCurrentStatus0.Size = New System.Drawing.Size(36, 24)
        Me.lblCurrentStatus0.TabIndex = 4
        Me.lblCurrentStatus0.Text = "Off"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(28, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Desired Temp"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(29, 223)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Actual Temp"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(29, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 24)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Indicator"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(29, 323)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Current Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(27, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(142, 24)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Desired Temp"
        '
        'txtDesiredTemp1
        '
        Me.txtDesiredTemp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesiredTemp1.Location = New System.Drawing.Point(260, 64)
        Me.txtDesiredTemp1.Name = "txtDesiredTemp1"
        Me.txtDesiredTemp1.Size = New System.Drawing.Size(47, 29)
        Me.txtDesiredTemp1.TabIndex = 10
        Me.txtDesiredTemp1.Text = "18"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(28, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 24)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Desired Temp"
        '
        'txtDesiredTemp2
        '
        Me.txtDesiredTemp2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesiredTemp2.Location = New System.Drawing.Point(261, 107)
        Me.txtDesiredTemp2.Name = "txtDesiredTemp2"
        Me.txtDesiredTemp2.Size = New System.Drawing.Size(47, 29)
        Me.txtDesiredTemp2.TabIndex = 12
        Me.txtDesiredTemp2.Text = "24"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(28, 152)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(142, 24)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Desired Temp"
        '
        'txtDesiredTemp3
        '
        Me.txtDesiredTemp3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesiredTemp3.Location = New System.Drawing.Point(261, 152)
        Me.txtDesiredTemp3.Name = "txtDesiredTemp3"
        Me.txtDesiredTemp3.Size = New System.Drawing.Size(47, 29)
        Me.txtDesiredTemp3.TabIndex = 14
        Me.txtDesiredTemp3.Text = "17"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(341, 451)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 24)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Current Time"
        '
        'TimeTrack
        '
        Me.TimeTrack.Location = New System.Drawing.Point(479, 479)
        Me.TimeTrack.Maximum = 1440
        Me.TimeTrack.Name = "TimeTrack"
        Me.TimeTrack.Size = New System.Drawing.Size(431, 45)
        Me.TimeTrack.TabIndex = 18
        '
        'TimeLabel
        '
        Me.TimeLabel.AutoSize = True
        Me.TimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.TimeLabel.Location = New System.Drawing.Point(479, 451)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.Size = New System.Drawing.Size(72, 24)
        Me.TimeLabel.TabIndex = 19
        Me.TimeLabel.Text = "Label9"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1126, 575)
        Me.Controls.Add(Me.TimeLabel)
        Me.Controls.Add(Me.TimeTrack)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDesiredTemp3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDesiredTemp2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDesiredTemp1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCurrentStatus0)
        Me.Controls.Add(Me.picLampOff0)
        Me.Controls.Add(Me.picLampOn0)
        Me.Controls.Add(Me.numCurrentTemp0)
        Me.Controls.Add(Me.txtDesiredTemp0)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.numCurrentTemp0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLampOff0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLampOn0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeTrack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDesiredTemp0 As System.Windows.Forms.TextBox
    Friend WithEvents numCurrentTemp0 As System.Windows.Forms.NumericUpDown
    Friend WithEvents picLampOn0 As System.Windows.Forms.PictureBox
    Friend WithEvents picLampOff0 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCurrentStatus0 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDesiredTemp1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDesiredTemp2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDesiredTemp3 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TimeTrack As System.Windows.Forms.TrackBar
    Friend WithEvents TimeLabel As System.Windows.Forms.Label

End Class
