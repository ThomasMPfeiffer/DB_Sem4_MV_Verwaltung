using Microsoft.VisualStudio.TestTools.UnitTesting;
using MV_Mitgliederverwaltung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MV_Mitgliederverwaltung.Tests
{
    [TestClass()]
    public class DbClassTests
    {

        [TestMethod()]
        public void ReadSQLTest()
        {
            DbClass.OpenConnetion();
            //Erstellen Eines speziellen Eintrags in die Datenbank
            DbClass.sql = "INSERT INTO dbo.Mitglied (Nachname, Vorname) VALUES('NTest','VTest');";
            DbClass.ModSQL();

            //Auslesen dieses Eintrags, ob er sauber ausgelesen wird
            DbClass.sql = "SELECT Vorname FROM dbo.Mitglied WHERE Nachname = 'NTest'";
            string result = DbClass.ReadSQL();
            Assert.IsTrue(result.Equals("VTest"),"VTest wurde nicht in der Datenbank gefunden Fehler!");

            //Löschen des Eintrags, damit die Db nicht zugemüllt wird
            DbClass.sql = "DELETE FROM dbo.Mitglied WHERE Nachname = 'NTest';";
            DbClass.ModSQL();
            DbClass.CloseConnection();
        }
    }
}