Imports MySql.Data.MySqlClient
Public Class InvoiceDB
    Public Shared Function AddNewSale(AccountId As Integer, ProfileId As Integer, TerminalId As Integer, CustomerId As Integer) As Integer
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim SaleId As Integer = 0
        Dim sql = "INSERT INTO sales (account_id,customer_id,profile_id,terminal_id) VALUES (@account,@customer,@profile,@terminal)"

        Dim dbcommand As New MySqlCommand(sql, Connection)

        dbcommand.Parameters.AddWithValue("@account", AccountId)
        dbcommand.Parameters.AddWithValue("@customer", CustomerId)
        dbcommand.Parameters.AddWithValue("@profile", ProfileId)
        dbcommand.Parameters.AddWithValue("@terminal", TerminalId)

        Try
            Connection.Open()

            dbcommand.Connection = Connection
            dbcommand.CommandText = sql
            dbcommand.ExecuteNonQuery()
            SaleId = dbcommand.LastInsertedId
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return SaleId
    End Function
    Public Shared Function GetAllSales(AccountId As Integer, ProfileId As Integer) As DataTable
        ' Se usa en Main para obtener el listado de ventas
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql = "SELECT * FROM sales_view WHERE account_id = @account AND profile_id LIKE @profile"

        Dim dbcommand As New MySqlCommand(Sql, Connection)
        dbcommand.Parameters.AddWithValue("@account", AccountId)
        dbcommand.Parameters.AddWithValue("@profile", ProfileId)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader()
            If reader.HasRows Then
                dt.Load(reader)
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return dt
    End Function
    Public Shared Function GetInvoice(InvoiceId As Integer) As Invoice
        Dim invoice As New Invoice
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM sales WHERE sale_id = @id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", InvoiceId)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With invoice
                    .Id = reader("sale_id").ToString
                    .Account = reader("account_id").ToString
                    .Customer = reader("customer_id").ToString
                    .Profile = reader("profile_id").ToString
                    .Terminal = reader("terminal_id").ToString
                    .Status = reader("status_id").ToString
                    .Note = reader("sale_note").ToString
                    .Timestamp = reader("sale_timestamp").ToString
                End With
            Else
                invoice = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return invoice
    End Function
    Public Shared Function UpdateInvoice(invoice As Invoice) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "UPDATE sales " &
            "SET customer_id=@customer,status_id=@status,sale_note=@note " &
            "WHERE sale_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", invoice.Id)
        dbcommand.Parameters.AddWithValue("@customer", invoice.Customer)
        dbcommand.Parameters.AddWithValue("@profile", invoice.Profile)
        dbcommand.Parameters.AddWithValue("@terminal", invoice.Terminal)
        dbcommand.Parameters.AddWithValue("@status", invoice.Status)
        dbcommand.Parameters.AddWithValue("@note", invoice.Note)

        Try
            Connection.Open()

            dbcommand.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

    End Function
End Class
