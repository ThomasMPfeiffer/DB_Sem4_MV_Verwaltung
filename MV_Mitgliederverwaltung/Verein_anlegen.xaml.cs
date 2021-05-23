using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MV_Mitgliederverwaltung
{
    /// <summary>
    /// Interaktionslogik für Verein_anlegen.xaml
    /// </summary>
    public partial class Verein_anlegen : Window
    {
        public Verein_anlegen()
        {
            InitializeComponent();
        }
        private string vereinsbezeichnung;

        private void Loadvereinsbezeichnung()
        {
            vereinsbezeichnung = TextboxSpartenname.Text;
        }

        //Läd Datagrid und nullt die Vereinsbezeichnung beim Eventhandler loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //leeres Anzeigegrid laden
            Loadvereinsbezeichnung();
            Gridupdate();
            DataGridSparten.ItemsSource = DbClass.dt.DefaultView;
            DbClass.CloseConnection();
        }

        //hinzufügen einer Sparte zum Verein
        private void Spartehinzufuegen_Button_Click(object sender, RoutedEventArgs e)
        {
            Loadvereinsbezeichnung();
            //Verein Erstellen, da sonst kein Hinzufügen einer Sparte möglich ist (ist gegen mehrfacherstellung gesichert)
            EintraginDb.AddVerein(vereinsbezeichnung);
            //hinzufügen der Sparte
            Sparte_hinzufuegen sparte_hinzufuegen = new Sparte_hinzufuegen(this);
            sparte_hinzufuegen.Show();
        }

        //Schreibt den Verein in die Datenbank (Wenn dies noch nicht durch Sparte Hinzufügen geschehen ist)
        private void Abschliessen_Button_Click(object sender, RoutedEventArgs e)
        {
            EintraginDb.AddVerein(vereinsbezeichnung);
            Close();
        }
       
        private void MenuItemBeenden_Click(object sender, RoutedEventArgs e)
        {
            Abbrechen();
        }

        private void Abbrechen_Button_Click(object sender, RoutedEventArgs e)
        {
            Abbrechen();
        }

        //Methode zum Abbrechen löscht den angelegten Verein
        private void Abbrechen()
        {
            //Verein wird beim Hinzufügen von Sparte auch generiert. Er muss also wieder gelöscht werden, wenn der Vorgang abgebrochen wird          
            try
            {
                DbClass.OpenConnetion();
                DbClass.sql = "DELETE FROM dbo.Admin_Connector_Sparte_PW WHERE Connector_Sparte_Verein_ID=(SELECT ID FROM dbo.Connector_Sparte_Verein WHERE VereinID = (SELECT ID FROM dbo.Verein WHERE Verein = '" + vereinsbezeichnung + "'));";
                DbClass.ModSQL();
                DbClass.sql = "DELETE FROM dbo.Connector_Sparte_Verein WHERE VereinID=(SELECT ID FROM dbo.Verein WHERE Verein = '" + vereinsbezeichnung + "');";
                DbClass.ModSQL();
                DbClass.sql = "DELETE FROM dbo.Verein WHERE Verein = '" + vereinsbezeichnung + "';";
                DbClass.ModSQL();
                DbClass.CloseConnection();
            }
            catch
            {

            }
            Close();
        }

        //Ein gridupdate, dass von der EintraginDb aufgerufen wird, damit das Grid zur Sparte aktualisiert wird
        public void Gridupdate()
        {
            //Aktualisierung
            DbClass.OpenConnetion();
            DbClass.sql = "SELECT Sparte FROM dbo.Sparte AS S " +
                "LEFT JOIN dbo.Connector_Sparte_Verein AS CSV ON S.ID = CSV.SparteID " +
                "LEFT JOIN dbo.Verein AS V ON CSV.VereinID = V.ID " +
                "WHERE S.ID=CSV.SparteID AND CSV.VereinID = V.ID AND V.Verein='" + vereinsbezeichnung + "';";
            DbClass.ModSQL();
            DataGridSparten.ItemsSource = DbClass.dt.DefaultView;
            DbClass.CloseConnection();
        }
    }
}
