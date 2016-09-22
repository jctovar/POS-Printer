Imports MySql.Data.MySqlClient
Public Class MySqlDataBase
    Public Shared Function GetConnection() As MySqlConnection
        Dim dbconn As New MySqlConnection
        Dim DatabaseName As String = My.Settings.database
        Dim ServerIP As String = My.Settings.host
        Dim Username As String = My.Settings.user
        Dim Password As String = My.Settings.password

        If Not dbconn Is Nothing Then dbconn.Close()
        Try
            ' Arma la cadena de conexion
            dbconn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; UseCompression=true", ServerIP, Username, Password, DatabaseName)
        Catch ex As Exception
            'Throw ex
            MessageBox.Show(ex.Message)
        End Try

        Return dbconn
    End Function
End Class
