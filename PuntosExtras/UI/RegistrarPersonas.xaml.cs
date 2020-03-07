using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PuntosExtras.Entidades;
using PuntosExtras.DAL;
using PuntosExtras.BLL;

namespace PuntosExtras.UI
{
    /// <summary>
    /// Interaction logic for RegistrarPersonas.xaml
    /// </summary>
    public partial class RegistrarPersonas : Window
    {
        public RegistrarPersonas()
        {
            InitializeComponent();
            PersonaIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            PersonaIdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Personas LlenarClase()
        {
            Personas persona = new Personas();
            persona.PersonasId = Convert.ToInt32(PersonaIdTextBox.Text);
            persona.Nombres = NombreTextBox.Text;

            return persona;
        }

        private void LlenarCampo(Personas persona)
        {
            PersonaIdTextBox.Text = Convert.ToString(persona.PersonasId);
            NombreTextBox.Text = persona.Nombres;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(PersonaIdTextBox.Text))
            {
                MessageBox.Show("No puede dejar el campo de persona ID vacio");
                PersonaIdTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MessageBox.Show("No puede dejar el campo de Nombres Vacio");
                NombreTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
           Personas persona = PersonasBLL.Buscar(Convert.ToInt32(PersonaIdTextBox.Text));

            return (persona != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Personas persona = new Personas();
            bool paso = false;

            if (!Validar())
                return;

            persona = LlenarClase();

            //determinar si es guardar o modificar
            if (PersonaIdTextBox.Text == "0")
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar una persona que no existe");
                    return;
                }
                paso = PersonasBLL.Modificar(persona);
            }

            //informar resurtado
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
                MessageBox.Show("No se pudo Guardar");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Personas persona = new Personas();
            int.TryParse(PersonaIdTextBox.Text, out id);

            Limpiar();

            persona = PersonasBLL.Buscar(id);

            if (persona != null)
            {
                MessageBox.Show("Persona Encontrado");
                LlenarCampo(persona);
            }
            else
                MessageBox.Show("Persona no Encontrado");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(PersonaIdTextBox.Text, out id);

            Limpiar();

            if (PersonasBLL.Eliminar(id))
            {
                MessageBox.Show("Persona Eliminado");
            }
            else
                MessageBox.Show("No se puede Eliminar un persona que no existe");
        }
    }
    }
