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


namespace MV_Mitgliederverwaltung
{
    /// <summary>
    /// Interaktionslogik für Anmeldung.xaml
    /// </summary>
    public partial class Anmeldung : Window
    {
        //Username und passwordID werden static gespeichert, für eine Verwendung z.b. Im Main_Window_Angemeldet
        public static string username;
        public static string passwordID;

        public Anmeldung()
        {
            InitializeComponent();
        }


        private void Einloggen_Click(object sender, RoutedEventArgs e)
        {
            LogginCheck();

        }

      
        // Die funtkion vergleicht Loggindaten aus den Text, bzw Passwordboxen mit den in der Datenbank abgespeicherten Loggindaten
        //Ist eine anmeldung erfolgt wird das hauptfenster geöffnet.
        private void LogginCheck()
        {
            username = TextboxAnmeldename.Text;

            DbClass.OpenConnetion();

            DbClass.sql = "SELECT Password FROM dbo.Password WHERE Username='" + username + "';";
            string dbpassword = DbClass.ReadSQL();

            DbClass.sql = "SELECT ID FROM dbo.Password WHERE Username='" + username + "';";
            passwordID = DbClass.ReadSQL();

            DbClass.CloseConnection();

            if (PasswordboxAnmeldung.Password == dbpassword)
            {
                MainWindowAngemeldet mainWindow = new MainWindowAngemeldet();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Falsches Password oder falscher Anmeldename", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void PasswordboxAnmeldung_KeyDown(object sender, KeyEventArgs e)
        {
            //Eingabe mit Enter ermöglichen
            if (e.Key == Key.Return)
            {
                LogginCheck();
            }
        }
    }
}
