Public Class Session
    Private varId As Integer
    Private varProfileId As Integer
    Private varStatus As Integer
    Private varTimestamp As String
    Public Property Id As Integer
        Get
            Return Me.varId
        End Get
        Set(value As Integer)
            Me.varId = value
        End Set
    End Property
    Public Property Profile As Integer
        Get
            Return Me.varProfileId
        End Get
        Set(value As Integer)
            Me.varProfileId = value
        End Set
    End Property
    Public Property Status As Integer
        Get
            Return Me.varStatus
        End Get
        Set(value As Integer)
            Me.varStatus = value
        End Set
    End Property
    Public Property Timestamp As String
        Get
            Return varTimestamp
        End Get
        Set(value As String)
            Me.varTimestamp = value
        End Set
    End Property
End Class
