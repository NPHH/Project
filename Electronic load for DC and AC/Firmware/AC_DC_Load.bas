'Firmware for AC DC Load
'for ATMega 32
'Version 2.0
'6.11.2019
'R. Schuster

$regfile = "m32def.dat"
$crystal = 16000000
$hwstack = 64
$swstack = 128
$framesize = 64
$baud = 19200
Config Serialin = Buffered , Size = 255

Config Adc = Single , Prescaler = Auto
Start Adc


Const Cr = &H0D
Const Lf = &H0A

Const False = 0
Const True = 1


Ac_dc_switch Alias Pinb.0
Ac_dc_relay Alias Portc.5
Ddrc.5 = 1

Load_on_off_switch Alias Pinb.1
On_off_relay Alias Portc.6
Ddrc.6 = 1

Remote_led Alias Portd.3
Ddrd.3 = 1

Soa_led Alias Portd.4
Ddrd.4 = 1

Overvoltage_led Alias Portd.6
Ddrd.6 = 1

Overcurrent_led Alias Portd.7
Ddrd.7 = 1

Overtemp_led Alias Portd.5
Ddrd.5 = 1

Fan Alias Portc.4
Ddrc.4 = 1

Gain_select Alias Portc.7
Ddrc.7 = 1

Const Sec_1 = 1000
Const Msec_500 = 500

Const No_error = 0
Const Overvoltage = 1
Const Overcurrent = 2
Const Overtemp = 4
Const Soa_error = 8

Const Fan_on_temp = 40
Const Fan_off_temp = 35
Const Critical_temp = 80
Const No_critical_temp = 75


Const Max_volts = 400.0
Const Max_amps = 9999.0
Const Min_amps = 200.0

Const P_max = 200.0
Const P_fan_on = 100.0
Const P_fan_off = 80.0

Const Gain_change_voltage = 50

Const Measure_time = 20
Const Avg_measure_time = 10
Const V_corr_factor_default = 0.1

Const A_corr_factor_default = 11
Const Dac_corr_factor_low = 1.67e-3
Const Dac_corr_factor_high = 1.67e-2

Const Regulation_const = 5

Const Overcurrent_wait_time = 1000
Const Fan_off_delay_time = 10000

Dim Cmd_string As String * 20
Dim Cin As Byte
Dim Cmd As String * 1
Dim L1 As Byte
Dim Remote As Byte
Dim Remote_bak As Byte
Dim Arg_string As String * 12
Dim Counter_1 As Word
Dim Counter_2 As Word
Dim Overcurrent_wait_counter As Word
Dim Fan_off_delaycounter As Word
Dim Dest_value As Word
Dim Dest_value_bak As Word
Dim Fatal_error As Byte
Dim Inv_value As Byte


Dim Vrms As Single
Dim V_avg As Single
Dim Volts As Single
Dim Gain As Byte
Dim Dest_current_range As Single
Dim Regulation_value As Integer
Dim Current_corr_value As Single
Dim Voltage_corr_value As Single


Dim Arms As Single
Dim A_avg As Single
Dim Amps As Single

Dim U As Single
Dim I As Single
Dim V As Single
Dim A As Single
Dim Period_counter As Byte
Dim Avg_counter As Byte
Dim Measure_completed As Bit
Dim Vi(22) As Word
Dim Ai(22) As Word
Dim Vai_request As Byte
Dim N As Byte



Dim Dest_current As Single
Dim Max_current As Single
Dim Temp_current As Single

Dim Temp_adcval As Word
Dim Temp As Single

Dim Ptot As Single


$include Mcp4921.inc
$include Max7219.inc

Declare Function Calculate_rms(x As Single) As Single
Declare Sub Set_dest_current()
Declare Function Calculate_heatsink_temp(byval Tempval As Word) As Single


'Initialising
Remote = 0
Remote_led = 1
Overcurrent_led = 1
Soa_led = 1
Arms = 0
Vrms = 0
V_avg = 0
A_avg = 0
Gain_select = 1
Gain = 1
Dest_current_range = 1000
Regulation_value = Regulation_const
Call Max7219_init

'Read current correction factor from EEPROM
'Use default value if <0 or >100
Readeeprom Current_corr_value , 1
If Current_corr_value < 0 Or Current_corr_value > 100 Then
    Current_corr_value = A_corr_factor_default
End If

'Read voltage correction factor from EEPROM
'Use default value if <0 or >1
Readeeprom Voltage_corr_value , 10
If Voltage_corr_value < 0 Or Voltage_corr_value > 1 Then
    Voltage_corr_value = V_corr_factor_default
End If

