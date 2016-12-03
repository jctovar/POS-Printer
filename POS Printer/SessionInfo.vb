Public Class SessionInfo
    Private session As New Session
    Private Sub SessionInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Información de la sesión")

        session = SessionDB.GetLastSession(Globales.ProfileId, My.Settings.store)

        TextBox1.Text = session.Timestamp.ToString
        TextBox2.Text = Globales.StoreName
        TextBox3.Text = Globales.ProfileName
        TextBox7.Text = InvoiceDB.GetTotalFromSession(Globales.SessionId).ToString("c")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class