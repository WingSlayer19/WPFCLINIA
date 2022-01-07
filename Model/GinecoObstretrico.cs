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
        public GinecoObstretrico()
        {

        }
        public GinecoObstretrico(uint G, uint P, uint Ab, uint Fur, double Pan, string Menarquia, string Ciclos, string Ivs, uint Ps, string Pap, string Ets, uint C, string Fpp, string Pf)
        {
            this.G = G;
            this.P = P;
            this.Ab = Ab;
            this.Fur = Fur;
            this.Pan = Pan;
            this.Menarquia = Menarquia;
            this.Ciclos = Ciclos;
            this.Ivs = Ivs;
            this.Pap = Pap;
            this.Ets = Ets;
            this.C = C;
            this.Ps = Ps;
            this.FPP = Fpp;
            this.PF = Pf;
        }

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
        [BsonElement("FPP")]
        public string FPP { get; set; }
        [BsonElement("PF")]
        public string PF { get; set; }
    }
}
