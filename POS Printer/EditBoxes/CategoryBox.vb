Public Class CategoryBox
    Public CategoryId As Integer
    Public Add As Boolean
    Private category As New Category
    Private Sub CategoryBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Categoría")

        If Add = False Then
            Me.Edit()
        End If
    End Sub
    Private Sub Edit()
        Try
            category = CategoryDB.GetCategory(CategoryId)
            TextBox1.Text = category.Name
            TextBox2.Text = category.Description
            CheckBox1.Checked = category.Visible
        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With category
            .Account = Globales.AccountId
            .Name = TextBox1.Text.ToString
            .Description = TextBox2.Text.ToString
            .Visible = CheckBox1.Checked
        End With

        If MessageBox.Show("Quiere guardar los cambios?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                If Add = True Then
                    If CategoryDB.AddCategory(category) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                Else
                    If CategoryDB.UpdateCategory(category) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error! " & ex.Message.ToString)
            End Try
        End If
    End Sub
End Class