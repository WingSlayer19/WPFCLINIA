using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFclinica.Model
{
    internal class Expediente
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public ushort Edad { get; set; }
        public string Profesion { get; set; }
        public string Procedencia { get; set; }
        public List<String> Telefonos { get; set;}

        // No se si esto debe estar aqui
        public string MotivoConsulta { get; set; }
        public string HistoriaEnfermedadActual { get; set; }
        // ----------------------------------
        
        public List<RevisionSistemas> RevisionSistemas { get; set; }
        public List<ND> Nd { get; set; }
        public Antecedentes Antecedentes { get; set; }
        public GinecoObstretrico GinecoObstretrico { get; set; }
        public ExamenFisico ExamenFisico { get; set; }
        public Historial Historial { get; set; }
        
    }
    public class RevisionSistemas
    {
        public string Descripcion { get; set; }
        public string Fecha { set; get; }
    }
}
