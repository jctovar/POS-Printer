Imports MySql.Data.MySqlClient
Public Class CustomerDB
    Public Shared Function GetCustomersList(AccountId As Integer) As DataTable
        ' Obtiene la tabla de clientes
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT customer_id,customer_name,customer_address_1,customer_address_2 FROM customers WHERE account_id=@account ORDER BY customer_name"

        Dim dbcommand = New MySqlCommand(Sql, Connection)
        dbcommand.Parameters.AddWithValue("@account", AccountId)

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
    Public Shared Function GetCustomer(CustomerID As Integer) As Customer
        Dim customer As New Customer
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM customers WHERE customer_id = @id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", CustomerID)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With customer
                    .Id = reader("customer_id").ToString
                    .Name = reader("customer_name").ToString
                    .Address1 = reader("customer_address_1").ToString
                    .Address2 = reader("customer_address_2").ToString
                    .PostalCode = reader("customer_postalcode").ToString
                    .Phone = reader("customer_phone").ToString
                    .Email = reader("customer_email").ToString
                    .RFC = reader("customer_rfc").ToString
                End With
            Else
                customer = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return customer
    End Function
    Public Shared Function UpdateCustomer(customer As Customer) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "UPDATE customers " &
            "SET customer_name=@name, customer_address_1=@address1, customer_address_2=@address2, customer_postalcode=@postalcode, customer_phone=@phone, customer_email=@email, customer_rfc=@rfc " &
            "WHERE customer_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", customer.Id)
        dbcommand.Parameters.AddWithValue("@name", customer.Name)
        dbcommand.Parameters.AddWithValue("@address1", customer.Address1)
        dbcommand.Parameters.AddWithValue("@address2", customer.Address2)
        dbcommand.Parameters.AddWithValue("@postalcode", customer.PostalCode)
        dbcommand.Parameters.AddWithValue("@phone", customer.Phone)
        dbcommand.Parameters.AddWithValue("@email", customer.Email)
        dbcommand.Parameters.AddWithValue("@rfc", customer.RFC)

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
    Public Shared Function DeleteItem(Id As Integer) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "DELETE FROM customers " &
            "WHERE customer_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", Id)

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
    Public Shared Function AddCustomer(customer As Customer) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "INSERT INTO customers " &
            "(account_id,customer_name,customer_address_1,customer_address_2,customer_postalcode,customer_phone,customer_email,customer_rfc) " &
            "VALUES (@account,@name,@address1,@address2,@postalcode,@phone,@email,@rfc)"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@account", customer.Account)
        dbcommand.Parameters.AddWithValue("@name", customer.Name)
        dbcommand.Parameters.AddWithValue("@address1", customer.Address1)
        dbcommand.Parameters.AddWithValue("@address2", customer.Address2)
        dbcommand.Parameters.AddWithValue("@postalcode", customer.PostalCode)
        dbcommand.Parameters.AddWithValue("@phone", customer.Phone)
        dbcommand.Parameters.AddWithValue("@email", customer.Email)
        dbcommand.Parameters.AddWithValue("@rfc", customer.RFC)

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
