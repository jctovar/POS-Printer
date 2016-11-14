Public Class Invoice
    Private varId As Integer
    Private varAccountId As Integer
    Private varCustomerId As Integer
    Private varTerminal As Integer
    Private varProfile As Integer
    Private varSession As Integer
    Private varStore As Integer
    Private varStatus As Integer
    Private varNote As String
    Private varTimestamp As String
    Private varSubtotal As Double
    Private varTax As Double
    Private varTotal As Double
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
    Public Property Customer As Integer
        Get
            Return Me.varCustomerId
        End Get
        Set(value As Integer)
            Me.varCustomerId = value
        End Set
    End Property
    Public Property Profile As Integer
        Get
            Return Me.varProfile
        End Get
        Set(value As Integer)
            Me.varProfile = value
        End Set
    End Property
    Public Property Session As Integer
        Get
            Return Me.varSession
        End Get
        Set(value As Integer)
            Me.varSession = value
        End Set
    End Property
    Public Property Store As Integer
        Get
            Return Me.varStore
        End Get
        Set(value As Integer)
            Me.varStore = value
        End Set
    End Property
    Public Property Terminal As Integer
        Get
            Return Me.varTerminal
        End Get
        Set(value As Integer)
            Me.varTerminal = value
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
    Public Property Note As String
        Get
            Return Me.varNote
        End Get
        Set(value As String)
            Me.varNote = value
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
    Public Property Subtotal As Double
        Get
            Return Me.varSubtotal
        End Get
        Set(value As Double)
            Me.varSubtotal = value
        End Set
    End Property
    Public Property Tax As Double
        Get
            Return Me.varTax
        End Get
        Set(value As Double)
            Me.varTax = value
        End Set
    End Property
    Public Property Total As Double
        Get
            Return Me.varTotal
        End Get
        Set(value As Double)
            Me.varTotal = value
        End Set
    End Property
End Class
