Imports OfficeOpenXml 'is the namespace from the EPPlus dll  
Imports System.IO
Public Class ExportExcel
    Public Shared Function Inventario(Filename As String) As Boolean
        Dim TableView As New DataTable
        'Fill in the correct path and filename  
        Using newFile = New FileStream(Filename, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
            Using package As New ExcelPackage(newFile)
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Inventario") 'or any other name for the WorkSheet  
                Dim row As Int32 = 1
                TableView = ProductDB.GetProductsList(Globales.AccountId, "", True)

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
                ws.Column(6).AutoFit()
                ws.Column(6).Style.Numberformat.Format = "$ ###,###,##0.00"
                With ws.Cells("A1:F1").Style
                    .Font.Color.SetColor(Color.White)
                    .Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                    .Font.Bold = True
                    .Fill.BackgroundColor.SetColor(Color.DarkSlateBlue)
                End With

                Try
                    package.Save()

                    System.Diagnostics.Process.Start(Filename)

                Catch ex As Exception
                    MessageBox.Show("Ocurrio un error; " & ex.ToString, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End Using
        End Using

        Return True
    End Function
    Public Shared Function Corte(Filename As String, SessionId As Integer) As Boolean
        Dim TableView As New DataTable
        'Fill in the correct path and filename  
        Using newFile = New FileStream(Filename, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
            Using package As New ExcelPackage(newFile)
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Corte de caja") 'or any other name for the WorkSheet  
                Dim row As Int32 = 1
                Dim endrow As Int32

                TableView = InvoiceDB.GetReportFromSession(SessionId)
                endrow = TableView.Rows.Count + 1

                ws.Cells.LoadFromDataTable(TableView, True)

                ws.Cells("A1").Value = "Folio"
                ws.Cells("B1").Value = "Fecha"
                ws.Cells("C1").Value = "Producto"
                ws.Cells("D1").Value = "Cantidad"
                ws.Cells("E1").Value = "Precio"
                ws.Cells("F1").Value = "Impuesto"
                ws.Cells("G1").Value = "Subtotal"
                ws.Column(2).AutoFit()
                ws.Column(2).Style.Numberformat.Format = "yyyy-mm-dd hh:MM"
                ws.Column(3).AutoFit()
                ws.Column(4).Style.Numberformat.Format = "0.00"
                ws.Column(5).AutoFit()
                ws.Column(5).Style.Numberformat.Format = "$ ###,###,##0.00"
                ws.Column(6).AutoFit()
                ws.Column(6).Style.Numberformat.Format = "$ ###,###,##0.00"
                ws.Column(7).AutoFit()
                ws.Column(7).Style.Numberformat.Format = "$ ###,###,##0.00"
                With ws.Cells("A1:G1").Style
                    .Font.Color.SetColor(Color.White)
                    .Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                    .Font.Bold = True
                    .Fill.BackgroundColor.SetColor(Color.DarkSlateBlue)
                End With

                For t = 2 To endrow
                    ws.Cells("G" & t).Formula = String.Format("=(D{0}*E{0}*(1+F{0}%))", t)
                Next

                ws.Cells("G" & endrow + 1).Formula = String.Format("SUM(G2:G{0})", endrow)
                ws.Cells("G" & endrow + 1).Style.Font.Bold = True

                Try
                    package.Save()

                    System.Diagnostics.Process.Start(Filename)

                Catch ex As Exception
                    MessageBox.Show("Ocurrio un error; " & ex.ToString, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End Using
        End Using

        Return True
    End Function
End Class
