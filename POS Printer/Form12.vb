Public Class Form12
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("select * from xxx where " & DateTimePicker1.Value)
    End Sub
End Class