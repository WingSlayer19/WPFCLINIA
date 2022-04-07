using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WPFclinica.Model
{
    internal class Expediente
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Image")]
        public byte[] Image { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("ESTADO_CIVIL")]
        public string EstadoCivil { get; set; }

        [BsonElement("EDAD")]
        public ushort Edad { get; set; }

        [BsonElement("PROFESION")]
        public string Profesion { get; set; }

        [BsonElement("PROCEDENCIA")]
        public string Procedencia { get; set; }

        [BsonElement("TELEFONO")]
        public List<String> Telefonos { get; set;}

        // No se si esto debe estar aqui
        [BsonElement("MOTIVO_CONSULTA")]
        public string MotivoConsulta { get; set; }
        [BsonElement("HISTORIA_ENFERMEDAD_ACTUAL")]
        public string HistoriaEnfermedadActual { get; set; }
        // Pero me parece que esto hay que corregirlo no se

        [BsonElement("Revision_sistemas")]
        public List<RevisionSistemas> RevisionSistemas { get; set; }
        [BsonElement("nd")]
        public List<ND> Nd { get; set; }
        [BsonElement("ANTECEDENTES")]
        public Antecedentes Antecedentes { get; set; }
        [BsonElement("GINECO-OBSTRETRICOS")]
        public GinecoObstretrico GinecoObstretrico { get; set; }
        [BsonElement("Examen_fisico")]
        public ExamenFisico ExamenFisico { get; set; }
        [BsonElement("HISTORIAL")]
        public Historial Historial { get; set; }

    }
    public class RevisionSistemas
    {
        public RevisionSistemas()
        {

        }
        public RevisionSistemas(string d)
        {
            this.Descripcion = d;
            this.Fecha = DateTime.Now.ToString();
            MyUUID = Guid.NewGuid().ToString();
        }
        [BsonElement("descripcion")]
        public string Descripcion { get; set; }
        [BsonElement("fecha")]
        public string Fecha { set; get; }
        [BsonElement("uuid")]
        public string MyUUID { get; set; }
    }
}
