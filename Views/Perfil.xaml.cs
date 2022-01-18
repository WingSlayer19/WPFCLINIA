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

namespace WPFclinica.Views
{
    /// <summary>
    /// Lógica de interacción para Perfil.xaml
    /// </summary>
    public partial class Perfil : Page
    {
        public Perfil()
        {
            InitializeComponent();
        }

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
    }
}
