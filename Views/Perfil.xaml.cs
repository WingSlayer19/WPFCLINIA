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

<<<<<<< HEAD
        private void BtnObs_Click(object sender, RoutedEventArgs e)
        {
            obstetrico ventana1 = new obstetrico();
            FramePerfil.Content = ventana1;
        }

        private void Avanzar(object sender, RoutedEventArgs e)
        {
            ginecologico ventana2 = new ginecologico();
            FramePerfil.Content = ventana2;
        }
=======
        public void Consultar()
        {
            MessageBox.Show("Tuhermana " + IdUsuario);
            ObjectId id = new ObjectId(IdUsuario);
            var exp = _expediente.GetById(id);
            if (exp != null)
            {
                nombre_paciente.Text = exp.Nombre;
                télefono_paciente.Text = String.Join("  ", exp.Telefonos);
                direccion_paciente.Text = exp.Procedencia;
                if (exp.Historial.HObstetricos != null || exp.Historial.HGinecologicos != null)
                {
                    var lista = exp.Historial.ConverToViewHistorial(exp.Historial);
                    historias.ItemsSource = lista;
                }
            }
        }

        public string IdUsuario = string.Empty;
>>>>>>> b933c48be7cafd74120891bf9b2fdd5d04dc60e9
    }
}
