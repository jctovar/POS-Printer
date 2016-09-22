Public Class Payment
    Private varSaleId As Integer
    Private varPaymentId As Integer
    Private varAmount As Double
    Public Property SaleId As Integer
        Get
            Return Me.varSaleId
        End Get
        Set(value As Integer)
            Me.varSaleId = value
        End Set
    End Property
    Public Property PaymentId As Integer
        Get
            Return Me.varPaymentId
        End Get
        Set(value As Integer)
            Me.varPaymentId = value
        End Set
    End Property
    Public Property Amount As Double
        Get
            Return Me.varAmount
        End Get
        Set(value As Double)
            Me.varAmount = value
        End Set
    End Property
End Class
