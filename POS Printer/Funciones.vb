Imports System.Globalization
Public Class Funciones
    Public Shared Function Money(ByVal value As Double) As String
        Return "$" & String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", value)
    End Function
    Public Shared Function Zeros(ByVal value As Integer) As String
        Dim decimalLength As Integer = value.ToString("D").Length + 5

        Return value.ToString("D" + decimalLength.ToString())
    End Function
    Public Shared Function Dec_Part(ByVal Num As String, ByVal Seperator As String) As String

        Dec_Part = Split(CStr(Num), Seperator)(1)
    End Function


End Class
