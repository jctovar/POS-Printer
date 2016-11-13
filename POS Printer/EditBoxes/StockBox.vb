Public Class StockBox
    Public StockId As Integer
    Public ProductId As Integer
    Public Add As Boolean
    Private stock As New Stock
    Private Sub StockBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Entrada")

        With ComboBox1
            .DisplayMember = "supplier_name"
            .ValueMember = "supplier_id"
            .DataSource = SupplierDB.GetSuppliersList(Globales.AccountId)
        End With

        If Add = False Then
            Me.Edit()
        End If

    End Sub
    Private Sub Edit()
        Try
            stock = StockDB.GetStock(StockId)
            ComboBox1.SelectedValue = stock.Supplier
            TextBox1.Text = stock.Price
            TextBox2.Text = stock.Quantity
            DateTimePicker1.Text = stock.StockDate
        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With stock
            .Id = StockId
            .Account = Globales.AccountId
            .Store = My.Settings.store
            .Supplier = ComboBox1.SelectedValue
            .Product = ProductId
            .Price = TextBox1.Text.ToString
            .Quantity = TextBox2.Text.ToString
            .StockDate = DateTimePicker1.Text
        End With

        If MessageBox.Show("Quiere guardar los cambios?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                If Add = True Then
                    If StockDB.AddStock(stock) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                Else
                    If StockDB.UpdateStock(stock) = True Then
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