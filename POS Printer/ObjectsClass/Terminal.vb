Public Class Terminal
    Private varId As Integer
    Private varAccount As Integer
    Private varName As String
    Private varDescription As String
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
    Public Property Visible As Boolean
        Get
            Return Me.varVisible
        End Get
        Set(value As Boolean)
            Me.varVisible = value
        End Set
    End Property
End Class
