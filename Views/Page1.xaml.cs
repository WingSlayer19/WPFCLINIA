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
    /// Lógica de interacción para Page1.xaml
    /// </summary>
    public partial class Page1 : Window
    {
        private ExpedienteHandler _expediente = new ExpedienteHandler();
        public Page1()
        {
            InitializeComponent();
            fecha.SelectedDate = DateTime.Now;
        }

        private string idPaciente;
        public void LlenarCampos(string id)
        {
            var exp = _expediente.GetById(id);
            nombres.Text = exp.Nombre;
            estado_civil.Text = exp.EstadoCivil;
            edad.Text = exp.Edad.ToString();
            procedencia.Text = exp.Procedencia;
            if (exp.Telefonos != null)
                telefono.Text = exp.Telefonos.First().ToString();
            motivo_consulta.Text = exp.MotivoConsulta;
            historia_enfermedad.Text = exp.HistoriaEnfermedadActual;
            if (exp.RevisionSistemas != null)
                revision1.Text = exp.RevisionSistemas.First().Descripcion;
            if (exp.Nd != null)
                ND1.Text = exp.Nd.First().Descripcion;
            if (exp.Antecedentes != null)
            {
                if (exp.Antecedentes.Mx != null)
                {
                    mx2.Text = exp.Antecedentes.Mx.Tipo.ToString();
                }

                if (exp.Antecedentes.Qx != null)
                {
                    qx2.Text = exp.Antecedentes.Qx.Tipo.ToString();
                }

                if (exp.Antecedentes.Tx != null)
                {
                    tx2.Text = exp.Antecedentes.Tx.Tipo.ToString();
                }

                if (exp.Antecedentes.Fam != null)
                {
                    fam2.Text = exp.Antecedentes.Fam.Tipo.ToString();
                }

                if (exp.Antecedentes.Tox != null)
                {
                    tox2.Text = exp.Antecedentes.Tox.Tipo.ToString();
                }

                if (exp.Antecedentes.Alergia != null)
                {
                    alg2.Text = exp.Antecedentes.Alergia.Tipo.ToString();
                }

                if (exp.Antecedentes.RH != null)
                {
                    rh2.Text = exp.Antecedentes.RH.Tipo.ToString();
                }

                if (exp.Antecedentes.HepB != null)
                {
                    hebp2.Text = exp.Antecedentes.HepB.Tipo.ToString();
                }

                if (exp.Antecedentes.Hiv != null)
                {
                    hiv2.Text = exp.Antecedentes.Hiv.Tipo.ToString();
                }

                if (exp.Antecedentes.Vdri != null)
                {
                    vdri2.Text = exp.Antecedentes.Vdri.Tipo.ToString();
                }

                if (exp.Antecedentes.Torch != null)
                {
                    torch2.Text = exp.Antecedentes.Torch.Tipo.ToString();
                }
            } //End if antecedentes

            if (exp.GinecoObstretrico != null)
            {
                g1.Text = exp.GinecoObstretrico.G.ToString();
                p1.Text = exp.GinecoObstretrico.P.ToString();
                ab1.Text = exp.GinecoObstretrico.Ab.ToString();
                pan1.Text = exp.GinecoObstretrico?.Pan.ToString();
                menarquia.Text = exp.GinecoObstretrico.Menarquia;
                ciclos.Text = exp.GinecoObstretrico?.Ciclos.ToString();
                ivs1.Text = exp.GinecoObstretrico.Ivs.ToString();
                ps.Text = exp.GinecoObstretrico.Ps.ToString();
                pap1.Text = exp.GinecoObstretrico.Pap.ToString();
                ets1.Text = exp.GinecoObstretrico.Ets.ToString();
                c1.Text = exp.GinecoObstretrico.C.ToString();
                fur1.Text = exp.GinecoObstretrico.Fur.ToString();
                ffp1.Text = exp.GinecoObstretrico.FPP.ToString();
                pf1.Text = exp.GinecoObstretrico.PF.ToString();
                ecto1.Text = exp.GinecoObstretrico.Ectopico.ToString();
                hv1.Text = exp.GinecoObstretrico.Hv.ToString();
                hm1.Text = exp.GinecoObstretrico.Hm.ToString();
                fup1.Text = exp.GinecoObstretrico.Fup.ToString();
            }

            if (exp.ExamenFisico != null)
            {
                pa.Text = exp.ExamenFisico.Pa.ToString();
              //  mmgh.Text = exp.ExamenFisico.Mmhg.ToString();
                fc.Text = exp.ExamenFisico.Fc.ToString();
                fr.Text = exp.ExamenFisico.Fr.ToString();
                t.Text = exp.ExamenFisico.T.ToString();
                w.Text = exp.ExamenFisico.W.ToString();
                talla.Text = exp.ExamenFisico.Talla.ToString();
                imc.Text = exp.ExamenFisico.Imc.ToString();
            }
            idPaciente = id;
        }

        private void ActualizarPaciente(object sender, RoutedEventArgs e)
        {
            if (g1.Text == "")
                g1.Text = "0";
            if (p1.Text == "")
                p1.Text = "0";
            if (ab1.Text == "")
                ab1.Text = "0";
            if (pan1.Text == "")
                pan1.Text = "0";
            if (ps.Text == "")
                ps.Text = "0";
            if (c1.Text == "")
                c1.Text = "0";
            if (fur1.Text == "")
                fur1.Text = "0";
            if (ecto1.Text == "")
                ecto1.Text = "0";
            if (pa.Text == "")
                pa.Text = "0";
         //   if (mmgh.Text == "")
           //     mmgh.Text = "0";
            if (fc.Text == "")
                fc.Text = "0";
            if (fr.Text == "")
                fr.Text = "0";
            if (t.Text == "")
                t.Text = "0";
            if (talla.Text == "")
                talla.Text = "0";
            if (imc.Text == "")
                imc.Text = "0";

            Expediente expediente = new Expediente();
            expediente.Id = new ObjectId(idPaciente);
            expediente.Nombre = nombres.Text;
            expediente.EstadoCivil = estado_civil.Text;
            expediente.Edad = (edad.Text);
            expediente.Procedencia = procedencia.Text;
            expediente.Telefonos = ListaTel(telefono.Text);
            expediente.MotivoConsulta = motivo_consulta.Text;
            expediente.HistoriaEnfermedadActual = historia_enfermedad.Text;
            expediente.RevisionSistemas = RevisionSistemasNuevo(revision1.Text);
            expediente.Nd = NDNuevo(ND1.Text);
            expediente.Antecedentes = AntecedentesNuevos();
            expediente.GinecoObstretrico = new GinecoObstretrico(
                G: (g1.Text),
                P: (p1.Text),
                Ab: (ab1.Text),
                Pan: (pan1.Text),
                Menarquia: menarquia.Text,
                Ciclos: ciclos.Text,
                Ivs: ivs1.Text,
                Ps: (ps.Text),
                Pap: pap1.Text,
                Ets: ets1.Text,
                C: (c1.Text),
                Fur: (fur1.Text),
                Fpp: ffp1.Text,
                Pf: pf1.Text,
                Ectopico: (ecto1.Text),
                Hv: hv1.Text,
                Hm: hm1.Text,
                Fup: fup1.Text);
            expediente.ExamenFisico = new ExamenFisico(
                Pa: (pa.Text),
              //  Mmhg: (mmgh.Text),
                Fc: (fc.Text),
                Fr: (fr.Text),
                T: (t.Text),
                W: w.Text,
                Talla: (talla.Text),
                Imc: (imc.Text));

            _expediente.UpdatePacienteExpe(e: expediente, id: idPaciente);
            MessageBox.Show("Paciente Cambiado");
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
        //    Content = new Pacientes();
        }

        private void InsertarPaciente(Object sender, RoutedEventArgs e) {
            if (g1.Text == "")
                g1.Text = "0";
            if (p1.Text == "")
                p1.Text = "0";
            if (ab1.Text == "")
                ab1.Text = "0";
            if (pan1.Text == "")
                pan1.Text = "0";
            if (ps.Text == "")
                ps.Text = "0";
            if (c1.Text == "")
                c1.Text = "0";
            if (fur1.Text == "")
                fur1.Text = "0";
            if (ecto1.Text == "")
                ecto1.Text = "0";
            if (pa.Text == "")
                pa.Text = "0";
          //  if (mmgh.Text == "")
            //    mmgh.Text = "0";
            if (fc.Text == "")
                fc.Text = "0";
            if (fr.Text == "")
                fr.Text = "0";
            if (t.Text == "")
                t.Text = "0";
            if (talla.Text == "")
                talla.Text = "0";
            if (imc.Text == "")
                imc.Text = "0";

            Expediente expediente = new Expediente();
            expediente.Nombre = nombres.Text;
            expediente.EstadoCivil = estado_civil.Text;
            expediente.Edad = (edad.Text);
            expediente.Procedencia = procedencia.Text;
            expediente.Telefonos = ListaTel(telefono.Text);
            expediente.MotivoConsulta = motivo_consulta.Text;
            expediente.HistoriaEnfermedadActual = historia_enfermedad.Text;
            expediente.RevisionSistemas = RevisionSistemasNuevo(revision1.Text);
            expediente.Nd = NDNuevo(ND1.Text);
            expediente.Antecedentes = AntecedentesNuevos();
            expediente.GinecoObstretrico = new GinecoObstretrico(
                G: (g1.Text),
                P: (p1.Text),
                Ab: (ab1.Text),
                Pan: (pan1.Text),
                Menarquia: menarquia.Text,
                Ciclos: ciclos.Text,
                Ivs: ivs1.Text,
                Ps: (ps.Text),
                Pap: pap1.Text,
                Ets: ets1.Text,
                C: (c1.Text),
                Fur: (fur1.Text),
                Fpp: ffp1.Text,
                Pf: pf1.Text,
                Ectopico: (ecto1.Text),
                Hv: hv1.Text,
                Hm: hm1.Text,
                Fup: fup1.Text);
            expediente.ExamenFisico = new ExamenFisico(
                Pa: (pa.Text),
              //  Mmhg: (mmgh.Text),
                Fc: (fc.Text),
                Fr: (fr.Text),
                T: (t.Text),
                W: w.Text,
                Talla: (talla.Text),
                Imc: (imc.Text));

            _expediente.SaveExpediente(expediente);
            MessageBox.Show("Paciente Registrado");
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
        }

        private List<string> ListaTel(string tel)
        {
            return new List<string> { tel };
        }

        private Examen ExamenDatos(TextBox tfo)
        {
            return new Examen(tfo.Text);
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
            if (mx2.Text == "")
                mx2.Text = "0";
            if (qx2.Text == "")
                qx2.Text = "0";
            if (tx2.Text == "")
                tx2.Text = "0";
            if (fam2.Text == "")
                fam2.Text = "0";
            if (tox2.Text == "")
                tox2.Text = "0";
            if (alg2.Text == "")
                alg2.Text = "0";
            if (rh2.Text == "")
                rh2.Text = "0";
            if (hebp2.Text == "")
                hebp2.Text = "0";
            if (hiv2.Text == "")
                hiv2.Text = "0";
            if (vdri2.Text == "")
                vdri2.Text = "0";
            if (torch2.Text == "")
                torch2.Text = "0";
            var Mx = ExamenDatos(mx2);
            var Qx = ExamenDatos(qx2);
            var Tx = ExamenDatos(tx2);
            var Fam = ExamenDatos(fam2);
            var Tox = ExamenDatos(tox2);
            var Alergia = ExamenDatos(alg2);
            var RH = ExamenDatos(rh2);
            var HepB = ExamenDatos(hebp2);
            var Hiv = ExamenDatos(hiv2);
            var Vdri = ExamenDatos(vdri2);
            var Torch = ExamenDatos(torch2);
            return new Antecedentes(Mx,Qx,Tx,Fam,Tox,Alergia,RH,Hiv,Vdri,HepB,Torch);
        }
    }
}
