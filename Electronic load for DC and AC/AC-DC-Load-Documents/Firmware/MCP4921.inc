'Declarations for MCP4921 D/A functions
'MCP4921.bas
'
'Version 1.0
'Date 29.1.209
'Author R. Schuster

Dim Daout(3) As Byte

'Adapt CS and LDAC portpins to your hardware
Cs Alias Portb.4
Ldac Alias Portb.3

Ddrb.3 = 1
Ddrb.4 = 1

Config Spi = Hard , Interrupt = Off , Data Order = Msb , Master = Yes , Polarity = Low , Phase = 0 , Clockrate = 64 , Noss = 0
Spiinit


Declare Sub Dac_out(byval Dacval As Word , Byval Gain As Byte)