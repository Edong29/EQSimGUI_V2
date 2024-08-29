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
                XAxisSerialPort.PortName = XAxisConnectionComboBox.SelectedItem.ToString()
                XAxisSerialPort.BaudRate = 9600  ' Set the appropriate baud rate
                XAxisSerialPort.Open()
                IsConnectedToXAxisCOM = True
                MessageBox.Show("Connected to Arduino 1 (X axis) on " & XAxisSerialPort.PortName)
            Catch ex As Exception
                MessageBox.Show("Failed to connect to Arduino 1: " & ex.Message)
            End Try
        End If

        ' Connect to Arduino 2 (Y axis)
        If YAxisConnectionComboBox.SelectedItem IsNot Nothing Then
            Try
                YAxisSerialPort.PortName = YAxisConnectionComboBox.SelectedItem.ToString()
                YAxisSerialPort.BaudRate = 9600  ' Set the appropriate baud rate
                YAxisSerialPort.Open()
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
                                ' Send initial G-code commands outside of BackgroundWorker
                                XAxisSerialPort.WriteLine("$100 = 29.78")
                                XAxisSerialPort.WriteLine("G90 G21 G94")

                            End If
                        Else
                            MessageBox.Show($"File {filePath} not found.")
                        End If
                    Else
                        MessageBox.Show("Please select an earthquake.")
                    End If

                Case "YSimulationButton"
                    ' Logic for button2 click
                    MessageBox.Show("Button 2 clicked")

                Case "XYSimulationButton"
                    ' Logic for button3 click
                    MessageBox.Show("Button 3 clicked")

                Case "HomeSimulatorButton"
                    ' Logic for button4 click
                    MessageBox.Show("Button 4 clicked")

                Case "StopSimulationButton"
                    ' Logic for button5 click
                    MessageBox.Show("Button 5 clicked")

                Case Else
                    ' Do nothing
            End Select
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
