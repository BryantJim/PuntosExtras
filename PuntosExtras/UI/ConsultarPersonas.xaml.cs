using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PuntosExtras.BLL;
using PuntosExtras.Entidades;

namespace PuntosExtras.UI
{
    /// <summary>
    /// Interaction logic for ConsultarPersonas.xaml
    /// </summary>
    public partial class ConsultarPersonas : Window
    {
        public ConsultarPersonas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Personas>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    //todo
                    case 0:
                        listado = PersonasBLL.GetList(p => true);
                        break;
                    //Id
                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = PersonasBLL.GetList(p => p.PersonasId == id);
                        break;
                    //Nombre
                    case 2:
                        listado = PersonasBLL.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;
                }

            }
            else
            {
                listado = PersonasBLL.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = listado;
        }
    }
}
