Imports MySql.Data.MySqlClient
Public Class StoreDB
    Public Shared Function GetStoreName(StoreId As Integer) As String
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Terminal As String
        Dim Sql As String = "SELECT * FROM stores WHERE store_id = @store"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@store", StoreId)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                Terminal = reader("store_name").ToString
            Else
                Terminal = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return Terminal

    End Function
    Public Shared Function GetStore(StoreId As Integer) As Store
        Dim store As New Store
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM stores WHERE store_id = @id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", StoreId)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With store
                    .Id = reader("store_id")
                    .Account = reader("account_id")
                    .Name = reader("store_name").ToString
                    .Address = reader("store_address").ToString
                    .Phone = reader("store_phone").ToString
                End With
            Else
                store = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return store
    End Function
    Public Shared Function GetStoresList(AccountId As Integer) As DataTable
        ' Obtiene la tabla de almacenes
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT store_id,store_name " &
            "FROM stores WHERE account_id = @account ORDER BY store_name"

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
    Public Shared Function UpdateStore(store As Store) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "UPDATE stores " &
            "SET store_name=@name, store_address=@address, store_phone=@phone " &
            "WHERE store_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", store.Id)
        dbcommand.Parameters.AddWithValue("@account", store.Account)
        dbcommand.Parameters.AddWithValue("@name", store.Name)
        dbcommand.Parameters.AddWithValue("@address", store.Address)
        dbcommand.Parameters.AddWithValue("@phone", store.Phone)

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
    Public Shared Function DeleteStore(Id As Integer) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "DELETE FROM stores " &
            "WHERE store_id=@id"
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
    Public Shared Function AddStore(store As Store) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "INSERT INTO stores " &
            "(account_id,store_name,store_address,store_phone) " &
            "VALUES (@account,@name,@address,@phone)"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", store.Id)
        dbcommand.Parameters.AddWithValue("@account", store.Account)
        dbcommand.Parameters.AddWithValue("@name", store.Name)
        dbcommand.Parameters.AddWithValue("@address", store.Address)
        dbcommand.Parameters.AddWithValue("@phone", store.Phone)

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
