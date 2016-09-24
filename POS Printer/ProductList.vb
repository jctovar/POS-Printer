Public Class ProductList
    Dim ds As New DataSet
    WithEvents bsData As New BindingSource
    Public TicketID As Integer
    Public ProductString As String
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Añadir producto al ticket " & TicketID)

        FillDatagrid()
    End Sub
    Public Sub FillDatagrid()
        bsData.DataSource = ProductDB.GetProductsList(Globales.AccountId, ProductString, True)
        bsData.Filter = "product_visible = 1"

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            With DataGridView1
                .RowTemplate.Height = 32
                .AutoGenerateColumns = True
                .DataSource = bsData
                .AutoResizeColumns()
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Categoría"
                .Columns(2).HeaderText = "Producto"
                .Columns(3).HeaderText = "Clave"
                .Columns(4).HeaderText = "Unidad"
                '.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Columns(4).DefaultCellStyle.Format = String.Format("n", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(5).HeaderText = "Disponibilidad"
                .Columns(5).Visible = False
                .Columns(6).HeaderText = "Unidad"
                .CurrentCell = DataGridView1.Rows(0).Cells(3) ' Columna visible
            End With

            ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", DataGridView1.RowCount)

        Catch ex As Exception
            ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", DataGridView1.Rows.Count)
        Finally
            DisconnectDatabase()
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
        ' bsData.Filter = "Clave like '" & TextBox4.Text & "%'"
        ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", DataGridView1.RowCount)
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Me.AddProduct()
    End Sub
    Private Sub AddProduct()
        ' Llama la ventana de cantidad y tara
        Dim frmQuantity As New Quantity

        frmQuantity.SaleID = TicketID
        frmQuantity.ProductID = DataGridView1(0, DataGridView1.CurrentRow.Index).Value

        If frmQuantity.ShowDialog() = DialogResult.OK Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        ' Captura la tecla de espacio
        If Asc(e.KeyChar) = 32 Or Asc(e.KeyChar) = 13 Then
            Me.AddProduct()
        ElseIf (Asc(e.KeyChar) = 27) Then ' Captura la tecla de esc
            Me.Close()
        End If
    End Sub
End Class