'Config Spi = Hard , Interrupt = Off , Data Order = Msb , Master = Yes , Polarity = Low , Phase = 0 , Clockrate = 64 , Noss = 0
'Spiinit

Declare Sub Max7219_init
Declare Sub Set_max7219_command(byval Command As Byte , Byval Value As Byte)
Declare Sub Max7219_display(byval Leftdigits As Single , Byval Rightdigits As Single)

Loadpin Alias Portb.2
Ddrb.2 = 1

Const Digit_0 = 1
Const Digit_1 = 2
Const Digit_2 = 3
Const Digit_3 = 4
Const Digit_4 = 5
Const Digit_5 = 6
Const Digit_6 = 7
Const Digit_7 = 8
Const Decode_mode_reg = &H09
Const Intensity_reg = &H0A
Const Scan_limit_reg = &H0B
Const Shutdown_reg = &H0C

Const Five_digits = 4
Const Six_digits = 5
Const Seven_digits = 6
Const Eight_digits = 7

Const Normal_intensity = 10

Const Shutdown_mode = 0
Const Normal_operation = 1

Const No_decode = 0
Const Code_b_digit0 = 1
Const Code_b_digits3 = &H0F
Const Code_b_digits7 = &HFF


