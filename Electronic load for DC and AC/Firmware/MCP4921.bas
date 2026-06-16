'Functions for MCP4921 D/A convertor
'see MCP4921.inc for declarations
'
'Version 1.0
'Date 29.1.2019
'Author R. Schuster

'Set DAC value given as 12bit value DACVal and set gain to 1 (Vout=Vref * DACVal/4095) or
' to 2 (Vout = 2* Vref * DACVal/4095)
Sub Dac_out(byval Dacval As Word , Byval Gain As Byte)

    Local Da_value As Word

    Da_value = Dacval
    Daout(1) = High(da_value)
    Daout(2) = Low(da_value)
    If Gain = 1 Then
      Daout(1) = Daout(1) Or &H70                           '   Write to DAC A, buffered, Gain 1, with Output Pwer Down Control bit
    Else
      Daout(1) = Daout(1) Or &H50
    End If                                                  '   Write to DAC A, buffered, Gain 2, with Output Pwer Down Control bit
    
	

    Waitus 4
    Spiout Daout(1) , 2
    Cs = 1
    Waitus 4
    Ldac = 0
    Waitus 4
    Ldac = 1
End Sub