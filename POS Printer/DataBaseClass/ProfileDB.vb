Imports MySql.Data.MySqlClient
Public Class ProfileDB
    Public Shared Function GetProfilesList(AccountId As Integer) As DataTable
        ' Obtiene la tabla de clientes
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT profile_id,profile_username,profile_name,role_name,profile_enable " &
            "FROM profiles " &
            "JOIN roles ON profiles.role_id = roles.role_id " &
            "WHERE account_id=@account ORDER BY profile_name"

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
    Public Shared Function Authentication(Username As String, Password As String) As Profile
        Dim profile As New Profile
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM profiles WHERE profile_username = @username AND profile_password = @password AND profile_enable = 1"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@username", Username)
        dbcommand.Parameters.AddWithValue("@password", Password)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With profile
                    .Id = reader("profile_id").ToString
                    .Name = reader("profile_name").ToString
                    .Username = reader("profile_username").ToString
                    .Phone = reader("profile_phone").ToString
                    .Email = reader("profile_email").ToString
                    .Password = reader("profile_password").ToString
                    .Role = reader("role_id").ToString
                    .Enable = reader("profile_enable").ToString
                End With
            Else
                profile = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return profile
    End Function
    Public Shared Function GetProfile(ProfileID As Integer) As Profile
        Dim profile As New Profile
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM profiles WHERE profile_id = @id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", ProfileID)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                With profile
                    .Id = reader("profile_id").ToString
                    .Name = reader("profile_name").ToString
                    .Username = reader("profile_username").ToString
                    .Phone = reader("profile_phone").ToString
                    .Email = reader("profile_email").ToString
                    .Password = reader("profile_password").ToString
                    .Role = reader("role_id").ToString
                    .Enable = reader("profile_enable").ToString
                End With
            Else
                profile = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return profile
    End Function
    Public Shared Function UpdateProfile(user As Profile) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "UPDATE profiles " &
            "SET profile_name=@name, profile_username=@username, profile_phone=@phone, profile_email=@email, profile_password=@password, role_id=@role, profile_enable=@enable " &
            "WHERE profile_id=@id"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@id", user.Id)
        dbcommand.Parameters.AddWithValue("@name", user.Name)
        dbcommand.Parameters.AddWithValue("@username", user.Username)
        dbcommand.Parameters.AddWithValue("@password", user.Password)
        dbcommand.Parameters.AddWithValue("@phone", user.Phone)
        dbcommand.Parameters.AddWithValue("@email", user.Email)
        dbcommand.Parameters.AddWithValue("@role", user.Role)
        dbcommand.Parameters.AddWithValue("@enable", user.Enable)

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
    Public Shared Function GetRoleList() As DataTable
        ' Obtiene la tabla de productos
        Dim dt = New DataTable()
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM roles"

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
    Public Shared Function DeleteProfile(Id As Integer) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "DELETE FROM profiles " &
            "WHERE profile_id=@id"
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
    Public Shared Function AddProfile(user As Profile) As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "INSERT INTO profiles " &
            "(account_id,profile_name,profile_username,profile_password,profile_phone,profile_email,role_id,profile_enable) " &
            "VALUES (@account,@name,@username,@password,@phone,@email,@role,@enable)"
        Dim dbcommand As New MySqlCommand(Sql, Connection)

        dbcommand.Parameters.AddWithValue("@account", user.Account)
        dbcommand.Parameters.AddWithValue("@name", user.Name)
        dbcommand.Parameters.AddWithValue("@username", user.Username)
        dbcommand.Parameters.AddWithValue("@password", user.Password)
        dbcommand.Parameters.AddWithValue("@phone", user.Phone)
        dbcommand.Parameters.AddWithValue("@email", user.Email)
        dbcommand.Parameters.AddWithValue("@role", user.Role)
        dbcommand.Parameters.AddWithValue("@enable", user.Enable)

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
