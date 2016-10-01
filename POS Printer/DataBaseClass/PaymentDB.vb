Imports MySql.Data.MySqlClient
Public Class PaymentDB
    Public Shared Function GetPaymentList(SaleId As Integer) As DataTable
        ' Obtiene la tabla de productos
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * " &
            "FROM sales_has_payments WHERE sale_id = @sale"

        Dim dbcommand = New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@sale", SaleId)

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
    Public Shared Function GetPayment(SaleId As Integer) As Double
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT SUM(payment_amount) AS payment_total FROM sales_has_payments WHERE sale_id = @id"

        Dim dbcommand As New MySqlCommand(Sql, Connection)
        Dim result As Double

        dbcommand.Parameters.AddWithValue("@id", SaleId)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                result = reader("payment_total").ToString
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
    Public Shared Function AddPayment(payment As Payment) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "INSERT INTO sales_has_payments " &
            "VALUES (@sale, @payment, @amount)"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@sale", payment.SaleId)
        dbcommand.Parameters.AddWithValue("@payment", payment.PaymentId)
        dbcommand.Parameters.AddWithValue("@amount", payment.Amount)

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
