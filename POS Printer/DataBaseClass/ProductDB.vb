Imports MySql.Data.MySqlClient
Public Class ProductDB
    Public Shared Function GetProduct(productID As Integer) As Product
        Dim product As New Product
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM products WHERE product_id = @product"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@product", productID)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With product
                    .Id = reader("product_id").ToString
                    .Name = reader("product_name").ToString
                    .Key = reader("product_key").ToString
                    .Tare = reader("product_tare")
                    .Unit = reader("unit_id").ToString
                    .Category = reader("category_id").ToString
                End With
            Else
                product = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return product
    End Function
    Public Shared Function GetProductsList(AccountId As Integer, ProductString As String, CategoryVisible As Boolean) As DataTable
        ' Obtiene la tabla de productos
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT product_id,category_name,product_name,product_key,unit_name " &
            "FROM products " &
            "JOIN categories ON products.category_id = categories.category_id " &
            "JOIN units ON products.unit_id = units.unit_id " &
            "WHERE products.account_id = @account AND product_key LIKE @product"

        If CategoryVisible = True Then
            Sql = Sql & " AND category_visible = TRUE"
        End If
        Dim dbcommand = New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@account", AccountId)
        dbcommand.Parameters.AddWithValue("@product", ProductString & "%")

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
    Public Shared Function UpdateProduct(product As Product) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "UPDATE products " &
            "SET product_name=@name, product_key=@key, unit_id=@unit, product_tare=@tare, category_id=@category " &
            "WHERE product_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", product.Id)
        dbcommand.Parameters.AddWithValue("@name", product.Name)
        dbcommand.Parameters.AddWithValue("@description", product.description)
        dbcommand.Parameters.AddWithValue("@key", product.Key)
        dbcommand.Parameters.AddWithValue("@unit", product.Unit)
        dbcommand.Parameters.AddWithValue("@tare", product.Tare)
        dbcommand.Parameters.AddWithValue("@category", product.Category)

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
    Public Shared Function GetUnitList() As DataTable
        ' Obtiene la tabla de productos
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM units"

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
    Public Shared Function DeleteProduct(ProductId As Integer) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "DELETE FROM products " &
            "WHERE product_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", ProductId)

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
    Public Shared Function AddProduct(product As Product) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "INSERT INTO products " &
            "(account_id,product_name,product_key,unit_id,product_tare,category_id) " &
            "VALUES (@account,@name,@key,@unit,@tare,@category)"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@account", product.Account)
        dbcommand.Parameters.AddWithValue("@name", product.Name)
        dbcommand.Parameters.AddWithValue("@description", product.Description)
        dbcommand.Parameters.AddWithValue("@key", product.Key)
        dbcommand.Parameters.AddWithValue("@unit", product.Unit)
        dbcommand.Parameters.AddWithValue("@tare", product.Tare)
        dbcommand.Parameters.AddWithValue("@category", product.Category)

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
