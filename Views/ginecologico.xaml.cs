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
    /// Lógica de interacción para ginecologico.xaml
    /// </summary>
    public partial class ginecologico : Page
    {
        private ExpedienteHandler _expediente = new ExpedienteHandler();
        public string Id = String.Empty;
        public ginecologico()
        {
            InitializeComponent();
        }

        //TODO: Hacer un fucking metodo para trabajar el Gineco y demas
        public void InsertGineco()
        {
            var historialGinecologico = GinecologicoDatos();
            var exp =_expediente.GetById(Id);
            Historial h = new Historial();
            h.HGinecologicos = historialGinecologico;
            exp.Historial = h;

            _expediente.SaveHistorial(Id, exp);
        }

        public List<HGinecologico> GinecologicoDatos()
        {
            HGinecologico obst = new HGinecologico();
            obst.Medico = medico.Text;
            obst.Hora = hora.Text;
            obst.Fecha = fecha.Text;
            obst.MotivoConsulta = motivo_consultag.Text;
            obst.SignosVitales = new SignosVitales(
                W: W.Text,
                PresionArterial: uint.Parse(presion.Text),
                Fc: uint.Parse(FC.Text),
                Fr: uint.Parse(FR.Text),
                T: uint.Parse(T.Text));
            obst.Descripciones = NewDescripciones();
            obst.NuevosDatos = NewPlanDatos(nd.Text);
            obst.Plan = NewPlanDatos(plan.Text);

            return new List<HGinecologico>() { obst };
        }

        public List<Descripciones> NewDescripciones()
        {
            Descripciones desc = new Descripciones(descripcion.Text);
            
            return new List<Descripciones>() { desc };
        }

        public List<PlanDatos> NewPlanDatos(string t)
        {
            PlanDatos planDatos = new PlanDatos(t);

            return new List<PlanDatos>() { planDatos };
        }

        private void nd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
