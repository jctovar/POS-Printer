Public Class CancelBox
    Public SaleId As Integer
    Private sale As New Invoice
    Private Sub CancelBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Cancelar venta")

        Me.Edit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Esta seguro de querer cancelar la venta?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            ' Cancel the sale
            Me.CancelSale()
        End If
    End Sub
    Private Sub Edit()
        Try
            sale = InvoiceDB.GetInvoice(SaleId)

            TextBox3.Text = String.Format("{0:000000}", sale.Id)
            TextBox2.Text = sale.Timestamp
            TextBox4.Text = sale.Profile

        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub CancelSale()
        Try
            sale.Status = 2
            sale.Note = TextBox1.Text

            InvoiceDB.UpdateInvoice(sale)

            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        End Try
    End Sub
End Class