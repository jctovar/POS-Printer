Public Class Customer
    Private varId As Integer
    Private varAccount As Integer
    Private varName As String
    Private varAddress1 As String
    Private varAddress2 As String
    Private varPostalCode As String
    Private varPhone As String
    Private varEmail As String
    Private varRFC As String
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
    Public Property Address1 As String
        Get
            Return Me.varAddress1
        End Get
        Set(value As String)
            Me.varAddress1 = value
        End Set
    End Property
    Public Property Address2 As String
        Get
            Return Me.varAddress2
        End Get
        Set(value As String)
            Me.varAddress2 = value
        End Set
    End Property
    Public Property PostalCode As String
        Get
            Return Me.varPostalCode
        End Get
        Set(value As String)
            Me.varPostalCode = value
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
    Public Property Email As String
        Get
            Return Me.varEmail
        End Get
        Set(value As String)
            Me.varEmail = value
        End Set
    End Property
    Public Property RFC As String
        Get
            Return Me.varRFC
        End Get
        Set(value As String)
            Me.varRFC = value
        End Set
    End Property
End Class
