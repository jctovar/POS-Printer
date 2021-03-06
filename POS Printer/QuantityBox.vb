﻿Public Class QuantityBox
    Public SaleId As Integer
    Public ProductId As Integer
    Private product As New Product
    Private price As New Price
    Private item As New Item
    Private unit As String
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            product = ProductDB.GetProduct(ProductId)
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error cargando los datos del producto. " & ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.CheckItemData()

        unit = ProductDB.GetUnitName(product.Unit).ToString

        Me.Text = String.Format("{0} - {1}", Application.ProductName, product.Name)
        Label1.Text = String.Format("{0} ( {1} )", Label1.Text, unit)

        Me.Calcula()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            TextBox1.Text = "1"
            TextBox1.SelectAll()
        End If

        Me.Calcula()
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs)
        TextBox1.SelectAll()
    End Sub
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Me.Calcula()
    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Me.Calcula()
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox3_GotFocus(sender As Object, e As EventArgs)
        TextBox3.SelectAll()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If TextBox3.Text = 0 And TextBox3.Visible = True Then
            TextBox3.Focus()
        Else
            If ItemDB.CheckItem(SaleId, ProductId) = True Then
                Me.UpdateItem()
            Else
                Me.AddItem()
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub CheckItemData()
        Try
            If ItemDB.CheckItem(SaleId, ProductId) = True Then
                item = ItemDB.GetItem(SaleId, ProductId)

                TextBox1.Text = item.Quantity
            Else
                With item
                    .Sale = SaleId
                    .Product = ProductId
                    .Tax = ProductDB.GetTaxValue(product.Tax)
                    .Quantity = CDbl(TextBox1.Text)
                End With
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error " & ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Calcula()

        Try
            price = PriceDB.SearchPrice(ProductId, CDbl(TextBox1.Text))
        Catch ex As Exception
            'MessageBox.Show("Ocurrio un error. " & ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            If price.Tare = 0 Then
                ' Calculo normal
                TextBox4.Text = (TextBox1.Text * price.Price).ToString("c")
            Else
                ' Calculo por medio de la formula de tara de peso
                Label3.Visible = True
                Label5.Visible = True
                Label6.Visible = True
                TextBox3.ReadOnly = False
                TextBox3.TabStop = True
                TextBox3.Visible = True
                TextBox5.Visible = True
                TextBox5.Text = price.Tare
                TextBox6.Visible = True

                ' Texbox1 = cantidad (pza)
                ' Texbox3 = peso (Kg) 
                ' Texbox6 = tarima (Kg)
                ' Texbox4 = total ($)

                Console.WriteLine(price.Tare)
                Console.WriteLine(TextBox6.Text)
                'Console.WriteLine(TextBox6.Text)
                TextBox4.Text = ((TextBox3.Text * price.Price) - (price.Tare * TextBox1.Text * price.Price) - (TextBox6.Text * price.Price)).ToString("c")
            End If

            TextBox2.Text = price.Price.ToString("c")

        Catch ex As Exception
            TextBox4.Text = "0.00"
        End Try
    End Sub
    Private Sub AddItem()

        item.Quantity = CDbl(TextBox1.Text)

        If TextBox3.ReadOnly = False Then
            Dim Tara As Double

            Tara = ((price.Tare * TextBox1.Text) + TextBox6.Text) * TextBox2.Text

            item.Price = ((TextBox2.Text * TextBox3.Text) - Tara) / TextBox1.Text
            item.Formula = CDbl(TextBox3.Text).ToString("n") & " KG (-" & (Tara / TextBox2.Text) & "KG) * " & TextBox2.Text
            item.Note = ""
        Else
            item.Price = TextBox2.Text
            item.Formula = CDbl(TextBox1.Text).ToString("n") & " " & unit & " * " & TextBox2.Text
            item.Note = ""
        End If

        item.Tare = price.Tare

        Try
            If ItemDB.AddItem(item) = True Then
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error agregando producto; " & ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UpdateItem()
        item.Quantity = CDbl(TextBox1.Text)

        If TextBox3.ReadOnly = False Then
            Dim Tara As Double

            Tara = price.Tare * TextBox1.Text * TextBox2.Text

            item.Price = ((TextBox2.Text * TextBox3.Text) - Tara) / TextBox1.Text
            item.Formula = CDbl(TextBox3.Text).ToString("n") & " KG (-" & (Tara / TextBox2.Text) & "KG) * " & TextBox2.Text
        Else
            item.Price = TextBox2.Text
            item.Formula = CDbl(TextBox1.Text).ToString("n") & " " & unit & " * " & TextBox2.Text
        End If

        item.Tare = price.Tare

        Try
            If ItemDB.UpdateItem(item) = True Then
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error actualizando producto; " & ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class