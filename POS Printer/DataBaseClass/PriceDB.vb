Imports MySql.Data.MySqlClient
Public Class PriceDB
    Public Shared Function GetPricesList(ProductId As Integer) As DataTable
        ' Obtiene la tabla de productos
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT price_id,price_value,price_quantity " &
            "FROM prices WHERE product_id = @product ORDER BY price_quantity"

        Dim dbcommand = New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@product", ProductId)

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
    Public Shared Function GetPrice(PriceId As Integer) As Price
        Dim price As New Price
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM prices WHERE price_id = @id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", PriceId)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With price
                    .Id = reader("price_id").ToString
                    .Product = reader("product_id").ToString
                    .Price = reader("price_value").ToString
                    .Quantity = reader("price_quantity").ToString
                End With
            Else
                price = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return price
    End Function
    Public Shared Function GetOnlyPrice(ProductId As Integer, Quantity As Double) As Double
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM prices WHERE product_id = @id AND price_quantity <= @qty " &
            "ORDER BY price_quantity DESC LIMIT 1"
        Dim dbcommand As New MySqlCommand(Sql, Connection)
        Dim result As Double

        dbcommand.Parameters.AddWithValue("@id", ProductId)
        dbcommand.Parameters.AddWithValue("@qty", Quantity)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                result = reader("price_value").ToString
            Else
                result = 0
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return result

    End Function
    Public Shared Function UpdatePrice(price As Price) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "UPDATE prices " &
            "SET price_value=@price, price_quantity=@quantity " &
            "WHERE price_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", price.Id)
        dbcommand.Parameters.AddWithValue("@product", price.Product)
        dbcommand.Parameters.AddWithValue("@price", price.Price)
        dbcommand.Parameters.AddWithValue("@quantity", price.Quantity)

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
    Public Shared Function DeletePrice(Id As Integer) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "DELETE FROM prices " &
            "WHERE price_id=@id"
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
    Public Shared Function AddPrice(price As Price) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "INSERT INTO prices " &
            "(product_id,price_value,price_quantity) " &
            "VALUES (@product,@price,@quantity)"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", price.Id)
        dbcommand.Parameters.AddWithValue("@product", price.Product)
        dbcommand.Parameters.AddWithValue("@price", price.Price)
        dbcommand.Parameters.AddWithValue("@quantity", price.Quantity)

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
