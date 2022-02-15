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
        }

        public List<HObstetrico> ObstetricoDatos()
        {
            HObstetrico obst = new HObstetrico();
            obst.Medico = medico.Text;
            obst.Hora = hora.Text;
            obst.Fecha = fecha.Text;
            obst.MotivoConsulta = motivo_consultag.Text;
            obst.Evoluciones = NewEvolucion();
            obst.SignosVitales = new SignosVitales(
                W: W.Text,
                PresionArterial: uint.Parse(presion.Text),
                Fc: uint.Parse(FC.Text),
                Fr: uint.Parse(FR.Text),
                T: uint.Parse(T.Text));
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
            expediente.Historial.HObstetricos = h.HObstetricos;
            _expediente.SaveHistorial(IdExpediente, expediente);
        }

        public void SetHistorial(string id, string uuid)
        {
            var exp = _expediente.GetById(id);
            var h = exp.Historial.HObstetricos.Find(x => x.MyUUID == uuid);

            medico.Text = h.Medico;
            hora.Text = h.Hora;
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
    }
}
