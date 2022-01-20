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
            FramePerfil.Content = ventana1;
        }

        private void Avanzar(object sender, RoutedEventArgs e)
        {
            ginecologico ventana2 = new ginecologico();
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
                if (exp.Historial.HObstetricos != null || exp.Historial.HGinecologicos != null)
                {
                    lista = exp.Historial.ConverToViewHistorial(exp.Historial);
                    historias.ItemsSource = lista;
                }
            }
        }

        public void ConsultarContenido(object sender, RoutedEventArgs e)
        {
            var pos = ((Button)sender).CommandParameter.ToString();
            string clave = pos.Substring(pos.Length - 1);
            string valor = pos.Substring(0, pos.Length - 1);
            HGinecologico hGinecologico = new HGinecologico();
            HObstetrico hObstetrico = new HObstetrico();
            if (clave == "G")
            {
                hGinecologico = exp.Historial.HGinecologicos[Convert.ToInt32(valor)];
                VisualizarHistorial(hGinecologico);
            }
            else
            {
                hObstetrico = exp.Historial.HObstetricos[Convert.ToInt32(valor)];
                VisualizarHistorial(hObstetrico);
            }
        }

        public void VisualizarHistorial(HGinecologico h)
        {
            ginecologico ventana2 = new ginecologico();
            ventana2.medico.Text = h.Medico;
            ventana2.hora.Text = h.Hora;
            ventana2.fecha.Text = h.Fecha;
            ventana2.fecha.SelectedDate = DateTime.Parse(h.Fecha);
            ventana2.motivo_consultag.Text = h.MotivoConsulta;
            ventana2.W.Text = h.SignosVitales.W;
            ventana2.presion.Text = h.SignosVitales.PresionArterial.ToString();
            ventana2.FC.Text = h.SignosVitales.Fc.ToString();
            ventana2.FR.Text = h.SignosVitales.Fr.ToString();
            ventana2.T.Text = h.SignosVitales.T.ToString();
            ventana2.descripcion.Text = DescripcionHistorial(h.Descripciones);
            ventana2.nd.Text = PlanNuevosDatosHistorial(h.NuevosDatos);
            ventana2.plan.Text = PlanNuevosDatosHistorial(h.Plan);
            FramePerfil.Content = ventana2;
        }
        public void VisualizarHistorial(HObstetrico h)
        {
            obstetrico ventana1 = new obstetrico();
            ventana1.medico.Text = h.Medico;
            ventana1.hora.Text = h.Hora;
            ventana1.fecha.Text = h.Fecha;
            ventana1.fecha.SelectedDate = DateTime.Parse(h.Fecha);
            ventana1.motivo_consultag.Text = h.MotivoConsulta;
            ventana1.evolucion.Text = EvolucionHistorial(h.Evoluciones);
            ventana1.W.Text = h.SignosVitales.W;
            ventana1.presion.Text = h.SignosVitales.PresionArterial.ToString();
            ventana1.FC.Text = h.SignosVitales.Fc.ToString();
            ventana1.FR.Text = h.SignosVitales.Fr.ToString();
            ventana1.T.Text = h.SignosVitales.T.ToString();
            ventana1.nd.Text = PlanNuevosDatosHistorial(h.NuevosDatos);
            ventana1.plan.Text = PlanNuevosDatosHistorial(h.Plan);
            FramePerfil.Content = ventana1;
        }

        private string DescripcionHistorial(List<Descripciones> desc)
        {
            List<string> list = new List<string>();
            foreach (var d in desc)
            {
                list.Add(d.Descripcion + "\n");
            }

            return String.Join(" ", list);
        }

        private string PlanNuevosDatosHistorial(List<PlanDatos> pld)
        {
            List<string> list = new List<string>();
            foreach (var d in pld)
            {
                list.Add(d.Descripcion + "\n");
            }

            return String.Join(" ", list);
        }

        private string EvolucionHistorial(List<Evolucion> pld)
        {
            List<string> list = new List<string>();
            foreach (var d in pld)
            {
                list.Add(d.Descripcion + "\n");
            }

            return String.Join(" ", list);
        }

        public string IdUsuario = string.Empty;
        private List<ViewHistorial> lista;
        private Expediente exp;
    }
}
