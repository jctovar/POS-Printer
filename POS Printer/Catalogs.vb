Public Class Catalogs
    Public Search As String
    Dim ds As New DataSet
    WithEvents bsData As New BindingSource
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Title As String = ""

        Select Case Search
            Case "products"
                title = "productos"
            Case "customers"
                Title = "clientes"
            Case "profiles"
                Title = "cuentas"
            Case "suppliers"
                Title = "proveedores"
            Case "categories"
                Title = "categorías"
            Case "terminals"
                Title = "terminales"
            Case "stocks"
                Title = "existencias"
        End Select

        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Catalogo de " & title)

        Me.FillDatagrid("")
    End Sub
    Public Sub FillDatagrid(ProductString As String)
        Select Case Search
            Case "products"
                bsData.DataSource = ProductDB.GetProductsList(Globales.AccountId, ProductString, False)
            Case "customers"
                bsData.DataSource = CustomerDB.GetCustomersList(Globales.AccountId)
            Case "profiles"
                bsData.DataSource = ProfileDB.GetProfilesList(Globales.AccountId)
            Case "suppliers"
                bsData.DataSource = SupplierDB.GetSuppliersList(Globales.AccountId)
            Case "categories"
                bsData.DataSource = CategoryDB.GetCategoriesList(Globales.AccountId)
            Case "terminals"
                bsData.DataSource = TerminalDB.GetTerminalsList(Globales.AccountId)
            Case "stocks"
                bsData.DataSource = StockDB.GetStocksList(Globales.AccountId)
        End Select

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            With DataGridView1
                .RowTemplate.Height = 32
                .AutoGenerateColumns = True
                .DataSource = bsData
                .AutoResizeColumns()
                .Columns(0).Visible = False
                .CurrentCell = DataGridView1.Rows(0).Cells(2) ' Columna visible
            End With

            ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", DataGridView1.RowCount)

        Catch ex As Exception
            ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", DataGridView1.Rows.Count)
        Finally
            DisconnectDatabase()
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub ToolStripTextBox1_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox1.TextChanged
        ' Inyecta la cadena de busqueda, para busqueda de producto, debe de ampliarse a un case para categoria
        Select Case Search
            Case "products"
                bsData.Filter = "product_key LIKE '" & ToolStripTextBox1.Text & "%' OR product_name LIKE '" & ToolStripTextBox1.Text & "%'"
        End Select

        ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", DataGridView1.RowCount)
    End Sub
    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        ' Captura la tecla de espacio
        If Asc(e.KeyChar) = 32 Then
            Me.EditItem()
        ElseIf (Asc(e.KeyChar) = 27) Then ' Captura la tecla de esc
            Me.Close()
        End If
    End Sub
    Private Sub EditItem()
        Select Case Search
            Case "products"
                Dim frmCustomer As New ProductBox

                frmCustomer.ProductId = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
                If frmCustomer.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
            Case "customers"
                Dim frmCustomer As New CustomerBox

                frmCustomer.CustomerId = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
                If frmCustomer.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
            Case "profiles"
                Dim frmProfile As New UserBox

                frmProfile.ProfileId = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
                If frmProfile.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
            Case "suppliers"
                Dim frmSupplier As New SupplierBox

                frmSupplier.SupplierId = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
                If frmSupplier.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
            Case "categories"
                Dim frmCategory As New CategoryBox

                frmCategory.CategoryId = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
                If frmCategory.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
            Case "terminals"
                Dim frmTerminal As New TerminalBox

                frmTerminal.TerminalId = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
                If frmTerminal.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
            Case "stocks"
                Dim frmStock As New StockBox

                frmStock.StockId = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
                If frmStock.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
        End Select
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Me.EditItem()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ' add new item
        Select Case Search
            Case "products"
                Dim frmProduct As New ProductBox

                frmProduct.Add = True
                If frmProduct.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
            Case "customers"
                Dim frmCustomer As New CustomerBox

                frmCustomer.Add = True
                If frmCustomer.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
            Case "profiles"
                Dim frmUser As New UserBox

                frmUser.Add = True
                If frmUser.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
            Case "suppliers"
                Dim frmSupplier As New SupplierBox

                frmSupplier.Add = True
                If frmSupplier.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
            Case "categories"
                Dim frmCategory As New CategoryBox

                frmCategory.Add = True
                If frmCategory.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
            Case "terminals"
                Dim frmTerminal As New TerminalBox

                frmTerminal.Add = True
                If frmTerminal.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
            Case "stocks"
                Dim frmStock As New StockBox

                frmStock.Add = True
                If frmStock.ShowDialog() = DialogResult.OK Then
                    Me.FillDatagrid("")
                End If
        End Select
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ' delete a item
        If MessageBox.Show("Esta seguro de eliminar el elemento?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            ' Cancel the Closing event from closing the form.
            Console.WriteLine(DataGridView1(0, DataGridView1.CurrentRow.Index).Value)
            Try
                Select Case Search
                    Case "products"
                        If ProductDB.DeleteProduct(DataGridView1(0, DataGridView1.CurrentRow.Index).Value) = True Then
                            Me.FillDatagrid("")
                        End If
                    Case "customers"
                        If CustomerDB.DeleteItem(DataGridView1(0, DataGridView1.CurrentRow.Index).Value) = True Then
                            Me.FillDatagrid("")
                        End If
                    Case "profiles"
                        If ProfileDB.DeleteItem(DataGridView1(0, DataGridView1.CurrentRow.Index).Value) = True Then
                            Me.FillDatagrid("")
                        End If
                    Case "suppliers"
                        If SupplierDB.DeleteItem(DataGridView1(0, DataGridView1.CurrentRow.Index).Value) = True Then
                            Me.FillDatagrid("")
                        End If
                    Case "categories"
                        If CategoryDB.DeleteItem(DataGridView1(0, DataGridView1.CurrentRow.Index).Value) = True Then
                            Me.FillDatagrid("")
                        End If
                    Case "terminals"
                        If TerminalDB.DeleteTerminal(DataGridView1(0, DataGridView1.CurrentRow.Index).Value) = True Then
                            Me.FillDatagrid("")
                        End If
                    Case "stocks"
                        If TerminalDB.DeleteTerminal(DataGridView1(0, DataGridView1.CurrentRow.Index).Value) = True Then
                            Me.FillDatagrid("")
                        End If
                End Select
            Catch ex As Exception
                'ex.Message
                MessageBox.Show("No se pudo eliminar el elemento por causa de su relacion con otros elementos.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
End Class