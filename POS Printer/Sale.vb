Imports System.IO.Ports
Public Class Sale
    Public SaleId As Integer
    Private Sale As New Invoice
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Evalua si es un nuevo ticket
        If SaleId > 0 Then
            Try
                Sale = InvoiceDB.GetInvoice(SaleId)

                If Sale.Status > 0 Then
                    ' deshabilta controles
                    btnSave.Enabled = False
                    TextBox1.Enabled = False
                    DataGridView1.Enabled = False
                    btnDelete.Enabled = False
                End If

                ToolStripStatusLabel2.Text = Sale.Timestamp
                TextBox7.Text = Sale.Total.ToString("n2")
                FillDatagrid()
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error; " & ex.ToString, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Ticket " & String.Format("{0:000000}", SaleId))

        ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", 0)

    End Sub
    Public Sub FillDatagrid()
        Dim TableView As New DataTable

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            TableView = ItemDB.GetAllItems(SaleId)
            ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", TableView.Rows.Count)

            With DataGridView1
                .RowTemplate.Height = 32
                .AutoGenerateColumns = True
                .DataSource = TableView
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(3).DefaultCellStyle.Format = String.Format("n", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(6).Visible = False
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(7).DefaultCellStyle.Format = String.Format("c", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(8).Visible = False
                .Columns(9).Visible = False
                .Columns(10).Visible = False
                .AutoResizeColumns()
                .CurrentCell = DataGridView1.Rows(0).Cells(2) ' Columna visible
            End With

        Catch ex As Exception
            ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", TableView.Rows.Count)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub PrintTicket(SaleId As Integer)
        Dim mySerialPort As New SerialPort

        Try
            With mySerialPort
                .PortName = My.Settings.serial
                .Open()
                .Write(PrintSale.Print(SaleId))
            End With

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error; " & ex.ToString, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            mySerialPort.Close()
        End Try

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If ItemDB.DeleteItem(DataGridView1(1, DataGridView1.CurrentRow.Index).Value, DataGridView1(0, DataGridView1.CurrentRow.Index).Value) = True Then
                Me.FillDatagrid()
                ' Me.GetTicket()
            End If
        Catch ex As Exception
            MsgBox("Selecione el producto")
        End Try
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Try
            PrintTicket(SaleId)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.CheckOut()
    End Sub

    Private Sub CheckOut()
        Dim frmPay As New CheckOut

        frmPay.SaleId = SaleId
        If frmPay.ShowDialog() = DialogResult.OK Then
            If MessageBox.Show("Imprimir ticket?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    PrintTicket(SaleId)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        ' Añade un nuevo producto
        If (Asc(e.KeyChar) = 32) Then
            ' edita cantidad
            Me.ChangeQty()
        ElseIf (Asc(e.KeyChar) = 8) Then
            Try
                If ItemDB.DeleteItem(DataGridView1(1, DataGridView1.CurrentRow.Index).Value, DataGridView1(0, DataGridView1.CurrentRow.Index).Value) = True Then
                    Me.FillDatagrid()
                    'Me.GetTicket()
                End If
            Catch ex As Exception
                MsgBox("Selecione el producto")
            End Try
        End If
    End Sub
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Me.ChangeQty()
    End Sub
    Private Sub ChangeQty()
        Dim frmQuantity As New QuantityBox

        With frmQuantity
            .ProductId = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
            .SaleId = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
        End With

        If frmQuantity.ShowDialog() = DialogResult.OK Then
            FillDatagrid()
            'GetTicket()
            TextBox1.SelectAll()
        End If
    End Sub
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown

        If e.KeyCode = 13 Or e.KeyCode = 40 Then
            If SaleId = 0 Then
                With Sale
                    .Account = Globales.AccountId
                    .Profile = Globales.ProfileId
                    .Store = My.Settings.store
                    .Session = Globales.SessionId
                    .Customer = 1
                End With

                SaleId = InvoiceDB.AddNewSale(Sale)
            End If
            ' Invoca la ventana de productos
            Dim frmAdd As New ProductList

            frmAdd.TicketID = SaleId
            frmAdd.ProductString = TextBox1.Text

            If frmAdd.ShowDialog() = DialogResult.OK Then

                FillDatagrid()
                Sale = InvoiceDB.GetInvoice(SaleId)
                TextBox7.Text = Sale.Total.ToString("n2")
                'TextBox1.SelectAll()
                TextBox1.Text = ""

            End If
        ElseIf e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.CheckOut()
    End Sub
End Class