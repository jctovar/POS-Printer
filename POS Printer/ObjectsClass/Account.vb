Public Class Account
    Private varId As Integer
    Private varName As String
    Private varRfc As String
    Private varSlogan As String
    Private varAddress1 As String
    Private varAddress2 As String
    Private varEmail As String
    Private varPostalCode As String
    Private varPhone As String
    Public Property Id As Integer
        Get
            Return Me.varId
        End Get
        Set(value As Integer)
            Me.varId = value
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
    Public Property Rfc As String
        Get
            Return Me.varRfc
        End Get
        Set(value As String)
            Me.varRfc = value
        End Set
    End Property
    Public Property Slogan As String
        Get
            Return Me.varSlogan
        End Get
        Set(value As String)
            Me.varSlogan = value
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
    Public Property Email As String
        Get
            Return Me.varEmail
        End Get
        Set(value As String)
            Me.varEmail = value
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
