﻿using System;
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
            ViewExpediente viewExpediente = new ViewExpediente();
            GridDatos.ItemsSource = viewExpediente.ConvertElement(list);
            
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
                var lista = list.Where(x => x.Nombre.Contains(txtBuscarPaciente.Text)).ToList();
                ViewExpediente viewExpediente = new ViewExpediente();
                GridDatos.ItemsSource = viewExpediente.ConvertElement(lista);
            }
        }

        public void deleteObstet(object sender, RoutedEventArgs e)
        {

        }

        public void updateObstet(object sender, RoutedEventArgs e)
        {

        }
    }
}
