
'MAX 7219 Library
'for Electronic AC/DC load
'Version 1.0
'Date: 15.11.2019
'Athor: Rainer Schuster

Dim Max_7219_bytes(2) As Byte

'Init MAX7219 mith 6 7 segment displays (3 for voltage, 3 for current)
Sub Max7219_init
        Call Set_max7219_command(shutdown_reg , Shutdown_mode)
        Call Set_max7219_command(scan_limit_reg , Six_digits)
        Call Set_max7219_command(decode_mode_reg , Code_b_digits7)
        Call Set_max7219_command(intensity_reg , Normal_intensity)
        Call Set_max7219_command(digit_0 , 0)
        Call Set_max7219_command(digit_1 , 0)
        Call Set_max7219_command(digit_2 , 0)
        Call Set_max7219_command(digit_3 , 0)
        Call Set_max7219_command(digit_4 , 0)
        Call Set_max7219_command(digit_5 , 0)

        Call Set_max7219_command(shutdown_reg , Normal_operation)
End Sub


'Send command and value for MAX7219 in SPI mode
'refer to datasheet for details
Sub Set_max7219_command(byval Command As Byte , Byval Value As Byte)
   Loadpin = 0
   Max_7219_bytes(1) = Command
   Max_7219_bytes(2) = Value
   Spiout Max_7219_bytes(1) , 2
   Loadpin = 1
End Sub

'Display voltage and current
Sub Max7219_display(byval Leftdigits As Single , Byval Rightdigits As Single)

Local D As Word
Local C As Word
Local B As Byte

   D = Leftdigits
   If D >= 100 Then
      C = D / 100
      B = C
      Call Set_max7219_command(digit_0 , B)
      D = D Mod 100
      B = D / 10
      Call Set_max7219_command(digit_1 , B)
      B = D Mod 10
      Call Set_max7219_command(digit_2 , B)
   Else
      D = Leftdigits * 10
      C = D / 100
      B = C
      Call Set_max7219_command(digit_0 , B)
      D = D Mod 100
      B = D / 10
      B = B Or &H80
      Call Set_max7219_command(digit_1 , B)
      B = D Mod 10
      Call Set_max7219_command(digit_2 , B)
    End If
    D = Rightdigits / 10
    C = D / 100
    B = C
    B = B Or &H80
    Call Set_max7219_command(digit_3 , B)
    D = D Mod 100
    B = D / 10
    Call Set_max7219_command(digit_4 , B)
    B = D Mod 10
    Call Set_max7219_command(digit_5 , B)

End Sub