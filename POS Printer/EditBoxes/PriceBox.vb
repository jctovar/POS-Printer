Public Class PriceBox
    Public PriceId As Integer
    Public ProductId As Integer
    Public Add As Boolean
    Private price As New Price
    Private Sub PriceBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Precio")

        If Add = False Then
            Me.Edit()
        End If
    End Sub
    Private Sub Edit()
        Try
            price = PriceDB.GetPrice(PriceId)
            TextBox1.Text = price.Price
            TextBox2.Text = price.Quantity
            If price.Quantity = 1 Then TextBox2.ReadOnly = True
        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With price
            .Id = PriceId
            .Product = ProductId
            .Price = TextBox1.Text.ToString
            .Quantity = TextBox2.Text.ToString
        End With

        If MessageBox.Show("Quiere guardar los cambios?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                If Add = True Then
                    If PriceDB.AddPrice(price) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                Else
                    If PriceDB.UpdatePrice(price) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error! " & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class