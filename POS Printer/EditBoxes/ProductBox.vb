Public Class ProductBox
    Public ProductId As Integer
    Public Add As Boolean
    Private product As New Product
    Private Sub ProductBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Producto")

        With ComboBox1
            .DisplayMember = "unit_name"
            .ValueMember = "unit_id"
            .DataSource = ProductDB.GetUnitList()
        End With

        With ComboBox2
            .DisplayMember = "category_name"
            .ValueMember = "category_id"
            .DataSource = CategoryDB.GetCategoriesList(Globales.AccountId)
        End With

        If Add = False Then
            Me.Edit()
            Me.GetPrices()
        End If
    End Sub
    Private Sub Edit()
        Try
            product = ProductDB.GetProduct(ProductId)
            TextBox1.Text = product.Name
            TextBox2.Text = product.Key
            ComboBox1.SelectedValue = product.Unit
            TextBox5.Text = product.Tare
            ComboBox2.SelectedValue = product.Category
        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With product
            .Name = TextBox1.Text.ToString
            .Account = Globales.AccountId
            .Key = TextBox2.Text.ToString
            .Unit = ComboBox1.SelectedValue
            .Tare = TextBox5.Text.ToString
            .Category = ComboBox2.SelectedValue
        End With

        If MessageBox.Show("Quiere guardar los cambios?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                If Add = True Then
                    If ProductDB.addProduct(product) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                Else
                    If ProductDB.UpdateProduct(product) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error! " & ex.Message.ToString)
            End Try
        End If
    End Sub
    Private Sub GetPrices()
        Dim TableView As New DataTable

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            TableView = PriceDB.GetPricesList(ProductId)

            With DataGridView1
                .RowTemplate.Height = 32
                .AutoGenerateColumns = True
                .DataSource = TableView
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Precio ($)"
                .Columns(1).DefaultCellStyle.Format = String.Format("n", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(2).HeaderText = "Cantidad"
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoResizeColumns()
                .CurrentCell = DataGridView1.Rows(0).Cells(1) ' Columna visible
            End With

        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Me.EditPrice()
    End Sub
    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDown
        Dim rowClicked As DataGridView.HitTestInfo = DataGridView1.HitTest(e.X, e.Y)

        If e.Button = MouseButtons.Right Then
            mnuPrices.Show(MousePosition.X, MousePosition.Y)
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Me.EditPrice()
    End Sub

    Private Sub EditPrice()
        Dim frmPrice As New PriceBox

        frmPrice.ProductId = ProductId
        frmPrice.PriceId = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
        If frmPrice.ShowDialog() = DialogResult.OK Then
            Me.GetPrices()
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.AddPrice()
    End Sub

    Private Sub AddPrice()
        Dim frmPrice As New PriceBox

        frmPrice.ProductId = ProductId
        frmPrice.Add = True
        If frmPrice.ShowDialog() = DialogResult.OK Then
            Me.GetPrices()
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            If MessageBox.Show("Esta seguro de eliminar el precio?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                If PriceDB.DeletePrice(DataGridView1(0, DataGridView1.CurrentRow.Index).Value) = True Then
                    Me.GetPrices()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error! " & ex.Message.ToString)
        End Try
    End Sub
End Class
