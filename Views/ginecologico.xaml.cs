using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class ginecologico : Window
    {

        private ExpedienteHandler _expediente = new ExpedienteHandler();
        public ginecologico()
        {
            InitializeComponent();
            fecha.SelectedDate = DateTime.Now;
        }

        public List<HGinecologico> GinecologicoDatos()
        {
            if (presion.Text == "")
                presion.Text = "0";
            if (FC.Text == "")
                FC.Text = "0";
            if (FR.Text == "")
                FR.Text = "0";
            if (T.Text == "")
                T.Text = "0";
            HGinecologico obst = new HGinecologico();
            obst.Medico = medico.Text;
            obst.Hora = hora.Text;
            obst.Fecha = fecha.Text;
            obst.MotivoConsulta = motivo_consultag.Text;
            obst.SignosVitales = new SignosVitales(
                W: W.Text,
                PresionArterial: (presion.Text),
                Fc: (FC.Text),
                Fr: (FR.Text),
                T: (T.Text));
            obst.Descripciones = NewDescripciones();
            obst.NuevosDatos = NewPlanDatos(nd.Text);
            obst.Plan = NewPlanDatos(plan.Text);
            obst.HistoriaEnfermedadActual = actual.Text;

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
            Historial h = new Historial
            {
                HGinecologicos = historialGinecologico
            };
            var expediente = _expediente.GetById(IdExpediente);
            if (expediente.Historial != null)
            {
                if (expediente.Historial.HGinecologicos != null)
                    expediente.Historial.HGinecologicos.Add(h.HGinecologicos[0]);
                else
                    expediente.Historial.HGinecologicos = h.HGinecologicos;
            } else
                expediente.Historial = h;
           
            _expediente.SaveHistorial(IdExpediente, expediente);
            MessageBox.Show("Historial Registrado");
        }

        public void SetHistorial(string id, string uuid)
        {
            var exp = _expediente.GetById(id);
            var h = exp.Historial.HGinecologicos.Find(x => x.MyUUID == uuid);

            medico.Text = h.Medico;
            hora.Text = h.Hora;
            if (!string.IsNullOrEmpty(h.Fecha))
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
            if (!string.IsNullOrEmpty(h.HistoriaEnfermedadActual))
                actual.Text = h.HistoriaEnfermedadActual.ToString();
        }

        private void UpdateGine(object sender, RoutedEventArgs e)
        {
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
                hGineElement.HistoriaEnfermedadActual = hgine.HistoriaEnfermedadActual;
            }
            else
            {
                hGine = new List<HGinecologico>();
                hGine.Add(new HGinecologico());
                expediente.Historial.HGinecologicos = hGine;
            }
         
            _expediente.SaveHistorial(IdExpediente, expediente);
            MessageBox.Show("Historial Registrado");
        }

        private void DeleteHistorial(object sender, RoutedEventArgs e)
        {
            Expediente expediente = _expediente.GetById(IdExpediente);
            var hGinecologicos = expediente.Historial.HGinecologicos;
            var hGine = hGinecologicos.FirstOrDefault(h => h.MyUUID == MyUUID);
            hGinecologicos.Remove(hGine);
            expediente.Historial.HGinecologicos = hGinecologicos;
            _expediente.SaveHistorial(IdExpediente, expediente);
            MessageBox.Show("Historial Borrado");
        }

        private void nd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private Perfil _page1;
        private void Regresar(object sender, RoutedEventArgs e)
        {
           // NavigationService.Navigate(_page1);
        }
    }
}
