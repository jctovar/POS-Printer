Public Class Config
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Configuración")

        TextBox1.Text = My.Settings.host.ToString
        TextBox2.Text = My.Settings.port.ToString
        TextBox3.Text = My.Settings.user.ToString
        TextBox4.Text = My.Settings.password.ToString
        TextBox5.Text = My.Settings.database.ToString
        TextBox6.Text = My.Settings.account.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.host = TextBox1.Text
        My.Settings.port = TextBox2.Text
        My.Settings.user = TextBox3.Text
        My.Settings.password = TextBox4.Text
        My.Settings.database = TextBox5.Text
        My.Settings.account = TextBox6.Text

        Me.DialogResult = DialogResult.OK
    End Sub
End Class