Public Class IdSearchBox
    Private Sub IdSearchBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Buscar venta")
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim frmSale As New Sale

        Try
            frmSale.SaleId = CInt(TextBox1.Text)

            frmSale.ShowDialog()
        Catch ex As Exception
            MsgBox("Ocurrio un error!")
        Finally
            Me.Close()
        End Try
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar)) Then
                e.Handled = True
            End If
        End If
    End Sub
End Class