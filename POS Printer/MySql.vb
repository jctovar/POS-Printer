Imports MySql.Data.MySqlClient
Module MySql
    Public conn As New MySqlConnection
    Public Sub ConnectDatabase()

        Try
            If conn.State = ConnectionState.Closed Then
                conn.ConnectionString =
                "server=" & My.Settings.host.ToString & ";" &
                "user id=" & My.Settings.user.ToString & ";" &
                "password=" & My.Settings.password.ToString & ";" &
                "port=" & My.Settings.port.ToString & ";" &
                "database=" & My.Settings.database.ToString & ";"

                conn.Open()
            End If

        Catch myerror As Exception
            MsgBox("Connection Error")
            End
        End Try
    End Sub
    Public Sub DisconnectDatabase()
        Try
            conn.Close()
        Catch myerror As Exception

        End Try
    End Sub
End Module
