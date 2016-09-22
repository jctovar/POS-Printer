Public Class About
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        Me.Text = String.Format("{0} - {1}", ApplicationTitle, "Acerca de...")

        Me.Label1.Text = My.Application.Info.ProductName
        If System.Diagnostics.Debugger.IsAttached = False Then
            Me.Label2.Text = String.Format("Versión {0}", My.Application.Deployment.CurrentVersion.ToString)
        Else
            Me.Label2.Text = String.Format("Versión {0}", "Debug mode")
        End If
        Me.Label3.Text = My.Application.Info.Copyright
        Me.Label4.Text = My.Application.Info.CompanyName
        Me.Label5.Text = My.Application.Info.Description
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class