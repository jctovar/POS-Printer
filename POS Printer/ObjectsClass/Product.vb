Public Class Product
    Private varId As Integer
    Private varAccountId As Integer
    Private varCategoryId As Integer
    Private varName As String
    Private varDescription As String
    Private varKey As String
    Private varTare As Integer
    Private varUnitId As Integer
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
            Return Me.varAccountId
        End Get
        Set(value As Integer)
            Me.varAccountId = value
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
    Public Property Tare As Integer
        Get
            Return Me.varTare
        End Get
        Set(value As Integer)
            Me.varTare = value
        End Set
    End Property
    Public Property Unit As Integer
        Get
            Return Me.varUnitId
        End Get
        Set(value As Integer)
            Me.varUnitId = value
        End Set
    End Property
    Public Property Category As Integer
        Get
            Return Me.varCategoryId
        End Get
        Set(value As Integer)
            Me.varCategoryId = value
        End Set
    End Property
End Class
