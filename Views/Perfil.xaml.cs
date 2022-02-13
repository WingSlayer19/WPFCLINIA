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
using WPFclinica.Model;

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
            exp = _expediente.GetById(IdUsuario);
            if (exp != null)
            {
                nombre_paciente.Text = exp.Nombre;
                télefono_paciente.Text = String.Join("  ", exp.Telefonos);
                direccion_paciente.Text = exp.Procedencia;
                if (exp.Historial != null)
                {
                    lista = exp.Historial.ConverToViewHistorial(exp.Historial);
                    historias.ItemsSource = lista;
                }
            }
        }

        public void Ver(object sender, RoutedEventArgs e)
        {
            string uuid = ((Button)sender).CommandParameter.ToString();
            var historialItem = lista.Find(x => x.MyUUID == uuid);

            if (historialItem.Tipo == "Obstetrico")
            {
                var h = exp.Historial.HObstetricos.First(x => x.MyUUID == historialItem.MyUUID);
                ViewObste(h);
            } 
            else if (historialItem.Tipo == "Ginecologico")
            {
                 var h = exp.Historial.HGinecologicos.First(x => x.MyUUID == historialItem.MyUUID);
                 ViewGine(h);
            }
            MessageBox.Show("UUID: " + historialItem.MyUUID + ' ' + uuid);
        }

        public void updateObstet(object sender, RoutedEventArgs e)
        {

        }

        public void deleteObstet(object sender, RoutedEventArgs e)
        {

        }

        private void ViewObste(HObstetrico h)
        {
            obstetrico ventana1 = new obstetrico();
            ventana1.IdExpediente = IdUsuario;
            ventana1.MyUUID = h.MyUUID;
            ventana1.BtnSave.IsEnabled = false;
            ventana1.BtnSave.Visibility = Visibility.Collapsed;
            ventana1.SetHistorial(ventana1.IdExpediente, ventana1.MyUUID);
            FramePerfil.Content = ventana1;
        }

        private void ViewGine(HGinecologico h)
        {
            ginecologico ventana2 = new ginecologico();
            ventana2.IdExpediente = IdUsuario;
            ventana2.MyUUID = h.MyUUID;
            ventana2.BtnIng.IsEnabled = false;
            ventana2.BtnIng.Visibility = Visibility.Collapsed;
            ventana2.SetHistorial(IdUsuario, h.MyUUID);
            FramePerfil.Content = ventana2;
        }

        public string IdUsuario = string.Empty;
        private List<ViewHistorial> lista;
        private Expediente exp;
    }
}
