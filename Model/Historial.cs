using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFclinica.Model
{
    internal class Historial
    {
        [BsonElement("H_OBSTETRICO")]
        public List<HObstetrico> HObstetricos { get; set; }
        [BsonElement("H_GINECOLOGICO")]
        public List<HGinecologico> HGinecologicos { get; set; }
    }

    public class HObstetrico
    {
        [BsonElement("FECHA")]
        public string Fecha { get; set; }
        [BsonElement("MEDICO")]
        public string Medico { get; set; }
        [BsonElement("HORA")]
        public string Hora { get; set; }
        [BsonElement("EVOLUCION")]
        public List<Evolucion> Evoluciones { get; set; }
        [BsonElement("MOTIVO_CONSULTA")]
        public string MotivoConsulta { get; set; }
        [BsonElement("SIGNOS_VITALES")]
        public SignosVitales SignosVitales { get; set; }
        [BsonElement("Nuevos_datos")]
        public List<PlanDatos> NuevosDatos { get; set; }
        [BsonElement("Plan")]
        public List<PlanDatos> Plan { get; set; }
    }

    public class HGinecologico
    {
        [BsonElement("FECHA")]
        public string Fecha { get; set; }
        [BsonElement("MEDICO")]
        public string Medico { get; set; }
        [BsonElement("HORA")]
        public string Hora { get; set; }
        [BsonElement("MOTIVO_CONSULTA")]
        public string MotivoConsulta { get; set; }
        [BsonElement("SIGNOS_VITALES")]
        public SignosVitales SignosVitales { get; set; }
        [BsonElement("Nuevos_datos")]
        public List<PlanDatos> NuevosDatos { get; set; }
        [BsonElement("Plan")]
        public List<PlanDatos> Plan { get; set; }
        [BsonElement("DESCRIPCION")]
        public List<Descripciones> Descripciones { get; set; }
    }

    public class Evolucion
    {
        [BsonElement("DESCRIPCION")]
        public string Descripcion { get; set; }
        [BsonElement("FECHA")]
        public string Fecha { set; get; }
    }

    public class SignosVitales
    {
        public SignosVitales(string W, uint PresionArterial, uint Fc, uint Fr, uint T)
        {
            this.W = W;
            this.Fr = Fr;
            this.T = T;
            this.Fc = Fc;
            this.PresionArterial = PresionArterial;
        }
        [BsonElement("W")]
        public string W { get; set; }
        [BsonElement("PRESION_ARTERIAL")]
        public uint PresionArterial { get; set; }
        [BsonElement("FC")]
        public uint Fc { get; set; }
        [BsonElement("FR")]
        public uint Fr { get; set; }
        [BsonElement("T")]
        public uint T { get; set; }
    }

    public class PlanDatos
    {
        public PlanDatos()
        {

        }
        public PlanDatos(string Descripcion)
        {
            this.Descripcion = Descripcion;
            Fecha = DateTime.Now.ToString();
        }
        [BsonElement("DESCRIPCION")]
        public string Descripcion { get; set; }
        [BsonElement("FECHA")]
        public string Fecha { set; get; }
    }

    public class Descripciones
    {
        public Descripciones()
        {

        }
        public Descripciones(string Descripcion)
        {
            this.Descripcion = Descripcion;
            Fecha = DateTime.Now.ToString();
        }
        [BsonElement("DESCRIPCION")]
        public string Descripcion { get; set; }
        [BsonElement("FECHA")]
        public string Fecha { set; get; }
    }
}
