using Galgenraten_3000.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Galgenraten_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public DasSpiel Spiel { get; set; } = new DasSpiel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            for (char c = 'a'; c <= 'z'; c++)
            {
                var bt = new Button()
                {
                    Content = c,
                    FontWeight=FontWeights.Bold,
                    FontSize=20,
                    Height=33,
                    Width=33,
                    Margin=new Thickness(5)
                };
                pTastatur.Children.Add(bt);
                bt.Click += Bt_Click;
            }

        }

        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            var bt = sender as Button;
            bt.IsEnabled = false;
            Spiel.Eingabe(bt.Content.ToString());
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
            if (Spiel.IstGewonnen)
            {
                MessageBox.Show("HERZLICHEN GLÜCKWUNSCH...");
                Neu_Click(sender, e);
            }
            else if(Spiel.IstTot)
            {
                MessageBox.Show("Du bist tot, Alter","Lösung: "+Spiel.GeheimesWort);
                Neu_Click(sender, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Ende_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Neu_Click(object sender, RoutedEventArgs e)
        {
            Spiel = new DasSpiel();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
            foreach (Button bt in pTastatur.Children)
            {
                bt.IsEnabled = true;
            }
        }

        public string BildDateiName => $@"c:\temp\maco\images\galgen-{Spiel.AnzahlFehler}.png";
    }
}
