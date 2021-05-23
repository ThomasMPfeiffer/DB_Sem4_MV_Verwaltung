using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MV_Mitgliederverwaltung
{
    public class Excelutility
    {
        //Diese Methode ermöglicht Programmerweiterungen zum einlesen von Exceltabellen in die Datenbank (derzeit nicht verwendet)
        public DataTable ReadExcelToDatatble (string worksheetName, string saveAsLocation, string ReporType, int HeaderLine, int ColumnStart)
        {
            System.Data.DataTable dataTable = new DataTable();
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range range;
            try
            {
                // Get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                // Erstellen eines neuen Workbooks
                excelworkBook = excel.Workbooks.Open(saveAsLocation);
                // Work sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)
                                      excelworkBook.Worksheets.Item[worksheetName];
                range = excelSheet.UsedRange;
                int cl = range.Columns.Count;
                // Schleife duch alle Objekte und Hinzufügen zum Sheet
                int rowcount = range.Rows.Count; ;
                //Überschrift der Tabelle erstellen
                for (int j = ColumnStart; j <= cl; j++)
                {
                    dataTable.Columns.Add(Convert.ToString
                                         (range.Cells[HeaderLine, j].Value2), typeof(string));
                }
                //Tabelle mit dem Inhalt der Excel File füllen             
                for (int i = HeaderLine + 1; i <= rowcount; i++)
                {
                    DataRow dr = dataTable.NewRow();
                    for (int j = ColumnStart; j <= cl; j++)
                    {

                        dr[j - ColumnStart] = Convert.ToString(range.Cells[i, j].Value2);
                    }

                    dataTable.Rows.InsertAt(dr, dataTable.Rows.Count + 1);
                }

                //Excel schließen und Data Table zurückgeben
                excelworkBook.Close();
                excel.Quit();
                return dataTable;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                excelSheet = null;
                range = null;
                excelworkBook = null;
            }
        }


        //Diese Funktion diehnt dem auslesen der Datenbandaten in eine Exceltabelle
        public bool WriteDataTableToExcel(DataTable dataTable, string worksheetName)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                //  get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                excel.DisplayAlerts = false;

                //  Erstellen eines neuen Workbooksk
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Work sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;

                // Schleife duch alle Objekte und Hinzufügen zum Sheet
                int rowcount = 1;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        // Hinzufügen der Überschriften
                        if (rowcount == 2)
                        {
                            excelSheet.Cells[1, i] = dataTable.Columns[i - 1].ColumnName;
                        }
                        // Füllen der excel file 
                        excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();
                    }
                }

                return true;
            }
            catch
            {              
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }


    }
}
