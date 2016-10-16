Public Class Item
    Private varProductId As Integer
    Private varSaleId As Integer
    Private varQty As Double
    Private varPrice As Double
    Private varTax As Double
    Private varNote As String
    Public Property Product As Integer
        Get
            Return Me.varProductId
        End Get
        Set(value As Integer)
            Me.varProductId = value
        End Set
    End Property
    Public Property Sale As Integer
        Get
            Return Me.varSaleId
        End Get
        Set(value As Integer)
            Me.varSaleId = value
        End Set
    End Property
    Public Property Quantity As Double
        Get
            Return Me.varQty
        End Get
        Set(value As Double)
            Me.varQty = value
        End Set
    End Property
    Public Property Price As Double
        Get
            Return Me.varPrice
        End Get
        Set(value As Double)
            Me.varPrice = value
        End Set
    End Property
    Public Property Tax As Double
        Get
            Return Me.varTax
        End Get
        Set(value As Double)
            Me.varTax = value
        End Set
    End Property
    Public Property Note As String
        Get
            Return Me.varNote
        End Get
        Set(value As String)
            Me.varNote = value
        End Set
    End Property
End Class
