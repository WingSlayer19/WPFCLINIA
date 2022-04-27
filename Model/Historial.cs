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

        public List<ViewHistorial> ConverToViewHistorial(Historial lista)
        {
            List<ViewHistorial> vistaHistorial = new List<ViewHistorial>();
            ViewHistorial historial;
            if (lista.HObstetricos != null)
            {
                foreach (var item in lista.HObstetricos)
                {
                    historial = new ViewHistorial();
                    historial.Fecha = item.Fecha;
                    historial.Medico = item.Medico;
                    historial.Tipo = "Obstetrico";
                    historial.MyUUID = item.MyUUID;
                    vistaHistorial.Add(historial);
                }
            }
            if (lista.HGinecologicos != null)
            {
                foreach (var item in lista.HGinecologicos)
                {
                    historial = new ViewHistorial();
                    historial.Fecha = item.Fecha;
                    historial.Medico = item.Medico;
                    historial.Tipo = "Ginecologico";
                    historial.MyUUID = item.MyUUID;
                    vistaHistorial.Add(historial);
                }
            }
            
            return vistaHistorial;
        }
    }

    public class HObstetrico
    {
        public HObstetrico()
        {
            Fecha = DateTime.Now.ToString();
            MyUUID = Guid.NewGuid().ToString();
        }
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
        [BsonElement("uuid")]
        public string MyUUID { get; set; }
    }

    public class HGinecologico
    {
        public HGinecologico()
        {
            Fecha = DateTime.Now.ToString();
            MyUUID = Guid.NewGuid().ToString();
        }
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
        [BsonElement("uuid")]
        public string MyUUID { get; set; }
    }

    public class Evolucion
    {
        public Evolucion()
        {
            this.MyUUID = Guid.NewGuid().ToString();
        }
        public Evolucion(string Descripcion)
        {
            this.Descripcion = Descripcion;
            this.MyUUID = Guid.NewGuid().ToString();
        }
        [BsonElement("DESCRIPCION")]
        public string Descripcion { get; set; }
        [BsonElement("FECHA")]
        public string Fecha { set; get; }
        [BsonElement("uuid")]
        public string MyUUID { get; set; }
    }

    public class SignosVitales
    {
        public SignosVitales(string W, string PresionArterial, string Fc, string Fr, string T)
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
        public string PresionArterial { get; set; }
        [BsonElement("FC")]
        public string Fc { get; set; }
        [BsonElement("FR")]
        public string Fr { get; set; }
        [BsonElement("T")]
        public string T { get; set; }
    }

    public class PlanDatos
    {
        public PlanDatos()
        {
            this.MyUUID = Guid.NewGuid().ToString();
        }
        public PlanDatos(string Descripcion)
        {
            this.Descripcion = Descripcion;
            Fecha = DateTime.Now.ToString();
            this.MyUUID = Guid.NewGuid().ToString();
        }
        [BsonElement("DESCRIPCION")]
        public string Descripcion { get; set; }
        [BsonElement("FECHA")]
        public string Fecha { set; get; }
        [BsonElement("uuid")]
        public string MyUUID { get; set; }
    }

    public class Descripciones
    {
        public Descripciones()
        {
            this.MyUUID = Guid.NewGuid().ToString();
        }
        public Descripciones(string Descripcion)
        {
            this.Descripcion = Descripcion;
            Fecha = DateTime.Now.ToString();
            this.MyUUID = Guid.NewGuid().ToString();
        }
        [BsonElement("DESCRIPCION")]
        public string Descripcion { get; set; }
        [BsonElement("FECHA")]
        public string Fecha { set; get; }
        [BsonElement("uuid")]
        public string MyUUID { get; set; }
    }

    public class ViewHistorial
    {
        public ViewHistorial()
        {
            this.MyUUID = Guid.NewGuid().ToString();
        }
        public string Tipo { get; set; } = string.Empty;
        public string Medico { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;
        public string MyUUID { get; set; } = string.Empty;
    }
}
