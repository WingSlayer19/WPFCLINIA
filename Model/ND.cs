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
        public ND()
        {

        }
        public ND(string d)
        {
            this.Descripcion = d;
            this.Fecha = DateTime.Now.ToString();
            MyUUID = Guid.NewGuid().ToString();
        }
        [BsonElement("descripcion")]
        public string Descripcion { get; set; }
        [BsonElement("fecha")]
        public string Fecha { get; set; }
        [BsonElement("uuid")]
        public string MyUUID { get; set; }
    }
}
