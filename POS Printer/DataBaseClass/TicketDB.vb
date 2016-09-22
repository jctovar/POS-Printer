Imports MySql.Data.MySqlClient
Public Class TicketDB
    Public Shared Function GetTicket(SaleID As Integer) As String
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
        Dim Invoice As Invoice = InvoiceDB.GetInvoice(SaleID)
        Dim Customer As Customer = CustomerDB.GetCustomer(Invoice.Customer)

        Dim IdTicket As String = String.Format("{0:000000}", SaleID)
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
        Ticket += "CLIENTE: " & Customer.Name & NewLine
        Ticket += NewLine
        Ticket += Items
        Ticket += NewLine
        Ticket += RightText
        Ticket += "SUBTOTAL" & TAB & Invoice.Account & TAB & NewLine
        Ticket += "IMPUESTO" & TAB & "0.00" & TAB & NewLine
        Ticket += StartBold & "TOTAL" & TAB & Invoice.Account & TAB & EndBold & NewLine
        Ticket += NewLine
        Ticket += LeftText
        Ticket += Numeros2Texto.Num2Text(CInt(Int(Invoice.Account))) & " PESOS " & Funciones.Dec_Part(Invoice.Account, ".") & "/100 M.N." & NewLine
        Ticket += NewLine
        Ticket += CenterText
        Ticket += ESC & Chr(45) & "1" & WebSite & ESC & Chr(45) & "0" & NewLine
        Ticket += EndText & NewLine
        Ticket += NewLine
        Ticket += ESC & Chr(98) & Chr(4) & Chr(2) & Chr(1) & "1" & IdTicket & Chr(30) & NewLine

        Return Ticket

        reader.Close()
        DisconnectDatabase()
    End Function
End Class
