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
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint1 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, 10.0R)
        Dim DataPoint2 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, 0.0R)
        Dim DataPoint3 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, 0.0R)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "En Suite", "", ""}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"2", "", "", ""}, -1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"3", "", "", ""}, -1)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"4", "", "", ""}, -1)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"5", "", "", ""}, -1)
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"6", "", "", ""}, -1)
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"7", "", "", ""}, -1)
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"8", "", "", ""}, -1)
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"9", "", "", ""}, -1)
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"10", "", "", ""}, -1)
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"11", "", "", ""}, -1)
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"12", "", "", ""}, -1)
        Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"13", "", "", ""}, -1)
        Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"14", "", "", ""}, -1)
        Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"15", "", "", ""}, -1)
        Dim ListViewItem16 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"16", "", "", ""}, -1)
        Dim ListViewItem17 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"17", "", "", ""}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ReadingGraph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.EventList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UpdateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LatestEvents = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.ReadingGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReadingGraph
        '
        ChartArea1.AxisX.IsStartedFromZero = False
        ChartArea1.Name = "ChartArea1"
        Me.ReadingGraph.ChartAreas.Add(ChartArea1)
        Me.ReadingGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReadingGraph.Location = New System.Drawing.Point(0, 0)
        Me.ReadingGraph.Name = "ReadingGraph"
        Series1.ChartArea = "ChartArea1"
        Series1.LabelAngle = 90
        Series1.Name = "Series1"
        DataPoint1.AxisLabel = "1 EnSuite"
        DataPoint1.Label = ""
        DataPoint1.LabelAngle = 90
        DataPoint1.LegendText = "1 EnSuite"
        Series1.Points.Add(DataPoint1)
        Series1.Points.Add(DataPoint2)
        Series1.Points.Add(DataPoint3)
        Me.ReadingGraph.Series.Add(Series1)
        Me.ReadingGraph.Size = New System.Drawing.Size(329, 327)
        Me.ReadingGraph.TabIndex = 1
        Me.ReadingGraph.Text = "Chart1"
        '
        'StatusLabel
        '
        Me.StatusLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusLabel.Location = New System.Drawing.Point(0, 327)
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
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.EventList)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LatestEvents)
        Me.SplitContainer1.Size = New System.Drawing.Size(987, 550)
        Me.SplitContainer1.SplitterDistance = 329
        Me.SplitContainer1.TabIndex = 4
        '
        'EventList
        '
        Me.EventList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.EventList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EventList.Location = New System.Drawing.Point(0, 327)
        Me.EventList.Name = "EventList"
        Me.EventList.Size = New System.Drawing.Size(654, 223)
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
        'UpdateTimer
        '
        Me.UpdateTimer.Enabled = True
        Me.UpdateTimer.Interval = 2000
        '
        'LatestEvents
        '
        Me.LatestEvents.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.LatestEvents.Dock = System.Windows.Forms.DockStyle.Top
        Me.LatestEvents.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15, ListViewItem16, ListViewItem17})
        Me.LatestEvents.Location = New System.Drawing.Point(0, 0)
        Me.LatestEvents.Name = "LatestEvents"
        Me.LatestEvents.Size = New System.Drawing.Size(654, 327)
        Me.LatestEvents.TabIndex = 1
        Me.LatestEvents.UseCompatibleStateImageBehavior = False
        Me.LatestEvents.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Relay"
        Me.ColumnHeader3.Width = 45
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Last Time"
        Me.ColumnHeader4.Width = 140
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Temperature"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Name"
        Me.ColumnHeader6.Width = 180
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
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents EventList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents UpdateTimer As System.Windows.Forms.Timer
    Friend WithEvents LatestEvents As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
End Class
