Public Class CustomerBox
    Public CustomerId As Integer
    Public Add As Boolean
    Private customer As New Customer
    Private Sub CustomerBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Cliente")

        If Add = False Then
            Me.Edit()
        End If
    End Sub
    Private Sub Edit()
        Try
            customer = CustomerDB.GetCustomer(CustomerId)
            TextBox1.Text = customer.Name
            TextBox2.Text = customer.Address1
            TextBox3.Text = customer.Address2
            TextBox4.Text = customer.PostalCode
            TextBox5.Text = customer.Email
            TextBox6.Text = customer.Phone
            TextBox7.Text = customer.RFC
        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With customer
            .Account = Globales.AccountId
            .Name = TextBox1.Text.ToString
            .Address1 = TextBox2.Text.ToString
            .Address2 = TextBox3.Text.ToString
            .PostalCode = TextBox4.Text.ToString
            .Email = TextBox5.Text.ToString
            .Phone = TextBox6.Text.ToString
            .RFC = TextBox7.Text.ToString
        End With

        If MessageBox.Show("Quiere guardar los cambios?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                If Add = True Then
                    If CustomerDB.AddCustomer(customer) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                Else
                    If CustomerDB.UpdateCustomer(customer) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error! " & ex.Message.ToString)
            End Try
        End If
    End Sub
End Class