Counter_1 = 0
Counter_2 = 0
Fatal_error = No_error
V = 0
A = 0
Measure_completed = 0
Period_counter = 0
Avg_counter = 0
Enable Timer0
Enable Timer2
Enable Interrupts
Start Timer0
Start Timer2


'Main Loop
Do
   'Check if any error detected
   'Check max voltage
   If Vrms > Max_volts Then
      Fatal_error = Fatal_error Or Overvoltage
      Call Dac_out(0 , 1)
      Overvoltage_led = 0
      On_off_relay = 0
   Else
      Inv_value = Overvoltage
      Inv_value = Not Inv_value
      Fatal_error = Fatal_error And Inv_value
      Overvoltage_led = 1
   End If

   'Check current 1 second after changing destination current
   If Overcurrent_wait_counter = 0 Then
      Max_current = Dest_current + 1000
      If Max_current > 10000 Then Max_current = 10000
      If Arms > Max_current Then
         Call Dac_out(0 , 1)
         Fatal_error = Fatal_error Or Overcurrent
         Overcurrent_led = 0
         On_off_relay = 0
      End If
   End If

   'Check max power (Safe operating area)
   Ptot = Vrms * Dest_current
   Ptot = Ptot / 1000
   If Ptot > P_max Then
      Call Dac_out(0 , 1)
      Fatal_error = Fatal_error Or Soa_error
      Soa_led = 0
      On_off_relay = 0
   End If

   'Check max. Destination current when load relay = Off
   'Imax = Pmax/Vrms
   If On_off_relay = 0 Then
      If Vrms < 20 Then
          Dest_current_range = 10000
      Else
          Dest_current_range = P_max / Vrms
          Dest_current_range = Dest_current_range * 1000
      End If
   End If

   'Calculate RMS values of Voltage and Current
   'Measure completed will be set in Timer 2 after 20 ADC conversions
   'Urms = SQR (1/20 * (u1² + u2² + ....+u20²))
   'Irms = SQR (1/20 * (i1² + i2² + ....+i20²))
   If Measure_completed = 1 Then
      For N = 1 To Measure_time
         U = Vi(n) * Voltage_corr_value
         U = U * U
         V = V + U
      Next
      Volts = Calculate_rms(v)

      For N = 1 To Measure_time
         I = Ai(n) * Current_corr_value
         I = I * I
         A = A + I
      Next
      If Vai_request = 1 Then                               'send u(i) and i(i) to com port (only for testing)
         Print "U";
         For N = 1 To Measure_time
             Print Vi(n);
             Print ";";
         Next
         Print
         For N = 1 To Measure_time
             Print Ai(n);
             Print ";";
         Next
         Print
         Vai_request = 0
      End If

      Amps = Calculate_rms(a)
      V_avg = V_avg + Volts
      A_avg = A_avg + Amps
      V = 0
      A = 0
      Measure_completed = 0
      Start Timer2
      Avg_counter = Avg_counter + 1
      'Calculate average of voltage/current after 10 RMS readings
      If Avg_counter >= Avg_measure_time Then
         Avg_counter = 0
         Vrms = V_avg / Avg_measure_time
         Arms = A_avg / Avg_measure_time
         V_avg = 0
         A_avg = 0
         If Gain = 1 Then                                   'Voltage Range 50..400V
            Vrms = Vrms * 10
            If Vrms < Gain_change_voltage Then              'Voltage <50V: change to 0..50V range
               Gain = 0
               Gain_select = 0
            End If
         Else
            If Vrms > Gain_change_voltage Then              'Voltage >50V: change to 50..400V
               Gain = 1
               Gain_select = 1
            End If
         End If
         If Fatal_error = 0 And On_off_relay = 1 Then
            Call Set_dest_current()                         'Calculate DAC setting only if load relay On
         Else
            Call Dac_out(0 , 1)
         End If
      End If
   End If


   If Counter_1 >= Msec_500 Then                            'Read switches, calculate heatsink temperature and update display every 500msec
      Counter_1 = 0
      Temp = Calculate_heatsink_temp(temp_adcval)           'Calculate heatsink temperature
      If Temp < Fan_off_temp And Fan_off_delaycounter = 0 Then       'Fan Off if temp <35°C or 10sec over after switching fan on because of power
         Fan = 0
      End If

      If Temp > Fan_on_temp Then                            'switch on fan if temp >40°C or P >100W
         Fan = 1
      End If
       If Ptot > P_fan_on Then
         Fan = 1
         Fan_off_delaycounter = Fan_off_delay_time
       End If

      If Temp > Critical_temp Then                          'Temp error
         Call Dac_out(0 , 1)
         Fatal_error = Fatal_error Or Overtemp
         Overtemp_led = 0
         On_off_relay = 0
      Else
         If Temp < No_critical_temp Then
            Inv_value = Overtemp
            Inv_value = Not Inv_value
            Fatal_error = Fatal_error And Inv_value
            Overtemp_led = 1
         End If
      End If

      Call Max7219_display(vrms , Arms)                     'Update display
      If Remote = 0 Then
         If Ac_dc_switch = 0 Then                           'read on/off switch an AC/DC switch and Destination current pot only in local mode
            Ac_dc_relay = 0
         Else
            Ac_dc_relay = 1
         End If
         If Load_on_off_switch = 0 Then
            If Fatal_error = No_error Then                  'switch on Load if no error
               On_off_relay = 1
            End If
         Else
            Call Dac_out(0 , 1)
            On_off_relay = 0
            Inv_value = Fatal_error And Overcurrent         'reset error condiition when load is switched off  and no error anymore
            If Inv_value > 0 Then
               Inv_value = Overcurrent
               Inv_value = Not Inv_value
               Fatal_error = Fatal_error And Inv_value
               Overcurrent_led = 1
            End If
            Inv_value = Fatal_error And Soa_error
            If Inv_value > 0 Then
               If Ptot < P_max Then
                  Inv_value = Soa_error
                  Inv_value = Not Inv_value
                  Fatal_error = Fatal_error And Inv_value
                  Soa_led = 1
               End If
            End If
         End If
      End If
   End If

   If Remote = 0 Then                                       'Read destination current pot in local mode
      If Dest_value <> Dest_value_bak Then
         Dest_current = Dest_value / 1023
         Dest_current = Dest_current * Dest_current_range
         Dest_value_bak = Dest_value
         Disable Timer0
         Overcurrent_wait_counter = Overcurrent_wait_time
         Enable Timer0
      End If
   End If



   While Ischarwaiting() > 0                                'Check if characters available on COM port
      Cin = Waitkey()
      If Cin = Lf Then
         Cmd = Mid(cmd_string , 1 , 1)
         L1 = Len(cmd_string)
         If L1 > 1 Then
            Arg_string = Mid(cmd_string , 2 , L1)
         End If
         Select Case Cmd
            Case "A" : Print "AAC DC Load V1.0"             'Send ID string
            Case "B":                                       'Set/clear remote control
                  If Arg_string = "1" Then
                      Remote = 1
                      Remote_led = 0
                  Else
                      Remote = 0
                      Remote_led = 1
                  End If
            Case "C":
               Print "C" ; Vrms
            Case "D":
               Print "D" ; Arms
            Case "E":
                  Print "E" ; Dest_current
            Case "F":                                       'Set Dest current
               If Remote = 1 Then
                  If Val(arg_string) < 10000 Then
                     Dest_current = Val(arg_string)
                     Disable Timer0
                     Overcurrent_wait_counter = Overcurrent_wait_time
                     Enable Timer0
                  End If
               End If
            Case "G":                                       'Print Error state
               Print "G" ; Fatal_error
            Case "H":                                       'Print Heatsink temperature
               Print "H" ; Temp
            Case "I":                                       'Switch AC/DC Relay in Remote Mode
               If Remote = 1 Then
                  If Arg_string = "1" Then
                       Ac_dc_relay = 0
                  Else
                       Ac_dc_relay = 1
                  End If
               End If
            Case "J":                                       'Switch Load on/off in remote mode (on only if no error)
               If Remote = 1 Then
                  If Arg_string = "1" Then
                     If Fatal_error = No_error Then
                        On_off_relay = 1
                     End If
                  Else
                     Call Dac_out(0 , 1)
                     On_off_relay = 0
                     Inv_value = Fatal_error And Overcurrent
                     If Inv_value > 0 Then
                        Inv_value = Overcurrent
                        Inv_value = Not Inv_value
                        Fatal_error = Fatal_error And Inv_value
                        Overcurrent_led = 1
                     End If
                     Inv_value = Fatal_error And Soa_error
                     If Inv_value > 0 Then
                        If Ptot < P_max Then
                           Inv_value = Soa_error
                           Inv_value = Not Inv_value
                           Fatal_error = Fatal_error And Inv_value
                           Soa_led = 1
                        End If
                     End If
                  End If
               End If
            Case "K":                                       'print Load relay state
               Print "K" ; On_off_relay
            Case "L":                                       'Print AC/DC Relay state
               Print "L" ; Ac_dc_relay
            Case "M":
               Print "M" ; Ptot
            Case "N":
               Print "N" ; Dest_current_range
            Case "O":                                       'Print remote state
               Print "O" ; Remote
            Case "P":
               Current_corr_value = Val(arg_string)         'Set current correction value and store in EEPROM
               Writeeeprom Current_corr_value , 1
            Case "R":
               Print "R" ; Current_corr_value
            Case "S":                                       'Set volatge correction value and store in EEPROM
               Voltage_corr_value = Val(arg_string)
               Writeeeprom Voltage_corr_value , 10
            Case "T":
               Print "T" ; Voltage_corr_value
            Case "U":                                       'send u(i) and i(i) only for testing purposes
               Vai_request = 1

         End Select
         Cmd_string = ""
      Else
         If Cin <> Cr Then
            Cmd_string = Cmd_string + Chr(cin)
         End If
      End If
  Wend


