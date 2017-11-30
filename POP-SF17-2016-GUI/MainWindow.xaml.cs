using POP_SF39_2016.model;
using POP_SF39_2016_GUI.ui;
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

namespace POP_SF39_2016_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbNamestaj.Items.Clear();

            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if(namestaj.Obrisan == false)
                    lbNamestaj.Items.Add(namestaj);

            }
            lbNamestaj.SelectedIndex = 0;
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }


        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };

            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {

            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;

            var namestajProzor = new NamestajWindow(izabraniNamestaj, NamestajWindow.Operacija.IZMENA);
            namestajProzor.ShowDialog();
        }
        private void ObrisiNamestaj(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;

            List<Namestaj> ListaNamestaja = Projekat.Instance.Namestaj;
            MessageBoxResult r = MessageBox.Show("title", "da li ste sigurni?", MessageBoxButton.YesNo);
            if (r==MessageBoxResult.Yes)
            {
                foreach(Namestaj namestaj in ListaNamestaja)
                    if(namestaj.Id==izabraniNamestaj.Id)
                        namestaj.Obrisan = true;
                Projekat.Instance.Namestaj = ListaNamestaja;
            };
            
        }
        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            var namestajZaBrisanje = (Namestaj)lbNamestaj.Namestaj.SelectedItem;

            if(MessageBox.Show(
                $"Dali ste sigurni da zelite da izbrisete namestaj: {namestajZaBrisanje.Naziv }?",
                "Brisanje namestaja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.Namestaj;

                foreach (var namestaj in lista)
                {
                    namestaj.Obrisan = true;
                }
                
            }
            Projekat.Instance.Namestaj = lista

        }
    }
}
