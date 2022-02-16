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
        public string MyUUID;
        private void InsertGineco(object sender, RoutedEventArgs e)
        {
            var historialGinecologico = GinecologicoDatos();
            Historial h = new Historial();
            h.HGinecologicos = historialGinecologico;
            var expediente = _expediente.GetById(IdExpediente);
            expediente.Historial.HGinecologicos = h.HGinecologicos;
            _expediente.SaveHistorial(IdExpediente, expediente);
        }

        public void SetHistorial(string id, string uuid)
        {
            var exp = _expediente.GetById(id);
            var h = exp.Historial.HGinecologicos.Find(x => x.MyUUID == uuid);

            medico.Text = h.Medico;
            hora.Text = h.Hora;
            fecha.SelectedDate = DateTime.Parse(h.Fecha);
            motivo_consultag.Text = h.MotivoConsulta;
            W.Text = h.SignosVitales.W;
            presion.Text = h.SignosVitales.PresionArterial.ToString();
            FC.Text = h.SignosVitales.Fc.ToString();
            FR.Text = h.SignosVitales.Fr.ToString();
            T.Text = h.SignosVitales.T.ToString();
            descripcion.Text = h.Descripciones.First().Descripcion;
            nd.Text = h.NuevosDatos.First().Descripcion;
            plan.Text = h.Plan.First().Descripcion;
        }

        private void UpdateGine(object sender, RoutedEventArgs e)
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


            if (hGine != null)
            {
                HGinecologico hGineElement= hGine.FirstOrDefault(h => h.MyUUID == MyUUID);
                var hgine = GinecologicoDatos().FirstOrDefault();
                hGineElement.Fecha = hgine.Fecha;
                hGineElement.Medico = hgine.Medico;
                hGineElement.Hora = hgine.Hora;
                hGineElement.MotivoConsulta = hgine.MotivoConsulta;
                hGineElement.SignosVitales = hgine.SignosVitales;
                hGineElement.Descripciones = hgine.Descripciones;
                hGineElement.NuevosDatos = hgine.NuevosDatos;
                hGineElement.Plan = hgine.Plan;
            }
            else
            {
                hGine = new List<HGinecologico>();
                hGine.Add(new HGinecologico());
                expediente.Historial.HGinecologicos = hGine;
            }
         
            _expediente.SaveHistorial(IdExpediente, expediente);

        }

        private void DeleteHistorial(object sender, RoutedEventArgs e)
        {
            Expediente expediente = _expediente.GetById(IdExpediente);
            var hGinecologicos = expediente.Historial.HGinecologicos;
            var hGine = hGinecologicos.FirstOrDefault(h => h.MyUUID == MyUUID);
            hGinecologicos.Remove(hGine);
            expediente.Historial.HGinecologicos = hGinecologicos;
            _expediente.SaveHistorial(IdExpediente, expediente);
        }

        private void nd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
