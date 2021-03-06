﻿Imports MySql.Data.MySqlClient
Public Class SessionDB
    Public Shared Function GetSessionsList(ProfileId As Integer) As DataTable
        ' Obtiene la tabla de sesiones
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT 
                                    sessions.session_id,
                                    profile_username,
                                    store_name,
                                    session_status,
                                    (SELECT 
                                            SUM(sale_total) AS session_total
                                        FROM
                                            albaco.sales_view
                                        WHERE
                                            session_id = sessions.session_id
                                                AND status = 'Pagada') AS total,
                                    session_timestamp
                                FROM
                                    albaco.sessions
                                        INNER JOIN
                                    profiles ON sessions.profile_id = profiles.profile_id
                                        INNER JOIN
                                    stores ON sessions.store_id = stores.store_id
                                WHERE
                                    profiles.account_id = @profile
                                ORDER BY session_timestamp DESC;"

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
    Public Shared Function GetLastSession(ProfileId As Integer, StoreId As Integer) As Session
        Dim session As New Session
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM sessions WHERE profile_id = @profile AND store_id = @store AND session_status = 0 ORDER BY session_timestamp DESC LIMIT 1"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@profile", ProfileId)
        dbcommand.Parameters.AddWithValue("@store", StoreId)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With session
                    .Id = reader("session_id")
                    .Profile = reader("profile_id")
                    .Store = reader("store_id")
                    .Status = reader("session_status")
                    .Timestamp = reader("session_timestamp")
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
                    .Store = reader("store_id")
                    .Status = reader("session_status")
                    .Timestamp = reader("session_timestamp")
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
            "SET session_status = @status " &
            "WHERE session_id = @id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", session.Id)
        dbcommand.Parameters.AddWithValue("@profile", session.Profile)
        dbcommand.Parameters.AddWithValue("@store", session.Store)
        dbcommand.Parameters.AddWithValue("@status", session.Status)
        dbcommand.Parameters.AddWithValue("@timestamp", session.Timestamp)

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
    Public Shared Function AddSession(session As Session) As Integer
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Id As Integer = 0
        Dim Sql As String = "INSERT INTO sessions " &
            "(profile_id, store_id) " &
            "VALUES (@profile, @store)"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", session.Id)
        dbcommand.Parameters.AddWithValue("@profile", session.Profile)
        dbcommand.Parameters.AddWithValue("@store", session.Store)
        dbcommand.Parameters.AddWithValue("@status", session.Status)
        dbcommand.Parameters.AddWithValue("@timestamp", session.Timestamp)

        Try
            Connection.Open()
            dbcommand.ExecuteNonQuery()
            Id = dbcommand.LastInsertedId
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return Id
    End Function
End Class
