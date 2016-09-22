Public Class UserBox
    Public ProfileId As Integer
    Public Add As Boolean
    Private profile As New Profile
    Private Sub UserBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Mis datos")

        With ComboBox1
            .DisplayMember = "role_name"
            .ValueMember = "role_id"
            .DataSource = ProfileDB.GetRoleList()
        End With

        If Add = False Then
            Me.Edit()
        End If
    End Sub
    Private Sub Edit()
        Try
            profile = ProfileDB.GetProfile(ProfileId)
            TextBox1.Text = profile.Name
            TextBox2.Text = profile.Username
            TextBox3.Text = profile.Email
            TextBox4.Text = profile.Phone
            TextBox5.Text = profile.Password
            ComboBox1.SelectedValue = profile.Role
            CheckBox1.Checked = profile.Enable
        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        End Try

        If profile.Role = 2 Then
            Label6.Visible = False
            ComboBox1.Visible = False
            CheckBox1.Visible = False
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With profile
            .Account = Globales.AccountId
            .Name = TextBox1.Text
            .Username = TextBox2.Text
            .Email = TextBox3.Text
            .Phone = TextBox4.Text
            .Password = TextBox5.Text
            .Role = ComboBox1.SelectedValue
            .Enable = CheckBox1.Checked
        End With

        If MessageBox.Show("Quiere guardar los cambios?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                If Add = True Then
                    If ProfileDB.addProfile(profile) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                Else
                    If ProfileDB.UpdateProfile(profile) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error! " & ex.Message.ToString)
            End Try
        End If
    End Sub
End Class