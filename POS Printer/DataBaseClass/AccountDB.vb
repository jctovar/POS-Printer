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
                    .Name = reader("account_name").ToString
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
    Public Shared Function UpdateAccount(account As Account) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "UPDATE accounts " &
            "SET account_name=@name, account_address_1=@address1, account_address_2=@address2, account_postalcode=@postalcode, account_phone=@phone, account_email=@email, account_rfc=@rfc, account_slogan=@slogan " &
            "WHERE account_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", account.Id)
        dbcommand.Parameters.AddWithValue("@name", account.Name)
        dbcommand.Parameters.AddWithValue("@address1", account.Address1)
        dbcommand.Parameters.AddWithValue("@address2", account.Address2)
        dbcommand.Parameters.AddWithValue("@postalcode", account.PostalCode)
        dbcommand.Parameters.AddWithValue("@phone", account.Phone)
        dbcommand.Parameters.AddWithValue("@email", account.Email)
        dbcommand.Parameters.AddWithValue("@rfc", account.Rfc)
        dbcommand.Parameters.AddWithValue("@slogan", account.Slogan)

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
