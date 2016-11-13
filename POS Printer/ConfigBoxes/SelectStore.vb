Public Class SelectStore
    Private Sub SelectStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Listado de almacenes")

        With Me.ListBox1
            .DisplayMember = "store_name"
            .ValueMember = "store_id"
            .DataSource = StoreDB.GetStoresList(Globales.AccountId)
            .SelectedValue = My.Settings.store
        End With
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Guarda la terminal en la configuración
        My.Settings.store = ListBox1.SelectedValue

        Me.DialogResult = DialogResult.OK
    End Sub
End Class