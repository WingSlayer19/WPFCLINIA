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
        public Antecedentes()
        {

        }
        public Antecedentes(Examen Mx, Examen Qx, Examen Tx, Examen Fam, Examen Tox, Examen Alergia, Examen RH, Examen Hiv, Examen Vdri, Examen HepB, Examen Torch)
        {
            this.Mx = Mx;
            this.Qx = Qx;
            this.Tx = Tx;
            this.Fam = Fam; 
            this.Tox = Tox; 
            this.Alergia = Alergia;
            this.RH = RH;   
            this.Vdri = Vdri;   
            this.HepB = HepB;   
            this.Hiv = Hiv;
            this.Torch = Torch;
        }
        [BsonElement("MX")]
        public Examen Mx { get; set; }
        [BsonElement("QX")]
        public Examen Qx { get; set; }
        [BsonElement("TX")]
        public Examen Tx { get; set; }
        [BsonElement("Fam")]
        public Examen Fam { get; set; }
        [BsonElement("Tox")]
        public Examen Tox { get; set; }
        [BsonElement("alergia")]
        public Examen Alergia { get; set; }
        [BsonElement("GrupoRH")]
        public Examen RH { get; set; }
        [BsonElement("HIV")]
        public Examen Hiv { get; set; }
        [BsonElement("vdri")]
        public Examen Vdri { get; set; }
        [BsonElement("hepb")]
        public Examen HepB { get; set; }
        [BsonElement("TORCH")]
        public Examen Torch { get; set; }
    }

    public class Examen
    {
        public Examen()
        {

        }
        public Examen(string ti)
        {
            this.Tipo = ti;
        }
        [BsonElement("tipo")]
        public string Tipo { get; set; }
    }

}
