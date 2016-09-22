Imports MySql.Data.MySqlClient
Public Class Form11
    Public TicketID As Integer
    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Cancelar venta " & TicketID)


    End Sub

End Class