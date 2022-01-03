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
    /// Lógica de interacción para Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
        //    Content = new Pacientes();
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            mx1.Text = fecha.Text;
            qx1.Text = fecha.Text;
            tx1.Text = fecha.Text;
            fam1.Text = fecha.Text;
            tox1.Text = fecha.Text;
            alg1.Text = fecha.Text;
            rh1.Text = fecha.Text;
            hiv1.Text = fecha.Text;
            vdri1.Text = fecha.Text;
            hep1.Text = fecha.Text;
            torch1.Text = fecha.Text;
        }
    }
}
