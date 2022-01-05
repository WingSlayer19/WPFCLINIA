using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFclinica.Model
{
    internal class ExamenFisico
    {
        [BsonElement("PA")]
        public uint Pa { get; set; }
        [BsonElement("MMHG")]
        public uint Mmhg { get; set; }
        [BsonElement("FC")]
        public uint Fc { get; set; }
        [BsonElement("FR")]
        public uint Fr { get; set; }
        [BsonElement("T")]
        public uint T { get; set; }
        [BsonElement("W")]
        public string W { get; set; }
        [BsonElement("TALLA")]
        public ushort Talla { get; set; }
        [BsonElement("IMC")]
        public ushort Imc { get; set; }
    }
}
