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
        public ExamenFisico()
        {

        }
        public ExamenFisico(string Pa, string Mmhg, string Fc, string Fr, string T, string W, string Talla, string Imc)
        {
            this.Pa = Pa;
            this.Mmhg = Mmhg;
            this.Fc = Fc;
            this.Fr = Fr;
            this.Talla = Talla;
            this.Imc = Imc;
            this.W = W;
            this.T = T;
        }
        [BsonElement("PA")]
        public string Pa { get; set; }
        [BsonElement("MMHG")]
        public string Mmhg { get; set; }
        [BsonElement("FC")]
        public string Fc { get; set; }
        [BsonElement("FR")]
        public string Fr { get; set; }
        [BsonElement("T")]
        public string T { get; set; }
        [BsonElement("W")]
        public string W { get; set; }
        [BsonElement("TALLA")]
        public string Talla { get; set; }
        [BsonElement("IMC")]
        public string Imc { get; set; }
    }
}
