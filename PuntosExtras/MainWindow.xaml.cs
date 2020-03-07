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
using PuntosExtras.UI;

namespace PuntosExtras
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistrarButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrarPersonas RP = new RegistrarPersonas();
            RP.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConsultarPersonas CP = new ConsultarPersonas();
            CP.Show();
        }
    }
}
