using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFclinica.Model
{
    internal class GinecoObstretrico
    {
        [BsonElement("G")]
        public uint G { get; set; }
        [BsonElement("P")]
        public uint P { get; set; }
        [BsonElement("Ab")]
        public uint Ab { get; set; }
        [BsonElement("FUR")]
        public uint Fur { get; set; }
        [BsonElement("PAN")]
        public double Pan { get; set; }
        [BsonElement("MENARQUIA")]
        public string Menarquia { get; set; }
        [BsonElement("CICLOS")]
        public string Ciclos { get; set; }
        [BsonElement("IVS")]
        public string Ivs { get; set; }
        [BsonElement("PS")]
        public uint Ps { get; set; }
        [BsonElement("PAP")]
        public string Pap { get; set; }
        [BsonElement("ETS")]
        public string Ets { get; set; }
        [BsonElement("C")]
        public uint C { get; set; }
    }
}
