<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series9 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series10 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series11 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series12 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Statuslabel = New System.Windows.Forms.Label()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Current_unit_button = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Trace_button = New System.Windows.Forms.Button()
        Me.Actvolts_button = New System.Windows.Forms.Button()
        Me.Actcurrent_button = New System.Windows.Forms.Button()
        Me.Actual_power_button = New System.Windows.Forms.Button()
        Me.Dest_current_button = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Samplingtime_button = New System.Windows.Forms.Button()
        Me.Range_textbox = New System.Windows.Forms.TextBox()
        Me.Sampling_time_textbox = New System.Windows.Forms.TextBox()
        Me.Remote_button = New System.Windows.Forms.Button()
        Me.Load_OnOff_Button = New System.Windows.Forms.Button()
        Me.ACDC_button = New System.Windows.Forms.Button()
        Me.Remote_label = New System.Windows.Forms.Label()
        Me.Load_label = New System.Windows.Forms.Label()
        Me.ACDC_label = New System.Windows.Forms.Label()
        Me.Dest_current_up_button = New System.Windows.Forms.Button()
        Me.Dest_current_down_button = New System.Windows.Forms.Button()
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer5 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Period_display = New System.Windows.Forms.Label()
        Me.Max_current_display = New System.Windows.Forms.Label()
        Me.Min_current_display = New System.Windows.Forms.Label()
        Me.Dynamic_load_start_button = New System.Windows.Forms.Button()
        Me.Period_down_button = New System.Windows.Forms.Button()
        Me.Period_up_button = New System.Windows.Forms.Button()
        Me.Max_current_down_button = New System.Windows.Forms.Button()
        Me.Max_current_up_button = New System.Windows.Forms.Button()
        Me.Min_current_down_button = New System.Windows.Forms.Button()
        Me.Min_current_up_button = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Timer6 = New System.Windows.Forms.Timer(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SOA_LED = New System.Windows.Forms.Label()
        Me.T_LED = New System.Windows.Forms.Label()
        Me.U_LED = New System.Windows.Forms.Label()
        Me.I_LED = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.Timer7 = New System.Windows.Forms.Timer(Me.components)
        Me.Actual_Voltage_display = New System.Windows.Forms.Label()
        Me.Actual_current_display = New System.Windows.Forms.Label()
        Me.Actual_power_display = New System.Windows.Forms.Label()
        Me.Max_dest_current_display = New System.Windows.Forms.Label()
        Me.Dest_current_display = New System.Windows.Forms.Label()
        Me.Heatsink_temp_display = New System.Windows.Forms.Label()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        ChartArea3.BorderColor = System.Drawing.Color.White
        ChartArea3.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend3)
        Me.Chart1.Location = New System.Drawing.Point(12, 49)
        Me.Chart1.Name = "Chart1"
        Series9.ChartArea = "ChartArea1"
        Series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series9.LabelForeColor = System.Drawing.Color.Red
        Series9.Legend = "Legend1"
        Series9.Name = "Actual current"
        Series10.ChartArea = "ChartArea1"
        Series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series10.Legend = "Legend1"
        Series10.Name = "Destination current"
        Series11.ChartArea = "ChartArea1"
        Series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series11.Legend = "Legend1"
        Series11.Name = "Voltage"
        Series12.ChartArea = "ChartArea1"
        Series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series12.Legend = "Legend1"
        Series12.Name = "Actual Power"
        Me.Chart1.Series.Add(Series9)
        Me.Chart1.Series.Add(Series10)
        Me.Chart1.Series.Add(Series11)
        Me.Chart1.Series.Add(Series12)
        Me.Chart1.Size = New System.Drawing.Size(926, 573)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1084, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Actual voltage [VRMS]"
        '
        'SerialPort
        '
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Statuslabel
        '
        Me.Statuslabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Statuslabel.Location = New System.Drawing.Point(12, 640)
        Me.Statuslabel.Name = "Statuslabel"
        Me.Statuslabel.Size = New System.Drawing.Size(1416, 32)
        Me.Statuslabel.TabIndex = 3
        Me.Statuslabel.Text = "Establishing connection...."
        Me.Statuslabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1217, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Actual current [ARMS]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1407, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Actual Power [W]"
        '
        'Current_unit_button
        '
        Me.Current_unit_button.Location = New System.Drawing.Point(1236, 99)
        Me.Current_unit_button.Name = "Current_unit_button"
        Me.Current_unit_button.Size = New System.Drawing.Size(82, 23)
        Me.Current_unit_button.TabIndex = 8
        Me.Current_unit_button.Text = "mARMS"
        Me.Current_unit_button.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1087, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Max Dest current [ARMS]"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1292, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Destination current [ARMS]"
        '
        'Trace_button
        '
        Me.Trace_button.Location = New System.Drawing.Point(960, 49)
        Me.Trace_button.Name = "Trace_button"
        Me.Trace_button.Size = New System.Drawing.Size(75, 23)
        Me.Trace_button.TabIndex = 14
        Me.Trace_button.Text = "Start Trace"
        Me.Trace_button.UseVisualStyleBackColor = True
        '
        'Actvolts_button
        '
        Me.Actvolts_button.BackColor = System.Drawing.SystemColors.Control
        Me.Actvolts_button.Location = New System.Drawing.Point(960, 84)
        Me.Actvolts_button.Name = "Actvolts_button"
        Me.Actvolts_button.Size = New System.Drawing.Size(75, 38)
        Me.Actvolts_button.TabIndex = 15
        Me.Actvolts_button.Text = "Actual voltage"
        Me.Actvolts_button.UseVisualStyleBackColor = False
        '
        'Actcurrent_button
        '
        Me.Actcurrent_button.BackColor = System.Drawing.SystemColors.Control
        Me.Actcurrent_button.Location = New System.Drawing.Point(960, 137)
        Me.Actcurrent_button.Name = "Actcurrent_button"
        Me.Actcurrent_button.Size = New System.Drawing.Size(75, 36)
        Me.Actcurrent_button.TabIndex = 16
        Me.Actcurrent_button.Text = "Actual current"
        Me.Actcurrent_button.UseVisualStyleBackColor = False
        '
        'Actual_power_button
        '
        Me.Actual_power_button.BackColor = System.Drawing.SystemColors.Control
        Me.Actual_power_button.Location = New System.Drawing.Point(960, 192)
        Me.Actual_power_button.Name = "Actual_power_button"
        Me.Actual_power_button.Size = New System.Drawing.Size(75, 37)
        Me.Actual_power_button.TabIndex = 17
        Me.Actual_power_button.Text = "Actual power"
        Me.Actual_power_button.UseVisualStyleBackColor = False
        '
        'Dest_current_button
        '
        Me.Dest_current_button.BackColor = System.Drawing.SystemColors.Control
        Me.Dest_current_button.Location = New System.Drawing.Point(960, 250)
        Me.Dest_current_button.Name = "Dest_current_button"
        Me.Dest_current_button.Size = New System.Drawing.Size(75, 37)
        Me.Dest_current_button.TabIndex = 18
        Me.Dest_current_button.Text = "Destination current"
        Me.Dest_current_button.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(960, 376)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 34)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Set Y-Range"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Samplingtime_button
        '
        Me.Samplingtime_button.Location = New System.Drawing.Point(960, 544)
        Me.Samplingtime_button.Name = "Samplingtime_button"
        Me.Samplingtime_button.Size = New System.Drawing.Size(75, 35)
        Me.Samplingtime_button.TabIndex = 20
        Me.Samplingtime_button.Text = "Sampling time msec"
        Me.Samplingtime_button.UseVisualStyleBackColor = True
        '
        'Range_textbox
        '
        Me.Range_textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Range_textbox.Location = New System.Drawing.Point(960, 340)
        Me.Range_textbox.MaxLength = 5
        Me.Range_textbox.Name = "Range_textbox"
        Me.Range_textbox.Size = New System.Drawing.Size(75, 26)
        Me.Range_textbox.TabIndex = 21
        Me.Range_textbox.Text = "100"
        Me.Range_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Sampling_time_textbox
        '
        Me.Sampling_time_textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sampling_time_textbox.Location = New System.Drawing.Point(960, 507)
        Me.Sampling_time_textbox.MaxLength = 5
        Me.Sampling_time_textbox.Name = "Sampling_time_textbox"
        Me.Sampling_time_textbox.Size = New System.Drawing.Size(75, 26)
        Me.Sampling_time_textbox.TabIndex = 22
        Me.Sampling_time_textbox.Text = "1000"
        Me.Sampling_time_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Remote_button
        '
        Me.Remote_button.Location = New System.Drawing.Point(1096, 257)
        Me.Remote_button.Name = "Remote_button"
        Me.Remote_button.Size = New System.Drawing.Size(75, 23)
        Me.Remote_button.TabIndex = 25
        Me.Remote_button.Text = "Remote"
        Me.Remote_button.UseVisualStyleBackColor = True
        '
        'Load_OnOff_Button
        '
        Me.Load_OnOff_Button.Enabled = False
        Me.Load_OnOff_Button.Location = New System.Drawing.Point(1271, 257)
        Me.Load_OnOff_Button.Name = "Load_OnOff_Button"
        Me.Load_OnOff_Button.Size = New System.Drawing.Size(75, 23)
        Me.Load_OnOff_Button.TabIndex = 26
        Me.Load_OnOff_Button.Text = "Load"
        Me.Load_OnOff_Button.UseVisualStyleBackColor = True
        '
        'ACDC_button
        '
        Me.ACDC_button.Enabled = False
        Me.ACDC_button.Location = New System.Drawing.Point(1433, 257)
        Me.ACDC_button.Name = "ACDC_button"
        Me.ACDC_button.Size = New System.Drawing.Size(75, 23)
        Me.ACDC_button.TabIndex = 27
        Me.ACDC_button.Text = "AC/DC"
        Me.ACDC_button.UseVisualStyleBackColor = True
        '
        'Remote_label
        '
        Me.Remote_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Remote_label.Location = New System.Drawing.Point(1096, 231)
        Me.Remote_label.Name = "Remote_label"
        Me.Remote_label.Size = New System.Drawing.Size(75, 16)
        Me.Remote_label.TabIndex = 28
        Me.Remote_label.Text = "Off"
        Me.Remote_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Load_label
        '
        Me.Load_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Load_label.Location = New System.Drawing.Point(1271, 231)
        Me.Load_label.Name = "Load_label"
        Me.Load_label.Size = New System.Drawing.Size(75, 17)
        Me.Load_label.TabIndex = 29
        Me.Load_label.Text = "Off"
        Me.Load_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ACDC_label
        '
        Me.ACDC_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ACDC_label.Location = New System.Drawing.Point(1433, 231)
        Me.ACDC_label.Name = "ACDC_label"
        Me.ACDC_label.Size = New System.Drawing.Size(75, 18)
        Me.ACDC_label.TabIndex = 30
        Me.ACDC_label.Text = "DC"
        Me.ACDC_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dest_current_up_button
        '
        Me.Dest_current_up_button.Enabled = False
        Me.Dest_current_up_button.Image = CType(resources.GetObject("Dest_current_up_button.Image"), System.Drawing.Image)
        Me.Dest_current_up_button.Location = New System.Drawing.Point(1371, 154)
        Me.Dest_current_up_button.Name = "Dest_current_up_button"
        Me.Dest_current_up_button.Size = New System.Drawing.Size(57, 31)
        Me.Dest_current_up_button.TabIndex = 31
        Me.Dest_current_up_button.UseVisualStyleBackColor = True
        '
        'Dest_current_down_button
        '
        Me.Dest_current_down_button.Enabled = False
        Me.Dest_current_down_button.Image = CType(resources.GetObject("Dest_current_down_button.Image"), System.Drawing.Image)
        Me.Dest_current_down_button.Location = New System.Drawing.Point(1448, 154)
        Me.Dest_current_down_button.Name = "Dest_current_down_button"
        Me.Dest_current_down_button.Size = New System.Drawing.Size(60, 31)
        Me.Dest_current_down_button.TabIndex = 32
        Me.Dest_current_down_button.UseVisualStyleBackColor = True
        '
        'Timer4
        '
        '
        'Timer5
        '
        Me.Timer5.Interval = 2000
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Period_display)
        Me.GroupBox1.Controls.Add(Me.Max_current_display)
        Me.GroupBox1.Controls.Add(Me.Min_current_display)
        Me.GroupBox1.Controls.Add(Me.Dynamic_load_start_button)
        Me.GroupBox1.Controls.Add(Me.Period_down_button)
        Me.GroupBox1.Controls.Add(Me.Period_up_button)
        Me.GroupBox1.Controls.Add(Me.Max_current_down_button)
        Me.GroupBox1.Controls.Add(Me.Max_current_up_button)
        Me.GroupBox1.Controls.Add(Me.Min_current_down_button)
        Me.GroupBox1.Controls.Add(Me.Min_current_up_button)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(1096, 320)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 161)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dynamic Load test"
        '
        'Period_display
        '
        Me.Period_display.AutoSize = True
        Me.Period_display.BackColor = System.Drawing.Color.Black
        Me.Period_display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Period_display.Font = New System.Drawing.Font("Distant Galaxy", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Period_display.ForeColor = System.Drawing.Color.OrangeRed
        Me.Period_display.Location = New System.Drawing.Point(302, 20)
        Me.Period_display.Name = "Period_display"
        Me.Period_display.Size = New System.Drawing.Size(89, 35)
        Me.Period_display.TabIndex = 15
        Me.Period_display.Text = "00.0"
        Me.Period_display.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Max_current_display
        '
        Me.Max_current_display.AutoSize = True
        Me.Max_current_display.BackColor = System.Drawing.Color.Black
        Me.Max_current_display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Max_current_display.Font = New System.Drawing.Font("Distant Galaxy", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Max_current_display.ForeColor = System.Drawing.Color.OrangeRed
        Me.Max_current_display.Location = New System.Drawing.Point(140, 20)
        Me.Max_current_display.Name = "Max_current_display"
        Me.Max_current_display.Size = New System.Drawing.Size(110, 35)
        Me.Max_current_display.TabIndex = 14
        Me.Max_current_display.Text = "00.00"
        Me.Max_current_display.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Min_current_display
        '
        Me.Min_current_display.AutoSize = True
        Me.Min_current_display.BackColor = System.Drawing.Color.Black
        Me.Min_current_display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Min_current_display.Font = New System.Drawing.Font("Distant Galaxy", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Min_current_display.ForeColor = System.Drawing.Color.OrangeRed
        Me.Min_current_display.Location = New System.Drawing.Point(7, 20)
        Me.Min_current_display.Name = "Min_current_display"
        Me.Min_current_display.Size = New System.Drawing.Size(110, 35)
        Me.Min_current_display.TabIndex = 13
        Me.Min_current_display.Text = "00.00"
        Me.Min_current_display.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dynamic_load_start_button
        '
        Me.Dynamic_load_start_button.Enabled = False
        Me.Dynamic_load_start_button.Location = New System.Drawing.Point(159, 132)
        Me.Dynamic_load_start_button.Name = "Dynamic_load_start_button"
        Me.Dynamic_load_start_button.Size = New System.Drawing.Size(75, 23)
        Me.Dynamic_load_start_button.TabIndex = 12
        Me.Dynamic_load_start_button.Text = "Start"
        Me.Dynamic_load_start_button.UseVisualStyleBackColor = True
        '
        'Period_down_button
        '
        Me.Period_down_button.Enabled = False
        Me.Period_down_button.Image = CType(resources.GetObject("Period_down_button.Image"), System.Drawing.Image)
        Me.Period_down_button.Location = New System.Drawing.Point(357, 88)
        Me.Period_down_button.Name = "Period_down_button"
        Me.Period_down_button.Size = New System.Drawing.Size(34, 31)
        Me.Period_down_button.TabIndex = 11
        Me.Period_down_button.UseVisualStyleBackColor = True
        '
        'Period_up_button
        '
        Me.Period_up_button.Enabled = False
        Me.Period_up_button.Image = CType(resources.GetObject("Period_up_button.Image"), System.Drawing.Image)
        Me.Period_up_button.Location = New System.Drawing.Point(302, 88)
        Me.Period_up_button.Name = "Period_up_button"
        Me.Period_up_button.Size = New System.Drawing.Size(34, 31)
        Me.Period_up_button.TabIndex = 10
        Me.Period_up_button.UseVisualStyleBackColor = True
        '
        'Max_current_down_button
        '
        Me.Max_current_down_button.Enabled = False
        Me.Max_current_down_button.Image = CType(resources.GetObject("Max_current_down_button.Image"), System.Drawing.Image)
        Me.Max_current_down_button.Location = New System.Drawing.Point(216, 88)
        Me.Max_current_down_button.Name = "Max_current_down_button"
        Me.Max_current_down_button.Size = New System.Drawing.Size(34, 31)
        Me.Max_current_down_button.TabIndex = 9
        Me.Max_current_down_button.UseVisualStyleBackColor = True
        '
        'Max_current_up_button
        '
        Me.Max_current_up_button.Enabled = False
        Me.Max_current_up_button.Image = CType(resources.GetObject("Max_current_up_button.Image"), System.Drawing.Image)
        Me.Max_current_up_button.Location = New System.Drawing.Point(140, 88)
        Me.Max_current_up_button.Name = "Max_current_up_button"
        Me.Max_current_up_button.Size = New System.Drawing.Size(34, 31)
        Me.Max_current_up_button.TabIndex = 8
        Me.Max_current_up_button.UseVisualStyleBackColor = True
        '
        'Min_current_down_button
        '
        Me.Min_current_down_button.Enabled = False
        Me.Min_current_down_button.Image = CType(resources.GetObject("Min_current_down_button.Image"), System.Drawing.Image)
        Me.Min_current_down_button.Location = New System.Drawing.Point(82, 88)
        Me.Min_current_down_button.Name = "Min_current_down_button"
        Me.Min_current_down_button.Size = New System.Drawing.Size(34, 31)
        Me.Min_current_down_button.TabIndex = 7
        Me.Min_current_down_button.UseVisualStyleBackColor = True
        '
        'Min_current_up_button
        '
        Me.Min_current_up_button.Enabled = False
        Me.Min_current_up_button.Image = CType(resources.GetObject("Min_current_up_button.Image"), System.Drawing.Image)
        Me.Min_current_up_button.Location = New System.Drawing.Point(6, 88)
        Me.Min_current_up_button.Name = "Min_current_up_button"
        Me.Min_current_up_button.Size = New System.Drawing.Size(34, 31)
        Me.Min_current_up_button.TabIndex = 6
        Me.Min_current_up_button.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(311, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 18)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Period [s]"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(144, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 18)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Max. Amps"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(3, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Min. Amps"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer6
        '
        Me.Timer6.Interval = 1000
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1079, 544)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 13)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Heatsink Temp [°C]"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.SOA_LED)
        Me.GroupBox2.Controls.Add(Me.T_LED)
        Me.GroupBox2.Controls.Add(Me.U_LED)
        Me.GroupBox2.Controls.Add(Me.I_LED)
        Me.GroupBox2.Location = New System.Drawing.Point(1208, 498)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(220, 59)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Errors"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(125, 43)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(23, 13)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "> T"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(172, 43)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = ">SOA"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(68, 43)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "> U"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "> I"
        '
        'SOA_LED
        '
        Me.SOA_LED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SOA_LED.Location = New System.Drawing.Point(175, 20)
        Me.SOA_LED.Name = "SOA_LED"
        Me.SOA_LED.Size = New System.Drawing.Size(27, 15)
        Me.SOA_LED.TabIndex = 3
        '
        'T_LED
        '
        Me.T_LED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.T_LED.Location = New System.Drawing.Point(121, 20)
        Me.T_LED.Name = "T_LED"
        Me.T_LED.Size = New System.Drawing.Size(27, 15)
        Me.T_LED.TabIndex = 2
        '
        'U_LED
        '
        Me.U_LED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.U_LED.Location = New System.Drawing.Point(68, 20)
        Me.U_LED.Name = "U_LED"
        Me.U_LED.Size = New System.Drawing.Size(27, 15)
        Me.U_LED.TabIndex = 1
        '
        'I_LED
        '
        Me.I_LED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.I_LED.Location = New System.Drawing.Point(13, 20)
        Me.I_LED.Name = "I_LED"
        Me.I_LED.Size = New System.Drawing.Size(27, 15)
        Me.I_LED.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1520, 25)
        Me.ToolStrip1.TabIndex = 37
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Open/Close Logfile"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        Me.ToolStripButton2.ToolTipText = "Set Sampling time for Logfile"
        '
        'Timer7
        '
        Me.Timer7.Interval = 1000
        '
        'Actual_Voltage_display
        '
        Me.Actual_Voltage_display.AutoSize = True
        Me.Actual_Voltage_display.BackColor = System.Drawing.Color.Black
        Me.Actual_Voltage_display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Actual_Voltage_display.Font = New System.Drawing.Font("Distant Galaxy", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Actual_Voltage_display.ForeColor = System.Drawing.Color.Crimson
        Me.Actual_Voltage_display.Location = New System.Drawing.Point(1087, 35)
        Me.Actual_Voltage_display.Name = "Actual_Voltage_display"
        Me.Actual_Voltage_display.Size = New System.Drawing.Size(114, 37)
        Me.Actual_Voltage_display.TabIndex = 38
        Me.Actual_Voltage_display.Text = "000.0"
        Me.Actual_Voltage_display.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Actual_current_display
        '
        Me.Actual_current_display.AutoSize = True
        Me.Actual_current_display.BackColor = System.Drawing.Color.Black
        Me.Actual_current_display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Actual_current_display.Font = New System.Drawing.Font("Distant Galaxy", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Actual_current_display.ForeColor = System.Drawing.Color.Chartreuse
        Me.Actual_current_display.Location = New System.Drawing.Point(1224, 35)
        Me.Actual_current_display.Name = "Actual_current_display"
        Me.Actual_current_display.Size = New System.Drawing.Size(122, 35)
        Me.Actual_current_display.TabIndex = 39
        Me.Actual_current_display.Text = "00000"
        Me.Actual_current_display.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Actual_power_display
        '
        Me.Actual_power_display.AutoSize = True
        Me.Actual_power_display.BackColor = System.Drawing.Color.Black
        Me.Actual_power_display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Actual_power_display.Font = New System.Drawing.Font("Distant Galaxy", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Actual_power_display.ForeColor = System.Drawing.Color.Yellow
        Me.Actual_power_display.Location = New System.Drawing.Point(1398, 35)
        Me.Actual_power_display.Name = "Actual_power_display"
        Me.Actual_power_display.Size = New System.Drawing.Size(110, 35)
        Me.Actual_power_display.TabIndex = 40
        Me.Actual_power_display.Text = "000.0"
        Me.Actual_power_display.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Max_dest_current_display
        '
        Me.Max_dest_current_display.AutoSize = True
        Me.Max_dest_current_display.BackColor = System.Drawing.Color.Black
        Me.Max_dest_current_display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Max_dest_current_display.Font = New System.Drawing.Font("Distant Galaxy", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Max_dest_current_display.ForeColor = System.Drawing.Color.LightSalmon
        Me.Max_dest_current_display.Location = New System.Drawing.Point(1090, 154)
        Me.Max_dest_current_display.Name = "Max_dest_current_display"
        Me.Max_dest_current_display.Size = New System.Drawing.Size(122, 35)
        Me.Max_dest_current_display.TabIndex = 41
        Me.Max_dest_current_display.Text = "00000"
        Me.Max_dest_current_display.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dest_current_display
        '
        Me.Dest_current_display.AutoSize = True
        Me.Dest_current_display.BackColor = System.Drawing.Color.Black
        Me.Dest_current_display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dest_current_display.Font = New System.Drawing.Font("Distant Galaxy", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dest_current_display.ForeColor = System.Drawing.Color.Blue
        Me.Dest_current_display.Location = New System.Drawing.Point(1224, 154)
        Me.Dest_current_display.Name = "Dest_current_display"
        Me.Dest_current_display.Size = New System.Drawing.Size(122, 35)
        Me.Dest_current_display.TabIndex = 42
        Me.Dest_current_display.Text = "00000"
        Me.Dest_current_display.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Heatsink_temp_display
        '
        Me.Heatsink_temp_display.AutoSize = True
        Me.Heatsink_temp_display.BackColor = System.Drawing.Color.Black
        Me.Heatsink_temp_display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Heatsink_temp_display.Font = New System.Drawing.Font("Distant Galaxy", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Heatsink_temp_display.ForeColor = System.Drawing.Color.Orange
        Me.Heatsink_temp_display.Location = New System.Drawing.Point(1082, 507)
        Me.Heatsink_temp_display.Name = "Heatsink_temp_display"
        Me.Heatsink_temp_display.Size = New System.Drawing.Size(89, 35)
        Me.Heatsink_temp_display.TabIndex = 43
        Me.Heatsink_temp_display.Text = "00.0"
        Me.Heatsink_temp_display.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        Me.ToolStripButton3.ToolTipText = "Calibrate Display"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1520, 681)
        Me.Controls.Add(Me.Heatsink_temp_display)
        Me.Controls.Add(Me.Dest_current_display)
        Me.Controls.Add(Me.Max_dest_current_display)
        Me.Controls.Add(Me.Actual_power_display)
        Me.Controls.Add(Me.Actual_current_display)
        Me.Controls.Add(Me.Actual_Voltage_display)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Dest_current_down_button)
        Me.Controls.Add(Me.Dest_current_up_button)
        Me.Controls.Add(Me.ACDC_label)
        Me.Controls.Add(Me.Load_label)
        Me.Controls.Add(Me.Remote_label)
        Me.Controls.Add(Me.ACDC_button)
        Me.Controls.Add(Me.Load_OnOff_Button)
        Me.Controls.Add(Me.Remote_button)
        Me.Controls.Add(Me.Sampling_time_textbox)
        Me.Controls.Add(Me.Range_textbox)
        Me.Controls.Add(Me.Samplingtime_button)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Dest_current_button)
        Me.Controls.Add(Me.Actual_power_button)
        Me.Controls.Add(Me.Actcurrent_button)
        Me.Controls.Add(Me.Actvolts_button)
        Me.Controls.Add(Me.Trace_button)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Current_unit_button)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Statuslabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Chart1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Electronic AC/DC Load"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Label1 As Label
    Friend WithEvents SerialPort As IO.Ports.SerialPort
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Statuslabel As Label
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Current_unit_button As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Trace_button As Button
    Friend WithEvents Actvolts_button As Button
    Friend WithEvents Actcurrent_button As Button
    Friend WithEvents Actual_power_button As Button
    Friend WithEvents Dest_current_button As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Samplingtime_button As Button
    Friend WithEvents Range_textbox As TextBox
    Friend WithEvents Sampling_time_textbox As TextBox
    Friend WithEvents Remote_button As Button
    Friend WithEvents Load_OnOff_Button As Button
    Friend WithEvents ACDC_button As Button
    Friend WithEvents Remote_label As Label
    Friend WithEvents Load_label As Label
    Friend WithEvents ACDC_label As Label
    Friend WithEvents Dest_current_up_button As Button
    Friend WithEvents Dest_current_down_button As Button
    Friend WithEvents Timer4 As Timer
    Friend WithEvents Timer5 As Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Dynamic_load_start_button As Button
    Friend WithEvents Period_down_button As Button
    Friend WithEvents Period_up_button As Button
    Friend WithEvents Max_current_down_button As Button
    Friend WithEvents Max_current_up_button As Button
    Friend WithEvents Min_current_down_button As Button
    Friend WithEvents Min_current_up_button As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Timer6 As Timer
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents SOA_LED As Label
    Friend WithEvents T_LED As Label
    Friend WithEvents U_LED As Label
    Friend WithEvents I_LED As Label
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents Timer7 As Timer
    Friend WithEvents Actual_Voltage_display As Label
    Friend WithEvents Actual_current_display As Label
    Friend WithEvents Actual_power_display As Label
    Friend WithEvents Max_dest_current_display As Label
    Friend WithEvents Dest_current_display As Label
    Friend WithEvents Min_current_display As Label
    Friend WithEvents Max_current_display As Label
    Friend WithEvents Period_display As Label
    Friend WithEvents Heatsink_temp_display As Label
    Friend WithEvents ToolStripButton3 As ToolStripButton
End Class
