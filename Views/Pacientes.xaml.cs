using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para Pacientes.xaml
    /// </summary>
    public partial class Pacientes : UserControl
    {
        private ExpedienteHandler _expediente = new ExpedienteHandler();
        private List<Expediente> list = new List<Expediente>();
        private void ReadAllExpedientes()
        {
            list = _expediente.GetAllExpedientes();
            var tempList = list.OrderBy(x => x.Nombre).ToList();
            ViewExpediente viewExpediente = new ViewExpediente();
            GridDatos.ItemsSource = viewExpediente.ConvertElement(tempList);
            
        }
        public Pacientes()
        {
            InitializeComponent();
            ReadAllExpedientes();
        }

        private void Consultar(object sender, RoutedEventArgs e)
        {
            var id = ((Button)sender).CommandParameter.ToString();
            Perfil perfil = new Perfil();
            perfil.IdUsuario = id;
            FramePacientes.Content = perfil;
            perfil.Consultar();
        }
        private void Agregar(object sender, RoutedEventArgs e)
        {
        //Window2 win1 = new Window2();
          //  win1.Show();
        Page1 ventana = new Page1();
            ventana.Show();
            ventana.btnPacienteCambio.Visibility = Visibility.Hidden;
            ventana.btnPacienteCambio.IsEnabled = false;
           // FramePacientes.Content = ventana;
        }

        private void RealizarBusqueda(object sender, RoutedEventArgs e)
        {
            BuscarEnLista();
        }

        private void RealizarBusquedaEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BuscarEnLista();
        }

        private void BuscarEnLista()
        {
            if (txtBuscarPaciente.Text == "")
            {
                list.Clear();
                ReadAllExpedientes();
            }
            else
            {
                try
                {
                    var lista = list.Where(x => x.Nombre.Contains(txtBuscarPaciente.Text)).ToList();

                    //Esta la agregue
                    var tempList = lista.OrderBy(x => x.Nombre).ToList();
                    ViewExpediente viewExpediente = new ViewExpediente();
                    GridDatos.ItemsSource = viewExpediente.ConvertElement(tempList);
                }
                catch (NullReferenceException)
                {

                    throw;
                }
            }
        }
        public void deleteObstet(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea elimanr el registro?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var id = ((Button)sender).CommandParameter.ToString();
                    _expediente.DeleteExpediente(id);
                    _expediente.DeleteFileByExp(id);
                    string path = "C:\\Files\\CLINICA\\" + id;
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                ReadAllExpedientes();
            }
        }

        public void updateObstet(object sender, RoutedEventArgs e)
        {

        }

    }
}
