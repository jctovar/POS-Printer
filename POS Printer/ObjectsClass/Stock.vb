Public Class Stock
    Private varId As Integer
    Private varAccount As Integer
    Private varSore As Integer
    Private varSupplier As Integer
    Private varProduct As Integer
    Private varPrice As Double
    Private varQuantity As Double
    Private varDate As Date
    Public Property Id As Integer
        Get
            Return Me.varId
        End Get
        Set(value As Integer)
            Me.varId = value
        End Set
    End Property
    Public Property Account As Integer
        Get
            Return Me.varAccount
        End Get
        Set(value As Integer)
            Me.varAccount = value
        End Set
    End Property
    Public Property Store As Integer
        Get
            Return Me.varSore
        End Get
        Set(value As Integer)
            Me.varSore = value
        End Set
    End Property
    Public Property Supplier As Integer
        Get
            Return Me.varSupplier
        End Get
        Set(value As Integer)
            Me.varSupplier = value
        End Set
    End Property
    Public Property Product As Integer
        Get
            Return Me.varProduct
        End Get
        Set(value As Integer)
            Me.varProduct = value
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
    Public Property Quantity As Double
        Get
            Return Me.varQuantity
        End Get
        Set(value As Double)
            Me.varQuantity = value
        End Set
    End Property
    Public Property StockDate As Date
        Get
            Return Me.varDate
        End Get
        Set(value As Date)
            Me.varDate = value
        End Set
    End Property
End Class
