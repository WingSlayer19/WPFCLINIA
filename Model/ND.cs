using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFclinica.Model
{
    internal class ND
    {
        [BsonElement("descripcion")]
        public string Descripcion { get; set; }
        [BsonElement("fecha")]
        public string Fecha { get; set; }
    }
}
