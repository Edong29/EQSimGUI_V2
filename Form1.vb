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
                    End If


                Case YSimulationButton.Name
                    ' Get the selected earthquake from the DataGridView
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
                    If bgWorkerX.IsBusy Then
                        bgWorkerX.CancelAsync()
                    End If

                    If bgWorkerY.IsBusy Then
                        bgWorkerY.CancelAsync()
                    End If
                    'MessageBox.Show("Simulation stopped.")

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

    Private Sub SimulationModeTabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SimulationModeTabControl.SelectedIndexChanged

        If SimulationModeTabControl.SelectedTab Is SinusoidalSelectionTabPage Then
            XYSimulationButton.Enabled = False
            YSimulationButton.Enabled = False
        ElseIf SimulationModeTabControl.SelectedTab Is CustomFileTabPage Or SimulationModeTabControl.SelectedTab Is EarthquakeSelectionTabPage Then
            XYSimulationButton.Enabled = True
            YSimulationButton.Enabled = True
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
#End Region


End Class
