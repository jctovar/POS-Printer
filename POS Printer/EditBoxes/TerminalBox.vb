Public Class TerminalBox
    Public TerminalId As Integer
    Public Add As Boolean
    Private terminal As New Terminal
    Private Sub TerminalBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Terminal")

        If Add = False Then
            Me.Edit()
        End If
    End Sub
    Private Sub Edit()
        Try
            terminal = TerminalDB.GetTerminal(TerminalId)
            TextBox1.Text = terminal.Name
            TextBox2.Text = terminal.Description
            CheckBox1.Checked = terminal.Visible
        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With terminal
            .Account = Globales.AccountId
            .Name = TextBox1.Text.ToString
            .Description = TextBox2.Text.ToString
            .Visible = CheckBox1.Checked
        End With

        If MessageBox.Show("Quiere guardar los cambios?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                If Add = True Then
                    If TerminalDB.AddTerminal(terminal) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                Else
                    If TerminalDB.UpdateTerminal(terminal) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error! " & ex.Message.ToString)
            End Try
        End If
    End Sub
End Class