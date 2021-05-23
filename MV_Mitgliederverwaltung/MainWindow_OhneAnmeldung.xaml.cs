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
    /// Interaktionslogik für MainWindow_OhneAnmeldung.xaml
    /// </summary>
    public partial class MainWindow_OhneAnmeldung : Window
    {
        public MainWindow_OhneAnmeldung()
        {
            InitializeComponent();
        }

        private void MenuItemBeenden_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Eventhandler für den Button zum Anlegen eines neuen Vereins. 
        private void Button_NeuerVerein_Click(object sender, RoutedEventArgs e)
        {
            //Öffnen des Fensters zum Anlegen eines Vereins
            Verein_anlegen verein_anlegen = new Verein_anlegen();
            verein_anlegen.Show();
        }

        //Eventhandler für den Button zum Anlegen eines neuen Users.
        private void Button_NeuerUser_Click(object sender, RoutedEventArgs e)
        {
            //Öffnen des Fensters zum Anlegen eines Users.
            NeuerUser neuerUser = new NeuerUser();
            neuerUser.Show();
        }

    }
}
