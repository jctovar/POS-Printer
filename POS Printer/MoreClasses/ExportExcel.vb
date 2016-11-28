Imports OfficeOpenXml 'is the namespace from the EPPlus dll  
Imports System.IO
Public Class ExportExcel
    Public Shared Function btnWriteToExcel_Click() As Boolean
        'Fill in the correct path and filename  
        Using newFile = New FileStream("test.xlsx", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
            Using package As New ExcelPackage(newFile)
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Inventario") 'or any other name for the WorkSheet  
                Dim row As Int32 = 1


                'Here you can do some formatting like making the first column a number column, autosize the cells, ....  

                package.Save()
            End Using
        End Using

        Return True
    End Function
End Class
