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
using System.Data;

namespace MV_Mitgliederverwaltung
{
    /// <summary>
    /// Interaktionslogik für AdminVerwalten_Fenster.xaml
    /// </summary>
    public partial class AdminVerwalten_Fenster : Window
    {
        public AdminVerwalten_Fenster()
        {
            InitializeComponent();
        }
        private int DataGridLengthInitialize;

        private void MenuItem_Speichern_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DbClass.OpenConnetion();
                //Schleife über alle Items, die vor dem Verändern des Datagrids schon da waren
                for (int i = 0; i < DataGridLengthInitialize; i++)
                {
                    //Lädt das aktuelle Item in eine DataRowView
                    DataRowView x = (DataRowView)DataGridAdmin.Items.GetItemAt(i);

                    //sql Update für jedes Element der DataRowView
                    DbClass.sql = "UPDATE dbo.Admin__Connector_Sparte_PW " +
                        "SET PasswordID=Pw.ID " +
                        "FROM dbo.Admin__Connector_Sparte_PW AS Adm " +
                        "LEFT JOIN dbo.Password AS Pw ON Adm.PasswordID=Pw.Id " +
                        "LEFT JOIN dbo.Connector_Sparte_Verein AS CSV ON Adm.Connector_Sparte_Verein_ID=CSV.ID " +
                        "LEFT JOIN dbo.Verein AS V ON CSV.VereinID = V.ID " +
                        "LEFT JOIN dbo.Sparte AS S ON CSV.SparteID=S.ID " +
                        "WHERE S.Sparte = '"+MainWindowAngemeldet.selectedSparte+"' AND V.Verein = '"+MainWindowAngemeldet.selectedVerein+"' AND PW.Username = '"+x.Row.ItemArray[0]+"';";
                    DbClass.ModSQL();

                }

                //Schleife über alle neu hinzugefügten Objekte im Datagrid
                for (int i = DataGridLengthInitialize; i < (DataGridAdmin.Items.Count - 1); i++)
                {
                    //Element wird in DateRowView gespeichert
                    DataRowView x = (DataRowView)DataGridAdmin.Items.GetItemAt(i);

                    //sql insert into für das das jeweilige Objekt
                    DbClass.sql = "INSERT INTO dbo.Admin__Connector_Sparte_PW(Connector_Sparte_Verein_ID, Admin, PasswordID) " +
                        "SELECT CSV.ID,1, PW.ID " +
                        "FROM dbo.Sparte AS S " +
                        "INNER JOIN dbo.Connector_Sparte_Verein as CSV ON S.ID = CSV.SparteID " +
                        "INNER JOIN Verein AS V ON V.ID = CSV.VereinID ,dbo.Password as PW " +
                        "WHERE S.Sparte = '" + MainWindowAngemeldet.selectedSparte + "' AND V.Verein = '" + MainWindowAngemeldet.selectedVerein + "' AND PW.Username = '" + x.Row.ItemArray[0] + "';";
                    DbClass.ModSQL();


                }
                MessageBox.Show("Speichern erfolgreich!", "Gespeichert", MessageBoxButton.OK);
            }

