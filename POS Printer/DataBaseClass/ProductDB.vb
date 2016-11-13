Imports MySql.Data.MySqlClient
Public Class ProductDB
    Public Shared Function GetProductsList(AccountId As Integer, ProductString As String, CategoryVisible As Boolean) As DataTable
        ' Obtiene la tabla de productos
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT " &
                                "`products`.`product_id` AS `product_id`, " &
                                "`products`.`account_id` AS `account_id`, " &
                                "`categories`.`category_name` AS `category_name`, " &
                                "`products`.`product_name` AS `product_name`, " &
                                "`products`.`product_key` AS `product_key`, " &
                                "((SELECT " &
                                        "SUM(`stocks`.`stock_quantity`) As `stock_quantity`" &
                                    "FROM " &
                                        "`stocks` " &
                                    "WHERE " &
                                        "`stocks`.`store_id` = @store AND " &
                                        "(`stocks`.`product_id` = `products`.`product_id`)) - (SELECT " &
                                        "SUM(`products_has_sales`.`sale_quantity`) AS `stock_quantity` " &
                                    "FROM " &
                                        "`products_has_sales` INNER JOIN `sales` ON `products_has_sales`.`sale_id` = `sales`.`sale_id` " &
                                    "WHERE " &
                                        "(`products_has_sales`.`product_id` = `products`.`product_id` AND `sales`.`store_id` = @store AND `sales`.`status_id` = 1))) AS `stock_quantity`, " &
                                "`units`.`unit_short` AS `unit_short`, " &
                                "(SELECT " &
                                        "(`prices`.`price_value` * ((`taxes`.`tax_value` / 100) + 1)) " &
                                    "FROM " &
                                        "`prices` " &
                                    "WHERE " &
                                        "((`prices`.`product_id` = `products`.`product_id`) " &
                                            "AND (`prices`.`price_quantity` = 1)) " &
                                    "LIMIT 1) AS `product_price`, " &
                                "`products`.`product_visible` AS `product_visible`, " &
                                "`categories`.`category_visible` AS `category_visible` " &
                            "FROM " &
                                "(((`products` " &
                                "JOIN `categories` ON ((`products`.`category_id` = `categories`.`category_id`))) " &
                                "Join `units` On ((`products`.`unit_id` = `units`.`unit_id`))) " &
                                "JOIN `taxes` ON ((`products`.`tax_id` = `taxes`.`tax_id`))) " &
                            "WHERE `products`.account_id = @account AND (product_key LIKE @product OR product_name LIKE @product) " &
                            "ORDER BY `categories`.`category_name` , `products`.`product_name`"

        If CategoryVisible = True Then
            Sql = Sql & " AND category_visible = TRUE"
        End If
        Dim dbcommand = New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@account", AccountId)
        dbcommand.Parameters.AddWithValue("@store", My.Settings.store)
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
                    .Id = reader("product_id")
                    .Name = reader("product_name").ToString
                    .Description = reader("product_description").ToString
                    .Key = reader("product_key").ToString
                    .Unit = reader("unit_id")
                    .Tax = reader("tax_id")
                    .Category = reader("category_id")
                    .Visible = reader("product_visible")
                    .Inventory = reader("product_inventory")
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
    Public Shared Function UpdateProduct(product As Product) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "UPDATE products " &
            "SET product_name=@name, product_description=@description, product_key=@key, unit_id=@unit, category_id=@category, product_visible=@visible, tax_id=@tax, product_inventory=@inventory " &
            "WHERE product_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", product.Id)
        dbcommand.Parameters.AddWithValue("@name", product.Name)
        dbcommand.Parameters.AddWithValue("@description", product.Description)
        dbcommand.Parameters.AddWithValue("@key", product.Key)
        dbcommand.Parameters.AddWithValue("@unit", product.Unit)
        dbcommand.Parameters.AddWithValue("@category", product.Category)
        dbcommand.Parameters.AddWithValue("@tax", product.Tax)
        dbcommand.Parameters.AddWithValue("@visible", product.Visible)
        dbcommand.Parameters.AddWithValue("@inventory", product.Inventory)

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
    Public Shared Function GetTaxList() As DataTable
        ' Obtiene la tabla de impuestos
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM taxes"

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
    Public Shared Function GetTaxValue(TaxId As Integer) As Double
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM taxes WHERE tax_id = @id"

        Dim dbcommand As New MySqlCommand(Sql, Connection)
        Dim result As Double

        dbcommand.Parameters.AddWithValue("@id", TaxId)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                result = reader("tax_value")
            Else
                result = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return result

    End Function
    Public Shared Function GetUnitName(UnitId As Integer) As String
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM units WHERE unit_id = @id"

        Dim dbcommand As New MySqlCommand(Sql, Connection)
        Dim result As String

        dbcommand.Parameters.AddWithValue("@id", UnitId)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                result = reader("unit_short").ToString
            Else
                result = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return result
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
            "(account_id,product_name,product_description,product_key,unit_id,category_id,product_visible,tax_id,product_inventory) " &
            "VALUES (@account,@name,@description,@key,@unit,@category,@visible,@tax,@inventory)"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@account", product.Account)
        dbcommand.Parameters.AddWithValue("@name", product.Name)
        dbcommand.Parameters.AddWithValue("@description", product.Description)
        dbcommand.Parameters.AddWithValue("@key", product.Key)
        dbcommand.Parameters.AddWithValue("@unit", product.Unit)
        dbcommand.Parameters.AddWithValue("@category", product.Category)
        dbcommand.Parameters.AddWithValue("@tax", product.Tax)
        dbcommand.Parameters.AddWithValue("@visible", product.Visible)
        dbcommand.Parameters.AddWithValue("@inventory", product.Inventory)

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
