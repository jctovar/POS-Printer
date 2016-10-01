Public Class SalesSearch
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

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            TableView = InvoiceDB.GetAllSalesByDate(Globales.AccountId, Globales.ProfileId, "20/09/2016")

            'ToolStripStatusLabel3.Text = String.Format("Se encontraron {0} registros", TableView.Rows.Count)

            With DataGridView1
                .RowTemplate.Height = 32
                .AutoGenerateColumns = True
                .DataSource = TableView
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
End Class