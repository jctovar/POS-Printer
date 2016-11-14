Public Class StoreBox
    Public StoreId As Integer
    Public Add As Boolean
    Private store As New Store
    Private Sub StoreBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Almacen")

        If Add = False Then
            Me.Edit()
        End If
    End Sub
    Private Sub Edit()
        Try
            store = StoreDB.GetStore(StoreId)
            TextBox1.Text = store.Name
            TextBox2.Text = store.Address
            TextBox3.Text = store.Phone
        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With store
            .Account = Globales.AccountId
            .Name = TextBox1.Text.ToString
            .Address = TextBox2.Text.ToString
            .Phone = TextBox3.Text.ToString
        End With

        If MessageBox.Show("Quiere guardar los cambios?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                If Add = True Then
                    If StoreDB.AddStore(store) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                Else
                    If StoreDB.UpdateStore(store) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error! " & ex.Message.ToString)
            End Try
        End If
    End Sub
End Class