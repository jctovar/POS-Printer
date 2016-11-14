Imports MySql.Data.MySqlClient
Public Class StockDB
    Public Shared Function GetStocksList(AccountId As Integer) As DataTable
        ' Obtiene la tabla de existencias
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM stocks_view " &
            "WHERE account_id = @account ORDER BY product_name"

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
    Public Shared Function GetStocksByProduct(ProductId As Integer, StoreId As Integer) As DataTable
        ' Obtiene la tabla de existencias
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT stock_id,stocks.product_id,stock_quantity,unit_name,stock_price,stock_date FROM stocks " &
            "INNER JOIN products ON stocks.product_id=products.product_id " &
            "INNER JOIN units ON products.unit_id=units.unit_id " &
            "WHERE stocks.product_id = @product AND stocks.store_id = @store ORDER BY stock_date DESC"

        Dim dbcommand = New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@product", ProductId)
        dbcommand.Parameters.AddWithValue("@store", StoreId)

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
    Public Shared Function GetStock(StockId As Integer) As Stock
        Dim stock As New Stock
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM stocks WHERE stock_id = @id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", StockId)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With stock
                    .Id = reader("stock_id")
                    .Account = reader("stock_id")
                    .Store = reader("stock_id")
                    .Supplier = reader("supplier_id")
                    .Product = reader("product_id")
                    .Price = reader("stock_price")
                    .Quantity = reader("stock_quantity")
                    .StockDate = reader("stock_date")
                End With
            Else
                stock = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return stock
    End Function
    Public Shared Function UpdateStock(stock As Stock) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "UPDATE stocks " &
            "SET supplier_id=@supplier, stock_price=@price, stock_quantity=@quantity, stock_date=@date " &
            "WHERE stock_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", stock.Id)
        dbcommand.Parameters.AddWithValue("@account", stock.Account)
        dbcommand.Parameters.AddWithValue("@supplier", stock.Supplier)
        dbcommand.Parameters.AddWithValue("@store", stock.Store)
        dbcommand.Parameters.AddWithValue("@product", stock.Product)
        dbcommand.Parameters.AddWithValue("@price", stock.Price)
        dbcommand.Parameters.AddWithValue("@quantity", stock.Quantity)
        dbcommand.Parameters.AddWithValue("@date", stock.StockDate)

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
    Public Shared Function AddStock(stock As Stock) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "INSERT INTO stocks " &
            "(account_id,supplier_id,store_id,product_id,stock_price,stock_quantity,stock_date) " &
            "VALUES (@account,@supplier,@store,@product,@price,@quantity,@date)"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", stock.Id)
        dbcommand.Parameters.AddWithValue("@account", stock.Account)
        dbcommand.Parameters.AddWithValue("@supplier", stock.Supplier)
        dbcommand.Parameters.AddWithValue("@store", stock.Store)
        dbcommand.Parameters.AddWithValue("@product", stock.Product)
        dbcommand.Parameters.AddWithValue("@price", stock.Price)
        dbcommand.Parameters.AddWithValue("@quantity", stock.Quantity)
        dbcommand.Parameters.AddWithValue("@date", stock.StockDate)

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
    Public Shared Function DeleteStock(Id As Integer) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "DELETE FROM stocks " &
            "WHERE stock_id=@id"
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
End Class
