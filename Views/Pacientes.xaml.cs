﻿using System;
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
    /// Lógica de interacción para Pacientes.xaml
    /// </summary>
    public partial class Pacientes : UserControl
    {
        public Pacientes()
        {
            InitializeComponent();
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
