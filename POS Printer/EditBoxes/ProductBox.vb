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

        With ComboBox3
            .DisplayMember = "tax_name"
            .ValueMember = "tax_id"
            .DataSource = ProductDB.GetTaxList()
        End With

        If Add = False Then
            Me.Edit()
            Me.GetPrices()
            Me.GetStocks()
        End If
    End Sub

    Private Sub Edit()
        Try
            product = ProductDB.GetProduct(ProductId)
            TextBox1.Text = product.Name
            TextBox2.Text = product.Key
            ComboBox1.SelectedValue = product.Unit
            TextBox6.Text = product.Description
            ComboBox2.SelectedValue = product.Category
            ComboBox3.SelectedValue = product.Tax
            CheckBox1.Checked = product.Visible
            CheckBox2.Checked = product.Inventory

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
            .Description = TextBox6.Text
            .Account = Globales.AccountId
            .Key = TextBox2.Text.ToString
            .Unit = ComboBox1.SelectedValue
            .Category = ComboBox2.SelectedValue
            .Tax = ComboBox3.SelectedValue
            .Visible = CheckBox1.Checked
            .Inventory = CheckBox2.Checked
        End With

        If MessageBox.Show("Quiere guardar los cambios?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                If Add = True Then
                    If ProductDB.AddProduct(product) = True Then
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
                .Columns(1).DefaultCellStyle.Format = String.Format("c", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(2).HeaderText = "Cantidad"
                .Columns(2).DefaultCellStyle.Format = String.Format("n", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(3).HeaderText = "Kg de tara"
                .Columns(3).DefaultCellStyle.Format = String.Format("n", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoResizeColumns()
                .CurrentCell = .Rows(0).Cells(1) ' Columna visible
            End With

        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub GetStocks()
        Dim TableView As New DataTable

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            TableView = StockDB.GetStocksByProduct(ProductId)

            With DataGridView2
                .RowTemplate.Height = 32
                .AutoGenerateColumns = True
                .DataSource = TableView
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).HeaderText = "Cantidad"
                .Columns(2).DefaultCellStyle.Format = String.Format("n", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(3).HeaderText = "Unidad"
                .Columns(4).HeaderText = "Precio ($)"
                .Columns(4).DefaultCellStyle.Format = String.Format("c", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).HeaderText = "Fecha"
                .AutoResizeColumns()
                .CurrentCell = .Rows(0).Cells(2) ' Columna visible
            End With

        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    ' Buttons price
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Edit price
        Dim frmPrice As New PriceBox

        frmPrice.ProductId = ProductId
        frmPrice.PriceId = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
        If frmPrice.ShowDialog() = DialogResult.OK Then
            Me.GetPrices()
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Add price
        Dim frmPrice As New PriceBox

        frmPrice.ProductId = ProductId
        frmPrice.Add = True
        If frmPrice.ShowDialog() = DialogResult.OK Then
            Me.GetPrices()
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Delete price
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
    ' Buttons stocks
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' Edit stock
        Dim frmStock As New StockBox

        frmStock.StockId = DataGridView2(0, DataGridView2.CurrentRow.Index).Value
        If frmStock.ShowDialog() = DialogResult.OK Then
            Me.GetStocks()
        End If
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ' Add stock
        Dim frmStock As New StockBox

        frmStock.StockId = DataGridView2(0, DataGridView2.CurrentRow.Index).Value
        frmStock.Add = True
        If frmStock.ShowDialog() = DialogResult.OK Then
            Me.GetStocks()
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ' Delete stock
    End Sub
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Me.Button4.PerformClick()
    End Sub
    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick
        Me.Button7.PerformClick()
    End Sub
End Class
