Imports System.ComponentModel
Imports System.IO
Imports System.IO.Ports

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
    End Sub

    Private Sub MicrocontrollerConnectionButton_Click(sender As Object, e As EventArgs) Handles MicrocontrollerConnectionButton.Click
        CloseConnection()
        ' Connect to Arduino 1 (X axis)
        If XAxisConnectionComboBox.SelectedItem IsNot Nothing Then
            Try
                With XAxisSerialPort
                    .PortName = XAxisConnectionComboBox.SelectedItem.ToString()
                    .BaudRate = 19200
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
                    .BaudRate = 19200
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
                Case "XSimulationButton"
                    ' Get the selected earthquake from the DataGridView
                    If EarthquakeSelectionDGV.SelectedRows.Count > 0 Then
                        Dim selectedEarthquake As String = EarthquakeSelectionDGV.SelectedRows(0).Cells(0).Value.ToString()
                        Dim filePath As String = $"C:\Earthquakes\{selectedEarthquake}X.txt"

                        If File.Exists(filePath) Then
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

                Case "YSimulationButton"
                    ' Get the selected earthquake from the DataGridView
                    If EarthquakeSelectionDGV.SelectedRows.Count > 0 Then
                        Dim selectedEarthquake As String = EarthquakeSelectionDGV.SelectedRows(0).Cells(0).Value.ToString()
                        Dim filePath As String = $"C:\Earthquakes\{selectedEarthquake}Y.txt"

                        If File.Exists(filePath) Then
                            If IsConnectedToYAxisCOM Then
                                ' Send initial G-code commands
                                YAxisSerialPort.WriteLine("$100 = 29.78")
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

                Case "XYSimulationButton"
                    ' Logic for XYSimulationButton click
                    MessageBox.Show("Button 3 clicked")

                Case "HomeSimulatorButton"
                    ' Logic for HomeSimulatorButton click
                    MessageBox.Show("Button 4 clicked")

                Case "StopSimulationButton"
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
                    'XChart.Series(0).Points.AddY(value(1) - 200) 'displays the gcode line of codes being read by the arduino to a chart
                    ' Use Invoke to update the TextBox on the UI thread
                    Me.Invoke(Sub()
                                  TextBox1.AppendText(line & vbNewLine) ' Updates the TextBox safely
                              End Sub)
                    XAxisSerialPort.WriteLine(line) 'sends Gcode to arduino
                    ' Wait for 10 milliseconds (simulate time interval)
                    'Threading.Thread.Sleep(10)
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
                    'XChart.Series(0).Points.AddY(value(1) - 200) 'displays the gcode line of codes being read by the arduino to a chart
                    ' Use Invoke to update the TextBox on the UI thread
                    Me.Invoke(Sub()
                                  TextBox2.AppendText(line & vbNewLine) ' Updates the TextBox safely
                              End Sub)
                    YAxisSerialPort.WriteLine(line) 'sends Gcode to arduino
                    ' Wait for 10 milliseconds (simulate time interval)
                    'Threading.Thread.Sleep(10)
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
        If IsConnectedToXAxisCOM AndAlso XAxisSerialPort.IsOpen Then
            XAxisSerialPort.Close()
            IsConnectedToXAxisCOM = False
        End If

        If IsConnectedToYAxisCOM AndAlso YAxisSerialPort.IsOpen Then
            YAxisSerialPort.Close()
            IsConnectedToYAxisCOM = False
        End If
    End Sub

    Private Sub FillEarthquakeSelection()
        EarthquakeSelectionDGV.Rows.Clear()
        EarthquakeSelectionDGV.Rows.Add("Kobe")
        EarthquakeSelectionDGV.Rows.Add("Northridge")
        EarthquakeSelectionDGV.Rows.Add("LomaPrieta")
    End Sub
#End Region


End Class
