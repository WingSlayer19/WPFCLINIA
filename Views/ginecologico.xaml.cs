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
        public ginecologico()
        {
            InitializeComponent();
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

        public string IdExpediente;
        private void InsertGineco(object sender, RoutedEventArgs e)
        {
            var historialGinecologico = GinecologicoDatos();
            Historial h = new Historial();
            h.HGinecologicos = historialGinecologico;
            var expediente = _expediente.GetById(IdExpediente);
            expediente.Historial = h;
            _expediente.SaveHistorial(IdExpediente, expediente);
        }

        private void updateObstet(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Me ejecute bb");
            Expediente expediente = _expediente.GetById(IdExpediente);
            List<HGinecologico> hGine = expediente.Historial.HGinecologicos;
            /*
             * Borrar
             * 
            
            HGinecologico hGineElement = hGine.FirstOrDefault(h => h.MyUUID == "e9719011-ccc6-4463-a3a6-4a21881e5db1");
            hGine.Remove(hGineElement);

            */

            /*
             * 
             * Actualizar
             * 
             * 
                if (hGine != null)
                {
                    HGinecologico hGineElement= hGine.FirstOrDefault(h => h.MyUUID == "e9719011-ccc6-4463-a3a6-4a21881e5db1");
                    hGineElement.Fecha = "jejejeje";
                }
                else
                {
                    hGine = new List<HGinecologico>();
                    hGine.Add(new HGinecologico());
                    expediente.Historial.HGinecologicos = hGine;
                }

            */
            _expediente.SaveHistorial(IdExpediente, expediente);

        }

        private void nd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
