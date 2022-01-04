using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFclinica.Model
{
    internal class Historial
    {
        public List<HObstetrico> HObstetricos { get; set; }
        public List<HGinecologico> HGinecologicos { get; set; }
    }

    public class HObstetrico
    {
        public string Fecha { get; set; }
        public string Medico { get; set; }
        public string Hora { get; set; }
        public List<Evolucion> Evoluciones { get; set; }
        public string MotivoConsulta { get; set; }
        public SignosVitales SignosVitales { get; set; }
        public List<PlanDatos> NuevosDatos { get; set; }
        public List<PlanDatos> Plan { get; set; }
    }

    public class HGinecologico
    {
        public string Fecha { get; set; }
        public string Medico { get; set; }
        public string Hora { get; set; }
        public string MotivoConsulta { get; set; }
        public SignosVitales SignosVitales { get; set; }
        public List<PlanDatos> NuevosDatos { get; set; }
        public List<PlanDatos> Plan { get; set; }
        public List<Descripciones> Descripciones { get; set; }
    }

    public class Evolucion
    {
        public string Descripcion { get; set; }
        public string Fecha { set; get; }
    }

    public class SignosVitales
    {
        public string W { get; set; }
        public uint PresionArterial { get; set; }
        public uint Fc { get; set; }
        public uint Fr { get; set; }
        public uint T { get; set; }
    }

    public class PlanDatos
    {
        public string Descripcion { get; set; }
        public string Fecha { set; get; }
    }

    public class Descripciones
    {
        public string Descripcion { get; set; }
        public string Fecha { set; get; }
    }
}
