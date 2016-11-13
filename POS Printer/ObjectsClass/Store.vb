Public Class Store
    Private varId As Integer
    Private varAccount As Integer
    Private varName As String
    Private varAddress As String
    Private varPhone As String
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
    Public Property Address As String
        Get
            Return Me.varAddress
        End Get
        Set(value As String)
            Me.varAddress = value
        End Set
    End Property
    Public Property Phone As String
        Get
            Return Me.varPhone
        End Get
        Set(value As String)
            Me.varPhone = value
        End Set
    End Property
End Class
