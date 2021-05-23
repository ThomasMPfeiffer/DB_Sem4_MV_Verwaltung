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
    /// Interaktionslogik für Sparte_hinzufuegen.xaml
    /// </summary>
    public partial class Sparte_hinzufuegen : Window
    {
        Verein_anlegen verein_Anlegen;

        public Sparte_hinzufuegen(Verein_anlegen vereinAnlegen)
        {
            InitializeComponent();
            verein_Anlegen = vereinAnlegen;
        }


        //Erstellt neue Sparte mit der Erstellenmethode aus EintraginDb
        private void Button_Hinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            string spartenbezeichnung = Textbox_Spartenbezeichnung.Text;
            string adminName = Textbox_AdminName.Text;
            EintraginDb.AddSparte(spartenbezeichnung,adminName);
            verein_Anlegen.Gridupdate();
            Close();

        }

        private void MenuItemBeenden_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
