Public Class Session
    Private varId As Integer
    Private varProfileId As Integer
    Private varStoreId As Integer
    Private varStatus As Boolean
    Private varTimestamp As Date
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
    Public Property Store As Integer
        Get
            Return Me.varStoreId
        End Get
        Set(value As Integer)
            Me.varStoreId = value
        End Set
    End Property
    Public Property Status As Boolean
        Get
            Return Me.varStatus
        End Get
        Set(value As Boolean)
            Me.varStatus = value
        End Set
    End Property
    Public Property Timestamp As Date
        Get
            Return varTimestamp
        End Get
        Set(value As Date)
            Me.varTimestamp = value
        End Set
    End Property
End Class
