Public Class Login
    Private profile As New Profile
    Private session As New Session
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Autentificación")

        TextBox1.Text = My.Settings.profile.ToString
        TextBox1.SelectAll()

        'TextBox1.AutoSize = False
        'TextBox1.Height = 26
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If GetAuthentication(TextBox1.Text, TextBox2.Text) = True Then
            My.Settings.profile = TextBox1.Text

            GetSession()
            Me.DialogResult = DialogResult.OK
        Else
            MessageBox.Show("Datos de autentificación invalidos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Function GetAuthentication(Username As String, Password As String) As Boolean
        Dim result As Boolean

        Try
            profile = ProfileDB.Authentication(Username, Password)

            Globales.ProfileId = profile.Id
            Globales.ProfileUsername = profile.Username
            Globales.ProfileName = profile.Name
            Globales.RoleId = profile.Role

            result = True
        Catch ex As Exception
            result = False
        End Try

        Return result
    End Function
    Private Sub GetSession()
        session = SessionDB.GetLastSession(Globales.ProfileId)

        If IsNothing(session) Then
            Dim session As New Session

            With session
                .Profile = Globales.ProfileId
            End With

            SessionDB.AddSession(session)
        Else
            Globales.SessionId = session.Id
        End If

    End Sub
End Class