Public Class Calibration_form
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cmd As String

        cmd = "S" + Voltage_calibration_value_textbox.Text
        Form1.Serial_out(cmd)

    End Sub

    Private Sub Calibration_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim cmd As String
        cmd = Str(Form1.Current_correction_factor)
        Current_calibration_value_textbox.Text = cmd
        cmd = Str(Form1.Voltage_correction_factor)
        Voltage_calibration_value_textbox.Text = cmd

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd As String

        cmd = "P" + Current_calibration_value_textbox.Text
        Form1.Serial_out(cmd)

    End Sub
End Class