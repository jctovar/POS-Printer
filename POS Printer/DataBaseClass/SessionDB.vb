Imports MySql.Data.MySqlClient
Public Class SessionDB
    Public Shared Function GetSessionsList(ProfileId As Integer) As DataTable
        ' Obtiene la tabla de productos
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * " &
            "FROM sessions WHERE profile_id = @profile ORDER BY session_start"

        Dim dbcommand = New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@profile", ProfileId)

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
    Public Shared Function GetLastSession(ProfileId As Integer) As Session
        Dim session As New Session
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM sessions WHERE profile_id = @id ORDER BY session_start DESC LIMIT 1"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", ProfileId)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With session
                    .Id = reader("session_id")
                    .Profile = reader("profile_id")
                    .Status = reader("session_action")
                    .StartDate = reader("session_start")
                    .EndDate = reader("session_end")
                End With
            Else
                session = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return session
    End Function
    Public Shared Function GetSession(SessionId As Integer) As Session
        Dim session As New Session
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM sessions WHERE session_id = @id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", SessionId)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With session
                    .Id = reader("session_id")
                    .Profile = reader("profile_id")
                    .Status = reader("session_action")
                    .StartDate = reader("session_start")
                    .EndDate = reader("session_end")
                End With
            Else
                session = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return session
    End Function
    Public Shared Function UpdateSession(session As Session) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "UPDATE sessions " &
            "SET terminal_name=@name, terminal_description=@description " &
            "WHERE terminal_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", session.Id)
        dbcommand.Parameters.AddWithValue("@profile", session.Profile)
        dbcommand.Parameters.AddWithValue("@status", session.Status)
        dbcommand.Parameters.AddWithValue("@start", session.StartDate)
        dbcommand.Parameters.AddWithValue("@end", session.EndDate)

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
    Public Shared Function AddSession(session As Session) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "INSERT INTO sessions " &
            "(profile_id) " &
            "VALUES (@profile)"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", session.Id)
        dbcommand.Parameters.AddWithValue("@profile", session.Profile)
        dbcommand.Parameters.AddWithValue("@status", session.Status)
        dbcommand.Parameters.AddWithValue("@start", session.StartDate)
        dbcommand.Parameters.AddWithValue("@end", session.EndDate)

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
