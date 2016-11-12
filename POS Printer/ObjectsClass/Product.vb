Public Class Product
    Private varId As Integer
    Private varAccount As Integer
    Private varCategory As Integer
    Private varName As String
    Private varDescription As String
    Private varKey As String
    Private varUnit As Integer
    Private varTax As Double
    Private varVisible As Boolean
    Private varInventory As Boolean
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
    Public Property Name As String
        Get
            Return Me.varName
        End Get
        Set(value As String)
            Me.varName = value
        End Set
    End Property
    Public Property Description As String
        Get
            Return Me.varDescription
        End Get
        Set(value As String)
            Me.varDescription = value
        End Set
    End Property
    Public Property Key As String
        Get
            Return Me.varKey
        End Get
        Set(value As String)
            Me.varKey = value
        End Set
    End Property
    Public Property Unit As Integer
        Get
            Return Me.varUnit
        End Get
        Set(value As Integer)
            Me.varUnit = value
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
    Public Property Category As Integer
        Get
            Return Me.varCategory
        End Get
        Set(value As Integer)
            Me.varCategory = value
        End Set
    End Property
    Public Property Visible As Boolean
        Get
            Return Me.varVisible
        End Get
        Set(value As Boolean)
            Me.varVisible = value
        End Set
    End Property
    Public Property Inventory As Boolean
        Get
            Return Me.varInventory
        End Get
        Set(value As Boolean)
            Me.varInventory = value
        End Set
    End Property
End Class
