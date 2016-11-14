Module MainModule
    Sub Main()
        Dim frmSplash As New Splash

        Application.EnableVisualStyles()

        GetAccount()
        CheckTerminal()
        CheckStore()

        frmSplash.ShowDialog()

        Try
            Application.Run(MainBox)
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error; " & ex.ToString, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        My.Settings.Save()
    End Sub
    Private Sub GetAccount()
        Dim account As New Account

        account = AccountDB.GetAccount(My.Settings.account.ToString)

        Globales.AccountId = account.Id
        Globales.AccountName = account.Name
        Globales.AccountRfc = account.Rfc
        Globales.AccountSlogan = account.Slogan
        Globales.AccountAddres_1 = account.Address1
        Globales.AccountAddres_2 = account.Address2
        Globales.AccountEmail = account.Email
        Globales.AccountPostalCode = account.PostalCode
        Globales.AccountPhone = account.Phone

    End Sub
    Private Sub CheckTerminal()

        Globales.TerminalName = TerminalDB.GetTerminalName(My.Settings.terminal)

        If String.IsNullOrEmpty(Globales.TerminalName) Then
            ' Selecciona terminal
            Dim frmTerminal As New SelectTerminal

            If frmTerminal.ShowDialog() = DialogResult.OK Then

            End If
        End If

    End Sub
    Private Sub CheckStore()

        Globales.StoreName = StoreDB.GetStoreName(My.Settings.store)

        If String.IsNullOrEmpty(Globales.StoreName) Then
            ' Selecciona terminal
            Dim frmStore As New SelectStore

            If frmStore.ShowDialog() = DialogResult.OK Then

            End If
        End If

    End Sub
End Module
