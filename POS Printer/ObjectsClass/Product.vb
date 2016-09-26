Public Class Product
    Private varId As Integer
    Private varAccountId As Integer
    Private varCategoryId As Integer
    Private varName As String
    Private varDescription As String
    Private varKey As String
    Private varUnit As Integer
    Private varVisible As Boolean
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
    Public Property Unit As Integer
        Get
            Return Me.varUnit
        End Get
        Set(value As Integer)
            Me.varUnit = value
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
    Public Property Visible As Boolean
        Get
            Return Me.varVisible
        End Get
        Set(value As Boolean)
            Me.varVisible = value
        End Set
    End Property
End Class
