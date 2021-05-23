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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;
using System.Collections;

namespace MV_Mitgliederverwaltung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindowAngemeldet : Window
    {

        private int DataGridLengthInitialize;
        public static string selectedVerein;
        public static string selectedSparte;

        public MainWindowAngemeldet()
        {
            InitializeComponent();
        }

        //Methode zum direkten Abruf des sql Strings zum Anzeign der Mitglieder
        private string AnzeigeMitglieder()
        {
            DbClass.sql = "SELECT ID FROM dbo.Password WHERE Username='" + Anmeldung.username + "';";
            return "SELECT M.ID, M.Nachname, M.Vorname, M.Straße, M.Hausnummer, M.Mitglied_seit, M.Geb_Datum, M.Telefon,M.Mobil, M.E_Mail, M.Mail_Eltern, M.Mobil_Eltern, W.PLZ, W.Wohnort " +
           "FROM dbo.Mitglied AS M LEFT JOIN dbo.Wohnort AS W ON M.WohnortID = W.ID " +
           "LEFT JOIN dbo.Connector_Mitglied_Sparte AS CMS ON M.ID = CMS.MitgliedID " +
           "LEFT JOIN dbo.Connector_Sparte_Verein AS CSV ON CMS.Connector_Sparte_Verein_ID = CSV.ID " +
           "LEFT JOIN dbo.Sparte AS S ON CSV.SparteID = S.ID " +
           "LEFT JOIN dbo.Admin__Connector_Sparte_PW AS Adm ON CSV.ID = Adm.Connector_Sparte_Verein_ID " +
           "LEFT JOIN dbo.Password AS PW ON Adm.PasswordID = PW.ID " +
           "LEFT JOIN dbo.Verein AS V ON CSV.VereinID = V.ID " +
           "WHERE " + Anmeldung.passwordID + " = Adm.PasswordID AND Adm.Admin = 1 AND  Adm.Connector_Sparte_Verein_ID = CSV.ID AND CSV.ID = CMS.Connector_Sparte_Verein_ID AND S.ID = CSV.SparteID AND CMS.MitgliedID = M.ID AND CSV.VereinID=V.ID AND V.Verein = '" + selectedVerein + "' AND S.Sparte='" + selectedSparte + "';";
        }

        //Beim Laden des Fensters wird die Combobox zum Auswählen des gewünschten Vereins gefüllt
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboVereinBoxDataFill();
        }

        //Methode zum füllen der Vereinscombobox wird in Window Loaded aufgerufen
        private void ComboVereinBoxDataFill()
        {
            DbClass.OpenConnetion();
            DbClass.sql = "SELECT DISTINCT V.Verein FROM dbo.Verein AS V " +
                "LEFT JOIN dbo.Connector_Sparte_Verein AS CSV ON V.ID = CSV.VereinID " +
                "LEFT JOIN dbo.Admin__Connector_Sparte_PW AS Adm ON CSV.ID = Adm.Connector_Sparte_Verein_ID " +
                "LEFT JOIN dbo.Password as PW ON Adm.PasswordID = PW.ID " +
                "LEFT JOIN dbo.Sparte as S ON CSV.SparteID = S.ID " +
                "WHERE " + Anmeldung.passwordID + " = Adm.PasswordID AND adm.Connector_Sparte_Verein_ID = CSV.ID AND CSV.VereinID = V.ID;";
            DbClass.ModSQL();

            //Daten von dt in Combobox laden
            foreach (DataRow x in DbClass.dt.Select())
            {
                cmb_Verein.Items.Add(x.ItemArray[0]);
            }

        }

        //Sobald die Selektion in der Vereinscombobox geändert wird, soll die Sparten Combobox geladen werden
        private void Cmb_Verein_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Speichert den ausgewählten Verein in die globale Variable
            selectedVerein = cmb_Verein.SelectedItem.ToString();
            //reinladen der Sparten Combobox
            DbClass.OpenConnetion();
            DbClass.sql = "SELECT Sparte FROM dbo.Sparte AS S " +
                "LEFT JOIN dbo.Connector_Sparte_Verein AS CSV ON S.ID = CSV.SparteID " +
                "LEFT JOIN dbo.Admin__Connector_Sparte_PW AS Adm ON CSV.ID = Adm.Connector_Sparte_Verein_ID " +
                "LEFT JOIN dbo.Password as PW ON Adm.PasswordID = PW.ID " +
                "LEFT JOIN dbo.Verein as V ON CSV.VereinID = V.ID " +
                "WHERE PW.Username='"+Anmeldung.username+"' AND PW.ID = Adm.PasswordID AND adm.Connector_Sparte_Verein_ID = CSV.ID AND CSV.SparteID = S.ID AND V.Verein='" + selectedVerein + "';";
            DbClass.ModSQL();
            //leeren der Combobox
            cmb_Sparte.Items.Clear();
            //Daten von dt in Combobox laden
            foreach (DataRow x in DbClass.dt.Select())
            {
                cmb_Sparte.Items.Add(x.ItemArray[0]);
            }
            DbClass.CloseConnection();
        }

        //Sobald die Auswahl in der Sparten Combobox geändert wird, soll die Mitgliedder Tabelle mit der richtigen Sparte geladen werden
        private void Cmb_Sparte_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedSparte = cmb_Sparte.SelectedItem.ToString();
            }
            catch
            {
                return;
            }

            LoadMitglieder();
        }

        //Laden der Mitglieder Daten in das DataGrid
        private void LoadMitglieder()
        {
            DbClass.OpenConnetion();
            DbClass.sql = AnzeigeMitglieder();
            DbClass.ModSQL();
            DataGridMitglieder.ItemsSource = DbClass.dt.DefaultView;
            DataGridLengthInitialize = GetDatagridLength(DataGridMitglieder);
            DbClass.CloseConnection();
        }

        //gibt einen Integer der Länge des Mitglieder Datagrids aus (Anzahl der Mitglieder) Verwendung in der Speichern Methode
        public static int GetDatagridLength(DataGrid datagrid_1)
        {
            try
            {
                DataRowView dataRow = (DataRowView)datagrid_1.Items.GetItemAt(0);
                return dataRow.DataView.Count;
            }
            catch
            {
                MessageBox.Show("Es sind keine Einträge vorhanden", "Info", MessageBoxButton.OK);
                return 0;
            }
        }

        //Schließt das Fenster ohne zu speichern
        private void MenuItemBeenden_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Speichert die aktuellen Werte des Datagrids in die Datenbank
        private void MenuItem_Speichern_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DbClass.OpenConnetion();
                //Schleife über alle Items, die vor dem Verändern des Datagrids schon da waren
                for (int i = 0; i < DataGridLengthInitialize; i++)
                {
                    //Lädt das aktuelle Item in eine DataRowView
                    DataRowView x = (DataRowView)DataGridMitglieder.Items.GetItemAt(i);
                    //Wohnort hinzufügen, wennn noch nicht Vorhanden
                    try
                    {
                        DbClass.sql = "INSERT INTO dbo.Wohnort VALUES('" + x.Row.ItemArray[13] + "','" + x.Row.ItemArray[12]+"');";
                        DbClass.ModSQL();
                    }
                    catch
                    {
                        break;
                    }
                    //sql Update für jedes Element der DataRowView
                    DbClass.sql = "UPDATE dbo.Mitglied " +
                   "SET Nachname = '" + x.Row.ItemArray[1].ToString() + "', " +
                   "Vorname = '" + x.Row.ItemArray[2].ToString() + "', " +
                   "Straße = '" + x.Row.ItemArray[3].ToString() + "', " +
                   "Hausnummer = '" + x.Row.ItemArray[4].ToString() + "', " +
                   "Mitglied_seit = '" + x.Row.ItemArray[5].ToString() + "', " +
                   "Geb_Datum = '" + x.Row.ItemArray[6].ToString() + "', " +
                   "Telefon = '" + x.Row.ItemArray[7].ToString() + "', " +
                   "Mobil = '" + x.Row.ItemArray[8].ToString() + "', " +
                   "E_Mail = '" + x.Row.ItemArray[9].ToString() + "', " +
                   "Mail_Eltern = '" + x.Row.ItemArray[10].ToString() + "', " +
                   "Mobil_Eltern = '" + x.Row.ItemArray[11].ToString() + "', " +
                   "WohnortID = (SELECT ID FROM dbo.Wohnort WHERE Wohnort = '" + x.Row.ItemArray[13].ToString() + "' ) " +
                   "WHERE ID = " + x.Row.ItemArray[0].ToString() + ";";

                    DbClass.ModSQL();

                }

                //Schleife über alle neu hinzugefügten Objekte im Datagrid
                for (int i = DataGridLengthInitialize; i < (DataGridMitglieder.Items.Count - 1); i++)
                {
                    //Element wird in DateRowView gespeichert
                    DataRowView x = (DataRowView)DataGridMitglieder.Items.GetItemAt(i);

                    try
                    {
                        DbClass.sql = "INSERT INTO dbo.Wohnort VALUES('" + x.Row.ItemArray[13] + "','" + x.Row.ItemArray[12] + "');";
                        DbClass.ModSQL();
                    }
                    catch
                    {
                       
                    }

                    //sql insert into für das das jeweilige Objekt
                    DbClass.sql = "INSERT INTO dbo.Mitglied (Nachname, Vorname, Straße, Hausnummer, Mitglied_seit, Geb_Datum, Telefon, Mobil, E_Mail, Mail_Eltern, Mobil_Eltern, WohnortID)" +
                        "VALUES ('" + x.Row.ItemArray[1].ToString() + "', '" + x.Row.ItemArray[2].ToString() + "', '"
                        + x.Row.ItemArray[3].ToString() + "', '" + x.Row.ItemArray[4].ToString() + "', '" + x.Row.ItemArray[5].ToString() + "', '" + x.Row.ItemArray[6].ToString() + "', '" + x.Row.ItemArray[7].ToString() + "', '"
                        + x.Row.ItemArray[8].ToString() + "', '" + x.Row.ItemArray[9].ToString() + "', '" + x.Row.ItemArray[10].ToString() + "', '" + x.Row.ItemArray[11].ToString() + "', " +
                        "(SELECT ID FROM dbo.Wohnort WHERE Wohnort = '" + x.Row.ItemArray[13].ToString() + "'));";
                    DbClass.ModSQL();

                    //Hinzufügen aller notwendigen Abhängigkeiten des neuen Mitglieds
                    DbClass.sql = "INSERT INTO dbo.Connector_Mitglied_Sparte VALUES ((SELECT TOP 1 (ID) FROM dbo.Mitglied ORDER BY ID DESC)," +
                        "(SELECT CSV.ID FROM dbo.Connector_Sparte_Verein AS CSV " +
                        "LEFT JOIN dbo.Sparte AS S ON CSV.SparteID = S.ID " +
                        "LEFT JOIN dbo.Verein AS V ON CSV.VereinID = V.ID " +
                        "WHERE S.Sparte = '" + selectedSparte + "' AND S.ID = CSV.SparteID AND CSV.VereinID=V.ID AND V.Verein='" + selectedVerein + "'),1,0);";
                    DbClass.ModSQL();

                }
                MessageBox.Show("Speichern erfolgreich!", "Gespeichert", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                DbClass.CloseConnection();
                MessageBox.Show("Speichern fehlgeschlagen bzw. Die Tabelle beinhaltet keine Einträge!" + Environment.NewLine +
                      "Descriptions: " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //Aktualisieren der Anzeige
            DbClass.sql = AnzeigeMitglieder();
            DbClass.ModSQL();
            DataGridMitglieder.ItemsSource = DbClass.dt.DefaultView;
            DataGridLengthInitialize = GetDatagridLength(DataGridMitglieder);
            DbClass.CloseConnection();

            DbClass.CloseConnection();
        }

        //Löst das Schreiben in ein Excel Dokument aus
        private void MenuItem_ExcelExport_Click(object sender, RoutedEventArgs e)
        {

            DbClass.OpenConnetion();
            //Laden der gewählten Mitglieder
            DbClass.sql = AnzeigeMitglieder();
            DbClass.ModSQL();
            //Schreiben der Mitglieder in eine DataTable
            DataTable Mitglieder = DbClass.dt;
            
            //Aktualisieren der Anzeige (Falls ungespeicherte Änderungen zur Verwirrung führen sollten)
            DataGridMitglieder.ItemsSource = DbClass.dt.DefaultView;

            DbClass.CloseConnection();
            Excelutility excelutility = new Excelutility();
            //Schreiben der Daten in ein neues Excel Sheet
            excelutility.WriteDataTableToExcel(Mitglieder, "Mitglieder_Musikverein");
        }

        //Methode verhindert, dass die ID bei Mitgiedern angezeigt wird
        private void DataGridMitglieder_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        //Hier können weitere Admins der aktuell Ausgewählten Sparte hinzugefügt werden
        private void MenuItemAdminaendern_Click(object sender, RoutedEventArgs e)
        {
            AdminVerwalten_Fenster adminVerwalten = new AdminVerwalten_Fenster();
            adminVerwalten.Show();
        }

        //Löscht den Eintrag, an dem sich der Button befindet
        private void Eintragloeschen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //ließt die Position des Buttons aus und lädt die Reihendaten in zulöschen
                DataRowView zuloeschen = ((FrameworkElement)sender).DataContext as DataRowView;
                DbClass.OpenConnetion();
                DbClass.sql = "DELETE FROM dbo.Connector_Mitglied_Sparte WHERE MitgliedID = " + zuloeschen.Row.ItemArray[0] + "; " +
                "DELETE FROM dbo.Mitglied WHERE ID = " + zuloeschen.Row.ItemArray[0] + "; ";
                DbClass.ModSQL();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Löschen fehlgeschlagen" + Environment.NewLine +
                      "Descriptions: " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //Aktualisieren der Anzeige, damit der Eintrag verschwindet
            DbClass.sql = AnzeigeMitglieder();
            DbClass.ModSQL();
            DataGridMitglieder.ItemsSource = DbClass.dt.DefaultView;
            DbClass.CloseConnection();
        }
    }

}