            catch (Exception ex)
            {
                DbClass.CloseConnection();
                MessageBox.Show("Speichern fehlgeschlagen. Stellen Sie sicher, dass der User, der Admin sein soll existiert!" + Environment.NewLine +
                      "Descriptions: " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //Aktualisieren der Anzeige
            DbClass.sql = "SELECT Username FROM Password AS PW " +
                "LEFT JOIN dbo.Admin__Connector_Sparte_PW AS Adm ON PW.ID = Adm.PasswordID " +
                "LEFT JOIN dbo.Connector_Sparte_Verein AS CSV ON Adm.Connector_Sparte_Verein_ID = CSV.ID " +
                "LEFT JOIN dbo.Verein AS V ON CSV.VereinID = V.ID " +
                "LEFT JOIN dbo.Sparte AS S ON CSV.SparteID = S.ID " +
                "WHERE PW.ID=Adm.PasswordID AND Admin=1 AND Adm.Connector_Sparte_Verein_ID=CSV.ID AND CSV.SparteID = S.ID AND S.Sparte='" + MainWindowAngemeldet.selectedSparte + "' AND CSV.VereinID=V.ID AND V.Verein='" + MainWindowAngemeldet.selectedVerein + "'";
            DbClass.ModSQL();
            DataGridAdmin.ItemsSource = DbClass.dt.DefaultView;
            DbClass.CloseConnection();

            DbClass.CloseConnection();
        }

        private void MenuItemBeenden_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DbClass.OpenConnetion();
            //Laden der Admins der aktuell ausgewählten Sparte
            DbClass.sql = "SELECT Username FROM Password AS PW " +
                "LEFT JOIN dbo.Admin__Connector_Sparte_PW AS Adm ON PW.ID = Adm.PasswordID " +
                "LEFT JOIN dbo.Connector_Sparte_Verein AS CSV ON Adm.Connector_Sparte_Verein_ID = CSV.ID " +
                "LEFT JOIN dbo.Verein AS V ON CSV.VereinID = V.ID " +
                "LEFT JOIN dbo.Sparte AS S ON CSV.SparteID = S.ID " +
                "WHERE PW.ID=Adm.PasswordID AND Admin=1 AND Adm.Connector_Sparte_Verein_ID=CSV.ID AND CSV.SparteID = S.ID AND S.Sparte='" + MainWindowAngemeldet.selectedSparte + "' AND CSV.VereinID=V.ID AND V.Verein='" + MainWindowAngemeldet.selectedVerein + "'";
            DbClass.ModSQL();
            //Die Admins werden in ein Datagrid gespeichert
            DataGridAdmin.ItemsSource = DbClass.dt.DefaultView;
            DataGridLengthInitialize = MainWindowAngemeldet.GetDatagridLength(DataGridAdmin);
            if (DataGridLengthInitialize == 0)
            {
                MessageBox.Show("Bitte zunächst eine Sparte auswählen!");
            }
            DbClass.CloseConnection();
        }

        private void Eintragloeschen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //ließt die Position des Buttons aus und lädt die Reihendaten in zulöschen
                DataRowView zuloeschen = ((FrameworkElement)sender).DataContext as DataRowView;
                DbClass.OpenConnetion();
                DbClass.sql = "UPDATE dbo.Admin__Connector_Sparte_PW " +
                    "SET Admin = 0 " +
                    "FROM dbo.Admin__Connector_Sparte_PW " +
                    "LEFT JOIN dbo.Password AS PW ON PW.ID = Admin__Connector_Sparte_PW.PasswordID " +
                    "LEFT JOIN dbo.Connector_Sparte_Verein AS CSV ON CSV.ID = Admin__Connector_Sparte_PW.Connector_Sparte_Verein_ID " +
                    "LEFT JOIN dbo.Sparte AS S ON S.ID = CSV.SparteID " +
                    "LEFT JOIN dbo.Verein AS V ON V.ID = CSV.VereinID " +
                    "WHERE Admin__Connector_Sparte_PW.PasswordID = PW.ID AND PW.Username = '" + Anmeldung.username + "' AND Admin__Connector_Sparte_PW.Connector_Sparte_Verein_ID = CSV.ID AND CSV.SparteID = S.ID AND S.Sparte = '" + MainWindowAngemeldet.selectedSparte + "' AND CSV.VereinID = V.ID AND V.Verein = '" + MainWindowAngemeldet.selectedVerein + "'; ";
                DbClass.ModSQL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Löschen fehlgeschlagen" + Environment.NewLine +
                      "Descriptions: " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //Aktualisieren der Anzeige, damit der Eintrag verschwindet
            DbClass.sql = DbClass.sql = "SELECT Username FROM Password AS PW " +
                "LEFT JOIN dbo.Admin__Connector_Sparte_PW AS Adm ON PW.ID = Adm.PasswordID " +
                "LEFT JOIN dbo.Connector_Sparte_Verein AS CSV ON Adm.Connector_Sparte_Verein_ID = CSV.ID " +
                "LEFT JOIN dbo.Verein AS V ON CSV.VereinID = V.ID " +
                "LEFT JOIN dbo.Sparte AS S ON CSV.SparteID = S.ID " +
                "WHERE PW.ID=Adm.PasswordID AND Admin=1 AND Adm.Connector_Sparte_Verein_ID=CSV.ID AND CSV.SparteID = S.ID AND S.Sparte='" + MainWindowAngemeldet.selectedSparte + "' AND CSV.VereinID=V.ID AND V.Verein='" + MainWindowAngemeldet.selectedVerein + "'";
            DbClass.ModSQL();
            DataGridAdmin.ItemsSource = DbClass.dt.DefaultView;
            DbClass.CloseConnection();
        }
    }
}
