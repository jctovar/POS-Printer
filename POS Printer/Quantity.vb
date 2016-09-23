Public Class Quantity
    Public SaleId As Integer
    Public ProductId As Integer
    Private product As New Product
    Private item As New Item
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.GetProduct()

        Me.Text = String.Format("{0} - {1}", Application.ProductName, Product.Name)

        TextBox2.Text = Funciones.Money(Me.GetPrice(ProductId, TextBox1.Text))
        Label1.Text = Label1.Text & " (" & Product.Unit & ")"

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
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox3_GotFocus(sender As Object, e As EventArgs)
        TextBox3.SelectAll()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ItemDB.CheckItem(SaleID, ProductID) = True Then
            Me.UpdateItem()
        Else
            Me.AddItem()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub GetProduct()
        Try
            product = ProductDB.GetProduct(ProductID)

            If ItemDB.CheckItem(SaleID, ProductID) = True Then
                item = ItemDB.GetItem(SaleID, ProductID)

                TextBox1.Text = item.Quantity
            Else
                With item
                    .Sale = SaleID
                    .Product = ProductID
                    .Quantity = CDbl(TextBox1.Text)
                End With
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error; " & ex.ToString, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Calcula()
        Dim Tara As Double = 0

        Try
            If Product.Tare = 0 Then
                ' Calculo normal
                TextBox4.Text = Funciones.Money(TextBox1.Text * Me.GetPrice(ProductId, TextBox1.Text))
            Else
                Label3.Visible = True
                TextBox3.ReadOnly = False
                TextBox3.TabStop = True
                TextBox3.Visible = True
                ' Calculo por medio de la formula de tara de peso
                ' Texbox1 = cantidad
                ' Texbox3 = peso (Kg) 
                If TextBox1.Text <= 0.5 Then
                    Tara = 0.5 * Me.GetPrice(ProductId, TextBox1.Text)
                ElseIf TextBox1.Text > 0.5 Then
                    Tara = product.Tare * TextBox1.Text * Me.GetPrice(ProductId, TextBox1.Text)
                End If

                TextBox4.Text = Funciones.Money(TextBox3.Text * Me.GetPrice(ProductId, TextBox1.Text) - Tara) ' - Tara
            End If

        Catch ex As Exception
            TextBox4.Text = "0.00"
        End Try
    End Sub
    Private Sub AddItem()

        item.Quantity = CDbl(TextBox1.Text)

        If TextBox3.ReadOnly = False Then
            Dim Tara As Double
            If TextBox1.Text <= 0.5 Then
                Tara = 0.5 * TextBox2.Text
            ElseIf TextBox1.Text > 0.5 Then
                Tara = Product.Tare * TextBox1.Text * TextBox2.Text
            End If
            item.Price = ((TextBox2.Text * TextBox3.Text) - Tara) / TextBox1.Text
            item.Note = TextBox3.Text & " KG (-" & (Tara / TextBox2.Text) & "KG) * " & Funciones.Money(TextBox2.Text)
        Else
            item.Price = TextBox2.Text
        End If

        Try
            If ItemDB.AddItem(item) = True Then
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error agregando producto; " & ex.ToString, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UpdateItem()
        item.Quantity = CDbl(TextBox1.Text)

        If TextBox3.ReadOnly = False Then
        Else
            item.Price = TextBox2.Text
        End If

        Try
            If ItemDB.UpdateItem(item) = True Then
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error actualizando producto; " & ex.ToString, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function GetPrice(product As Integer, quantity As Double) As Double
        Return PriceDB.GetOnlyPrice(ProductId, quantity)
    End Function
End Class