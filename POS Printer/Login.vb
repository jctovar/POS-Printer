Imports MySql.Data.MySqlClient
Public Class Login
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Autentificación")

        TextBox1.Text = My.Settings.profile.ToString
        TextBox1.SelectAll()

        'TextBox1.AutoSize = False
        'TextBox1.Height = 26
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If GetAuthentication() = True Then
            My.Settings.profile = TextBox1.Text
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
    Private Function GetAuthentication() As Boolean
        Dim Connection As MySqlConnection = MySqlDataBase.GetConnection
        Dim Sql As String = "SELECT * FROM profiles WHERE profile_username = @username AND profile_password = @password AND profile_enable = 1"
        Dim dbcommand As New MySqlCommand(Sql, Connection)
        Dim result As Boolean

        dbcommand.Parameters.AddWithValue("@username", TextBox1.Text)
        dbcommand.Parameters.AddWithValue("@password", TextBox2.Text)

        Try
            Connection.Open()

            Dim reader As MySqlDataReader = dbcommand.ExecuteReader(CommandBehavior.SingleRow)

            If reader.Read Then
                Globales.ProfileId = reader("profile_id").ToString
                Globales.ProfileUsername = reader("profile_username").ToString
                Globales.ProfileName = reader("profile_name").ToString
                Globales.RoleId = reader("role_id").ToString

                result = True
            Else
                ' Datos invalidos.
                MessageBox.Show("Datos de autentificación invalidos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Connection.Close()
        End Try

        Return result
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class