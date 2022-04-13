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
    public partial class Page1 : Page
    {
        private ExpedienteHandler _expediente = new ExpedienteHandler();
        public Page1()
        {
            InitializeComponent();
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
                    mx1.Text = exp.Antecedentes.Mx.Fecha;
                    mx2.Text = exp.Antecedentes.Mx.Folio.ToString();
                    mx3.Text = exp.Antecedentes.Mx.Tipo.ToString();
                }

                if (exp.Antecedentes.Qx != null)
                {
                    qx1.Text = exp.Antecedentes.Qx.Fecha;
                    qx2.Text = exp.Antecedentes.Qx.Folio.ToString();
                    qx3.Text = exp.Antecedentes.Qx.Tipo.ToString();
                }

                if (exp.Antecedentes.Tx != null)
                {
                    tx1.Text = exp.Antecedentes.Tx.Fecha;
                    tx2.Text = exp.Antecedentes.Tx.Folio.ToString();
                    tx3.Text = exp.Antecedentes.Tx.Tipo.ToString();
                }

                if (exp.Antecedentes.Fam != null)
                {
                    fam1.Text = exp.Antecedentes.Fam.Fecha;
                    fam2.Text = exp.Antecedentes.Fam.Folio.ToString();
                    fam3.Text = exp.Antecedentes.Fam.Tipo.ToString();
                }

                if (exp.Antecedentes.Tox != null)
                {
                    tox1.Text = exp.Antecedentes.Tox.Fecha;
                    tox2.Text = exp.Antecedentes.Tox.Folio.ToString();
                    tox3.Text = exp.Antecedentes.Tox.Tipo.ToString();
                }

                if (exp.Antecedentes.Alergia != null)
                {
                    alg1.Text = exp.Antecedentes.Alergia.Fecha;
                    alg2.Text = exp.Antecedentes.Alergia.Folio.ToString();
                    alg3.Text = exp.Antecedentes.Alergia.Tipo.ToString();
                }

                if (exp.Antecedentes.RH != null)
                {
                    rh1.Text = exp.Antecedentes.RH.Fecha;
                    rh2.Text = exp.Antecedentes.RH.Folio.ToString();
                    rh3.Text = exp.Antecedentes.RH.Tipo.ToString();
                }

                if (exp.Antecedentes.HepB != null)
                {
                    hep1.Text = exp.Antecedentes.HepB.Fecha;
                    hebp2.Text = exp.Antecedentes.HepB.Folio.ToString();
                    hep3.Text = exp.Antecedentes.HepB.Tipo.ToString();
                }

                if (exp.Antecedentes.Hiv != null)
                {
                    hiv1.Text = exp.Antecedentes.Hiv.Fecha;
                    hiv2.Text = exp.Antecedentes.Hiv.Folio.ToString();
                    hiv3.Text = exp.Antecedentes.Hiv.Tipo.ToString();
                }

                if (exp.Antecedentes.Vdri != null)
                {
                    vdri1.Text = exp.Antecedentes.Vdri.Fecha;
                    vdri2.Text = exp.Antecedentes.Vdri.Folio.ToString();
                    vdri3.Text = exp.Antecedentes.Vdri.Tipo.ToString();
                }

                if (exp.Antecedentes.Torch != null)
                {
                    torch1.Text = exp.Antecedentes.Torch.Fecha;
                    torch2.Text = exp.Antecedentes.Torch.Folio.ToString();
                    torch3.Text = exp.Antecedentes.Torch.Tipo.ToString();
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
                mmgh.Text = exp.ExamenFisico.Mmhg.ToString();
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
            if (mmgh.Text == "")
                mmgh.Text = "0";
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
            if (mmgh.Text == "")
                mmgh.Text = "0";
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
            MessageBox.Show("Paciente Registrado");
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
