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
    public class EintraginDbTests
    {
        [TestMethod()]
        public void AddVereinTest()
        {
            //Hinzufügen des Vereins MVTest
            bool Erfolg = EintraginDb.AddVerein("MVTest");
            Assert.IsTrue(Erfolg, "Diesen Verein gab es bereits");

            //Löschen des zum Testen hinzugefügten Vereins
            DbClass.OpenConnetion();
            DbClass.sql = "DELETE FROM dbo.Verein WHERE Verein = 'MVTest';";
            DbClass.ModSQL();
            DbClass.CloseConnection();
        }

        [TestMethod()]
        public void AddSparteTest()
        {
            DbClass.OpenConnetion();
            //Hinzufügen eines Testusers
            DbClass.sql = "INSERT INTO dbo.Password VALUES ('TUSER','testpw');";
            DbClass.ModSQL();
            DbClass.CloseConnection();
            //Hinzufügen der Sparte MVTest
            try
            {
                EintraginDb.AddSparte("STest", "TUSER");
                Assert.IsTrue(true, "Diese Sparte gab es bereits");
            }
            catch
            {
                Assert.Fail();
            }

            //clean up
            DbClass.OpenConnetion();
            DbClass.sql = "DELETE FROM dbo.Admin__Connector_Sparte_PW WHERE PasswordID = (Select ID FROM dbo.Password WHERE Username = 'TUSER');";
            DbClass.ModSQL();
            DbClass.sql = "DELETE FROM dbo.Connector_Sparte_Verein WHERE SparteID = (Select ID FROM dbo.Sparte WHERE Sparte = 'STest');";
            DbClass.ModSQL();
            DbClass.sql = "DELETE FROM dbo.Sparte WHERE Sparte = 'STest';";
            DbClass.ModSQL();
            DbClass.sql = "DELETE FROM dbo.Password WHERE Username = 'TUSER';";
            DbClass.ModSQL();
            DbClass.CloseConnection();
        }

        [TestMethod()]
        public void AddUserTest()
        {
            //Hinzufügen des Eines dummy Users MVTest
            try
            {
                EintraginDb.AddUser("TUSER", "testp1");
                Assert.IsTrue(true, "Diesen Verein gab es bereits");

            }
            catch
            {
                Assert.Fail();
            }

            //Löschen des zum Testen hinzugefügten Vereins
            DbClass.OpenConnetion();
            DbClass.sql = "DELETE FROM dbo.Password WHERE Username='TUSER';";
            DbClass.ModSQL();
            DbClass.CloseConnection();
        }
    }
}