Public Class PrintSale
    Public Shared Function Print(SaleId As Integer) As String
        Dim Sale As Invoice

        Dim ESC As String = Chr(27) 'ESC byte in hex notation
        Dim INIT As String = ESC & Chr(64)
        Dim LeftText As String = ESC & Chr(29) & Chr(97) & "0"
        Dim CenterText As String = ESC & Chr(29) & Chr(97) & "1"
        Dim RightText As String = ESC & Chr(29) & Chr(97) & "2"
        Dim NewLine As String = Chr(10) 'LF byte in hex notation
        Dim SuperFont As String = ESC & Chr(105) & "11" ' Fuente 2x
        Dim NormalFont As String = ESC & Chr(105) & "00"
        Dim StartBold As String = ESC & Chr(69)
        Dim EndBold As String = ESC & Chr(70)

        Dim Title As String = Globales.AccountName
        Dim Address As String = Globales.AccountAddres_1 & NewLine & Globales.AccountAddres_2
        Dim PostalCode As String = Globales.AccountPostalCode
        Dim RFC As String = Globales.AccountRfc
        Dim SloganText As String = Globales.AccountSlogan
        Dim EndText As String = "PARA CUALQUIER ACLARACION SOLO CON SU TICKET," & NewLine & "MAXIMO 8 DIAS. GRACIAS POR SU COMPRA."
        Dim WebSite As String = Globales.AccountWeb
        Dim Email As String = Globales.AccountEmail
        Dim Username As String = Globales.ProfileUsername
        Dim PaymentTotal As Double = PaymentDB.GetPayment(SaleId)

        Dim IdTicket As String = String.Format("{0:000000}", SaleId)
        Dim DateTicket As String = Format(Date.Now(), "dd MMM yyyy hh:mm")

        Dim Ticket As String = INIT
        Dim Items As String

        Try
            Sale = InvoiceDB.GetInvoice(SaleId)
        Catch ex As Exception
            Throw ex
        End Try

        Try
            Items = PrintAllItems(SaleId)
        Catch ex As Exception
            Throw ex
        End Try

        Ticket += ESC & Chr(68) & Chr(6) & Chr(13) & Chr(28) & Chr(36) & Chr(0) ' Tabuladores
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
        'Ticket += "FECHA DE IMPRESION: " & DateTicket & NewLine
        Ticket += "FECHA DE VENTA: " & Sale.Timestamp & NewLine
        Ticket += "ATENDIO: " & UCase(Username) & NewLine
        Ticket += "CLIENTE: " & CustomerDB.GetCustomerName(Sale.Customer) & NewLine
        Ticket += NewLine
        Ticket += Items
        Ticket += NewLine
        Ticket += RightText
        Ticket += "SUBTOTAL" & TAB() & Sale.Subtotal.ToString("c") & TAB() & NewLine
        Ticket += "IMPUESTO" & TAB() & Sale.Tax.ToString("c") & TAB() & NewLine
        Ticket += StartBold & "TOTAL" & TAB(2) & Sale.Total.ToString("c") & TAB() & EndBold & NewLine
        Ticket += NewLine
        Ticket += "SU PAGO" & TAB() & PaymentTotal.ToString("c") & TAB() & NewLine
        Ticket += "CAMBIO" & TAB() & (PaymentTotal - Sale.Total).ToString("c") & TAB() & NewLine
        Ticket += NewLine
        Ticket += LeftText
        Ticket += Numeros2Texto.Num2Text(CInt(Sale.Total)) & " PESOS " & (Sale.Total - CInt(Sale.Total)).ToString & "/100 M.N." & NewLine
        Ticket += NewLine
        Ticket += Sale.Note
        Ticket += NewLine
        Ticket += CenterText
        Ticket += ESC & Chr(45) & "1" & WebSite & ESC & Chr(45) & "0" & NewLine
        Ticket += EndText & NewLine
        Ticket += NewLine
        Ticket += ESC & Chr(98) & Chr(4) & Chr(2) & Chr(1) & "1" & IdTicket & Chr(30) & NewLine
        Ticket += ESC & Chr(100) & Chr(50)

        Return Ticket

    End Function
    Private Shared Function PrintAllItems(Saleid) As String
        Dim TableView As New DataTable
        Dim NewLine As String = Chr(10)
        Dim Items As String = "CANT" & TAB & "UNIDAD" & TAB & "DESCRIPCION" & TAB & TAB & "IMPORTE" & NewLine

        TableView = ItemDB.GetAllItems(Saleid)

        Using reader As DataTableReader = TableView.CreateDataReader
            Do
                If reader.HasRows Then
                    Do While reader.Read()
                        Items += CDbl(reader("sale_quantity")).ToString("n") & TAB() & reader("unit_short") & TAB() & reader("product_name") & NewLine
                        If reader("sale_note") = "" Then
                            Items += TAB() & CDbl(reader("sale_quantity")).ToString("n") & " * " & CDbl(reader("sale_price")).ToString("c") & TAB(2) & CDbl(reader("sale_import")).ToString("c") & NewLine
                        Else
                            Items += TAB() & reader("sale_note") & TAB() & CDbl(reader("sale_import")).ToString("c") & NewLine
                        End If

                    Loop
                End If
            Loop While reader.NextResult()
        End Using

        Return Items

    End Function
    Private Shared Function TAB(Optional Count As Integer = 1) As String
        Dim result As String = Nothing

        For x = 1 To Count
            result = result + Chr(9)
        Next

        Return result
    End Function
End Class
