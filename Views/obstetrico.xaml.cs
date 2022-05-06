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
    /// Lógica de interacción para obstetrico.xaml
    /// </summary>
    public partial class obstetrico : Page
    {
        private ExpedienteHandler _expediente = new ExpedienteHandler();
        public obstetrico()
        {
            InitializeComponent();
            fecha.SelectedDate = DateTime.Now;
        }

        public List<HObstetrico> ObstetricoDatos()
        {
            if (presion.Text == "")
                presion.Text = "0";
            if (FC.Text == "")
                FC.Text = "0";
            if (FR.Text == "")
                FR.Text = "0";
            if (T.Text == "")
                T.Text = "0";
            HObstetrico obst = new HObstetrico();
            obst.Medico = medico.Text;
            obst.Hora = hora.Text;
            obst.Fecha = fecha.Text;
            obst.MotivoConsulta = motivo_consultag.Text;
            obst.Evoluciones = NewEvolucion();
            obst.SignosVitales = new SignosVitales(
                W: W.Text,
                PresionArterial: (presion.Text),
                Fc: (FC.Text),
                Fr: (FR.Text),
                T: (T.Text));
            obst.NuevosDatos = NewPlanDatos(nd.Text);
            obst.Plan = NewPlanDatos(plan.Text);
            return new List<HObstetrico>() { obst };
        }

        public List<Evolucion> NewEvolucion()
        {
            Evolucion ev = new Evolucion(evolucion.Text);
            return new List<Evolucion>() { ev };
        }
        public List<PlanDatos> NewPlanDatos(string t)
        {
            PlanDatos planDatos = new PlanDatos(t);

            return new List<PlanDatos>() { planDatos };
        }

        public string IdExpediente;
        public string MyUUID;

        private void InserObstetrico(object sender, RoutedEventArgs e)
        {
            var obstetricoDatos = ObstetricoDatos();
            Historial h = new Historial
            {
                HObstetricos = obstetricoDatos
            };
            var expediente = _expediente.GetById(IdExpediente);
            if (expediente.Historial != null)
            {
                if (expediente.Historial.HObstetricos != null)
                    expediente.Historial.HObstetricos.Add(h.HObstetricos[0]);
                else
                    expediente.Historial.HObstetricos = h.HObstetricos;
            }
            else
            {
                expediente.Historial = h;
            }

            _expediente.SaveHistorial(IdExpediente, expediente);
            MessageBox.Show("Historial Registrado");
        }

        public void SetHistorial(string id, string uuid)
        {
            var exp = _expediente.GetById(id);
            var h = exp.Historial.HObstetricos.Find(x => x.MyUUID == uuid);

            medico.Text = h.Medico;
            hora.Text = h.Hora;
            if (h.Fecha != null)
                fecha.SelectedDate = DateTime.Parse(h.Fecha);
            motivo_consultag.Text = h.MotivoConsulta;
            evolucion.Text = h.Evoluciones.First().Descripcion;
            W.Text = h.SignosVitales.W;
            presion.Text = h.SignosVitales.PresionArterial.ToString();
            FC.Text = h.SignosVitales.Fc.ToString();
            FR.Text = h.SignosVitales.Fr.ToString();
            T.Text = h.SignosVitales.T.ToString();
            nd.Text = h.NuevosDatos.First().Descripcion;
            plan.Text = h.Plan.First().Descripcion;
        }

        public void DeleteHistorial(object sender, RoutedEventArgs e)
        {
            Expediente expediente = _expediente.GetById(IdExpediente);
            var hObstetricos = expediente.Historial.HObstetricos;
            var hObst = hObstetricos.FirstOrDefault(h => h.MyUUID == MyUUID);
            hObstetricos.Remove(hObst);
            expediente.Historial.HObstetricos = hObstetricos;
            _expediente.SaveHistorial(IdExpediente, expediente);
        }

        private void UpdateObstet(object sender, RoutedEventArgs e)
        {
            Expediente expediente = _expediente.GetById(IdExpediente);
            List<HObstetrico> hObste = expediente.Historial.HObstetricos;
            /*
             * Borrar
             * 
            
            HGinecologico hGineElement = hGine.FirstOrDefault(h => h.MyUUID == "e9719011-ccc6-4463-a3a6-4a21881e5db1");
            hGine.Remove(hGineElement);

            */


            if (hObste != null)
            {
                HObstetrico hObsteElement = hObste.FirstOrDefault(h => h.MyUUID == MyUUID);
                var hgine = ObstetricoDatos().FirstOrDefault();
                hObsteElement.Fecha = hgine.Fecha;
                hObsteElement.Medico = hgine.Medico;
                hObsteElement.Hora = hgine.Hora;
                hObsteElement.Evoluciones = hgine.Evoluciones;
                hObsteElement.MotivoConsulta = hgine.MotivoConsulta;
                hObsteElement.SignosVitales = hgine.SignosVitales;
                hObsteElement.NuevosDatos = hgine.NuevosDatos;
                hObsteElement.Plan = hgine.Plan;
            }
            else
            {
                hObste = new List<HObstetrico>();
                hObste.Add(new HObstetrico());
                expediente.Historial.HObstetricos = hObste;
            }

            _expediente.SaveHistorial(IdExpediente, expediente);

        }
        private Perfil _page2;
        private void Regresar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_page2);
        }
    }
}
