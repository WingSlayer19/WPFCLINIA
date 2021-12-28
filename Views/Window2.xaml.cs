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
using System.Windows.Shapes;

namespace WPFclinica.Views
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
       
        public Window2()
        {
         
            InitializeComponent();
        }

        private void Guardar(object sender, RoutedEventArgs e)
        {
            
        }
        // protected override void OnStateChanged(EventArgs e)
        // {
        //   if (WindowState == WindowState.Maximized && !_inStateChange)
        //  {
        //    _inStateChange = true;
        //   WindowState = WindowState.Normal;
        //  WindowStyle = WindowStyle.None;
        //  WindowState = WindowState.Maximized;
        //   ResizeMode = ResizeMode.NoResize;
        //  _inStateChange = false;
        // }
        // base.OnStateChanged(e);
        // }

    }
}
