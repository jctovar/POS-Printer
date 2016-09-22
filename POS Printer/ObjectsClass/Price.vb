Public Class Price
    Private varId As Integer
    Private varProduct As Integer
    Private varPrice As Double
    Private varQuantity As Integer
    Public Property Id As Integer
        Get
            Return Me.varId
        End Get
        Set(value As Integer)
            Me.varId = value
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
    Public Property Quantity As Integer
        Get
            Return Me.varQuantity
        End Get
        Set(value As Integer)
            Me.varQuantity = value
        End Set
    End Property
End Class
