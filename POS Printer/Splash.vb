Public Class Splash
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Application.Info.Title <> "" Then
            Label1.Text = My.Application.Info.Title
        Else
            'Si falta el título de la aplicación, utilice el nombre de la aplicación sin la extensión
            Label1.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        If System.Diagnostics.Debugger.IsAttached = False Then
            Me.Label2.Text = String.Format("Versión {0}", My.Application.Deployment.CurrentVersion.ToString)
        Else
            Me.Label2.Text = String.Format("Versión {0}", "Debug mode")
        End If

        'Información de Copyright
        Label3.Text = My.Application.Info.Copyright
    End Sub
End Class