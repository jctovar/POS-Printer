﻿Public Class SupplierBox
    Public SupplierId As Integer
    Public Add As Boolean
    Private supplier As New Supplier
    Private Sub SupplierBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = String.Format("{0} - {1}", Application.ProductName, "Proveedor")

        If Add = False Then
            Me.Edit()
        End If
    End Sub
    Private Sub Edit()
        Try
            supplier = SupplierDB.GetSupplier(SupplierId)
            TextBox1.Text = supplier.Name
            TextBox2.Text = supplier.Address1
            TextBox3.Text = supplier.Address2
            TextBox4.Text = supplier.PostalCode
            TextBox5.Text = supplier.Email
            TextBox6.Text = supplier.Phone
        Catch ex As Exception
            MsgBox("Ocurrio un error! " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With supplier
            .Account = Globales.AccountId
            .Name = TextBox1.Text.ToString
            .Address1 = TextBox2.Text.ToString
            .Address2 = TextBox3.Text.ToString
            .PostalCode = TextBox4.Text.ToString
            .Email = TextBox5.Text.ToString
            .Phone = TextBox6.Text.ToString
        End With

        If MessageBox.Show("Quiere guardar los cambios?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                If Add = True Then
                    If SupplierDB.AddSupplier(supplier) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                Else
                    If SupplierDB.UpdateSupplier(supplier) = True Then
                        Me.DialogResult = DialogResult.OK
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error! " & ex.Message.ToString)
            End Try
        End If
    End Sub
End Class