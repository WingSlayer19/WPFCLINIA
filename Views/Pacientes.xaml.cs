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
    /// Lógica de interacción para Pacientes.xaml
    /// </summary>
    public partial class Pacientes : UserControl
    {
        private ExpedienteHandler _expediente = new ExpedienteHandler();
        private void ReadAllExpedientes()
        {
            var list = _expediente.GetAllExpedientes();
            GridDatos.ItemsSource = list;
            String eso = list[0].Nombre + " " + list[0].Edad;
            MessageBox.Show(eso);
        }
        public Pacientes()
        {
            InitializeComponent();
            ReadAllExpedientes();
        }
        private void Agregar(object sender, RoutedEventArgs e)
        {
        //Window2 win1 = new Window2();
          //  win1.Show();
        Page1 ventana = new Page1();
            FramePacientes.Content = ventana;
        }


    }
}
