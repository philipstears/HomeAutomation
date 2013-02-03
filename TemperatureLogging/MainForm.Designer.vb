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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint4 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, 10.0R)
        Dim DataPoint5 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, 0.0R)
        Dim DataPoint6 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, 0.0R)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ReadingGraph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.UpdateGraphButton = New System.Windows.Forms.Button()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.EventList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.ReadingGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReadingGraph
        '
        ChartArea2.AxisX.IsStartedFromZero = False
        ChartArea2.Name = "ChartArea1"
        Me.ReadingGraph.ChartAreas.Add(ChartArea2)
        Me.ReadingGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReadingGraph.Location = New System.Drawing.Point(0, 0)
        Me.ReadingGraph.Name = "ReadingGraph"
        Series2.ChartArea = "ChartArea1"
        Series2.LabelAngle = 90
        Series2.Name = "Series1"
        DataPoint4.AxisLabel = "1 EnSuite"
        DataPoint4.Label = ""
        DataPoint4.LabelAngle = 90
        DataPoint4.LegendText = "1 EnSuite"
        Series2.Points.Add(DataPoint4)
        Series2.Points.Add(DataPoint5)
        Series2.Points.Add(DataPoint6)
        Me.ReadingGraph.Series.Add(Series2)
        Me.ReadingGraph.Size = New System.Drawing.Size(329, 280)
        Me.ReadingGraph.TabIndex = 1
        Me.ReadingGraph.Text = "Chart1"
        '
        'UpdateGraphButton
        '
        Me.UpdateGraphButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UpdateGraphButton.Location = New System.Drawing.Point(0, 503)
        Me.UpdateGraphButton.Name = "UpdateGraphButton"
        Me.UpdateGraphButton.Size = New System.Drawing.Size(329, 47)
        Me.UpdateGraphButton.TabIndex = 2
        Me.UpdateGraphButton.Text = "Update Graph"
        Me.UpdateGraphButton.UseVisualStyleBackColor = True
        '
        'StatusLabel
        '
        Me.StatusLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusLabel.Location = New System.Drawing.Point(0, 280)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(329, 223)
        Me.StatusLabel.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ReadingGraph)
        Me.SplitContainer1.Panel1.Controls.Add(Me.StatusLabel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.UpdateGraphButton)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.EventList)
        Me.SplitContainer1.Size = New System.Drawing.Size(987, 550)
        Me.SplitContainer1.SplitterDistance = 329
        Me.SplitContainer1.TabIndex = 4
        '
        'EventList
        '
        Me.EventList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.EventList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EventList.Location = New System.Drawing.Point(0, 0)
        Me.EventList.Name = "EventList"
        Me.EventList.Size = New System.Drawing.Size(654, 550)
        Me.EventList.TabIndex = 0
        Me.EventList.UseCompatibleStateImageBehavior = False
        Me.EventList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Time"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Event Description"
        Me.ColumnHeader2.Width = 300
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 550)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.Text = "Temperature Logger"
        CType(Me.ReadingGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents ReadingGraph As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents UpdateGraphButton As System.Windows.Forms.Button
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents EventList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
End Class
