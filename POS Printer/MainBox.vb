﻿Imports System.ComponentModel
Imports System.IO.Ports
Public Class MainBox
    Dim ds As New DataSet
    WithEvents bsData As New BindingSource
    Private SaleId As Integer = 0
    Private Sub MainBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = My.Settings.mainbox

        Me.ShowStatus()
        ' Inicia aplicacion


    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MessageBox.Show("Esta seguro de querer salir?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            ' Cancel the Closing event from closing the form.
            e.Cancel = True
        End If
    End Sub
    Private Sub MainBox_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        My.Settings.mainbox = Me.Size
    End Sub
    ' ***********************************************************
    ' Llamadas de las principales rutinas
    ' ***********************************************************
    Private Sub ShowStatus()

        Me.Text = String.Format("{0} - {1} [{2}]", Application.ProductName, Globales.AccountName, Globales.StoreName)
        ' Muestra usuario y caja en la barra de estado
        ToolStripStatusLabel1.Text = "Caja: " & Globales.TerminalName

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

            bsData.DataSource = InvoiceDB.GetAllInvoices(Globales.AccountId, My.Settings.store)
            bsData.Filter = "username = '" & Globales.ProfileUsername & "'"

            With DataGridView1
                .RowTemplate.Height = 32
                .AutoGenerateColumns = True
                .DataSource = bsData
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Folio"
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(1).DefaultCellStyle.Format = "000000"
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Visible = False
                .Columns(5).Visible = False
                .Columns(6).HeaderText = "Fecha"
                .Columns(7).HeaderText = "Cliente"
                .Columns(8).Visible = False
                .Columns(9).Visible = False
                .Columns(10).HeaderText = "Importe"
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(10).DefaultCellStyle.Format = String.Format("c", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(11).HeaderText = "Pago"
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Format = String.Format("c", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(12).HeaderText = "Estado"
                .AutoResizeColumns()
                .CurrentCell = DataGridView1.Rows(0).Cells(1) ' Columna visible
            End With

            ToolStripStatusLabel3.Text = String.Format("Se encontraron {0} registros", TableView.Rows.Count)

        Catch ex As Exception
            ToolStripStatusLabel3.Text = String.Format("Se encontraron {0} registros", TableView.Rows.Count)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
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
            AlmacenesToolStripMenuItem.Enabled = True

            btnCustomers.Enabled = True ' Customers button
            btnProducts.Enabled = True ' Products button

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

    Private Sub EditSale()
        ' Edita una venta
        Dim frmEdit As New Sale

        Try
            frmEdit.SaleId = DataGridView1(1, DataGridView1.CurrentRow.Index).Value

            If frmEdit.ShowDialog() = DialogResult.OK Then
                FillDatagrid()
            End If
        Catch ex As Exception
            MsgBox("Selecione venta")
        End Try
    End Sub
    Private Sub ListadoDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim frmSales As New SalesSearch

        frmSales.ShowDialog()
    End Sub
    Private Sub ExistenciasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim frmStocks As New Catalogs
        frmStocks.Search = "stocks"

        If frmStocks.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    ' ***********************************************************
    ' Llamadas de los menus
    ' ***********************************************************
    Private Sub ConfiguraciónToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ConfiguraciónToolStripMenuItem.Click
        Dim frmConfig As New Config

        frmConfig.ShowDialog()
    End Sub
    Private Sub AutenticarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AutenticarToolStripMenuItem.Click
        Me.Autentificacion()
    End Sub
    Private Sub AcercaDeToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Dim frmAbout As New About

        frmAbout.ShowDialog()
    End Sub
    Private Sub NuevaVentaToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles NuevaVentaToolStripMenuItem.Click
        Me.NewTicket()
    End Sub
    Private Sub SalirToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub DatosDeLaCuentaToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DatosDeLaCuentaToolStripMenuItem.Click
        Dim frmAccount As New AccountBox

        If frmAccount.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub MisDatosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles MisDatosToolStripMenuItem.Click
        ' Show profiles windows
        Dim frmProfile As New UserBox
        frmProfile.ProfileId = Globales.ProfileId

        If frmProfile.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub ClientesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        ' Show customers windows
        Dim frmCustomers As New Catalogs
        frmCustomers.Search = "customers"

        If frmCustomers.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub ProveedoresToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        ' Show profiles windows
        Dim frmSuppliers As New Catalogs
        frmSuppliers.Search = "suppliers"

        If frmSuppliers.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub ProductosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        ' Show products windows
        Dim frmProducts As New Catalogs
        frmProducts.Search = "products"

        If frmProducts.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub CuentasToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CuentasToolStripMenuItem.Click
        ' Show profiles windows
        Dim frmProfiles As New Catalogs
        frmProfiles.Search = "profiles"

        If frmProfiles.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub CategoríasToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CategoríasToolStripMenuItem.Click
        ' Show profiles windows
        Dim frmCategories As New Catalogs
        frmCategories.Search = "categories"

        If frmCategories.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub AlmacenesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlmacenesToolStripMenuItem.Click
        ' Show stores windows
        Dim frmStores As New Catalogs
        frmStores.Search = "stores"

        If frmStores.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub TerminalesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles TerminalesToolStripMenuItem.Click
        ' Show profiles windows
        Dim frmTerminals As New Catalogs
        frmTerminals.Search = "terminals"

        If frmTerminals.ShowDialog() = DialogResult.OK Then
            'Me.ShowStatus()
        End If
    End Sub
    Private Sub ImpresoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpresoraToolStripMenuItem.Click
        Dim frmPrinter As New Serial

        frmPrinter.ShowDialog()

        ShowStatus()
    End Sub
    Private Sub DefinirTerminalToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DefinirTerminalToolStripMenuItem.Click
        ' Selecciona terminal
        Dim frmTerminal As New SelectTerminal

        If frmTerminal.ShowDialog() = DialogResult.OK Then
            Me.ShowStatus()
        End If
    End Sub
    Private Sub SeleccionarAlmacenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarAlmacenToolStripMenuItem.Click
        ' Selecciona store
        Dim frmStore As New SelectStore

        If frmStore.ShowDialog() = DialogResult.OK Then
            Me.ShowStatus()
            Me.FillDatagrid()
        End If
    End Sub
    Private Sub ImprimirVentaToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ImprimirVentaToolStripMenuItem.Click
        Dim mySerialPort As New SerialPort

        Try
            With mySerialPort
                .PortName = My.Settings.serial
                .Open()
                .Write(PrintSale.Print(DataGridView1(1, DataGridView1.CurrentRow.Index).Value))
            End With

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error; " & ex.ToString, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            mySerialPort.Close()
        End Try
    End Sub
    Private Sub BusquedaDeVentaToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BusquedaDeVentaToolStripMenuItem.Click
        Dim frmSearch As New IdSearchBox

        frmSearch.ShowDialog()
    End Sub
    Private Sub RecargarListadoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RecargarListadoToolStripMenuItem.Click
        Me.FillDatagrid()
    End Sub
    ' ***********************************************************
    ' Llamadas de los botones
    ' ***********************************************************
    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click
        Me.Autentificacion()
    End Sub
    Private Sub btnNew_Click_1(sender As Object, e As EventArgs) Handles btnNew.Click
        ' Invoca ventana para nueva venta
        Me.NewTicket()
    End Sub
    Private Sub btnCustomers_Click(sender As Object, e As EventArgs) Handles btnCustomers.Click
        Me.ClientesToolStripMenuItem.PerformClick()
    End Sub
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim frmReport As New Form12

        frmReport.ShowDialog()
    End Sub
    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        Me.ProductosToolStripMenuItem.PerformClick()
    End Sub
    ' ***********************************************************
    ' Llamadas del grid
    ' ***********************************************************
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Try
            SaleId = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 32 Then
            Me.EditSale()
        End If
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Me.EditSale()
    End Sub
End Class