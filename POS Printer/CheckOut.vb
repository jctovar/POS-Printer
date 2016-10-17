Public Class CheckOut
    Public SaleId As Integer
    Private payment1 As New Payment
    Private payment2 As New Payment
    Private invoice As Invoice
    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Registrar pago")

        invoice = InvoiceDB.GetInvoice(SaleId)

        TextBox1.Text = invoice.Total.ToString("c")

        With ComboBox1
            .DisplayMember = "customer_name"
            .ValueMember = "customer_id"
            .DataSource = CustomerDB.GetCustomersList(Globales.AccountId)
            .SelectedValue = invoice.Customer
        End With

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Calcular()
        Dim Pago As Double

        Try
            Pago = CDbl(TextBox2.Text) + CDbl(TextBox3.Text)

            TextBox4.Text = (Pago - TextBox1.Text).ToString("c")
        Catch ex As Exception
            TextBox4.Text = (0).ToString("c")
        End Try

    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Me.Calcular()
    End Sub
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Me.Calcular()
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CDbl(TextBox4.Text >= 0) Then
            If CDbl(TextBox2.Text) > 0 Then
                With payment1
                    .SaleId = SaleId
                    .PaymentId = 1
                    .Amount = CDbl(TextBox2.Text)
                End With

                Try
                    If PaymentDB.AddPayment(payment1) = True Then
                        Console.WriteLine("ok")
                    End If
                Catch ex As Exception

                End Try
            End If

            If CDbl(TextBox3.Text) > 0 Then
                With payment2
                    .SaleId = SaleId
                    .PaymentId = 2
                    .Amount = CDbl(TextBox3.Text)
                End With
                Try
                    If PaymentDB.AddPayment(payment2) = True Then
                        Console.WriteLine("ok")
                    End If
                Catch ex As Exception

                End Try
            End If
            With invoice
                .Status = 1
                .Customer = ComboBox1.SelectedValue
                .Note = TextBox5.Text
            End With

            Try
                If InvoiceDB.UpdateInvoice(invoice) = True Then
                    Me.DialogResult = DialogResult.OK
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Else
            MsgBox("Verifique el pago!")
        End If
    End Sub
End Class