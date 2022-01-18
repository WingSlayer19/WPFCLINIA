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

        public void InserObstetrico()
        {
            var obstetricoDatos = ObstetricoDatos();
            var expediente = _expediente.GetById(IdExpediente);
            expediente.Historial.HObstetricos = obstetricoDatos;
            _expediente.SaveHistorial(IdExpediente, expediente);
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
    }
}
