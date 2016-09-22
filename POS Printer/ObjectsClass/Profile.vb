Public Class Profile
    Private varId As Integer
    Private varAccount As Integer
    Private varName As String
    Private varUsername As String
    Private varPhone As String
    Private varEmail As String
    Private varPassword As String
    Private varRole As Integer
    Private varEnable As Boolean
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
    Public Property Username As String
        Get
            Return Me.varUsername
        End Get
        Set(value As String)
            Me.varUsername = value
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
    Public Property Password As String
        Get
            Return Me.varPassword
        End Get
        Set(value As String)
            Me.varPassword = value
        End Set
    End Property
    Public Property Role As Integer
        Get
            Return Me.varRole
        End Get
        Set(value As Integer)
            Me.varRole = value
        End Set
    End Property
    Public Property Enable As Boolean
        Get
            Return Me.varEnable
        End Get
        Set(value As Boolean)
            Me.varEnable = value
        End Set
    End Property
End Class
