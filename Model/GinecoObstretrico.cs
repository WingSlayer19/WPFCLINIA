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
        public GinecoObstretrico(string G, string P, string Ab, string Fur, string Pan, string Menarquia, 
            string Ciclos, string Ivs, string Ps, string Pap, string Ets, string C, string Fpp, string Pf, 
            string Ectopico, string Fup, string Hv, string Hm)
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
            this.Ectopico = Ectopico;
            this.Fup = Fup;
            this.Hv = Hv;
            this.Hm = Hm;
        }

        [BsonElement("G")]
        public string G { get; set; }
        [BsonElement("P")]
        public string P { get; set; }
        [BsonElement("Ab")]
        public string Ab { get; set; }
        [BsonElement("FUR")]
        public string Fur { get; set; }
        [BsonElement("PAN")]
        public string Pan { get; set; }
        [BsonElement("MENARQUIA")]
        public string Menarquia { get; set; }
        [BsonElement("CICLOS")]
        public string Ciclos { get; set; }
        [BsonElement("IVS")]
        public string Ivs { get; set; }
        [BsonElement("PS")]
        public string Ps { get; set; }
        [BsonElement("PAP")]
        public string Pap { get; set; }
        [BsonElement("ETS")]
        public string Ets { get; set; }
        [BsonElement("C")]
        public string C { get; set; }
        [BsonElement("FPP")]
        public string FPP { get; set; }
        [BsonElement("PF")]
        public string PF { get; set; }
        [BsonElement("Ectopico")]
        public string Ectopico { get; set; }
        [BsonElement("FUP")]
        public string Fup { get; set; }
        [BsonElement("HV")]
        public string Hv { get; set; }
        [BsonElement("Hm")]
        public string Hm { get; set; }
    }
}
