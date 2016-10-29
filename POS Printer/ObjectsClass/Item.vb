Public Class Item
    Private varProductId As Integer
    Private varSaleId As Integer
    Private varQty As Double
    Private varPrice As Double
    Private varTax As Double
    Private varFormula As String
    Private varNote As String
    Private varTare As Double
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
    Public Property Formula As String
        Get
            Return Me.varFormula
        End Get
        Set(value As String)
            Me.varFormula = value
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
    Public Property Tare As Double
        Get
            Return Me.varTare
        End Get
        Set(value As Double)
            Me.varTare = value
        End Set
    End Property
End Class
