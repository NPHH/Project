Public Class Form1

    'Electronic AC/DC Load control programm with Visual studio 2015
    'Version 1.0
    'Date 2019-11-12
    'Author: Rainer Schuster

    Dim myPort As Array  'COM Ports detected on the system will be stored here
    Dim collector, reading As String
    Dim OpenPort As Byte
    Dim Comportname As String
    Dim Comport_opened As Boolean
    Dim Repeat_counter As Byte

    Public Shared Current_correction_factor As Single
    Public Shared Voltage_correction_factor As Single

    Dim Label1_string As String
    Dim Empfstring As String
    Dim lpathandname As String
    Dim File_open As Boolean
    Dim csvstring As String

    Dim csvTextwriter As System.IO.StreamWriter
    Dim Filesamplingtime As Long

    Dim Actual_voltage As Single
    Dim Actual_current As Single
    Dim Actual_power As Single
    Dim Dest_current As Single
    Dim Max_dest_current As Single
    Dim Max_dest_current_mA As Integer

    Dim counter As Double

    Dim Current_Unit As Byte

    Dim Actual_voltage_trace As Boolean
    Dim Actual_current_trace As Boolean
    Dim Dest_current_trace As Boolean
    Dim Actual_power_trace As Boolean
    Dim Samplingtime As Long
    Dim Trace_active As Boolean
    Dim Y_range As Long

    Dim Remote As Boolean
    Dim remote_dest_current As Long

    Dim Dest_current_up_button_pressed As Boolean
    Dim Dest_current_down_button_pressed As Boolean
    Dim Delta_dest_current_counter As Byte
    Dim Delta_dest_current As Single

    Dim Dynamic_min_current As Integer
    Dim Dynamic_max_current As Integer
    Dim Period_time As Integer

    Dim Min_current_up_button_pressed As Boolean
    Dim Min_current_down_button_pressed As Boolean
    Dim Max_current_up_button_pressed As Boolean
    Dim Max_current_down_button_pressed As Boolean
    Dim Period_up_button_pressed As Boolean
    Dim Period_down_button_pressed As Boolean
    Dim Load_test_started As Boolean
    Dim Min_current_active As Boolean

    Dim heatsink_temp As Single
    Dim errorstate As Byte

    Const DELTA_MILLIAMPS_LOW = 10
    Const DELTA_MILLIAMPS_MID = 100
    Const DELTA_MILLIAMPS_HIGH = 1000

    Const SWITCH_TO_MID = 10
    Const SWITCH_TO_HIGH = 20

    Const AMPS = 1
    Const MILLIAMPS = 2

    Const MAX_RETRY = 3
    'Send a string to the COM Port, terminate program if communication interrupted
    Public Sub Serial_out(ByVal s As String)
        Try
            SerialPort.Write(s)
        Catch ex As Exception
            Timer5.Enabled = False
            Timer4.Enabled = False
            Timer3.Enabled = False
            Timer2.Enabled = False
            Timer6.Enabled = False
            Timer7.Enabled = False

            MsgBox("Communication interrupted !", MsgBoxStyle.Critical)
            End

        End Try
    End Sub
    'Query data from AC/DC Load every second
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim cmd As String

        cmd = "C" + Chr(13) + Chr(10) 'Read VRMS - Actual voltage
        Serial_out(cmd)

        cmd = "D" + Chr(13) + Chr(10) 'Read ARMS - Actual current
        Serial_out(cmd)

        cmd = "E" + Chr(13) + Chr(10) 'Read ARMS - Destination current
        Serial_out(cmd)

        cmd = "N" + Chr(13) + Chr(10) 'Read ARMS - Max destination current
        Serial_out(cmd)

        cmd = "O" + Chr(13) + Chr(10) 'Read Remote state
        Serial_out(cmd)

        cmd = "K" + Chr(13) + Chr(10) 'Read Load On/Off relay state
        Serial_out(cmd)

        cmd = "L" + Chr(13) + Chr(10) 'Read AC/DC relay state
        Serial_out(cmd)

        cmd = "H" + Chr(13) + Chr(10) 'Read Heatsink temp
        Serial_out(cmd)

        cmd = "G" + Chr(13) + Chr(10) 'Read Error state
        Serial_out(cmd)

        cmd = "R" + Chr(13) + Chr(10) 'Read Current calibration value
        Serial_out(cmd)

        cmd = "T" + Chr(13) + Chr(10) 'Read Voltage calibration value
        Serial_out(cmd)

        Timer5.Enabled = True

    End Sub
    'Plot voltge/current/power traces according to activated traces in Sampling time interval
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        If Actual_voltage_trace = True Then
            Chart1.Series(2).Points.AddXY(counter, Actual_voltage)
        End If

        If Actual_current_trace = True Then
            Chart1.Series(0).Points.AddXY(counter, Actual_current)
        End If

        If Actual_power_trace = True Then
            Chart1.Series(3).Points.AddXY(counter, Actual_power)
        End If

        If Dest_current_trace = True Then
            Chart1.Series(1).Points.AddXY(counter, Dest_current)
        End If

        Chart1.ChartAreas(0).AxisX.CustomLabels.Add(counter - 1, counter + 1, Str(counter * Samplingtime / 1000))
        counter += 1
        If counter > 60 Then
            counter = 0
            Chart1.Series(0).Points.Clear()
            Chart1.Series(1).Points.Clear()
            Chart1.Series(2).Points.Clear()
            Chart1.Series(3).Points.Clear()
            Chart1.ChartAreas(0).AxisX.CustomLabels.Clear()
            Chart1.ChartAreas(0).AxisX.Interval = 1
            Chart1.ChartAreas(0).AxisX.Minimum = 0
            Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = 90
        End If
    End Sub
    'Scan all available COM Ports and check if the AC/DC load is connected to one of them
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim cmd As String

        If UBound(myPort) >= 0 Then
            If Comport_opened = True Then 'if COM port alread opened then repeat version query until limit reached
                If Repeat_counter < MAX_RETRY Then
                    cmd = "A" + Chr(13) + Chr(10)
                    Serial_out(cmd)
                    Repeat_counter += 1
                Else
                    Comport_opened = False
                End If
            End If
            If Comport_opened = False Then
                Err.Clear()
                Try
                    SerialPort.Close()             'Close our Serial Port
                    SerialPort.PortName = myPort(OpenPort)
                    Comportname = SerialPort.PortName
                    'Set SerialPort1 to the selected COM port at startup
                    SerialPort.BaudRate = 19200
                    SerialPort.Parity = IO.Ports.Parity.None
                    SerialPort.DataBits = 8
                    SerialPort.StopBits = 1
                    SerialPort.ReceivedBytesThreshold = 1
                    SerialPort.Open()
                    'send  version query to target
                    Comport_opened = True
                    Repeat_counter = 0
                    cmd = "A" + Chr(13) + Chr(10)
                    Serial_out(cmd)
                    OpenPort = OpenPort + 1
                    If OpenPort > UBound(myPort) Then
                        OpenPort = 0
                    End If
                Catch ex As Exception
                    OpenPort = OpenPort + 1
                    If OpenPort > UBound(myPort) Then
                        OpenPort = 0
                    End If
                End Try
            End If
        Else
            Timer1.Enabled = False
            MsgBox("No free COM port found!", MsgBoxStyle.Critical)
            End
        End If



    End Sub

    Delegate Sub SetTextCallback(ByVal text As String) 'Added to prevent threading errors during receiveing of data
    'Will be called at form closed event
    Private Sub form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim cmd As String

        If Remote = True Then
            cmd = "B0" + Chr(13) + Chr(10) 'set to local mode 
            Serial_out(cmd)
        End If
        Application.DoEvents()
        SerialPort.Close()             'Close our Serial Port
        If File_open = True Then
            csvTextwriter.Close()
        End If
        End
    End Sub

    Private Sub form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'When our form loads, auto detect all serial ports in the system 
        myPort = IO.Ports.SerialPort.GetPortNames() 'Get all com ports available
        OpenPort = 0
        Comport_opened = False
        Repeat_counter = 0

        On Error Resume Next


        Dynamic_min_current = 0
        Dynamic_max_current = 0
        Period_time = 1000
        Load_test_started = False

        Current_Unit = AMPS

        Filesamplingtime = 1

        Timer1.Enabled = True
        counter = 1
        Samplingtime = 1000
        Y_range = 100
        Actual_voltage_trace = False
        Actual_power_trace = False
        Actual_current_trace = False
        Dest_current_trace = False
        Trace_active = False
        Remote = False
        remote_dest_current = 0
        Delta_dest_current = DELTA_MILLIAMPS_MID


        File_open = False
        Dest_current_up_button_pressed = False
        Dest_current_down_button_pressed = False
        Delta_dest_current_counter = 0
        Delta_dest_current = DELTA_MILLIAMPS_LOW

        Chart1.ChartAreas(0).AxisX.Interval = 1
        Chart1.ChartAreas(0).AxisX.Minimum = 0
        Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = 90
        Chart1.ChartAreas(0).AxisY.Interval = Y_range / 10
        Chart1.ChartAreas(0).AxisY.Minimum = 0
        Chart1.ChartAreas(0).AxisY.Maximum = Y_range

    End Sub
    'Automatically called every time a data is received at the serialPort
    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        Dim x As Byte
        Dim stg As String

        Empfstring += SerialPort.ReadExisting()
        Do
            x = InStr(Empfstring, Chr(10))
            If x > 2 Then
                stg = Mid(Empfstring, 1, x - 2)
                Empfstring = Mid(Empfstring, x + 1, Len(Empfstring))
                ReceiveText(stg)
            End If
        Loop Until x = 0

    End Sub
    'Change the current unit from mA to A and vice versa
    Private Sub Current_unit_button_Click(sender As Object, e As EventArgs) Handles Current_unit_button.Click
        If Current_Unit = AMPS Then
            Current_Unit = MILLIAMPS
            Current_unit_button.Text = "ARMS"
            Label2.Text = "Actual current [mARMS]"
            Label4.Text = "Max Dest current [mARMS]"
            Label5.Text = "Destination current [mARMS]"
            Label6.Text = "Min. mAmps"
            Label7.Text = "Max. mAmps"
        Else
            Current_Unit = AMPS
            Current_unit_button.Text = "mARMS"
            Label2.Text = "Actual current [ARMS]"
            Label4.Text = "Max Dest current [ARMS]"
            Label5.Text = "Destination current [ARMS]"
            Label6.Text = "Min. Amps"
            Label7.Text = "Max. Amps"
        End If
    End Sub
    'Start/Stop plotting of traces
    Private Sub Trace_button_Click(sender As Object, e As EventArgs) Handles Trace_button.Click
        If Trace_active = False Then
            Trace_active = True
            Trace_button.Text = "Stop Trace"
            counter = 0
            Chart1.Series(0).Points.Clear()
            Chart1.Series(1).Points.Clear()
            Chart1.Series(2).Points.Clear()
            Chart1.Series(3).Points.Clear()
            Timer3.Interval = Samplingtime
            Timer3.Enabled = True
        Else
            Trace_active = False
            Trace_button.Text = "Start Trace"
            Timer3.Enabled = False
        End If
    End Sub
    'Start/Stop voltage trace
    Private Sub Actvolts_button_Click(sender As Object, e As EventArgs) Handles Actvolts_button.Click
        If Actual_voltage_trace = True Then
            Actual_voltage_trace = False
            Actvolts_button.BackColor = Color.LightGray
        Else
            Actual_voltage_trace = True
            Actvolts_button.BackColor = Color.OrangeRed
            counter = 0
            Chart1.Series(0).Points.Clear()
            Chart1.Series(1).Points.Clear()
            Chart1.Series(2).Points.Clear()
            Chart1.Series(3).Points.Clear()
        End If
    End Sub
    'Start/Stop actual current trace
    Private Sub Actcurrent_button_Click(sender As Object, e As EventArgs) Handles Actcurrent_button.Click
        If Actual_current_trace = True Then
            Actual_current_trace = False
            Actcurrent_button.BackColor = Color.LightGray
        Else
            Actual_current_trace = True
            Actcurrent_button.BackColor = Color.LightSkyBlue
            counter = 0
            Chart1.Series(0).Points.Clear()
            Chart1.Series(1).Points.Clear()
            Chart1.Series(2).Points.Clear()
            Chart1.Series(3).Points.Clear()
        End If

    End Sub
    'Start/Stop actual power trace
    Private Sub Actual_power_button_Click(sender As Object, e As EventArgs) Handles Actual_power_button.Click
        If Actual_power_trace = True Then
            Actual_power_trace = False
            Actcurrent_button.BackColor = Color.LightGray
        Else
            Actual_power_trace = True
            Actual_power_button.BackColor = Color.SteelBlue
            counter = 0
            Chart1.Series(0).Points.Clear()
            Chart1.Series(1).Points.Clear()
            Chart1.Series(2).Points.Clear()
            Chart1.Series(3).Points.Clear()
        End If

    End Sub
    'Start/Stop detsination current trace
    Private Sub Dest_current_button_Click(sender As Object, e As EventArgs) Handles Dest_current_button.Click
        If Dest_current_trace = True Then
            Dest_current_trace = False
            Dest_current_button.BackColor = Color.LightGray
        Else
            Dest_current_trace = True
            Dest_current_button.BackColor = Color.Orange
            counter = 0
            Chart1.Series(0).Points.Clear()
            Chart1.Series(1).Points.Clear()
            Chart1.Series(2).Points.Clear()
            Chart1.Series(3).Points.Clear()
        End If

    End Sub
    'Change Y-range of plot area
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Val(Range_textbox.Text) <= 10000 Then
            Y_range = Val(Range_textbox.Text)
        Else
            Y_range = 10000
            Range_textbox.Text = "10000"
        End If
        Chart1.ChartAreas(0).AxisY.Interval = Y_range / 10
        Chart1.ChartAreas(0).AxisY.Minimum = 0
        Chart1.ChartAreas(0).AxisY.Maximum = Y_range
        counter = 0
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
    End Sub
    'Change sampling time of plot area
    Private Sub Samplingtime_button_Click(sender As Object, e As EventArgs) Handles Samplingtime_button.Click
        If Val(Sampling_time_textbox.Text) <= 60000 Then
            Samplingtime = Val(Sampling_time_textbox.Text)
        Else
            Samplingtime = 60000
            Sampling_time_textbox.Text = "60000"
        End If
        counter = 0
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.ChartAreas(0).AxisX.CustomLabels.Clear()
        Chart1.ChartAreas(0).AxisX.Interval = 1
        Chart1.ChartAreas(0).AxisX.Minimum = 0
        Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = 90
        Timer3.Interval = Samplingtime
    End Sub
    'Switch remote control On/Off
    Private Sub Remote_button_Click(sender As Object, e As EventArgs) Handles Remote_button.Click
        Dim cmd As String

        If Remote = False Then
            cmd = "B1" + Chr(13) + Chr(10) 'Send Remote On command
        Else
            cmd = "B0" + Chr(13) + Chr(10) 'Send remote Off command
        End If
        Serial_out(cmd)
    End Sub
    'The following functions handles the Up/Down buttons for changing the destination current
    'and changing of period time
    'Timer4 handles the necessary actions every 100ms
    Private Sub Dest_current_up_button_Mousedown(sender As Object, e As EventArgs) Handles Dest_current_up_button.MouseDown

        Dest_current_up_button_pressed = True
    End Sub
    Private Sub Dest_current_up_button_Mouseup(sender As Object, e As EventArgs) Handles Dest_current_up_button.MouseUp

        Dest_current_up_button_pressed = False
        Delta_dest_current_counter = 0
        If Current_Unit = AMPS Then
            Delta_dest_current = DELTA_MILLIAMPS_MID
        Else
            Delta_dest_current = DELTA_MILLIAMPS_LOW
        End If

    End Sub
    Private Sub Min_current_up_button_Mousedown(sender As Object, e As EventArgs) Handles Min_current_up_button.MouseDown

        Min_current_up_button_pressed = True
    End Sub
    Private Sub Min_current_up_button_Mouseup(sender As Object, e As EventArgs) Handles Min_current_up_button.MouseUp

        Min_current_up_button_pressed = False
        Delta_dest_current_counter = 0
        If Current_Unit = AMPS Then
            Delta_dest_current = DELTA_MILLIAMPS_MID
        Else
            Delta_dest_current = DELTA_MILLIAMPS_LOW
        End If

    End Sub
    Private Sub Min_current_down_button_Mousedown(sender As Object, e As EventArgs) Handles Min_current_down_button.MouseDown

        Min_current_down_button_pressed = True
    End Sub
    Private Sub Min_current_down_button_Mouseup(sender As Object, e As EventArgs) Handles Min_current_down_button.MouseUp

        Min_current_down_button_pressed = False
        Delta_dest_current_counter = 0
        If Current_Unit = AMPS Then
            Delta_dest_current = DELTA_MILLIAMPS_MID
        Else
            Delta_dest_current = DELTA_MILLIAMPS_LOW
        End If

    End Sub
    Private Sub Max_current_up_button_Mousedown(sender As Object, e As EventArgs) Handles Max_current_up_button.MouseDown

        Max_current_up_button_pressed = True
    End Sub
    Private Sub Max_current_up_button_Mouseup(sender As Object, e As EventArgs) Handles Max_current_up_button.MouseUp

        Max_current_up_button_pressed = False
        Delta_dest_current_counter = 0
        If Current_Unit = AMPS Then
            Delta_dest_current = DELTA_MILLIAMPS_MID
        Else
            Delta_dest_current = DELTA_MILLIAMPS_LOW
        End If

    End Sub
    Private Sub Max_current_down_button_Mousedown(sender As Object, e As EventArgs) Handles Max_current_down_button.MouseDown

        Max_current_down_button_pressed = True
    End Sub
    Private Sub Max_current_down_button_Mouseup(sender As Object, e As EventArgs) Handles Max_current_down_button.MouseUp

        Max_current_down_button_pressed = False
        Delta_dest_current_counter = 0
        If Current_Unit = AMPS Then
            Delta_dest_current = DELTA_MILLIAMPS_MID
        Else
            Delta_dest_current = DELTA_MILLIAMPS_LOW
        End If

    End Sub
    Private Sub Period_up_button_Mousedown(sender As Object, e As EventArgs) Handles Period_up_button.MouseDown

        Period_up_button_pressed = True
    End Sub
    Private Sub Period_up_button_Mouseup(sender As Object, e As EventArgs) Handles Period_up_button.MouseUp

        Period_up_button_pressed = False
        Delta_dest_current_counter = 0
        If Current_Unit = AMPS Then
            Delta_dest_current = DELTA_MILLIAMPS_MID
        Else
            Delta_dest_current = DELTA_MILLIAMPS_LOW
        End If

    End Sub
    Private Sub Period_down_button_Mousedown(sender As Object, e As EventArgs) Handles Period_down_button.MouseDown

        Period_down_button_pressed = True
    End Sub
    Private Sub Period_down_button_Mouseup(sender As Object, e As EventArgs) Handles Period_down_button.MouseUp

        Period_down_button_pressed = False
        Delta_dest_current_counter = 0
        If Current_Unit = AMPS Then
            Delta_dest_current = DELTA_MILLIAMPS_MID
        Else
            Delta_dest_current = DELTA_MILLIAMPS_LOW
        End If

    End Sub
    'Handles the Up/Down button activities every 100ms
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Dim cmd As String

        If Dest_current_up_button_pressed = True Or Dest_current_down_button_pressed = True Or Min_current_up_button_pressed = True Or Min_current_down_button_pressed = True Or Max_current_up_button_pressed = True Or Max_current_down_button_pressed = True Then
            Delta_dest_current_counter += 1
            If Delta_dest_current_counter > SWITCH_TO_HIGH Then
                Delta_dest_current = DELTA_MILLIAMPS_HIGH
            Else
                If Delta_dest_current_counter > SWITCH_TO_MID Then
                    If Current_Unit = AMPS Then
                        Delta_dest_current = DELTA_MILLIAMPS_HIGH
                    Else
                        Delta_dest_current = DELTA_MILLIAMPS_MID
                    End If
                End If
            End If
        End If

        If Dest_current_up_button_pressed = True Then
            remote_dest_current += Delta_dest_current
            If remote_dest_current > Max_dest_current_mA Then
                remote_dest_current = Max_dest_current_mA
            End If
            cmd = "F" + Str(remote_dest_current) + Chr(13) + Chr(10) 'send new destination current
            Serial_out(cmd)
            cmd = "E" + Chr(13) + Chr(10) 'Read back Destination current immediately
            Serial_out(cmd)
        End If

        If Dest_current_down_button_pressed = True Then
            remote_dest_current -= Delta_dest_current
            If remote_dest_current <= 0 Then
                remote_dest_current = 0
            End If
            cmd = "F" + Str(remote_dest_current) + Chr(13) + Chr(10) 'send new destination current
            Serial_out(cmd)
            cmd = "E" + Chr(13) + Chr(10) 'Read back Destination current immediately
            Serial_out(cmd)
        End If

        If Min_current_up_button_pressed = True Then
            Dynamic_min_current += Delta_dest_current
            If Dynamic_min_current > Max_dest_current_mA Or Dynamic_min_current > Dynamic_max_current Then
                Dynamic_min_current = Dynamic_max_current
            End If
            If Current_Unit = AMPS Then
                Min_current_display.Text = Format(Dynamic_min_current / 1000, "00.00")
            Else
                Min_current_display.Text = Format(Dynamic_min_current, "00000")
            End If
        End If

        If Min_current_down_button_pressed = True Then
            Dynamic_min_current -= Delta_dest_current
            If Dynamic_min_current <= 0 Then
                Dynamic_min_current = 0
            End If
            If Current_Unit = AMPS Then
                Min_current_display.Text = Format(Dynamic_min_current / 1000, "00.00")
            Else
                Min_current_display.Text = Format(Dynamic_min_current, "00000")
            End If
        End If

        If Max_current_up_button_pressed = True Then
            Dynamic_max_current += Delta_dest_current
            If Dynamic_max_current > Max_dest_current_mA Then
                Dynamic_max_current = Max_dest_current_mA
            End If
            If Current_Unit = AMPS Then
                Max_current_display.Text = Format(Dynamic_max_current / 1000, "00.00")
            Else
                Max_current_display.Text = Format(Dynamic_max_current, "00000")
            End If
        End If

        If Max_current_down_button_pressed = True Then
            Dynamic_max_current -= Delta_dest_current
            If Dynamic_max_current <= 0 Then
                Dynamic_max_current = 0
            End If
            If Current_Unit = AMPS Then
                Max_current_display.Text = Format(Dynamic_max_current / 1000, "00.00")
            Else
                Max_current_display.Text = Format(Dynamic_max_current, "00000")
            End If
        End If

        If Period_up_button_pressed = True Then
            Period_time += 100
            If Period_time > 60000 Then
                Period_time = 60000
            End If
            Period_display.Text = Format(Period_time / 1000, "00.0")
        End If

        If Period_down_button_pressed = True Then
            Period_time -= 100
            If Period_time <= 100 Then
                Period_time = 100
            End If
            Period_display.Text = Format(Period_time / 1000, "00.0")
        End If

    End Sub

    Private Sub Dest_current_down_button_Mouseup(sender As Object, e As EventArgs) Handles Dest_current_down_button.MouseUp
        Dest_current_down_button_pressed = False
        Delta_dest_current_counter = 0
        Delta_dest_current = DELTA_MILLIAMPS_LOW

    End Sub
    Private Sub Dest_current_down_button_Mousedown(sender As Object, e As EventArgs) Handles Dest_current_down_button.MouseDown
        Dest_current_down_button_pressed = True

    End Sub
    'Will be started with 2s interval after sending a query to the target
    'Timer will be stopped after receiving an answer
    'If there is no answer within 2 seconds, a communication interrpted message box appears and program will be terminated
    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick

        Timer5.Enabled = False
        Timer4.Enabled = False
        Timer3.Enabled = False
        Timer2.Enabled = False
        Timer6.Enabled = False
        Timer7.Enabled = False

        MsgBox("Communication interrupted !", MsgBoxStyle.Critical)
        End

    End Sub
    'Starts/Stops the dynamic load functionality
    Private Sub Dynamic_load_start_button_Click(sender As Object, e As EventArgs) Handles Dynamic_load_start_button.Click
        Dim cmd As String

        If Load_test_started = False Then
            Load_test_started = True
            Dynamic_load_start_button.Text = "Stop"
            Dynamic_load_start_button.BackColor = Color.Red
            Min_current_active = True
            Timer6.Interval = Period_time
            Timer6.Enabled = True
            Dest_current_down_button.Enabled = False
            Dest_current_up_button.Enabled = False
        Else
            Load_test_started = False
            Dynamic_load_start_button.Text = "Start"
            Dynamic_load_start_button.BackColor = Color.LightGray
            Timer6.Enabled = False
            cmd = "F0" + Chr(13) + Chr(10) 'set destination  current 0
            Serial_out(cmd)
            Dest_current_down_button.Enabled = True
            Dest_current_up_button.Enabled = True
        End If
    End Sub
    'Switches from min Load to max load and vice cersa on dynamic load functionality depending on the 
    'period setting
    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        Dim cmd As String

        If Min_current_active = True Then
            cmd = "F" + Str(Dynamic_min_current) + Chr(13) + Chr(10)
            Min_current_active = False
        Else
            cmd = "F" + Str(Dynamic_max_current) + Chr(13) + Chr(10)
            Min_current_active = True
        End If
        Serial_out(cmd)
    End Sub
    'Swiches the load On/Off
    Private Sub Load_OnOff_Button_Click(sender As Object, e As EventArgs) Handles Load_OnOff_Button.Click
        Dim cmd As String

        If Load_label.Text = "On" Or errorstate > 0 Then
            cmd = "J0" + Chr(13) + Chr(10)
        Else
            cmd = "J1" + Chr(13) + Chr(10)
        End If
        Serial_out(cmd)
    End Sub
    'Switches from DC to AC/DC and vice versa
    Private Sub ACDC_button_Click(sender As Object, e As EventArgs) Handles ACDC_button.Click
        Dim cmd As String

        If ACDC_label.Text = "DC" Then
            cmd = "I1" + Chr(13) + Chr(10)
        Else
            cmd = "I0" + Chr(13) + Chr(10)
        End If
        Serial_out(cmd)

    End Sub
    'Opnes a file dialog for opening/closing a log file
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim msg As String
        Dim result As DialogResult

        If File_open = False Then
            With Me.SaveFileDialog1
                .Filter = "csv-files (*.csv) | *.csv"
                .FilterIndex = 1
                .InitialDirectory = CurDir()
            End With
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                lpathandname = SaveFileDialog1.FileName
                csvTextwriter = New System.IO.StreamWriter(lpathandname, False)
                If Current_Unit = MILLIAMPS Then
                    csvstring = "Time;Actual voltage[V];Actual current[mA];Actual power[W];Destination current[mA];Max. Destination current[mA];Heatsink temp. [°C]"
                Else
                    csvstring = "Time;Actual voltage[V];Actual current[A];Actual power[W];Destination current[A];Max. Destination current[A];Heatsink temp. [°C]"
                End If
                csvTextwriter.WriteLine(csvstring)
                csvTextwriter.Flush()
                File_open = True
                Timer7.Enabled = True
            End If
        Else
            msg = "Close file: " + lpathandname + "?"
            result = MessageBox.Show(Me, msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then
                csvTextwriter.Close()
                File_open = False
                Timer7.Enabled = False
            End If
        End If
    End Sub
    'Opens a input box for changing the sampling time for log file entries
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim Inputtime As String

        Inputtime = InputBox("Samplingtime in Seconds (1 to 60s):", "Samplingtime", Str(Filesamplingtime))
        If Val(Inputtime) >= 1 And Val(Inputtime) <= 60 Then
            Filesamplingtime = Val(Inputtime)
            Timer7.Interval = Filesamplingtime * 1000
        End If

    End Sub
    'Writes the log file data into a file very Sampling time
    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick

        If File_open = True Then
            csvstring = TimeOfDay + ";" + Str(Actual_voltage) + ";" + Str(Actual_current) + ";" + Str(Actual_power) + ";" + Str(Dest_current) + ";" + Str(Max_dest_current) + ";" + Str(heatsink_temp)
            csvTextwriter.WriteLine(csvstring)
        End If
    End Sub
    'opens the calibration window
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

        ToolStripButton3.Enabled = False
        Calibration_form.Show()
        ToolStripButton3.Enabled = True

    End Sub
    'DEcodes the input string received at the COM port

    Private Sub ReceiveText(ByVal empf As String)
        Dim Command As String
        Dim param As String
        Dim paramval As Single
        Dim st As String
        Dim cmd As String


        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.InvokeRequired Then
            Dim y As New SetTextCallback(AddressOf ReceiveText)
            'use begin invoke to prevent hanging of the 
            'program if the comport is closed 
            Me.BeginInvoke(y, New Object() {(empf)})
        Else
            Command = Mid(empf, 1, 1)
            param = Mid(empf, 2, Len(empf))
            paramval = Val(param)
            Timer5.Enabled = False
            Select Case Command
                Case "A" 'ID string received
                    If InStr(param, "AC DC Load") > 0 Then
                        Me.Timer1.Enabled = False
                        Me.Statuslabel.Text = "Connected to " + param + " on " + Comportname
                        Timer2.Enabled = True
                    End If

                Case "C" 'VRMS received
                    st = Format(paramval, "000.0")
                    Actual_voltage = Val(st)
                    Actual_Voltage_display.Text = st
                Case "D" 'Actual current received (always in mA)
                    If Current_Unit = AMPS Then
                        Actual_current = paramval / 1000
                        st = Format(Actual_current, "00.00")
                        Actual_power = Actual_voltage * Actual_current
                    Else
                        Actual_current = paramval
                        st = Format(Actual_current, "00000")
                        Actual_power = (Actual_voltage * Actual_current) / 1000
                    End If
                    Actual_current_display.Text = st 'Display actual current
                    st = Format(Actual_power, "000.0")
                    Actual_power_display.Text = st 'Display actual power
                Case "E" 'Destination current
                    If Current_Unit = AMPS Then
                        Dest_current = paramval / 1000
                        st = Format(Dest_current, "00.00")
                    Else
                        Dest_current = paramval
                        st = Format(Dest_current, "00000")
                    End If
                    Dest_current_display.Text = st 'Display actual current
                Case "G" 'Display error state
                    errorstate = Val(param)
                    If (errorstate And 1) > 0 Then 'Overvoltage error
                        U_LED.BackColor = Color.Red
                    Else
                        U_LED.BackColor = Color.LightGray
                    End If
                    If (errorstate And 2) > 0 Then 'Overcurrent error
                        I_LED.BackColor = Color.Red
                    Else
                        I_LED.BackColor = Color.LightGray
                    End If
                    If (errorstate And 4) > 0 Then 'Overtemp error
                        T_LED.BackColor = Color.Red
                    Else
                        T_LED.BackColor = Color.LightGray
                    End If
                    If (errorstate And 8) > 0 Then 'S.O.A. error
                        SOA_LED.BackColor = Color.Red
                    Else
                        SOA_LED.BackColor = Color.LightGray
                    End If
                Case "H" 'Heatsink temperature
                    heatsink_temp = paramval
                    Heatsink_temp_display.Text = Format(paramval, "00.0")
                Case "K" 'Load On/Off relay state received
                    If paramval = 1 Then
                        Load_label.Text = "On"
                        Load_label.BackColor = Color.Red
                    Else
                        Load_label.Text = "Off"
                        Load_label.BackColor = Color.LightGreen
                    End If
                Case "L" 'AC/DC relay state received
                    If paramval = 1 Then
                        ACDC_label.Text = "DC"
                        ACDC_label.BackColor = Color.Red
                    Else
                        ACDC_label.Text = "AC/DC"
                        ACDC_label.BackColor = Color.LightGreen
                    End If

                Case "N" 'Max Destination current
                    Max_dest_current_mA = paramval
                    If Current_Unit = AMPS Then
                        Max_dest_current = paramval / 1000
                        st = Format(Max_dest_current, "00.0")
                    Else
                        Max_dest_current = paramval
                        st = Format(Max_dest_current, "00000")
                    End If
                    Max_dest_current_display.Text = st 'Display actual current
                Case "O" 'Remote state received
                    If paramval = 1 Then
                        If Remote = False Then 'switch Remote On
                            Remote = True
                            Remote_label.Text = "On"
                            Remote_label.BackColor = Color.LightGreen
                            cmd = "F" + Str(remote_dest_current) + Chr(13) + Chr(10)
                            Serial_out(cmd)
                            Dest_current_up_button.Enabled = True
                            Dest_current_down_button.Enabled = True
                            Min_current_up_button.Enabled = True
                            Min_current_down_button.Enabled = True
                            Max_current_up_button.Enabled = True
                            Max_current_down_button.Enabled = True
                            Period_up_button.Enabled = True
                            Period_down_button.Enabled = True
                            Dynamic_load_start_button.Enabled = True
                            Timer4.Enabled = True
                            Load_OnOff_Button.Enabled = True
                            ACDC_button.Enabled = True
                        End If
                    Else
                        If Remote = True Then
                            Remote = False
                            Remote_label.Text = "Off"
                            Remote_label.BackColor = Color.LightGray
                            Dest_current_up_button.Enabled = False
                            Dest_current_down_button.Enabled = False
                            Min_current_up_button.Enabled = False
                            Min_current_down_button.Enabled = False
                            Max_current_up_button.Enabled = False
                            Max_current_down_button.Enabled = False
                            Period_up_button.Enabled = False
                            Period_down_button.Enabled = False
                            Dynamic_load_start_button.Enabled = False
                            Timer4.Enabled = False
                            Load_OnOff_Button.Enabled = False
                            ACDC_button.Enabled = False
                        End If
                    End If
                Case "R" 'Current correction factor
                    Current_correction_factor = paramval
                Case "T" 'Voltage correction factor
                    Voltage_correction_factor = paramval

            End Select
        End If
    End Sub


End Class
