using Microsoft.VisualStudio.TestTools.UnitTesting;
using MV_Mitgliederverwaltung;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MV_Mitgliederverwaltung.Tests
{
    [TestClass()]
    public class ExcelutilityTests
    {
        [TestMethod()]
        public void WriteDataTableToExcelTest()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Column1", typeof(int));
            table.Columns.Add("Column2", typeof(string));
            table.Columns.Add("Column3", typeof(string));
            table.Columns.Add("Column4", typeof(DateTime));
            DataRow dataRow = table.NewRow();
            dataRow["Column1"] = 1;
            dataRow["Column2"] = "1";
            dataRow["Column3"] = "1";
            dataRow["Column4"] = DateTime.Now;
            table.Rows.Add(dataRow);

            Excelutility testexcel = new Excelutility();
            bool erfolg = testexcel.WriteDataTableToExcel(table,"unittest");
        }
    }
}