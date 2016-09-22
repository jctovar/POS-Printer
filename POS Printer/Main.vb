Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class Main
    Friend dbconn As MySqlConnection
    Private SaleId As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.GetAccount()
        Me.CheckTerminal()
        Me.ShowStatus()
        ' Inicia aplicacion
        Me.Text = String.Format("{0} - {1}", Application.ProductName, Globales.AccountName)

    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MessageBox.Show("Esta seguro de querer salir?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            ' Cancel the Closing event from closing the form.
            e.Cancel = True
        End If
    End Sub
    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        If Asc(e.KeyChar) = 32 Then
            Me.EditSale()
        End If
    End Sub
    Private Sub ShowStatus()
        ' Muestra usuario y caja en la barra de estado
        ToolStripStatusLabel1.Text = "Caja: " & TerminalDB.GetName(My.Settings.terminal)

        If Globales.ProfileId = False Then
            ToolStripStatusLabel4.Text = "Usuario: No autentificado"
        ElseIf IsNumeric(Globales.ProfileId) Then
            ToolStripStatusLabel4.Text = "Usuario: " & Globales.ProfileName.ToString.ToLower
        End If
    End Sub
    Private Sub SetDatagrid()

    End Sub
    Private Sub FillDatagrid()
        Dim TableView As New DataTable

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            TableView = InvoiceDB.GetAllSales(Globales.AccountId, Globales.ProfileId)

            ToolStripStatusLabel3.Text = String.Format("Se encontraron {0} registros", TableView.Rows.Count)

            With DataGridView1
                .RowTemplate.Height = 32
                .AutoGenerateColumns = True
                .DataSource = TableView
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Folio"
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(1).DefaultCellStyle.Format = "000000"
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Visible = False
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(7).DefaultCellStyle.Format = String.Format("n", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .AutoResizeColumns()
                .CurrentCell = DataGridView1.Rows(0).Cells(1) ' Columna visible
            End With

        Catch ex As Exception
            ToolStripStatusLabel3.Text = String.Format("Se encontraron {0} registros", TableView.Rows.Count)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ConfiguraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraciónToolStripMenuItem.Click
        Dim frmConfig As New Config

        frmConfig.ShowDialog()
    End Sub
    Private Sub ImpresoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpresoraToolStripMenuItem.Click
        Dim frmPrinter As New Serial

        frmPrinter.ShowDialog()

        ShowStatus()
    End Sub
    Private Sub Autentificacion()
        ' Valida datos del usuario
        Dim frmLogin As New Login

        If frmLogin.ShowDialog() = DialogResult.OK Then
            ShowStatus()
            btnNew.Enabled = True
            btnReport.Enabled = True
            NuevaVentaToolStripMenuItem.Enabled = True
            CancelarVentaToolStripMenuItem.Enabled = True
            CuentasToolStripMenuItem.Enabled = True
            ClientesToolStripMenuItem.Enabled = True
            ProductosToolStripMenuItem.Enabled = True
            ProveedoresToolStripMenuItem.Enabled = True
            CategoríasToolStripMenuItem.Enabled = True
            MisDatosToolStripMenuItem.Enabled = True
            TerminalesToolStripMenuItem.Enabled = True

            ToolStripButton1.Enabled = True ' Customers button
            ToolStripButton2.Enabled = True ' Products button

            FillDatagrid()
        End If
    End Sub
    Private Sub NewTicket()
        ' Invoca ventana para nueva venta
        Dim frmNew As New Sale

        If frmNew.ShowDialog() Then
            FillDatagrid()
        End If
    End Sub
    Private Sub AutenticarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutenticarToolStripMenuItem.Click
        Me.Autentificacion()
    End Sub
    Private Sub GetAccount()
        Dim rd As MySqlDataReader
        Dim cmd As New MySqlCommand

        ConnectDatabase()

        cmd.Parameters.AddWithValue("account_key", My.Settings.account.ToString)
        cmd.CommandText = "SELECT * FROM accounts WHERE account_key = @account_key"
        cmd.Connection = conn
        rd = cmd.ExecuteReader

        If rd.Read Then
            Globales.AccountId = rd.GetString("account_id")
            Globales.AccountName = rd.GetString("account_name")
            Globales.AccountRfc = rd.GetString("account_rfc")
            Globales.AccountSlogan = rd.GetString("account_slogan")
            Globales.AccountAddres_1 = rd.GetString("account_address_1")

            Globales.AccountAddres_2 = rd.GetString("account_address_2")
            Globales.AccountEmail = rd.GetString("account_email")
            Globales.AccountPostalCode = rd.GetString("account_postalcode")
            Globales.AccountPhone = rd.GetString("account_phone")
        End If

        rd.Close()
        DisconnectDatabase()
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ' Invoca ventana para nueva venta
        Me.NewTicket()
    End Sub
    Private Sub EditSale()
        ' Edita una venta
        Dim frmEdit As New Sale

        Try
            frmEdit.TicketID = DataGridView1(1, DataGridView1.CurrentRow.Index).Value

            If frmEdit.ShowDialog() = DialogResult.OK Then
                FillDatagrid()
            End If
        Catch ex As Exception
            MsgBox("Selecione venta")
        End Try
    End Sub
    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Dim frmAbout As New About

        frmAbout.ShowDialog()
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Me.Autentificacion()
    End Sub
    Private Sub NuevaVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaVentaToolStripMenuItem.Click
        Me.NewTicket()
    End Sub
    Private Sub DefinirTerminalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefinirTerminalToolStripMenuItem.Click
        ' Selecciona terminal
        Dim frmTerminal As New SelectTerminal

        If frmTerminal.ShowDialog() = DialogResult.OK Then
            Me.ShowStatus()
        End If
    End Sub
    Private Sub CheckTerminal()

        If String.IsNullOrEmpty(TerminalDB.GetName(My.Settings.terminal)) Then
            ' Selecciona terminal
            Dim frmTerminal As New SelectTerminal

            If frmTerminal.ShowDialog() = DialogResult.OK Then
                Me.ShowStatus()
            End If
        End If

    End Sub
    Private Sub CancelarVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelarVentaToolStripMenuItem.Click
        Dim frmCancel As New Form11

        Try
            frmCancel.TicketID = (DataGridView1(1, DataGridView1.CurrentRow.Index).Value)

            If frmCancel.ShowDialog() = DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("Selecione venta")
        End Try

    End Sub
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim frmReport As New Form12

        frmReport.ShowDialog()
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Try
            SaleId = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RecargarListadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecargarListadoToolStripMenuItem.Click
        Me.FillDatagrid()
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Me.EditSale()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        ' Show customers windows
        Dim frmCustomers As New Catalogs
        frmCustomers.Search = "customers"

        If frmCustomers.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        ' Show products windows
        Dim frmProducts As New Catalogs
        frmProducts.Search = "products"

        If frmProducts.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub CuentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuentasToolStripMenuItem.Click
        ' Show profiles windows
        Dim frmProfiles As New Catalogs
        frmProfiles.Search = "profiles"

        If frmProfiles.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        ' Show profiles windows
        Dim frmSuppliers As New Catalogs
        frmSuppliers.Search = "suppliers"

        If frmSuppliers.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub TerminalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerminalesToolStripMenuItem.Click
        ' Show profiles windows
        Dim frmTerminals As New Catalogs
        frmTerminals.Search = "terminals"

        If frmTerminals.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub MisDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MisDatosToolStripMenuItem.Click
        ' Show profiles windows
        Dim frmProfile As New UserBox
        frmProfile.ProfileId = Globales.ProfileId

        If frmProfile.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.ClientesToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.ProductosToolStripMenuItem.PerformClick()
    End Sub

    Private Sub CategoríasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoríasToolStripMenuItem.Click
        ' Show profiles windows
        Dim frmCategories As New Catalogs
        frmCategories.Search = "categories"

        If frmCategories.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DataGridView1.Refresh()
    End Sub
End Class
