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
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.GUITabControl = New System.Windows.Forms.TabControl()
        Me.InitializationTabPage = New System.Windows.Forms.TabPage()
        Me.ArduinoGroupBox = New System.Windows.Forms.GroupBox()
        Me.ConnectionRefreshButton = New System.Windows.Forms.Button()
        Me.MicrocontrollerConnectionButton = New System.Windows.Forms.Button()
        Me.YAxisConnectionComboBox = New System.Windows.Forms.ComboBox()
        Me.XAxisConnectionComboBox = New System.Windows.Forms.ComboBox()
        Me.YAxisConnectionlabel = New System.Windows.Forms.Label()
        Me.XAxisConnectionLabel = New System.Windows.Forms.Label()
        Me.EarthquakeTabPage = New System.Windows.Forms.TabPage()
        Me.EarthquakeSimulationControlsGroupBox = New System.Windows.Forms.GroupBox()
        Me.StopSimulationButton = New System.Windows.Forms.Button()
        Me.HomeSimulatorButton = New System.Windows.Forms.Button()
        Me.XYSimulationButton = New System.Windows.Forms.Button()
        Me.YSimulationButton = New System.Windows.Forms.Button()
        Me.XSimulationButton = New System.Windows.Forms.Button()
        Me.EarthquakeSimulationVisualizerGroupBox = New System.Windows.Forms.GroupBox()
        Me.YAxisVisualizationPanel = New System.Windows.Forms.Panel()
        Me.XAxisVisualizationPanel = New System.Windows.Forms.Panel()
        Me.EarthQuakeSelectionGroupBox = New System.Windows.Forms.GroupBox()
        Me.EarthquakeSelectionDGV = New System.Windows.Forms.DataGridView()
        Me.EarthquakeNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SinusoidalTabPage = New System.Windows.Forms.TabPage()
        Me.MainPanel.SuspendLayout()
        Me.GUITabControl.SuspendLayout()
        Me.InitializationTabPage.SuspendLayout()
        Me.ArduinoGroupBox.SuspendLayout()
        Me.EarthquakeTabPage.SuspendLayout()
        Me.EarthquakeSimulationControlsGroupBox.SuspendLayout()
        Me.EarthquakeSimulationVisualizerGroupBox.SuspendLayout()
        Me.EarthQuakeSelectionGroupBox.SuspendLayout()
        CType(Me.EarthquakeSelectionDGV, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GUITabControl
        '
        Me.GUITabControl.Controls.Add(Me.InitializationTabPage)
        Me.GUITabControl.Controls.Add(Me.EarthquakeTabPage)
        Me.GUITabControl.Controls.Add(Me.SinusoidalTabPage)
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
        'EarthquakeTabPage
        '
        Me.EarthquakeTabPage.Controls.Add(Me.EarthquakeSimulationControlsGroupBox)
        Me.EarthquakeTabPage.Controls.Add(Me.EarthquakeSimulationVisualizerGroupBox)
        Me.EarthquakeTabPage.Controls.Add(Me.EarthQuakeSelectionGroupBox)
        Me.EarthquakeTabPage.Location = New System.Drawing.Point(4, 25)
        Me.EarthquakeTabPage.Name = "EarthquakeTabPage"
        Me.EarthquakeTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.EarthquakeTabPage.Size = New System.Drawing.Size(1600, 692)
        Me.EarthquakeTabPage.TabIndex = 1
        Me.EarthquakeTabPage.Text = "(2) Earthquake Simulation"
        Me.EarthquakeTabPage.UseVisualStyleBackColor = True
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
        'EarthquakeSimulationVisualizerGroupBox
        '
        Me.EarthquakeSimulationVisualizerGroupBox.Controls.Add(Me.YAxisVisualizationPanel)
        Me.EarthquakeSimulationVisualizerGroupBox.Controls.Add(Me.XAxisVisualizationPanel)
        Me.EarthquakeSimulationVisualizerGroupBox.Location = New System.Drawing.Point(291, 6)
        Me.EarthquakeSimulationVisualizerGroupBox.Name = "EarthquakeSimulationVisualizerGroupBox"
        Me.EarthquakeSimulationVisualizerGroupBox.Size = New System.Drawing.Size(1303, 680)
        Me.EarthquakeSimulationVisualizerGroupBox.TabIndex = 1
        Me.EarthquakeSimulationVisualizerGroupBox.TabStop = False
        Me.EarthquakeSimulationVisualizerGroupBox.Text = "Earthquake Simulation Visualizer"
        '
        'YAxisVisualizationPanel
        '
        Me.YAxisVisualizationPanel.Location = New System.Drawing.Point(6, 350)
        Me.YAxisVisualizationPanel.Name = "YAxisVisualizationPanel"
        Me.YAxisVisualizationPanel.Size = New System.Drawing.Size(1291, 323)
        Me.YAxisVisualizationPanel.TabIndex = 1
        '
        'XAxisVisualizationPanel
        '
        Me.XAxisVisualizationPanel.Location = New System.Drawing.Point(6, 21)
        Me.XAxisVisualizationPanel.Name = "XAxisVisualizationPanel"
        Me.XAxisVisualizationPanel.Size = New System.Drawing.Size(1291, 323)
        Me.XAxisVisualizationPanel.TabIndex = 0
        '
        'EarthQuakeSelectionGroupBox
        '
        Me.EarthQuakeSelectionGroupBox.Controls.Add(Me.EarthquakeSelectionDGV)
        Me.EarthQuakeSelectionGroupBox.Location = New System.Drawing.Point(6, 6)
        Me.EarthQuakeSelectionGroupBox.Name = "EarthQuakeSelectionGroupBox"
        Me.EarthQuakeSelectionGroupBox.Size = New System.Drawing.Size(279, 486)
        Me.EarthQuakeSelectionGroupBox.TabIndex = 0
        Me.EarthQuakeSelectionGroupBox.TabStop = False
        Me.EarthQuakeSelectionGroupBox.Text = "Earthquake Selection"
        '
        'EarthquakeSelectionDGV
        '
        Me.EarthquakeSelectionDGV.AllowUserToAddRows = False
        Me.EarthquakeSelectionDGV.AllowUserToDeleteRows = False
        Me.EarthquakeSelectionDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EarthquakeSelectionDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EarthquakeNameColumn})
        Me.EarthquakeSelectionDGV.Location = New System.Drawing.Point(6, 21)
        Me.EarthquakeSelectionDGV.MultiSelect = False
        Me.EarthquakeSelectionDGV.Name = "EarthquakeSelectionDGV"
        Me.EarthquakeSelectionDGV.ReadOnly = True
        Me.EarthquakeSelectionDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.EarthquakeSelectionDGV.Size = New System.Drawing.Size(267, 459)
        Me.EarthquakeSelectionDGV.TabIndex = 0
        '
        'EarthquakeNameColumn
        '
        Me.EarthquakeNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EarthquakeNameColumn.HeaderText = "Earthquake"
        Me.EarthquakeNameColumn.Name = "EarthquakeNameColumn"
        Me.EarthquakeNameColumn.ReadOnly = True
        '
        'SinusoidalTabPage
        '
        Me.SinusoidalTabPage.Location = New System.Drawing.Point(4, 25)
        Me.SinusoidalTabPage.Name = "SinusoidalTabPage"
        Me.SinusoidalTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SinusoidalTabPage.Size = New System.Drawing.Size(1600, 692)
        Me.SinusoidalTabPage.TabIndex = 2
        Me.SinusoidalTabPage.Text = "(3) Sinusoidal Wave Simulation"
        Me.SinusoidalTabPage.UseVisualStyleBackColor = True
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
        Me.GUITabControl.ResumeLayout(False)
        Me.InitializationTabPage.ResumeLayout(False)
        Me.ArduinoGroupBox.ResumeLayout(False)
        Me.ArduinoGroupBox.PerformLayout()
        Me.EarthquakeTabPage.ResumeLayout(False)
        Me.EarthquakeSimulationControlsGroupBox.ResumeLayout(False)
        Me.EarthquakeSimulationVisualizerGroupBox.ResumeLayout(False)
        Me.EarthQuakeSelectionGroupBox.ResumeLayout(False)
        CType(Me.EarthquakeSelectionDGV, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents EarthquakeTabPage As TabPage
    Private WithEvents EarthquakeSimulationControlsGroupBox As GroupBox
    Private WithEvents StopSimulationButton As Button
    Private WithEvents HomeSimulatorButton As Button
    Private WithEvents XYSimulationButton As Button
    Private WithEvents YSimulationButton As Button
    Private WithEvents XSimulationButton As Button
    Private WithEvents EarthquakeSimulationVisualizerGroupBox As GroupBox
    Private WithEvents YAxisVisualizationPanel As Panel
    Private WithEvents XAxisVisualizationPanel As Panel
    Private WithEvents EarthQuakeSelectionGroupBox As GroupBox
    Private WithEvents EarthquakeSelectionDGV As DataGridView
    Private WithEvents EarthquakeNameColumn As DataGridViewTextBoxColumn
    Private WithEvents SinusoidalTabPage As TabPage
End Class
