Public Class Session
    Private varId As Integer
    Private varProfileId As Integer
    Private varStatus As Integer
    Private varStart As Date
    Private varEnd As Date
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
    Public Property StartDate As Date
        Get
            Return varStart
        End Get
        Set(value As Date)
            Me.varStart = value
        End Set
    End Property
    Public Property EndDate As Date
        Get
            Return varEnd
        End Get
        Set(value As Date)
            Me.varEnd = value
        End Set
    End Property
End Class
