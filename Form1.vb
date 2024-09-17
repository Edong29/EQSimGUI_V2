Imports System.ComponentModel
Imports System.IO
Imports System.IO.Ports
Imports System.Windows.Forms.DataVisualization.Charting

Public Class MainForm
#Region "Properties"
    ' SerialPort objects for two Arduinos
    Private WithEvents XAxisSerialPort As New SerialPort
    Private WithEvents YAxisSerialPort As New SerialPort

    ' Properties to track connection status
    Public Property IsConnectedToXAxisCOM As Boolean = False
    Public Property IsConnectedToYAxisCOM As Boolean = False

    Public Property CustomXAxisFilename As String
    Public Property CustomYAxisFilename As String

    Public Property GCodeXAxisList As List(Of String)

    Public Property GCodeYAxisList As List(Of String)

#End Region


#Region "Events"
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeComPorts()
        FillEarthquakeSelection()
        FillFrequencySelection()
    End Sub

    Private Sub MicrocontrollerConnectionButton_Click(sender As Object, e As EventArgs) Handles MicrocontrollerConnectionButton.Click
        CloseConnection()
        ' Connect to Arduino 1 (X axis)
        If XAxisConnectionComboBox.SelectedItem IsNot Nothing Then
            Try
                With XAxisSerialPort
                    .PortName = XAxisConnectionComboBox.SelectedItem.ToString()
                    .BaudRate = 115200
                    .DataBits = 8
                    .Parity = Parity.None
                    .StopBits = StopBits.One
                    .DtrEnable = True
                    .Open()
                    'Threading.Thread.Sleep(10)
                    '.Write(vbCr & vbNewLine & vbCr & vbNewLine)
                End With
                'XAxisSerialPort.PortName = XAxisConnectionComboBox.SelectedItem.ToString()
                'XAxisSerialPort.BaudRate = 9600  ' Set the appropriate baud rate
                'XAxisSerialPort.Open()
                IsConnectedToXAxisCOM = True
                XAxisSerialPort.WriteLine("$100 = 29.78")
                MessageBox.Show("Connected to Arduino 1 (X axis) on " & XAxisSerialPort.PortName)
            Catch ex As Exception
                MessageBox.Show("Failed to connect to Arduino 1: " & ex.Message)
            End Try
        End If

        ' Connect to Arduino 2 (Y axis)
        If YAxisConnectionComboBox.SelectedItem IsNot Nothing Then
            Try
                With YAxisSerialPort
                    .PortName = YAxisConnectionComboBox.SelectedItem.ToString()
                    .BaudRate = 115200
                    .DataBits = 8
                    .Parity = Parity.None
                    .StopBits = StopBits.One
                    .DtrEnable = True
                    .Open()
                    'Threading.Thread.Sleep(10)
                    '.Write(vbCr & vbNewLine & vbCr & vbNewLine)
                End With
                'YAxisSerialPort.PortName = YAxisConnectionComboBox.SelectedItem.ToString()
                'YAxisSerialPort.BaudRate = 9600  ' Set the appropriate baud rate
                'YAxisSerialPort.Open()
                IsConnectedToYAxisCOM = True
                'YAxisSerialPort.WriteLine("$101 = 29.78")
                Dim text = YAxisSerialPort.ReadLine()
                MessageBox.Show("Connected to Arduino 2 (Y axis) on " & YAxisSerialPort.PortName)
            Catch ex As Exception
                MessageBox.Show("Failed to connect to Arduino 2: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CloseConnection()
    End Sub

    Private Sub ConnectionRefreshButton_Click(sender As Object, e As EventArgs) Handles ConnectionRefreshButton.Click
        CloseConnection()
        InitializeComPorts()
    End Sub

    Private Sub SimulationControlsButton_Click(sender As Object, e As EventArgs) Handles XSimulationButton.Click, YSimulationButton.Click, XYSimulationButton.Click, HomeSimulatorButton.Click, StopSimulationButton.Click
        ' Determine which button was clicked
        Dim clickedButton As Button = TryCast(sender, Button)

        If clickedButton IsNot Nothing Then
            Select Case clickedButton.Name
                Case XSimulationButton.Name
                    ' Check the selected tab
                    If SimulationModeTabControl.SelectedTab Is EarthquakeSelectionTabPage Then
                        ' Earthquake tab selected
                        If EarthquakeSelectionDGV.SelectedRows.Count > 0 Then
                            Dim selectedEarthquake As String = EarthquakeSelectionDGV.SelectedRows(0).Cells(0).Value.ToString()
                            Dim filePath As String = $"C:\Earthquakes\{selectedEarthquake}X.txt"
                            XVisualizationChart.Series.Clear()
                            YVisualizationChart.Series.Clear()


                            If File.Exists(filePath) Then
                                ReadAndDisplayXData(filePath)

                                If IsConnectedToXAxisCOM Then
                                    ' Send initial G-code commands
                                    XAxisSerialPort.WriteLine("$100 = 29.78")
                                    XAxisSerialPort.WriteLine("G90 G21 G94")

                                    ' Start BackgroundWorker to read file and write to serial port
                                    If Not bgWorkerX.IsBusy Then
                                        bgWorkerX.RunWorkerAsync(filePath)
                                    End If
                                Else
                                    MessageBox.Show("X axis COM port is not connected.")
                                End If
                            Else
                                MessageBox.Show($"File {filePath} not found.")
                            End If
                        Else
                            MessageBox.Show("Please select an earthquake.")
                        End If

                    ElseIf SimulationModeTabControl.SelectedTab Is SinusoidalSelectionTabPage Then
                        ' Sinusoidal tab selected
                        If SinusoidalSelectionDGV.SelectedRows.Count > 0 Then
                            Dim frequency As String = SinusoidalSelectionDGV.SelectedRows(0).Cells(0).Value.ToString()
                            Dim amplitude As String = SinusoidalSelectionDGV.SelectedRows(0).Cells(1).Value.ToString()
                            Dim filePath As String = $"C:\Earthquakes\Frequencies\{frequency} {amplitude}.txt"
                            XVisualizationChart.Series.Clear()
                            YVisualizationChart.Series.Clear()

                            If File.Exists(filePath) Then
                                Dim xValues = ReadAndDisplayXData(filePath)
                                ' Assuming data is loaded into a list or array called "amplitudeData"
                                Dim maxAmplitude As Double = xValues.Max()
                                Dim minAmplitude As Double = xValues.Min()

                                ' Update the chart's Y-axis
                                XVisualizationChart.ChartAreas(0).AxisY.Maximum = maxAmplitude + 2 ' Add some padding
                                XVisualizationChart.ChartAreas(0).AxisY.Minimum = minAmplitude - 2 ' Add some padding


                                If IsConnectedToXAxisCOM Then
                                    ' Send initial G-code commands
                                    XAxisSerialPort.WriteLine("$100 = 29.78")
                                    XAxisSerialPort.WriteLine("G90 G21 G94")

                                    ' Start BackgroundWorker to read file and write to serial port
                                    If Not bgWorkerX.IsBusy Then
                                        bgWorkerX.RunWorkerAsync(filePath)
                                    End If
                                Else
                                    MessageBox.Show("X axis COM port is not connected.")
                                End If
                            Else
                                MessageBox.Show($"File {filePath} not found.")
                            End If
                        Else
                            MessageBox.Show("Please select frequency and amplitude.")
                        End If

                    ElseIf SimulationModeTabControl.SelectedTab Is CustomFileTabPage Then
                        ' Custom tab selected
                        ' Add your custom simulation logic here
                        If File.Exists(CustomXAxisFilename) Then
                            Dim xValues = ReadAndDisplayCustomXData(GCodeXAxisList)

                            If IsConnectedToXAxisCOM Then
                                ' Send initial G-code commands
                                XAxisSerialPort.WriteLine("$100 = 29.78")
                                XAxisSerialPort.WriteLine("G90 G21 G94")

                                ' Start BackgroundWorker to read file and write to serial port
                                If Not bgWorkerCustomX.IsBusy Then
                                    bgWorkerCustomX.RunWorkerAsync(GCodeXAxisList)
                                End If
                            Else
                                MessageBox.Show("X axis COM port is not connected.")
                            End If
                        Else
                            MessageBox.Show($"File {CustomXAxisFilename} not found.")
                        End If
                    End If


                Case YSimulationButton.Name
                    ' Check the selected tab
                    If SimulationModeTabControl.SelectedTab Is EarthquakeSelectionTabPage Then
                        If EarthquakeSelectionDGV.SelectedRows.Count > 0 Then
                            Dim selectedEarthquake As String = EarthquakeSelectionDGV.SelectedRows(0).Cells(0).Value.ToString()
                            Dim filePath As String = $"C:\Earthquakes\{selectedEarthquake}Y.txt"
                            XVisualizationChart.Series.Clear()
                            YVisualizationChart.Series.Clear()

                            If File.Exists(filePath) Then
                                ReadAndDisplayYData(filePath)
                                If IsConnectedToYAxisCOM Then
                                    ' Send initial G-code commands
                                    'YAxisSerialPort.WriteLine("$101 = 29.78")
                                    YAxisSerialPort.WriteLine("G90 G21 G94")

                                    ' Start BackgroundWorker to read file and write to serial port
                                    If Not bgWorkerY.IsBusy Then
                                        bgWorkerY.RunWorkerAsync(filePath)
                                    End If
                                Else
                                    MessageBox.Show("Y axis COM port is not connected.")
                                End If
                            Else
                                MessageBox.Show($"File {filePath} not found.")
                            End If
                        Else
                            MessageBox.Show("Please select an earthquake.")
                        End If

                    ElseIf SimulationModeTabControl.SelectedTab Is CustomFileTabPage Then
                        ' Custom tab selected
                        ' Add your custom simulation logic here
                        If File.Exists(CustomYAxisFilename) Then
                            ReadAndDisplayCustomYData(GCodeYAxisList)

                            If IsConnectedToYAxisCOM Then
                                ' Send initial G-code commands
                                YAxisSerialPort.WriteLine("$101 = 29.78")
                                YAxisSerialPort.WriteLine("G90 G21 G94")

                                ' Start BackgroundWorker to read file and write to serial port
                                If Not bgWorkerCustomY.IsBusy Then
                                    bgWorkerCustomY.RunWorkerAsync(GCodeYAxisList)
                                End If
                            Else
                                MessageBox.Show("Y axis COM port is not connected.")
                            End If
                        Else
                            MessageBox.Show($"File {CustomYAxisFilename} not found.")
                        End If
                    End If
                    ' Get the selected earthquake from the DataGridView


                Case XYSimulationButton.Name
                    XSimulationButton.PerformClick()
                    YSimulationButton.PerformClick()

                Case HomeSimulatorButton.Name
                    'If XAxisSerialPort.IsOpen Then
                    '    XAxisSerialPort.WriteLine("G01 X200 F2000")
                    '    TextBox1.Text = XAxisSerialPort.ReadLine()
                    'End If
                    'If YAxisSerialPort.IsOpen Then
                    '    YAxisSerialPort.WriteLine("G01 Y360 F3600")
                    'End If

                    If IsConnectedToXAxisCOM Then
                        XAxisSerialPort.WriteLine("G90 G21 G94")
                        XAxisSerialPort.WriteLine("G01 X200 F2000")
                        TextBox1.AppendText(XAxisSerialPort.ReadLine()) ' Updates the TextBox safely
                    Else
                        'MessageBox.Show("X axis COM port is not connected.")
                    End If

                    If IsConnectedToYAxisCOM Then
                        YAxisSerialPort.WriteLine("G90 G21 G94")
                        YAxisSerialPort.WriteLine("G01 Y360 F3600")
                        TextBox2.AppendText(YAxisSerialPort.ReadLine()) ' Updates the TextBox safely
                    Else
                        'MessageBox.Show("Y axis COM port is not connected.")
                    End If

                Case StopSimulationButton.Name
                    ' Logic for StopSimulationButton click
                    ' Add logic to stop the simulation if running

                    If SimulationModeTabControl.SelectedTab Is EarthquakeSelectionTabPage Or SimulationModeTabControl.SelectedTab Is SinusoidalSelectionTabPage Then
                        If bgWorkerX.IsBusy Then
                            bgWorkerX.CancelAsync()
                        End If

                        If bgWorkerY.IsBusy Then
                            bgWorkerY.CancelAsync()
                        End If
                    ElseIf SimulationModeTabControl.SelectedTab Is CustomFileTabPage Then
                        If bgWorkerCustomX.IsBusy Then
                            bgWorkerCustomX.CancelAsync()
                        End If

                        If bgWorkerCustomY.IsBusy Then
                            bgWorkerCustomY.CancelAsync()
                        End If

                    End If



                Case Else
                    ' Do nothing
            End Select
        End If
    End Sub

    Private Sub bgWorkerX_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWorkerX.DoWork
        Dim filePath As String = DirectCast(e.Argument, String)
        Try
            Dim objReader As New System.IO.StreamReader(filePath)
            Do While objReader.Peek() >= 0
                Dim line As String = objReader.ReadLine
                'value = str.Split(" ")
                If bgWorkerX.CancellationPending Then
                    e.Cancel = True
                Else
                    Dim readbuffer = XAxisSerialPort.ReadLine()
                    If readbuffer.IndexOf("ok") >= 0 Then
                        'XChart.Series(0).Points.AddY(value(1) - 200) 'displays the gcode line of codes being read by the arduino to a chart
                        ' Use Invoke to update the TextBox on the UI thread
                        Me.Invoke(Sub()
                                      TextBox1.AppendText(line & vbNewLine) ' Updates the TextBox safely
                                  End Sub)
                        XAxisSerialPort.WriteLine(line) 'sends Gcode to arduino
                        ' Wait for 10 milliseconds (simulate time interval)
                        'Threading.Thread.Sleep(10)
                    End If

                End If
            Loop
        Catch ex As Exception
            MessageBox.Show("Error during simulation: " & ex.Message)
        End Try
    End Sub
    Private Sub bgWorkerX_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorkerX.RunWorkerCompleted
        If e.Cancelled Then
            MessageBox.Show("Simulation was stopped.")
        ElseIf e.Error IsNot Nothing Then
            MessageBox.Show("Error: " & e.Error.Message)
        Else
            MessageBox.Show("Simulation completed successfully.")
        End If
    End Sub

    Private Sub bgWorkerY_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWorkerY.DoWork
        Dim filePath As String = DirectCast(e.Argument, String)
        Try
            Dim objReader As New System.IO.StreamReader(filePath)
            Do While objReader.Peek() >= 0
                Dim line As String = objReader.ReadLine
                'value = str.Split(" ")
                If bgWorkerY.CancellationPending Then
                    e.Cancel = True
                Else
                    Dim readbuffer = YAxisSerialPort.ReadLine()
                    If readbuffer.IndexOf("ok") >= 0 Then
                        'XChart.Series(0).Points.AddY(value(1) - 200) 'displays the gcode line of codes being read by the arduino to a chart
                        ' Use Invoke to update the TextBox on the UI thread
                        Me.Invoke(Sub()
                                      TextBox2.AppendText(line & vbNewLine) ' Updates the TextBox safely
                                  End Sub)
                        YAxisSerialPort.WriteLine(line) 'sends Gcode to arduino
                        'Wait for 10 milliseconds (simulate time interval)
                        'Threading.Thread.Sleep(1)
                    End If
                End If
            Loop
        Catch ex As Exception
            MessageBox.Show("Error during simulation: " & ex.Message)
        End Try
    End Sub
    Private Sub bgWorkerY_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorkerY.RunWorkerCompleted
        If e.Cancelled Then
            MessageBox.Show("Simulation was stopped.")
        ElseIf e.Error IsNot Nothing Then
            MessageBox.Show("Error: " & e.Error.Message)
        Else
            MessageBox.Show("Simulation completed successfully.")
        End If
    End Sub

    Private Sub bgWorkerCustomX_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWorkerCustomX.DoWork
        Dim gcodeLines As List(Of String) = DirectCast(e.Argument, List(Of String))
        Try
            For Each line As String In gcodeLines
                ' Check if the background worker is being cancelled
                If bgWorkerCustomX.CancellationPending Then
                    e.Cancel = True
                    Exit For
                Else
                    ' Simulate reading from the serial port (or just check for the "ok" response)
                    Dim readbuffer As String = XAxisSerialPort.ReadLine()
                    If readbuffer.IndexOf("ok") >= 0 Then
                        ' Use Invoke to update the TextBox on the UI thread
                        Me.Invoke(Sub()
                                      TextBox1.AppendText(line & vbNewLine) ' Updates the TextBox safely
                                  End Sub)

                        ' Send the G-code line to the Arduino
                        XAxisSerialPort.WriteLine(line)

                        ' Wait for 10 milliseconds (simulate time interval)
                        'Threading.Thread.Sleep(10)
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error during simulation: " & ex.Message)
        End Try
    End Sub

    Private Sub bgWorkerCustomX_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorkerCustomX.RunWorkerCompleted
        If e.Cancelled Then
            MessageBox.Show("Simulation was stopped.")
        ElseIf e.Error IsNot Nothing Then
            MessageBox.Show("Error: " & e.Error.Message)
        Else
            MessageBox.Show("Simulation completed successfully.")
        End If
    End Sub

    Private Sub bgWorkerCustomY_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWorkerCustomY.DoWork
        Dim gcodeLines As List(Of String) = DirectCast(e.Argument, List(Of String))
        Try
            For Each line As String In gcodeLines
                ' Check if the background worker is being cancelled
                If bgWorkerCustomY.CancellationPending Then
                    e.Cancel = True
                    Exit For
                Else
                    ' Simulate reading from the serial port (or just check for the "ok" response)
                    Dim readbuffer As String = YAxisSerialPort.ReadLine()
                    If readbuffer.IndexOf("ok") >= 0 Then
                        ' Use Invoke to update the TextBox on the UI thread
                        Me.Invoke(Sub()
                                      TextBox2.AppendText(line & vbNewLine) ' Updates the TextBox safely
                                  End Sub)

                        ' Send the G-code line to the Arduino
                        YAxisSerialPort.WriteLine(line)

                        ' Wait for 10 milliseconds (simulate time interval)
                        'Threading.Thread.Sleep(1)
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error during simulation: " & ex.Message)
        End Try
    End Sub

    Private Sub bgWorkerCustomY_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorkerCustomY.RunWorkerCompleted
        If e.Cancelled Then
            MessageBox.Show("Simulation was stopped.")
        ElseIf e.Error IsNot Nothing Then
            MessageBox.Show("Error: " & e.Error.Message)
        Else
            MessageBox.Show("Simulation completed successfully.")
        End If
    End Sub


    Private Sub SimulationModeTabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SimulationModeTabControl.SelectedIndexChanged

        If SimulationModeTabControl.SelectedTab Is SinusoidalSelectionTabPage Then
            XYSimulationButton.Enabled = False
            YSimulationButton.Enabled = False
        ElseIf SimulationModeTabControl.SelectedTab Is CustomFileTabPage Or SimulationModeTabControl.SelectedTab Is EarthquakeSelectionTabPage Then
            XYSimulationButton.Enabled = True
            YSimulationButton.Enabled = True
        End If
    End Sub

    Private Sub CustomXAxisButton_Click(sender As Object, e As EventArgs) Handles CustomXAxisButton.Click
        MessageBox.Show("Please select a file containing acceleration data.", "Select Acceleration Data", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|Data Files (*.dat)|*.dat|All Files (*.*)|*.*"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            CustomXAxisFilename = openFileDialog.FileName


            GCodeXAxisList = ConvertToXAxisGCode(CustomXAxisFilename)

            ' Get only the filename and add it to the RecordingTitleListBox
            CustomXAxisFileTextbox.Clear()
            Dim fileName As String = Path.GetFileName(CustomXAxisFilename)
            CustomXAxisFileTextbox.Text = fileName
        End If
    End Sub
    Private Sub CustomYAxisButton_Click(sender As Object, e As EventArgs) Handles CustomYAxisButton.Click
        MessageBox.Show("Please select a file containing acceleration data.", "Select Acceleration Data", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|Data Files (*.dat)|*.dat|All Files (*.*)|*.*"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            CustomYAxisFilename = openFileDialog.FileName


            GCodeYAxisList = ConvertToYAxisGCode(CustomYAxisFilename)

            ' Get only the filename and add it to the RecordingTitleListBox
            CustomYAxisFileTextbox.Clear()
            Dim fileName As String = Path.GetFileName(CustomYAxisFilename)
            CustomYAxisFileTextbox.Text = fileName
        End If
    End Sub

#End Region

#Region "Functions"
    Private Sub InitializeComPorts()
        ' Get all available COM ports
        Dim comPorts As String() = SerialPort.GetPortNames()

        ' Add COM ports to ComboBox1
        XAxisConnectionComboBox.Items.Clear()
        XAxisConnectionComboBox.Items.AddRange(comPorts)

        ' Add COM ports to ComboBox2
        YAxisConnectionComboBox.Items.Clear()
        YAxisConnectionComboBox.Items.AddRange(comPorts)
    End Sub

    Private Sub CloseConnection()
        'If IsConnectedToXAxisCOM AndAlso XAxisSerialPort.IsOpen Then
        If XAxisSerialPort.IsOpen Then
            XAxisSerialPort.Close()
            IsConnectedToXAxisCOM = False
        End If

        'If IsConnectedToYAxisCOM AndAlso YAxisSerialPort.IsOpen Then
        If YAxisSerialPort.IsOpen Then
            YAxisSerialPort.Close()
            IsConnectedToYAxisCOM = False
        End If
    End Sub

    Private Sub FillEarthquakeSelection()
        EarthquakeSelectionDGV.Rows.Clear()
        EarthquakeSelectionDGV.Rows.Add("Kobe")
        EarthquakeSelectionDGV.Rows.Add("Northridge")
        EarthquakeSelectionDGV.Rows.Add("LomaPrieta")
        EarthquakeSelectionDGV.Rows.Add("Landers")
        EarthquakeSelectionDGV.Rows.Add("ChiChi")
        EarthquakeSelectionDGV.Rows.Add("Hollister")
        EarthquakeSelectionDGV.Rows.Add("ImperialValley")
    End Sub

    Private Sub FillFrequencySelection()
        SinusoidalSelectionDGV.Rows.Clear()
        '2mm
        SinusoidalSelectionDGV.Rows.Add("0.5Hz", "2mm")
        SinusoidalSelectionDGV.Rows.Add("1.0Hz", "2mm")
        SinusoidalSelectionDGV.Rows.Add("1.5Hz", "2mm")
        SinusoidalSelectionDGV.Rows.Add("2.0Hz", "2mm")
        SinusoidalSelectionDGV.Rows.Add("2.5Hz", "2mm")
        SinusoidalSelectionDGV.Rows.Add("3.0Hz", "2mm")
        SinusoidalSelectionDGV.Rows.Add("3.5Hz", "2mm")
        SinusoidalSelectionDGV.Rows.Add("4.0Hz", "2mm")
        SinusoidalSelectionDGV.Rows.Add("4.5Hz", "2mm")
        SinusoidalSelectionDGV.Rows.Add("5.0Hz", "2mm")
        SinusoidalSelectionDGV.Rows.Add("5.5Hz", "2mm")
        SinusoidalSelectionDGV.Rows.Add("6.0Hz", "2mm")
        '4mm
        SinusoidalSelectionDGV.Rows.Add("0.5Hz", "4mm")
        SinusoidalSelectionDGV.Rows.Add("1.0Hz", "4mm")
        SinusoidalSelectionDGV.Rows.Add("1.5Hz", "4mm")
        SinusoidalSelectionDGV.Rows.Add("2.0Hz", "4mm")
        SinusoidalSelectionDGV.Rows.Add("2.5Hz", "4mm")
        SinusoidalSelectionDGV.Rows.Add("3.0Hz", "4mm")
        SinusoidalSelectionDGV.Rows.Add("3.5Hz", "4mm")
        SinusoidalSelectionDGV.Rows.Add("4.0Hz", "4mm")
        SinusoidalSelectionDGV.Rows.Add("4.5Hz", "4mm")
        SinusoidalSelectionDGV.Rows.Add("5.0Hz", "4mm")
        SinusoidalSelectionDGV.Rows.Add("5.5Hz", "4mm")
        SinusoidalSelectionDGV.Rows.Add("6.0Hz", "4mm")
        '6mm
        SinusoidalSelectionDGV.Rows.Add("0.5Hz", "6mm")
        SinusoidalSelectionDGV.Rows.Add("1.0Hz", "6mm")
        SinusoidalSelectionDGV.Rows.Add("1.5Hz", "6mm")
        SinusoidalSelectionDGV.Rows.Add("2.0Hz", "6mm")
        SinusoidalSelectionDGV.Rows.Add("2.5Hz", "6mm")
        SinusoidalSelectionDGV.Rows.Add("3.0Hz", "6mm")
        SinusoidalSelectionDGV.Rows.Add("3.5Hz", "6mm")
        SinusoidalSelectionDGV.Rows.Add("4.0Hz", "6mm")
        SinusoidalSelectionDGV.Rows.Add("4.5Hz", "6mm")
        SinusoidalSelectionDGV.Rows.Add("5.0Hz", "6mm")
        SinusoidalSelectionDGV.Rows.Add("5.5Hz", "6mm")
        SinusoidalSelectionDGV.Rows.Add("6.0Hz", "6mm")
    End Sub

    Private Function ReadAndDisplayXData(filePath As String) As List(Of Double)
        ' Clear previous chart data
        XVisualizationChart.Series.Clear()

        ' Create a new series for the chart
        Dim series As New Series("X Motion Data")
        series.ChartType = SeriesChartType.FastLine
        XVisualizationChart.Series.Add(series)


        Dim xValues As New List(Of Double)

        Try
            ' Read all lines from the file
            Dim lines As String() = File.ReadAllLines(filePath)

            ' Loop through each line in the file
            For Each line As String In lines
                ' Split the line by spaces
                Dim parts As String() = line.Split(" "c)

                ' Check if the line has at least 3 parts
                If parts.Length >= 3 Then
                    ' Extract the middle value (F) and subtract 200
                    Dim xValue As Double = Double.Parse(parts(1)) - 200

                    ' Add the calculated value to the chart
                    series.Points.AddY(xValue)

                    xValues.Add(xValue)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error reading the file: " & ex.Message)
        End Try

        Return xValues
    End Function

    Private Sub ReadAndDisplayYData(filePath As String)
        ' Clear previous chart data
        YVisualizationChart.Series.Clear()

        ' Create a new series for the chart
        Dim series As New Series("Y Motion Data")
        series.ChartType = SeriesChartType.FastLine
        YVisualizationChart.Series.Add(series)

        Try
            ' Read all lines from the file
            Dim lines As String() = File.ReadAllLines(filePath)

            ' Loop through each line in the file
            For Each line As String In lines
                ' Split the line by spaces
                Dim parts As String() = line.Split(" "c)

                ' Check if the line has at least 3 parts
                If parts.Length >= 3 Then
                    ' Extract the middle value (F) and subtract 360
                    Dim xValue As Double = Double.Parse(parts(1)) - 360

                    ' Add the calculated value to the chart
                    series.Points.AddY(xValue)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error reading the file: " & ex.Message)
        End Try
    End Sub

    Private Function ReadAndDisplayCustomXData(dataLines As List(Of String)) As List(Of Double)
        ' Clear previous chart data
        XVisualizationChart.Series.Clear()

        ' Create a new series for the chart
        Dim series As New Series("X Motion Data")
        series.ChartType = SeriesChartType.FastLine
        XVisualizationChart.Series.Add(series)

        Dim xValues As New List(Of Double)

        Try
            ' Loop through each line in the list
            For Each line As String In dataLines
                ' Split the line by spaces
                Dim parts As String() = line.Split(" "c)

                ' Check if the line has at least 3 parts
                If parts.Length >= 3 Then
                    ' Extract the middle value (F) and subtract 200
                    Dim xValue As Double = Double.Parse(parts(1)) - 200

                    ' Add the calculated value to the chart
                    series.Points.AddY(xValue)

                    xValues.Add(xValue)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error processing the data: " & ex.Message)
        End Try

        Return xValues
    End Function

    Private Sub ReadAndDisplayCustomYData(dataLines As List(Of String))
        ' Clear previous chart data
        YVisualizationChart.Series.Clear()

        ' Create a new series for the chart
        Dim series As New Series("Y Motion Data")
        series.ChartType = SeriesChartType.FastLine
        YVisualizationChart.Series.Add(series)

        Try
            ' Loop through each line in the provided list
            For Each line As String In dataLines
                ' Split the line by spaces
                Dim parts As String() = line.Split(" "c)

                ' Check if the line has at least 3 parts
                If parts.Length >= 3 Then
                    ' Extract the middle value (F) and subtract 360
                    Dim yValue As Double = Double.Parse(parts(1)) - 360

                    ' Add the calculated value to the chart
                    series.Points.AddY(yValue)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error processing the data: " & ex.Message)
        End Try
    End Sub


    Function ConvertToXAxisGCode(filePath As String) As List(Of String)
        Dim lines() As String
        Dim gCodeList As New List(Of String)

        Try
            lines = IO.File.ReadAllLines(filePath)

            ' Check if the file has enough lines to process
            If lines.Length < 12 Then
                Throw New FormatException("File does not contain enough data to process.")
            End If

            Dim velocity As Double = 0
            Dim displacement As Double = 0
            Dim timeStep As Double = 0.01 ' Time step in seconds (10 ms)

            ' Constants for G-code format
            Dim baseX As Double = 200

            ' Start reading data from the file (skip header lines)
            For i As Integer = 10 To lines.Length - 2
                ' Split the data
                Dim currentLine As String() = lines(i).Split(vbTab)
                Dim nextLine As String() = lines(i + 1).Split(vbTab)

                ' Validate the format of each line
                If currentLine.Length < 2 OrElse nextLine.Length < 2 Then
                    Throw New FormatException("Data format is incorrect in the file.")
                End If

                Dim currentTime As Double
                Dim currentAccel As Double
                Dim nextAccel As Double

                ' Try parsing the time and acceleration values
                If Not Double.TryParse(currentLine(0), currentTime) OrElse
               Not Double.TryParse(currentLine(1), currentAccel) OrElse
               Not Double.TryParse(nextLine(1), nextAccel) Then
                    Throw New FormatException("Unable to parse time or acceleration data.")
                End If

                currentAccel *= 9.80665 ' Convert g to m/s²
                nextAccel *= 9.80665

                ' Calculate the change in velocity using the provided formula
                Dim dV As Double = 0.5 * (currentAccel + nextAccel) * timeStep

                Dim m_to_mm As Integer = 1000

                velocity += dV * m_to_mm

                Dim dD As Double = (velocity + (velocity - dV)) * (timeStep / 2)

                displacement += dD

                ' Calculate velocity in mm/min for G-code
                Dim velocityMMMin As Double = velocity * 60 ' Convert m/s to mm/min

                ' Generate G-code
                Dim gCodeLine As String = String.Format("G01X {0:F2} F{1:F2}", baseX + displacement, Math.Abs(velocityMMMin))
                gCodeList.Add(gCodeLine)
            Next

        Catch ex As FormatException
            ' Handle format exception (e.g., log the error, show a message, etc.)
            MessageBox.Show("Error processing the file: " & ex.Message, "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CustomXAxisFileTextbox.Clear()
            CustomXAxisFilename = ""
            Return New List(Of String)() ' Return an empty list to indicate failure
        Catch ex As Exception
            ' Handle any other unexpected errors
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CustomXAxisFileTextbox.Clear()
            CustomXAxisFilename = ""
            Return New List(Of String)() ' Return an empty list to indicate failure
        End Try

        Return gCodeList
    End Function

    Function ConvertToYAxisGCode(filePath As String) As List(Of String)
        Dim lines() As String
        Dim gCodeList As New List(Of String)

        Try
            lines = IO.File.ReadAllLines(filePath)

            ' Check if the file has enough lines to process
            If lines.Length < 12 Then
                Throw New FormatException("File does not contain enough data to process.")
            End If

            Dim velocity As Double = 0
            Dim displacement As Double = 0
            Dim timeStep As Double = 0.01 ' Time step in seconds (10 ms)

            ' Constants for G-code format
            Dim baseX As Double = 360

            ' Start reading data from the file (skip header lines)
            For i As Integer = 10 To lines.Length - 2
                ' Split the data
                Dim currentLine As String() = lines(i).Split(vbTab)
                Dim nextLine As String() = lines(i + 1).Split(vbTab)

                ' Validate the format of each line
                If currentLine.Length < 2 OrElse nextLine.Length < 2 Then
                    Throw New FormatException("Data format is incorrect in the file.")
                End If

                Dim currentTime As Double
                Dim currentAccel As Double
                Dim nextAccel As Double

                ' Try parsing the time and acceleration values
                If Not Double.TryParse(currentLine(0), currentTime) OrElse
                   Not Double.TryParse(currentLine(1), currentAccel) OrElse
                   Not Double.TryParse(nextLine(1), nextAccel) Then
                    Throw New FormatException("Unable to parse time or acceleration data.")
                End If

                currentAccel *= 9.80665 ' Convert g to m/s²
                nextAccel *= 9.80665

                ' Calculate the change in velocity using the provided formula
                Dim dV As Double = 0.5 * (currentAccel + nextAccel) * timeStep

                Dim m_to_mm As Integer = 1000

                velocity += dV * m_to_mm

                Dim dD As Double = (velocity + (velocity - dV)) * (timeStep / 2)

                displacement += dD

                ' Calculate velocity in mm/min for G-code
                Dim velocityMMMin As Double = velocity * 60 ' Convert m/s to mm/min

                ' Generate G-code
                Dim gCodeLine As String = String.Format("G01Y {0:F2} F{1:F2}", baseX + displacement, Math.Abs(velocityMMMin))
                gCodeList.Add(gCodeLine)
            Next

        Catch ex As FormatException
            ' Handle format exception (e.g., log the error, show a message, etc.)
            MessageBox.Show("Error processing the file: " & ex.Message, "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CustomYAxisFileTextbox.Clear()
            CustomYAxisFilename = ""
            Return New List(Of String)() ' Return an empty list to indicate failure
        Catch ex As Exception
            ' Handle any other unexpected errors
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CustomYAxisFileTextbox.Clear()
            CustomYAxisFilename = ""
            Return New List(Of String)() ' Return an empty list to indicate failure
        End Try

        Return gCodeList
    End Function




#End Region

End Class
