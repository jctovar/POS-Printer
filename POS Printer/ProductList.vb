Public Class ProductList
    Dim ds As New DataSet
    WithEvents bsData As New BindingSource
    Public TicketID As Integer
    Public ProductString As String
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = My.Settings.productslist

        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Catalogo de productos")

        FillDatagrid()
    End Sub
    Private Sub ProductList_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        My.Settings.productslist = Me.Size
    End Sub
    Public Sub FillDatagrid()

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            bsData.DataSource = ProductDB.GetProductsList(Globales.AccountId, ProductString, True)
            bsData.Filter = "product_visible = 1"

            With DataGridView1
                .RowTemplate.Height = 32
                .AutoGenerateColumns = True
                .DataSource = bsData
                .AutoResizeColumns()
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).HeaderText = "Categoría"
                .Columns(3).HeaderText = "Producto"
                .Columns(4).HeaderText = "Clave"
                .Columns(5).HeaderText = "Existencia"
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).DefaultCellStyle.Format = String.Format("n", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(6).HeaderText = "Unidad"
                .Columns(7).HeaderText = "Precio"
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(7).DefaultCellStyle.Format = String.Format("c", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(8).Visible = False
                .Columns(9).Visible = False
                .CurrentCell = DataGridView1.Rows(0).Cells(3) ' Columna visible
            End With

            ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", DataGridView1.RowCount)

        Catch ex As Exception
            ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", DataGridView1.Rows.Count)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Me.AddProduct()
    End Sub
    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        ' Captura la tecla de espacio
        If Asc(e.KeyChar) = 32 Then
            Me.AddProduct()
        ElseIf (Asc(e.KeyChar) = 27) Then ' Captura la tecla de esc
            Me.Close()
        End If
    End Sub
    Private Sub AddProduct()
        ' Llama la ventana de cantidad y tara
        Dim frmQuantity As New QuantityBox

        frmQuantity.SaleId = TicketID
        frmQuantity.ProductId = DataGridView1(0, DataGridView1.CurrentRow.Index).Value

        If frmQuantity.ShowDialog() = DialogResult.OK Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = 13 Then
            Me.AddProduct()
        End If
    End Sub
End Class