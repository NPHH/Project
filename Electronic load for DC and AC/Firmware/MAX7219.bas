

'Display voltage and current
Sub Max7219_display(byval Leftdigits As Single , Byval Rightdigits As Single)


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