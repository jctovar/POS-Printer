Imports MySql.Data.MySqlClient
Public Class AccountDB
    Public Shared Function GetAccount(Key As String) As Account
        Dim account As New Account
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM accounts WHERE account_key = @account_key"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@account_key", Key)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With account
                    .Id = reader("account_id")
                    .Account = reader("account_name").ToString
                    .Rfc = reader("account_rfc").ToString
                    .Slogan = reader("account_slogan").ToString
                    .Address1 = reader("account_address_1").ToString
                    .Address2 = reader("account_address_2").ToString
                    .PostalCode = reader("account_postalcode").ToString
                    .Email = reader("account_email").ToString
                    .Phone = reader("account_phone").ToString
                End With
            Else
                account = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return account
    End Function
End Class
