Imports OfficeOpenXml 'is the namespace from the EPPlus dll  
Imports System.IO
Public Class ExportExcel
    Public Shared Function btnWriteToExcel_Click(Filename As String) As Boolean
        Dim TableView As New DataTable
        'Fill in the correct path and filename  
        Using newFile = New FileStream(Filename, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
            Using package As New ExcelPackage(newFile)
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Inventario") 'or any other name for the WorkSheet  
                Dim row As Int32 = 1
                TableView = ProductDB.GetProductsList(1, "", True)

                ws.Cells.LoadFromDataTable(TableView, True)

                ws.DeleteColumn(1, 2)
                ws.Cells("A1").Value = "Categoría"
                ws.Cells("B1").Value = "Nombre"
                ws.Cells("C1").Value = "Clave"
                ws.Cells("D1").Value = "Cantidad"
                ws.Cells("E1").Value = "Unidad"
                ws.Cells("F1").Value = "Precio"
                ws.DeleteColumn(7, 2)
                ws.Column(1).AutoFit()
                ws.Column(2).AutoFit()
                ws.Column(4).Style.Numberformat.Format = "0.00"
                ws.Column(6).Style.Numberformat.Format = "$ ###,###,##0.00"
                ws.Cells("A1:F1").Style.Font.Color.SetColor(Color.White)
                ws.Cells("A1:F1").Style.Font.Bold = True
                ws.Cells("A1:F1").Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                ws.Cells("A1:F1").Style.Fill.BackgroundColor.SetColor(Color.DarkSlateBlue)



                'Here you can do some formatting like making the first column a number column, autosize the cells, ....  

                package.Save()
            End Using
        End Using

        Return True
    End Function
End Class
