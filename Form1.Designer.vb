﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim ChartArea7 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend7 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea8 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend8 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GUITabControl = New System.Windows.Forms.TabControl()
        Me.InitializationTabPage = New System.Windows.Forms.TabPage()
        Me.ArduinoGroupBox = New System.Windows.Forms.GroupBox()
        Me.ConnectionRefreshButton = New System.Windows.Forms.Button()
        Me.MicrocontrollerConnectionButton = New System.Windows.Forms.Button()
        Me.YAxisConnectionComboBox = New System.Windows.Forms.ComboBox()
        Me.XAxisConnectionComboBox = New System.Windows.Forms.ComboBox()
        Me.YAxisConnectionlabel = New System.Windows.Forms.Label()
        Me.XAxisConnectionLabel = New System.Windows.Forms.Label()
        Me.SimulationTabPage = New System.Windows.Forms.TabPage()
        Me.SimulationModeTabControl = New System.Windows.Forms.TabControl()
        Me.EarthquakeSelectionTabPage = New System.Windows.Forms.TabPage()
        Me.EarthquakeSelectionDGV = New System.Windows.Forms.DataGridView()
        Me.EarthquakeNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SinusoidalSelectionTabPage = New System.Windows.Forms.TabPage()
        Me.SinusoidalSelectionDGV = New System.Windows.Forms.DataGridView()
        Me.FrequencyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AmplitudeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomFileTabPage = New System.Windows.Forms.TabPage()
        Me.CustomYAxisButton = New System.Windows.Forms.Button()
        Me.CustomYAxisFileTextbox = New System.Windows.Forms.TextBox()
        Me.CustomXAxisButton = New System.Windows.Forms.Button()
        Me.CustomXAxisFileTextbox = New System.Windows.Forms.TextBox()
        Me.EarthquakeSimulationControlsGroupBox = New System.Windows.Forms.GroupBox()
        Me.StopSimulationButton = New System.Windows.Forms.Button()
        Me.HomeSimulatorButton = New System.Windows.Forms.Button()
        Me.XYSimulationButton = New System.Windows.Forms.Button()
        Me.YSimulationButton = New System.Windows.Forms.Button()
        Me.XSimulationButton = New System.Windows.Forms.Button()
        Me.SimulationVisualizerGroupBox = New System.Windows.Forms.GroupBox()
        Me.YAxisVisualizationPanel = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.YVisualizationChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.XAxisVisualizationPanel = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.XVisualizationChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.bgWorkerX = New System.ComponentModel.BackgroundWorker()
        Me.bgWorkerY = New System.ComponentModel.BackgroundWorker()
        Me.bgWorkerCustomX = New System.ComponentModel.BackgroundWorker()
        Me.bgWorkerCustomY = New System.ComponentModel.BackgroundWorker()
        Me.FrequencyNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.AmplitudeNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.FrequencyLabel = New System.Windows.Forms.Label()
        Me.AmplitudeLabel = New System.Windows.Forms.Label()
        Me.DurationLabel = New System.Windows.Forms.Label()
        Me.DurationNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.MainPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GUITabControl.SuspendLayout()
        Me.InitializationTabPage.SuspendLayout()
        Me.ArduinoGroupBox.SuspendLayout()
        Me.SimulationTabPage.SuspendLayout()
        Me.SimulationModeTabControl.SuspendLayout()
        Me.EarthquakeSelectionTabPage.SuspendLayout()
        CType(Me.EarthquakeSelectionDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SinusoidalSelectionTabPage.SuspendLayout()
        CType(Me.SinusoidalSelectionDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomFileTabPage.SuspendLayout()
        Me.EarthquakeSimulationControlsGroupBox.SuspendLayout()
        Me.SimulationVisualizerGroupBox.SuspendLayout()
        Me.YAxisVisualizationPanel.SuspendLayout()
        CType(Me.YVisualizationChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XAxisVisualizationPanel.SuspendLayout()
        CType(Me.XVisualizationChart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FrequencyNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmplitudeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DurationNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.TitleLabel)
        Me.MainPanel.Location = New System.Drawing.Point(12, 12)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(1608, 100)
        Me.MainPanel.TabIndex = 2
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.TitleLabel.Location = New System.Drawing.Point(15, 12)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(993, 73)
        Me.TitleLabel.TabIndex = 0
        Me.TitleLabel.Text = "STRONG MOTION SIMULATOR"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(3, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'GUITabControl
        '
        Me.GUITabControl.Controls.Add(Me.InitializationTabPage)
        Me.GUITabControl.Controls.Add(Me.SimulationTabPage)
        Me.GUITabControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GUITabControl.Location = New System.Drawing.Point(12, 118)
        Me.GUITabControl.Name = "GUITabControl"
        Me.GUITabControl.SelectedIndex = 0
        Me.GUITabControl.Size = New System.Drawing.Size(1608, 721)
        Me.GUITabControl.TabIndex = 3
        '
        'InitializationTabPage
        '
        Me.InitializationTabPage.Controls.Add(Me.ArduinoGroupBox)
        Me.InitializationTabPage.Location = New System.Drawing.Point(4, 25)
        Me.InitializationTabPage.Name = "InitializationTabPage"
        Me.InitializationTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.InitializationTabPage.Size = New System.Drawing.Size(1600, 692)
        Me.InitializationTabPage.TabIndex = 0
        Me.InitializationTabPage.Text = "(1) Initialization"
        Me.InitializationTabPage.UseVisualStyleBackColor = True
        '
        'ArduinoGroupBox
        '
        Me.ArduinoGroupBox.Controls.Add(Me.ConnectionRefreshButton)
        Me.ArduinoGroupBox.Controls.Add(Me.MicrocontrollerConnectionButton)
        Me.ArduinoGroupBox.Controls.Add(Me.YAxisConnectionComboBox)
        Me.ArduinoGroupBox.Controls.Add(Me.XAxisConnectionComboBox)
        Me.ArduinoGroupBox.Controls.Add(Me.YAxisConnectionlabel)
        Me.ArduinoGroupBox.Controls.Add(Me.XAxisConnectionLabel)
        Me.ArduinoGroupBox.Location = New System.Drawing.Point(6, 6)
        Me.ArduinoGroupBox.Name = "ArduinoGroupBox"
        Me.ArduinoGroupBox.Size = New System.Drawing.Size(279, 680)
        Me.ArduinoGroupBox.TabIndex = 0
        Me.ArduinoGroupBox.TabStop = False
        Me.ArduinoGroupBox.Text = "Microcontroller Initialization"
        '
        'ConnectionRefreshButton
        '
        Me.ConnectionRefreshButton.Location = New System.Drawing.Point(102, 129)
        Me.ConnectionRefreshButton.Name = "ConnectionRefreshButton"
        Me.ConnectionRefreshButton.Size = New System.Drawing.Size(75, 23)
        Me.ConnectionRefreshButton.TabIndex = 5
        Me.ConnectionRefreshButton.Text = "Refresh"
        Me.ConnectionRefreshButton.UseVisualStyleBackColor = True
        '
        'MicrocontrollerConnectionButton
        '
        Me.MicrocontrollerConnectionButton.Location = New System.Drawing.Point(183, 129)
        Me.MicrocontrollerConnectionButton.Name = "MicrocontrollerConnectionButton"
        Me.MicrocontrollerConnectionButton.Size = New System.Drawing.Size(75, 23)
        Me.MicrocontrollerConnectionButton.TabIndex = 4
        Me.MicrocontrollerConnectionButton.Text = "Connect"
        Me.MicrocontrollerConnectionButton.UseVisualStyleBackColor = True
        '
        'YAxisConnectionComboBox
        '
        Me.YAxisConnectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.YAxisConnectionComboBox.FormattingEnabled = True
        Me.YAxisConnectionComboBox.Location = New System.Drawing.Point(137, 89)
        Me.YAxisConnectionComboBox.Name = "YAxisConnectionComboBox"
        Me.YAxisConnectionComboBox.Size = New System.Drawing.Size(121, 24)
        Me.YAxisConnectionComboBox.TabIndex = 3
        '
        'XAxisConnectionComboBox
        '
        Me.XAxisConnectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.XAxisConnectionComboBox.FormattingEnabled = True
        Me.XAxisConnectionComboBox.Location = New System.Drawing.Point(137, 47)
        Me.XAxisConnectionComboBox.Name = "XAxisConnectionComboBox"
        Me.XAxisConnectionComboBox.Size = New System.Drawing.Size(121, 24)
        Me.XAxisConnectionComboBox.TabIndex = 2
        '
        'YAxisConnectionlabel
        '
        Me.YAxisConnectionlabel.AutoSize = True
        Me.YAxisConnectionlabel.Location = New System.Drawing.Point(14, 92)
        Me.YAxisConnectionlabel.Name = "YAxisConnectionlabel"
        Me.YAxisConnectionlabel.Size = New System.Drawing.Size(117, 16)
        Me.YAxisConnectionlabel.TabIndex = 1
        Me.YAxisConnectionlabel.Text = "Y Axis Connection:"
        '
        'XAxisConnectionLabel
        '
        Me.XAxisConnectionLabel.AutoSize = True
        Me.XAxisConnectionLabel.Location = New System.Drawing.Point(15, 50)
        Me.XAxisConnectionLabel.Name = "XAxisConnectionLabel"
        Me.XAxisConnectionLabel.Size = New System.Drawing.Size(116, 16)
        Me.XAxisConnectionLabel.TabIndex = 0
        Me.XAxisConnectionLabel.Text = "X Axis Connection:"
        '
        'SimulationTabPage
        '
        Me.SimulationTabPage.Controls.Add(Me.SimulationModeTabControl)
        Me.SimulationTabPage.Controls.Add(Me.EarthquakeSimulationControlsGroupBox)
        Me.SimulationTabPage.Controls.Add(Me.SimulationVisualizerGroupBox)
        Me.SimulationTabPage.Location = New System.Drawing.Point(4, 25)
        Me.SimulationTabPage.Name = "SimulationTabPage"
        Me.SimulationTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SimulationTabPage.Size = New System.Drawing.Size(1600, 692)
        Me.SimulationTabPage.TabIndex = 1
        Me.SimulationTabPage.Text = "(2) Simulation"
        Me.SimulationTabPage.UseVisualStyleBackColor = True
        '
        'SimulationModeTabControl
        '
        Me.SimulationModeTabControl.Controls.Add(Me.EarthquakeSelectionTabPage)
        Me.SimulationModeTabControl.Controls.Add(Me.SinusoidalSelectionTabPage)
        Me.SimulationModeTabControl.Controls.Add(Me.CustomFileTabPage)
        Me.SimulationModeTabControl.Location = New System.Drawing.Point(6, 6)
        Me.SimulationModeTabControl.Name = "SimulationModeTabControl"
        Me.SimulationModeTabControl.SelectedIndex = 0
        Me.SimulationModeTabControl.Size = New System.Drawing.Size(279, 486)
        Me.SimulationModeTabControl.TabIndex = 3
        '
        'EarthquakeSelectionTabPage
        '
        Me.EarthquakeSelectionTabPage.Controls.Add(Me.EarthquakeSelectionDGV)
        Me.EarthquakeSelectionTabPage.Location = New System.Drawing.Point(4, 25)
        Me.EarthquakeSelectionTabPage.Name = "EarthquakeSelectionTabPage"
        Me.EarthquakeSelectionTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.EarthquakeSelectionTabPage.Size = New System.Drawing.Size(271, 457)
        Me.EarthquakeSelectionTabPage.TabIndex = 0
        Me.EarthquakeSelectionTabPage.Text = "Earthquake"
        Me.EarthquakeSelectionTabPage.UseVisualStyleBackColor = True
        '
        'EarthquakeSelectionDGV
        '
        Me.EarthquakeSelectionDGV.AllowUserToAddRows = False
        Me.EarthquakeSelectionDGV.AllowUserToDeleteRows = False
        Me.EarthquakeSelectionDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EarthquakeSelectionDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EarthquakeNameColumn})
        Me.EarthquakeSelectionDGV.Location = New System.Drawing.Point(6, 6)
        Me.EarthquakeSelectionDGV.MultiSelect = False
        Me.EarthquakeSelectionDGV.Name = "EarthquakeSelectionDGV"
        Me.EarthquakeSelectionDGV.ReadOnly = True
        Me.EarthquakeSelectionDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.EarthquakeSelectionDGV.Size = New System.Drawing.Size(259, 445)
        Me.EarthquakeSelectionDGV.TabIndex = 0
        '
        'EarthquakeNameColumn
        '
        Me.EarthquakeNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EarthquakeNameColumn.HeaderText = "Earthquake"
        Me.EarthquakeNameColumn.Name = "EarthquakeNameColumn"
        Me.EarthquakeNameColumn.ReadOnly = True
        '
        'SinusoidalSelectionTabPage
        '
        Me.SinusoidalSelectionTabPage.Controls.Add(Me.DurationLabel)
        Me.SinusoidalSelectionTabPage.Controls.Add(Me.DurationNumericUpDown)
        Me.SinusoidalSelectionTabPage.Controls.Add(Me.AmplitudeLabel)
        Me.SinusoidalSelectionTabPage.Controls.Add(Me.FrequencyLabel)
        Me.SinusoidalSelectionTabPage.Controls.Add(Me.AmplitudeNumericUpDown)
        Me.SinusoidalSelectionTabPage.Controls.Add(Me.FrequencyNumericUpDown)
        Me.SinusoidalSelectionTabPage.Controls.Add(Me.SinusoidalSelectionDGV)
        Me.SinusoidalSelectionTabPage.Location = New System.Drawing.Point(4, 25)
        Me.SinusoidalSelectionTabPage.Name = "SinusoidalSelectionTabPage"
        Me.SinusoidalSelectionTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SinusoidalSelectionTabPage.Size = New System.Drawing.Size(271, 457)
        Me.SinusoidalSelectionTabPage.TabIndex = 1
        Me.SinusoidalSelectionTabPage.Text = "Sinusoidal"
        Me.SinusoidalSelectionTabPage.UseVisualStyleBackColor = True
        '
        'SinusoidalSelectionDGV
        '
        Me.SinusoidalSelectionDGV.AllowUserToAddRows = False
        Me.SinusoidalSelectionDGV.AllowUserToDeleteRows = False
        Me.SinusoidalSelectionDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SinusoidalSelectionDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FrequencyColumn, Me.AmplitudeColumn})
        Me.SinusoidalSelectionDGV.Location = New System.Drawing.Point(6, 6)
        Me.SinusoidalSelectionDGV.MultiSelect = False
        Me.SinusoidalSelectionDGV.Name = "SinusoidalSelectionDGV"
        Me.SinusoidalSelectionDGV.ReadOnly = True
        Me.SinusoidalSelectionDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SinusoidalSelectionDGV.Size = New System.Drawing.Size(259, 272)
        Me.SinusoidalSelectionDGV.TabIndex = 1
        Me.SinusoidalSelectionDGV.Visible = False
        '
        'FrequencyColumn
        '
        Me.FrequencyColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FrequencyColumn.HeaderText = "Frequency"
        Me.FrequencyColumn.Name = "FrequencyColumn"
        Me.FrequencyColumn.ReadOnly = True
        '
        'AmplitudeColumn
        '
        Me.AmplitudeColumn.HeaderText = "Amplitude"
        Me.AmplitudeColumn.Name = "AmplitudeColumn"
        Me.AmplitudeColumn.ReadOnly = True
        '
        'CustomFileTabPage
        '
        Me.CustomFileTabPage.Controls.Add(Me.CustomYAxisButton)
        Me.CustomFileTabPage.Controls.Add(Me.CustomYAxisFileTextbox)
        Me.CustomFileTabPage.Controls.Add(Me.CustomXAxisButton)
        Me.CustomFileTabPage.Controls.Add(Me.CustomXAxisFileTextbox)
        Me.CustomFileTabPage.Location = New System.Drawing.Point(4, 25)
        Me.CustomFileTabPage.Name = "CustomFileTabPage"
        Me.CustomFileTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.CustomFileTabPage.Size = New System.Drawing.Size(271, 457)
        Me.CustomFileTabPage.TabIndex = 2
        Me.CustomFileTabPage.Text = "Custom"
        Me.CustomFileTabPage.UseVisualStyleBackColor = True
        '
        'CustomYAxisButton
        '
        Me.CustomYAxisButton.Location = New System.Drawing.Point(6, 91)
        Me.CustomYAxisButton.Name = "CustomYAxisButton"
        Me.CustomYAxisButton.Size = New System.Drawing.Size(75, 23)
        Me.CustomYAxisButton.TabIndex = 3
        Me.CustomYAxisButton.Text = "Y-Axis"
        Me.CustomYAxisButton.UseVisualStyleBackColor = True
        '
        'CustomYAxisFileTextbox
        '
        Me.CustomYAxisFileTextbox.Location = New System.Drawing.Point(6, 63)
        Me.CustomYAxisFileTextbox.Name = "CustomYAxisFileTextbox"
        Me.CustomYAxisFileTextbox.Size = New System.Drawing.Size(259, 22)
        Me.CustomYAxisFileTextbox.TabIndex = 2
        '
        'CustomXAxisButton
        '
        Me.CustomXAxisButton.Location = New System.Drawing.Point(6, 34)
        Me.CustomXAxisButton.Name = "CustomXAxisButton"
        Me.CustomXAxisButton.Size = New System.Drawing.Size(75, 23)
        Me.CustomXAxisButton.TabIndex = 1
        Me.CustomXAxisButton.Text = "X-Axis"
        Me.CustomXAxisButton.UseVisualStyleBackColor = True
        '
        'CustomXAxisFileTextbox
        '
        Me.CustomXAxisFileTextbox.Location = New System.Drawing.Point(6, 6)
        Me.CustomXAxisFileTextbox.Name = "CustomXAxisFileTextbox"
        Me.CustomXAxisFileTextbox.Size = New System.Drawing.Size(259, 22)
        Me.CustomXAxisFileTextbox.TabIndex = 0
        '
        'EarthquakeSimulationControlsGroupBox
        '
        Me.EarthquakeSimulationControlsGroupBox.Controls.Add(Me.StopSimulationButton)
        Me.EarthquakeSimulationControlsGroupBox.Controls.Add(Me.HomeSimulatorButton)
        Me.EarthquakeSimulationControlsGroupBox.Controls.Add(Me.XYSimulationButton)
        Me.EarthquakeSimulationControlsGroupBox.Controls.Add(Me.YSimulationButton)
        Me.EarthquakeSimulationControlsGroupBox.Controls.Add(Me.XSimulationButton)
        Me.EarthquakeSimulationControlsGroupBox.Location = New System.Drawing.Point(6, 498)
        Me.EarthquakeSimulationControlsGroupBox.Name = "EarthquakeSimulationControlsGroupBox"
        Me.EarthquakeSimulationControlsGroupBox.Size = New System.Drawing.Size(279, 188)
        Me.EarthquakeSimulationControlsGroupBox.TabIndex = 2
        Me.EarthquakeSimulationControlsGroupBox.TabStop = False
        Me.EarthquakeSimulationControlsGroupBox.Text = "Simulation Controls"
        '
        'StopSimulationButton
        '
        Me.StopSimulationButton.Location = New System.Drawing.Point(186, 102)
        Me.StopSimulationButton.Name = "StopSimulationButton"
        Me.StopSimulationButton.Size = New System.Drawing.Size(75, 23)
        Me.StopSimulationButton.TabIndex = 5
        Me.StopSimulationButton.Text = "Stop"
        Me.StopSimulationButton.UseVisualStyleBackColor = True
        '
        'HomeSimulatorButton
        '
        Me.HomeSimulatorButton.Location = New System.Drawing.Point(105, 102)
        Me.HomeSimulatorButton.Name = "HomeSimulatorButton"
        Me.HomeSimulatorButton.Size = New System.Drawing.Size(75, 23)
        Me.HomeSimulatorButton.TabIndex = 4
        Me.HomeSimulatorButton.Text = "Home"
        Me.HomeSimulatorButton.UseVisualStyleBackColor = True
        '
        'XYSimulationButton
        '
        Me.XYSimulationButton.Location = New System.Drawing.Point(186, 44)
        Me.XYSimulationButton.Name = "XYSimulationButton"
        Me.XYSimulationButton.Size = New System.Drawing.Size(75, 23)
        Me.XYSimulationButton.TabIndex = 3
        Me.XYSimulationButton.Text = "XY"
        Me.XYSimulationButton.UseVisualStyleBackColor = True
        '
        'YSimulationButton
        '
        Me.YSimulationButton.Location = New System.Drawing.Point(105, 44)
        Me.YSimulationButton.Name = "YSimulationButton"
        Me.YSimulationButton.Size = New System.Drawing.Size(75, 23)
        Me.YSimulationButton.TabIndex = 2
        Me.YSimulationButton.Text = "Y"
        Me.YSimulationButton.UseVisualStyleBackColor = True
        '
        'XSimulationButton
        '
        Me.XSimulationButton.Location = New System.Drawing.Point(24, 44)
        Me.XSimulationButton.Name = "XSimulationButton"
        Me.XSimulationButton.Size = New System.Drawing.Size(75, 23)
        Me.XSimulationButton.TabIndex = 1
        Me.XSimulationButton.Text = "X"
        Me.XSimulationButton.UseVisualStyleBackColor = True
        '
        'SimulationVisualizerGroupBox
        '
        Me.SimulationVisualizerGroupBox.Controls.Add(Me.YAxisVisualizationPanel)
        Me.SimulationVisualizerGroupBox.Controls.Add(Me.XAxisVisualizationPanel)
        Me.SimulationVisualizerGroupBox.Location = New System.Drawing.Point(291, 6)
        Me.SimulationVisualizerGroupBox.Name = "SimulationVisualizerGroupBox"
        Me.SimulationVisualizerGroupBox.Size = New System.Drawing.Size(1303, 680)
        Me.SimulationVisualizerGroupBox.TabIndex = 1
        Me.SimulationVisualizerGroupBox.TabStop = False
        Me.SimulationVisualizerGroupBox.Text = "Simulation Visualizer"
        '
        'YAxisVisualizationPanel
        '
        Me.YAxisVisualizationPanel.Controls.Add(Me.TextBox2)
        Me.YAxisVisualizationPanel.Controls.Add(Me.YVisualizationChart)
        Me.YAxisVisualizationPanel.Location = New System.Drawing.Point(6, 350)
        Me.YAxisVisualizationPanel.Name = "YAxisVisualizationPanel"
        Me.YAxisVisualizationPanel.Size = New System.Drawing.Size(1291, 323)
        Me.YAxisVisualizationPanel.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(1126, 32)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(161, 287)
        Me.TextBox2.TabIndex = 5
        '
        'YVisualizationChart
        '
        ChartArea7.Name = "ChartArea1"
        Me.YVisualizationChart.ChartAreas.Add(ChartArea7)
        Me.YVisualizationChart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend7.Name = "Legend1"
        Me.YVisualizationChart.Legends.Add(Legend7)
        Me.YVisualizationChart.Location = New System.Drawing.Point(0, 0)
        Me.YVisualizationChart.Name = "YVisualizationChart"
        Series7.ChartArea = "ChartArea1"
        Series7.Legend = "Legend1"
        Series7.Name = "Series1"
        Me.YVisualizationChart.Series.Add(Series7)
        Me.YVisualizationChart.Size = New System.Drawing.Size(1291, 323)
        Me.YVisualizationChart.TabIndex = 6
        Me.YVisualizationChart.Text = "Chart1"
        '
        'XAxisVisualizationPanel
        '
        Me.XAxisVisualizationPanel.Controls.Add(Me.PictureBox1)
        Me.XAxisVisualizationPanel.Controls.Add(Me.TextBox1)
        Me.XAxisVisualizationPanel.Controls.Add(Me.XVisualizationChart)
        Me.XAxisVisualizationPanel.Location = New System.Drawing.Point(6, 21)
        Me.XAxisVisualizationPanel.Name = "XAxisVisualizationPanel"
        Me.XAxisVisualizationPanel.Size = New System.Drawing.Size(1291, 323)
        Me.XAxisVisualizationPanel.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1126, 32)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(161, 287)
        Me.TextBox1.TabIndex = 4
        '
        'XVisualizationChart
        '
        ChartArea8.Name = "ChartArea1"
        Me.XVisualizationChart.ChartAreas.Add(ChartArea8)
        Me.XVisualizationChart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend8.Name = "Legend1"
        Me.XVisualizationChart.Legends.Add(Legend8)
        Me.XVisualizationChart.Location = New System.Drawing.Point(0, 0)
        Me.XVisualizationChart.Name = "XVisualizationChart"
        Series8.ChartArea = "ChartArea1"
        Series8.Legend = "Legend1"
        Series8.Name = "Series1"
        Me.XVisualizationChart.Series.Add(Series8)
        Me.XVisualizationChart.Size = New System.Drawing.Size(1291, 323)
        Me.XVisualizationChart.TabIndex = 5
        Me.XVisualizationChart.Text = "Chart1"
        '
        'bgWorkerX
        '
        Me.bgWorkerX.WorkerSupportsCancellation = True
        '
        'bgWorkerY
        '
        Me.bgWorkerY.WorkerSupportsCancellation = True
        '
        'bgWorkerCustomX
        '
        Me.bgWorkerCustomX.WorkerSupportsCancellation = True
        '
        'bgWorkerCustomY
        '
        Me.bgWorkerCustomY.WorkerSupportsCancellation = True
        '
        'FrequencyNumericUpDown
        '
        Me.FrequencyNumericUpDown.DecimalPlaces = 1
        Me.FrequencyNumericUpDown.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.FrequencyNumericUpDown.Location = New System.Drawing.Point(6, 300)
        Me.FrequencyNumericUpDown.Name = "FrequencyNumericUpDown"
        Me.FrequencyNumericUpDown.Size = New System.Drawing.Size(120, 22)
        Me.FrequencyNumericUpDown.TabIndex = 2
        '
        'AmplitudeNumericUpDown
        '
        Me.AmplitudeNumericUpDown.DecimalPlaces = 1
        Me.AmplitudeNumericUpDown.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.AmplitudeNumericUpDown.Location = New System.Drawing.Point(6, 344)
        Me.AmplitudeNumericUpDown.Name = "AmplitudeNumericUpDown"
        Me.AmplitudeNumericUpDown.Size = New System.Drawing.Size(120, 22)
        Me.AmplitudeNumericUpDown.TabIndex = 3
        '
        'FrequencyLabel
        '
        Me.FrequencyLabel.AutoSize = True
        Me.FrequencyLabel.Location = New System.Drawing.Point(6, 281)
        Me.FrequencyLabel.Name = "FrequencyLabel"
        Me.FrequencyLabel.Size = New System.Drawing.Size(101, 16)
        Me.FrequencyLabel.TabIndex = 4
        Me.FrequencyLabel.Text = "Frequency (Hz):"
        '
        'AmplitudeLabel
        '
        Me.AmplitudeLabel.AutoSize = True
        Me.AmplitudeLabel.Location = New System.Drawing.Point(6, 325)
        Me.AmplitudeLabel.Name = "AmplitudeLabel"
        Me.AmplitudeLabel.Size = New System.Drawing.Size(103, 16)
        Me.AmplitudeLabel.TabIndex = 5
        Me.AmplitudeLabel.Text = "Amplitude (mm):"
        '
        'DurationLabel
        '
        Me.DurationLabel.AutoSize = True
        Me.DurationLabel.Location = New System.Drawing.Point(6, 369)
        Me.DurationLabel.Name = "DurationLabel"
        Me.DurationLabel.Size = New System.Drawing.Size(78, 16)
        Me.DurationLabel.TabIndex = 7
        Me.DurationLabel.Text = "Duration (s):"
        '
        'DurationNumericUpDown
        '
        Me.DurationNumericUpDown.Location = New System.Drawing.Point(6, 388)
        Me.DurationNumericUpDown.Name = "DurationNumericUpDown"
        Me.DurationNumericUpDown.Size = New System.Drawing.Size(120, 22)
        Me.DurationNumericUpDown.TabIndex = 6
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1632, 851)
        Me.Controls.Add(Me.GUITabControl)
        Me.Controls.Add(Me.MainPanel)
        Me.Name = "MainForm"
        Me.Text = "Earthquake Simulator V2"
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GUITabControl.ResumeLayout(False)
        Me.InitializationTabPage.ResumeLayout(False)
        Me.ArduinoGroupBox.ResumeLayout(False)
        Me.ArduinoGroupBox.PerformLayout()
        Me.SimulationTabPage.ResumeLayout(False)
        Me.SimulationModeTabControl.ResumeLayout(False)
        Me.EarthquakeSelectionTabPage.ResumeLayout(False)
        CType(Me.EarthquakeSelectionDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SinusoidalSelectionTabPage.ResumeLayout(False)
        Me.SinusoidalSelectionTabPage.PerformLayout()
        CType(Me.SinusoidalSelectionDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomFileTabPage.ResumeLayout(False)
        Me.CustomFileTabPage.PerformLayout()
        Me.EarthquakeSimulationControlsGroupBox.ResumeLayout(False)
        Me.SimulationVisualizerGroupBox.ResumeLayout(False)
        Me.YAxisVisualizationPanel.ResumeLayout(False)
        Me.YAxisVisualizationPanel.PerformLayout()
        CType(Me.YVisualizationChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XAxisVisualizationPanel.ResumeLayout(False)
        Me.XAxisVisualizationPanel.PerformLayout()
        CType(Me.XVisualizationChart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FrequencyNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmplitudeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DurationNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents MainPanel As Panel
    Private WithEvents TitleLabel As Label
    Private WithEvents GUITabControl As TabControl
    Private WithEvents InitializationTabPage As TabPage
    Private WithEvents ArduinoGroupBox As GroupBox
    Private WithEvents ConnectionRefreshButton As Button
    Private WithEvents MicrocontrollerConnectionButton As Button
    Private WithEvents YAxisConnectionComboBox As ComboBox
    Private WithEvents XAxisConnectionComboBox As ComboBox
    Private WithEvents YAxisConnectionlabel As Label
    Private WithEvents XAxisConnectionLabel As Label
    Private WithEvents SimulationTabPage As TabPage
    Private WithEvents EarthquakeSimulationControlsGroupBox As GroupBox
    Private WithEvents StopSimulationButton As Button
    Private WithEvents HomeSimulatorButton As Button
    Private WithEvents XYSimulationButton As Button
    Private WithEvents YSimulationButton As Button
    Private WithEvents XSimulationButton As Button
    Private WithEvents SimulationVisualizerGroupBox As GroupBox
    Private WithEvents YAxisVisualizationPanel As Panel
    Private WithEvents XAxisVisualizationPanel As Panel
    Friend WithEvents bgWorkerX As System.ComponentModel.BackgroundWorker
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents bgWorkerY As System.ComponentModel.BackgroundWorker
    Friend WithEvents XVisualizationChart As DataVisualization.Charting.Chart
    Friend WithEvents YVisualizationChart As DataVisualization.Charting.Chart
    Private WithEvents EarthquakeSelectionDGV As DataGridView
    Private WithEvents EarthquakeNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents SimulationModeTabControl As TabControl
    Friend WithEvents EarthquakeSelectionTabPage As TabPage
    Friend WithEvents SinusoidalSelectionTabPage As TabPage
    Friend WithEvents CustomFileTabPage As TabPage
    Private WithEvents SinusoidalSelectionDGV As DataGridView
    Friend WithEvents FrequencyColumn As DataGridViewTextBoxColumn
    Friend WithEvents AmplitudeColumn As DataGridViewTextBoxColumn
    Friend WithEvents CustomXAxisFileTextbox As TextBox
    Friend WithEvents CustomYAxisButton As Button
    Friend WithEvents CustomYAxisFileTextbox As TextBox
    Friend WithEvents CustomXAxisButton As Button
    Friend WithEvents bgWorkerCustomX As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgWorkerCustomY As System.ComponentModel.BackgroundWorker
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents AmplitudeNumericUpDown As NumericUpDown
    Friend WithEvents FrequencyNumericUpDown As NumericUpDown
    Friend WithEvents AmplitudeLabel As Label
    Friend WithEvents FrequencyLabel As Label
    Friend WithEvents DurationLabel As Label
    Friend WithEvents DurationNumericUpDown As NumericUpDown
End Class
