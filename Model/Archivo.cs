using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFclinica.Model
{
    internal class Archivo
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("extension")]
        public string Extension { get; set; } // # another nepe

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("path")]
        public string Path { get; set; }

        [BsonElement("_expedienteId")]
        public ObjectId ExpedienteId { get; set; }

        public Archivo() { }

        public Archivo(string nameFile, string idExpe)
        {
            this.Nombre = nameFile.Replace(" ", "_");
            this.ExpedienteId = new ObjectId(idExpe);
            this.Extension = nameFile.Substring(nameFile.LastIndexOf('.'));
            this.Path = "C:\\Files\\CLINICA\\" + idExpe + "\\" + idExpe + "_" + this.Nombre;
        }
    }
}
