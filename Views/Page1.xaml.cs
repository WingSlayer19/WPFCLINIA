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
            expediente.Telefonos = listaTel(telefono.Text);
            expediente.MotivoConsulta = motivo_consulta.Text;
            expediente.HistoriaEnfermedadActual = historia_enfermedad.Text;
            expediente.RevisionSistemas.Add(new RevisionSistemas(revision1.Text));
            expediente.Nd.Add(new ND(ND1.Text));
            expediente.Antecedentes.Mx = ExamenDatos(mx1, mx3, mx2);
            expediente.Antecedentes.Qx = ExamenDatos(qx1, qx3, qx2);
            expediente.Antecedentes.Tx = ExamenDatos(tx1, tx3, tx2);
            expediente.Antecedentes.Fam = ExamenDatos(fam1, fam2, fam3);
            expediente.Antecedentes.Tox = ExamenDatos(tox1, tox3, tox2);
            expediente.Antecedentes.Alergia = ExamenDatos(alg1, alg2, alg3);
            expediente.Antecedentes.RH = ExamenDatos(rh1, rh2, rh3);
            expediente.Antecedentes.HepB = ExamenDatos(hep1, hep3, hebp2);
            expediente.Antecedentes.Hiv = ExamenDatos(hiv1, hiv3, hiv2);
            expediente.Antecedentes.Vdri = ExamenDatos(vdri1, vdri3, vdri2);
            expediente.Antecedentes.Torch = ExamenDatos(torch1, torch2, torch3);
            expediente.GinecoObstretrico = new GinecoObstretrico(
                G: uint.Parse(g1.Text),
                P: uint.Parse(p1.Text),
                Ab: uint.Parse(ab1.Text),
                Pan: uint.Parse(pan1.Text),
                Menarquia: menarquia.Text,
                Ciclos: ciclos.Text,
                Ivs: ivs1.Text,
                Ps: uint.Parse(ps.Text),
                Pap: pap1.Text,
                Ets: ets1.Text,
                C: uint.Parse(c1.Text),
                Fur: uint.Parse(fur1.Text),
                Fpp: ffp1.Text,
                Pf: pf1.Text);
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

        private List<string> listaTel(string tel)
        {
            return new List<string> { tel };
        }

        private Examen ExamenDatos(DatePicker tfe, TextBox tfo, TextBox tti)
        {
            return new Examen(tfe.Text, tti.Text, uint.Parse(tfo.Text));
        }
    }
}
