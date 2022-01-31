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
    /// Lógica de interacción para Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private ExpedienteHandler _expediente = new ExpedienteHandler();
        public Page1()
        {
            InitializeComponent();
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
        //    Content = new Pacientes();
        }

        private void InsertarPaciente(Object sender, RoutedEventArgs e) {
            Expediente expediente = new Expediente();
            expediente.Nombre = nombres.Text + " " + apellidos.Text;
            expediente.EstadoCivil = estado_civil.Text;
            expediente.Edad = ushort.Parse(edad.Text);
            expediente.Procedencia = procedencia.Text;
            expediente.Telefonos = ListaTel(telefono.Text);
            expediente.MotivoConsulta = motivo_consulta.Text;
            expediente.HistoriaEnfermedadActual = historia_enfermedad.Text;
            expediente.RevisionSistemas = RevisionSistemasNuevo(revision1.Text);
            expediente.Nd = NDNuevo(ND1.Text);
            expediente.Antecedentes = AntecedentesNuevos();
            expediente.GinecoObstretrico = new GinecoObstretrico(
                G: uint.Parse(g1.Text),
                P: uint.Parse(p1.Text),
                Ab: uint.Parse(ab1.Text),
                Pan: double.Parse(pan1.Text),
                Menarquia: menarquia.Text,
                Ciclos: ciclos.Text,
                Ivs: ivs1.Text,
                Ps: uint.Parse(ps.Text),
                Pap: pap1.Text,
                Ets: ets1.Text,
                C: uint.Parse(c1.Text),
                Fur: uint.Parse(fur1.Text),
                Fpp: ffp1.Text,
                Pf: pf1.Text,
                Ectopico: uint.Parse(ecto1.Text),
                Hv: hv1.Text,
                Hm: hm1.Text,
                Fup: fup1.Text);
            expediente.ExamenFisico = new ExamenFisico(
                Pa: uint.Parse(pa.Text),
                Mmhg: uint.Parse(mmgh.Text),
                Fc: uint.Parse(fc.Text),
                Fr: uint.Parse(fr.Text),
                T: uint.Parse(t.Text),
                W: w.Text,
                Talla: ushort.Parse(talla.Text),
                Imc: ushort.Parse(imc.Text));

            _expediente.SaveExpediente(expediente);
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            mx1.Text = fecha.Text;
            qx1.Text = fecha.Text;
            tx1.Text = fecha.Text;
            fam1.Text = fecha.Text;
            tox1.Text = fecha.Text;
            alg1.Text = fecha.Text;
            rh1.Text = fecha.Text;
            hiv1.Text = fecha.Text;
            vdri1.Text = fecha.Text;
            hep1.Text = fecha.Text;
            torch1.Text = fecha.Text;
        }

        private List<string> ListaTel(string tel)
        {
            return new List<string> { tel };
        }

        private Examen ExamenDatos(DatePicker tfe, TextBox tti, TextBox tfo)
        {
            return new Examen(tfe.Text, tti.Text, uint.Parse(tfo.Text));
        }

        private List<RevisionSistemas> RevisionSistemasNuevo(string t)
        {
            var r = new RevisionSistemas(t);
            return new List<RevisionSistemas> { r };
        }

        private List<ND> NDNuevo(string t)
        {
            ND r = new ND(t);
            return new List<ND> { r };
        }

        private Antecedentes AntecedentesNuevos()
        {
            var Mx = ExamenDatos(mx1, mx3, mx2);
            var Qx = ExamenDatos(qx1, qx3, qx2);
            var Tx = ExamenDatos(tx1, tx3, tx2);
            var Fam = ExamenDatos(fam1, fam3, fam2);
            var Tox = ExamenDatos(tox1, tox3, tox2);
            var Alergia = ExamenDatos(alg1, alg3, alg2);
            var RH = ExamenDatos(rh1, rh3, rh2);
            var HepB = ExamenDatos(hep1, hep3, hebp2);
            var Hiv = ExamenDatos(hiv1, hiv3, hiv2);
            var Vdri = ExamenDatos(vdri1, vdri3, vdri2);
            var Torch = ExamenDatos(torch1, torch3, torch2);
            return new Antecedentes(Mx,Qx,Tx,Fam,Tox,Alergia,RH,Hiv,Vdri,HepB,Torch);
        }
    }
}
