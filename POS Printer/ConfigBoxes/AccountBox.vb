Public Class AccountBox
    Private account As New Account
    Private Sub AccountBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Cuenta")

        account = AccountDB.GetAccount(My.Settings.account.ToString)

        TextBox1.Text = account.Name
        TextBox2.Text = account.Address1
        TextBox3.Text = account.Address2
        TextBox4.Text = account.PostalCode
        TextBox5.Text = account.Email
        TextBox6.Text = account.Phone
        TextBox7.Text = account.Rfc
        TextBox8.Text = account.Slogan

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With account
            .Id = Globales.AccountId
            .Name = TextBox1.Text.ToString
            .Address1 = TextBox2.Text.ToString
            .Address2 = TextBox3.Text.ToString
            .PostalCode = TextBox4.Text.ToString
            .Email = TextBox5.Text.ToString
            .Phone = TextBox6.Text.ToString
            .Rfc = TextBox7.Text.ToString
            .Slogan = TextBox8.Text.ToString
        End With

        Try
            If AccountDB.UpdateAccount(account) = True Then
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error; " & ex.ToString, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class