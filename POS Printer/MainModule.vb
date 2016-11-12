Module MainModule
    Sub Main()
        Dim frmSplash As New Splash

        Application.EnableVisualStyles()

        GetAccount()
        CheckTerminal()

        frmSplash.ShowDialog()

        Try
            Application.Run(MainBox)
        Catch ex As Exception

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

        If String.IsNullOrEmpty(TerminalDB.GetTerminalName(My.Settings.terminal)) Then
            ' Selecciona terminal
            Dim frmTerminal As New SelectTerminal

            If frmTerminal.ShowDialog() = DialogResult.OK Then

            End If
        End If

    End Sub
End Module
