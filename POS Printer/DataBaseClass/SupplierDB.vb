Imports MySql.Data.MySqlClient
Public Class SupplierDB
    Public Shared Function GetSuppliersList(AccountId As Integer) As DataTable
        ' Obtiene la tabla de clientes
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT supplier_id,supplier_name,supplier_address_1,supplier_address_2 FROM suppliers WHERE account_id=@account ORDER BY supplier_name"

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
    Public Shared Function GetSupplier(SupplierID As Integer) As Supplier
        Dim supplier As New Supplier
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM suppliers WHERE supplier_id = @id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", SupplierID)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With supplier
                    .Id = reader("supplier_id").ToString
                    .Name = reader("supplier_name").ToString
                    .Address1 = reader("supplier_address_1").ToString
                    .Address2 = reader("supplier_address_2").ToString
                    .PostalCode = reader("supplier_postalcode").ToString
                    .Email = reader("supplier_email").ToString
                    .Phone = reader("supplier_phone").ToString
                End With
            Else
                supplier = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return supplier
    End Function
    Public Shared Function UpdateSupplier(supplier As Supplier) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "UPDATE suppliers " &
            "SET supplier_name=@name, supplier_address_1=@address1, supplier_address_2=@address2, supplier_postalcode=@postalcode, supplier_phone=@phone, supplier_email=@email " &
            "WHERE supplier_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", supplier.Id)
        dbcommand.Parameters.AddWithValue("@name", supplier.Name)
        dbcommand.Parameters.AddWithValue("@address1", supplier.Address1)
        dbcommand.Parameters.AddWithValue("@address2", supplier.Address2)
        dbcommand.Parameters.AddWithValue("@postalcode", supplier.PostalCode)
        dbcommand.Parameters.AddWithValue("@phone", supplier.Phone)
        dbcommand.Parameters.AddWithValue("@email", supplier.Email)

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
        Dim Sql As String = "DELETE FROM suppliers " &
            "WHERE supplier_id=@id"
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
    Public Shared Function AddSupplier(supplier As Supplier) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "INSERT INTO suppliers " &
            "(account_id,supplier_name,supplier_address_1,supplier_address_2,supplier_postalcode,supplier_phone,supplier_email) " &
            "VALUES (@account,@name,@address1,@address2,@postalcode,@phone,@email)"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@account", supplier.Account)
        dbcommand.Parameters.AddWithValue("@name", supplier.Name)
        dbcommand.Parameters.AddWithValue("@address1", supplier.Address1)
        dbcommand.Parameters.AddWithValue("@address2", supplier.Address2)
        dbcommand.Parameters.AddWithValue("@postalcode", supplier.PostalCode)
        dbcommand.Parameters.AddWithValue("@phone", supplier.Phone)
        dbcommand.Parameters.AddWithValue("@email", supplier.Email)
        dbcommand.Parameters.AddWithValue("@rfc", supplier.RFC)

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
