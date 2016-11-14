Public Class SelectTerminal
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Listado de terminales")

        With Me.ListBox1
            .DisplayMember = "terminal_name"
            .ValueMember = "terminal_id"
            .DataSource = TerminalDB.GetTerminalsList(Globales.AccountId)
            .SelectedValue = My.Settings.terminal
        End With
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Guarda la terminal en la configuración
        My.Settings.terminal = ListBox1.SelectedValue
        Globales.TerminalName = ListBox1.Text

        Me.DialogResult = DialogResult.OK
    End Sub
End Class