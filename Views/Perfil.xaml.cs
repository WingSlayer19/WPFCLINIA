using MongoDB.Bson;
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
using WPFclinica.Handler;

namespace WPFclinica.Views
{
    /// <summary>
    /// Lógica de interacción para Perfil.xaml
    /// </summary>
    public partial class Perfil : Page
    {
        ExpedienteHandler _expediente = new ExpedienteHandler();
        public Perfil()
        {
            InitializeComponent();
        }

        private void BtnObs_Click(object sender, RoutedEventArgs e)
        {
            obstetrico ventana1 = new obstetrico();
            ventana1.IdExpediente = IdUsuario;
            FramePerfil.Content = ventana1;
        }

        private void Avanzar(object sender, RoutedEventArgs e)
        {
            ginecologico ventana2 = new ginecologico();
            ventana2.IdExpediente = IdUsuario;
            FramePerfil.Content = ventana2;
        }

        public void Consultar()
        {
            var exp = _expediente.GetById(IdUsuario);
            if (exp != null)
            {
                nombre_paciente.Text = exp.Nombre;
                télefono_paciente.Text = String.Join("  ", exp.Telefonos);
                direccion_paciente.Text = exp.Procedencia;
                if (exp.Historial != null)
                {
                    var lista = exp.Historial.ConverToViewHistorial(exp.Historial);
                    historias.ItemsSource = lista;
                }
            }
        }

        public void Ver(object sender, RoutedEventArgs e)
        {
            string uuid = ((Button)sender).CommandParameter.ToString();
            MessageBox.Show("UUID: " + uuid);
        }

        public string IdUsuario = string.Empty;
    }
}
