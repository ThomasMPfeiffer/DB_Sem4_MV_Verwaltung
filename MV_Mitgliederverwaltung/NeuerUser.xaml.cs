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
    /// Interaktionslogik für NeuerUser.xaml
    /// </summary>
    public partial class NeuerUser : Window
    {
        public NeuerUser()
        {
            InitializeComponent();
        }


        private void Beenden_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Erstellt den neuen User mit der Erstellenmethode aus EintraginDb
        private void Button_Erstellen_Click(object sender, RoutedEventArgs e)
        {
            string username = Textbox_Nutzername.Text;
            string pw1 = PasswordBox_ersteEingabe.Password;
            string pw2 = PasswordBox_zweiteEingabe.Password;
            if (pw1 == pw2)
            {
                EintraginDb.AddUser(username, pw1);
                Close();
            }
            else
            {
                MessageBox.Show("Die Passwörter stimmen nicht überein!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
    }
}
