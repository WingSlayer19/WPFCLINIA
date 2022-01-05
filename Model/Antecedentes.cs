using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFclinica.Model
{
    internal class Antecedentes
    {
        [BsonElement("MX")]
        public MX Mx { get; set; }
        [BsonElement("QX")]
        public QX Qx { get; set; }
    }

    public class MX
    {
        [BsonElement("fecha")]
        public string Fecha { get; set; }
        [BsonElement("tipo")]
        public string Tipo { get; set; }
        [BsonElement("folio")]
        public uint Folio { get; set; }
    }

    public class QX
    {
        [BsonElement("fecha")]
        public string Fecha { get; set; }
        [BsonElement("tipo")]
        public string Tipo { get; set; }
        [BsonElement("folio")]
        public uint Folio { get; set; }
    }
}
