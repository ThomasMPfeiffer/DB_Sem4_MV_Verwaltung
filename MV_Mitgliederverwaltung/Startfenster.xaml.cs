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
    /// Interaktionslogik für Startfenster.xaml
    /// </summary>
    public partial class Startfenster : Window
    {
        public Startfenster()
        {
            InitializeComponent();
        }

        // Öffnet das Angemeldet Fenster
        private void AnmeldungButton_Click(object sender, RoutedEventArgs e)
        {
            Anmeldung Anmeldefenster = new Anmeldung();
            Anmeldefenster.Show();
        }

        //Öffnet das Fenster ohne Anmeldung
        private void OhneAnmeldung_Click(object sender, RoutedEventArgs e)
        {
            MainWindow_OhneAnmeldung HauptfensterohneAnmeldung = new MainWindow_OhneAnmeldung();
            HauptfensterohneAnmeldung.Show();
        }
    }
}
