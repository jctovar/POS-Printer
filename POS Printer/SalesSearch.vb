Public Class SalesSearch
    Public Search As String
    Dim ds As New DataSet
    WithEvents bsData As New BindingSource
    Private Sub SaleSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Busqueda de ventas")

        ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", 0)

        With Me.ComboBox1
            .DisplayMember = "terminal_name"
            .ValueMember = "terminal_id"
            .DataSource = TerminalDB.GetTerminalsList(Globales.AccountId)
            .SelectedValue = My.Settings.terminal
        End With

        With Me.ComboBox2
            .DisplayMember = "status_name"
            .ValueMember = "status_id"
            .DataSource = InvoiceDB.GetSaleType()
            .SelectedValue = 0
        End With

        FillDatagrid()
    End Sub
    Private Sub FillDatagrid()
        Dim TableView As New DataTable

        bsData.DataSource = InvoiceDB.GetAllInvoices(Globales.AccountId, My.Settings.store)

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            'TableView = InvoiceDB.GetAllInvoices(Globales.AccountId)

            'ToolStripStatusLabel3.Text = String.Format("Se encontraron {0} registros", TableView.Rows.Count)

            With DataGridView1
                .RowTemplate.Height = 32
                .AutoGenerateColumns = True
                .DataSource = bsData
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Folio"
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(1).DefaultCellStyle.Format = "000000"
                .Columns(2).Visible = False
                .Columns(3).Visible = True
                .Columns(4).Visible = True
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(7).DefaultCellStyle.Format = String.Format("n", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .AutoResizeColumns()
                .CurrentCell = DataGridView1.Rows(0).Cells(1) ' Columna visible
            End With

        Catch ex As Exception
            'ToolStripStatusLabel3.Text = String.Format("Se encontraron {0} registros", TableView.Rows.Count)
            MessageBox.Show(ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bsData.Filter = "terminal LIKE '" & ComboBox1.Text & "%' AND status LIKE '" & ComboBox2.Text & "%'"

        ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", DataGridView1.RowCount)
    End Sub
End Class