Loop

'Calculate heatsink temperature (see description for details)
Function Calculate_heatsink_temp(byval Tempval As Word) As Single

Local T As Single

   If Tempval >= 366 Then                                   'Temp < 40°C
         T = Tempval - 366
         T = T * -0.1
         T = T + 40
   Else
      If Tempval >= 218 Then                                'Temp < 60°C
         T = Tempval - 218
         T = T * -0.135
         T = T + 60
      Else
         If Tempval >= 128 Then                             'Temp <80°C
            T = Tempval - 128
            T = T * -0.222
            T = T + 80
         Else
            T = Tempval - 76
            T = T * -0.385
            T = T + 100
         End If
      End If
   End If
   Calculate_heatsink_temp = T
End Function


'Calculate RMS values
Function Calculate_rms(x As Single) As Single

   Local X1 As Single

   X1 = X / Measure_time
   X1 = Sqr(x1)
   Calculate_rms = X1
End Function

'Timer interrupt routine will be called every ms with highest priority
'Reading of u(i) and i(i) and destination current pot and heatsink temperature
Tim2_isr:
   Timer2 = 256 - 16                                        '16 * 64usec = 1msec
   Vi(period_counter + 1) = Getadc(0)
   Ai(period_counter + 1) = Getadc(1)
   Dest_value = Getadc(3)                                   ' Read Destination Current/Resistor on ADC3
   Temp_adcval = Getadc(2)
   Period_counter = Period_counter + 1
   If Period_counter = Measure_time Then
      Period_counter = 0
      Measure_completed = 1
      Stop Timer2
   End If
