Imports MySql.Data.MySqlClient
Imports System.IO.Ports
Public Class Sale
    Public TicketID As Integer
    Private mySerialPort As New SerialPort
    Private Sale As Invoice
    Private Customer As String
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Carga la configuracion del com
        ConfigSerial()

        ' Evalua si es un nuevo ticket
        If TicketID > 0 Then
            Sale = InvoiceDB.GetInvoice(TicketID)
            If Sale.Status > 0 Then
                ' deshabilta controles
                btnSave.Enabled = False
                TextBox1.Enabled = False
                DataGridView1.Enabled = False
                ToolStripButton1.Enabled = False
                btnDelete.Enabled = False
            End If

            GetTicket()
            FillDatagrid()
        End If

        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Ticket " & String.Format("{0:000000}", TicketID))

        ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", 0)

    End Sub
    Private Sub ConfigSerial()
        With mySerialPort
            .PortName = My.Settings.serial.ToString
        End With
    End Sub
    Public Sub FillDatagrid()
        Dim TableView As New DataTable

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            TableView = ItemDB.GetAllItems(TicketID)
            ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", TableView.Rows.Count)

            With DataGridView1
                .RowTemplate.Height = 32
                .AutoGenerateColumns = True
                .DataSource = TableView
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(3).DefaultCellStyle.Format = String.Format("n", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).DefaultCellStyle.Format = String.Format("n", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(6).DefaultCellStyle.Format = String.Format("n", System.Globalization.CultureInfo.CreateSpecificCulture("es-MX"))
                .AutoResizeColumns()
                .CurrentCell = DataGridView1.Rows(0).Cells(2) ' Columna visible
            End With

        Catch ex As Exception
            ToolStripStatusLabel1.Text = String.Format("Se encontraron {0} registros", TableView.Rows.Count)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub GetTicket()
        ' Consulta la cabecera del ticket de venta (sales)
        Dim rd As MySqlDataReader
        Dim cmd As New MySqlCommand

        ConnectDatabase()

        cmd.Parameters.AddWithValue("sale_id", TicketID)
        cmd.CommandText = "SELECT * FROM sales_view WHERE sale_id = @sale_id"
        cmd.Connection = conn
        rd = cmd.ExecuteReader

        If rd.Read Then
            Try
                Me.Text = Me.Text & " - " & rd.GetString("Fecha de venta")
                Customer = rd.GetString("Cliente")
                TextBox7.Text = Funciones.Money(rd.GetString("Importe"))
            Catch ex As Exception
            Finally
                DisconnectDatabase()
            End Try

        End If
        rd.Close()
    End Sub
    Private Sub PrintTicket(SaleID As Integer)
        'Dim reader As MySqlDataReader

        Dim ESC As String = Chr(27) 'ESC byte in hex notation
        Dim INIT As String = ESC & Chr(64)
        Dim TAB As String = Chr(9)
        Dim LeftText As String = ESC & Chr(29) & Chr(97) & "0"
        Dim CenterText As String = ESC & Chr(29) & Chr(97) & "1"
        Dim RightText As String = ESC & Chr(29) & Chr(97) & "2"
        Dim NewLine As String = Chr(10) 'LF byte in hex notation
        Dim SuperFont As String = ESC & Chr(105) & "11" ' Fuente 2x
        Dim NormalFont As String = ESC & Chr(105) & "00"
        Dim StartBold As String = ESC & Chr(69)
        Dim EndBold As String = ESC & Chr(70)

        Dim Items As String = "CANT" & TAB & "UNIDAD" & TAB & "DESCRIPCION" & TAB & TAB & "IMPORTE" & NewLine

        Dim Title As String = Globales.AccountName
        Dim Address As String = Globales.AccountAddres_1 & NewLine & Globales.AccountAddres_2
        Dim PostalCode As String = Globales.AccountPostalCode
        Dim RFC As String = Globales.AccountRfc
        Dim SloganText As String = Globales.AccountSlogan
        Dim EndText As String = "PARA CUALQUIER ACLARACION SOLO CON SU TICKET," & NewLine & "MAXIMO 8 DIAS. GRACIAS POR SU COMPRA."
        Dim WebSite As String = Globales.AccountWeb
        Dim Email As String = Globales.AccountEmail
        Dim Username As String = Globales.ProfileUsername

        Dim IdTicket As String = String.Format("{0:000000}", TicketID)
        Dim DateTicket As String = Format(Date.Now(), "dd MMM yyyy hh:mm")

        ConnectDatabase()

        Dim Sql As String = "SELECT * FROM items_view WHERE sale_id = " & SaleID
        Dim dbcommand As New MySqlCommand(Sql, conn)
        Dim reader As MySqlDataReader = dbcommand.ExecuteReader()

        'reader = GetItems(SaleID)

        Do While reader.Read()
            Items += reader.GetString("Cantidad") & Chr(9) & reader.GetString("Unidad") & Chr(9) & reader.GetString("Producto") & NewLine
            Console.WriteLine(Items)
            If reader.GetString("Peso") = "" Then
                Items += TAB & TAB & reader.GetString("Cantidad") & " * " & reader.GetString("Precio") & TAB & TAB & reader.GetString("Importe") & NewLine
            Else
                Items += TAB & reader.GetString("Peso") & TAB & TAB & reader.GetString("Importe") & NewLine
            End If
        Loop

        Try
            ' mySerialPort.PortName = "COM3"
            mySerialPort.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim Ticket As String = INIT
        Ticket += ESC & Chr(68) & Chr(5) & Chr(15) & Chr(27) & Chr(35) & Chr(0)
        Ticket += CenterText
        Ticket += SuperFont ' aumenta el tamaño de la fuente
        Ticket += ESC & Chr(69) & Title & ESC & Chr(70) & NewLine
        Ticket += NormalFont ' cancela aumento de fuente
        Ticket += SloganText & NewLine
        Ticket += NewLine
        Ticket += LeftText
        Ticket += "RFC: " & RFC & NewLine
        Ticket += "DIRECCION: " & Address & NewLine
        Ticket += "CODIGO POSTAL: " & AccountPostalCode & NewLine
        Ticket += NewLine
        Ticket += "TICKET: " & IdTicket & NewLine
        Ticket += "FECHA DE IMPRESION: " & DateTicket & NewLine
        Ticket += "ATENDIO: " & UCase(Username) & NewLine
        Ticket += "CLIENTE: " & Customer & NewLine
        Ticket += NewLine
        Ticket += Items
        Ticket += NewLine
        Ticket += RightText
        Ticket += "SUBTOTAL" & TAB & TextBox7.Text & TAB & NewLine
        Ticket += "IMPUESTO" & TAB & "0.00" & TAB & NewLine
        Ticket += StartBold & "TOTAL" & TAB & TextBox7.Text & TAB & EndBold & NewLine
        Ticket += NewLine
        Ticket += LeftText
        Ticket += Numeros2Texto.Num2Text(CInt(Int(TextBox7.Text))) & " PESOS " & Funciones.Dec_Part(TextBox7.Text, ".") & "/100 M.N." & NewLine
        Ticket += NewLine
        Ticket += CenterText
        Ticket += ESC & Chr(45) & "1" & WebSite & ESC & Chr(45) & "0" & NewLine
        Ticket += EndText & NewLine
        Ticket += NewLine
        Ticket += ESC & Chr(98) & Chr(4) & Chr(2) & Chr(1) & "1" & IdTicket & Chr(30) & NewLine

        mySerialPort.Write(Ticket)
        mySerialPort.Write(ESC & Chr(100) & Chr(50)) ' Corte de hoja

        reader.Close()
        DisconnectDatabase()
        mySerialPort.Close()
    End Sub
    Public Function GetItems(sale_id As Integer) As MySqlDataReader
        ' Retorna los productos de un ticket

        ConnectDatabase()

        Dim Sql As String = "SELECT * FROM items_view WHERE sale_id = " & sale_id
        Dim dbcommand As New MySqlCommand(Sql, conn)
        Dim reader As MySqlDataReader = dbcommand.ExecuteReader()
        Try
            If reader.HasRows Then

            End If
            'reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            DisconnectDatabase()
        End Try

        Return reader
    End Function
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ' Invoca la ventana de productos
        Dim frmAdd As New ProductList

        frmAdd.TicketID = TicketID
        If frmAdd.ShowDialog() = DialogResult.OK Then
            FillDatagrid()
            GetTicket()
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If ItemDB.DeleteItem(DataGridView1(1, DataGridView1.CurrentRow.Index).Value, DataGridView1(0, DataGridView1.CurrentRow.Index).Value) = True Then
                Me.FillDatagrid()
                Me.GetTicket()
            End If
        Catch ex As Exception
            MsgBox("Selecione el producto")
        End Try
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Try
            PrintTicket(TicketID)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim frmPay As New CheckOut

        frmPay.TicketID = TicketID
        If frmPay.ShowDialog() = DialogResult.OK Then
            If MessageBox.Show("Imprimir ticket?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    PrintTicket(TicketID)
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
                    Me.GetTicket()
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
        Dim frmQuantity As New Quantity

        With frmQuantity
            .ProductID = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
            .SaleID = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
        End With

        If frmQuantity.ShowDialog() = DialogResult.OK Then
            FillDatagrid()
            GetTicket()
            TextBox1.SelectAll()
        End If
    End Sub
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Console.WriteLine(e.KeyCode)

        If e.KeyCode = 13 Or e.KeyCode = 40 Then
            If TicketID = 0 Then
                TicketID = InvoiceDB.AddNewSale(Globales.AccountId, Globales.ProfileId, 1, 1)
            End If
            ' Invoca la ventana de productos
            Dim frmAdd As New ProductList

            frmAdd.TicketID = TicketID
            frmAdd.ProductString = TextBox1.Text
            If frmAdd.ShowDialog() = DialogResult.OK Then
                FillDatagrid()
                GetTicket()
                TextBox1.SelectAll()
            End If
        ElseIf e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub
End Class