Return

'Calculate DAC value for destination current setting'
'activate I - characteristic regulation if Dest current >30mA
'see description for details
Sub Set_dest_current()


   Local Dac_volts As Single
   Local Uin As Single
   Local Dac_gain As Byte
   Local Calculated_current As Word

   Dac_gain = 1
   If Vrms < 2 Then
      Calculated_current = 0
   Else
      If Dest_current > 0 Then
         If Dest_current <= 30 Then                         'No I regulation
            Regulation_value = Regulation_const
            If Ac_dc_relay = 1 Then
               Temp_current = Dest_current + 50
            Else
               Temp_current = Dest_current + 100
            End If
         Else
            Temp_current = Dest_current + Regulation_value
            If Temp_current < 0 Then Temp_current = 0
            If Temp_current > Dest_current_range Then Temp_current = Dest_current_range
            If Arms < Dest_current Then
               Regulation_value = Regulation_value + Regulation_const
            Else
               If Arms > Dest_current Then
                  Regulation_value = Regulation_value - Regulation_const
               End If
            End If
         End If
      Else
         Temp_current = Dest_current
      End If

      Dac_volts = Temp_current / Vrms
      If Gain = 0 Then
        Dac_volts = Dac_volts * Dac_corr_factor_low
      Else
        Dac_volts = Dac_volts * Dac_corr_factor_high
      End If
      If Dac_volts > 2.5 Then
         Dac_gain = 2
         Dac_volts = Dac_volts / 2
      End If
      Dac_volts = Dac_volts * 4095
      Dac_volts = Dac_volts / 2.5
      Calculated_current = Dac_volts
   End If
   Call Dac_out(calculated_current , Dac_gain)

End Sub

'Timer 0 interrupt routine every 1ms
'used as general purpose timer
Tim0_isr:

   Timer0 = 256 - 62                                        ' 62 *16 usec=1ms Interval
   Counter_1 = Counter_1 + 1
   Counter_2 = Counter_2 + 1
   If Overcurrent_wait_counter > 0 Then
       Overcurrent_wait_counter = Overcurrent_wait_counter - 1
   End If
   If Fan_off_delaycounter > 0 Then
      Fan_off_delaycounter = Fan_off_delaycounter - 1
   End If
   Return

'include functions for 12bit DAC
$include Mcp4921.bas
'include functions for MAX7219 display driver
$include Max7219.bas