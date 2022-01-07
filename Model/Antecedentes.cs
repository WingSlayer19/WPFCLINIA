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
        public Examen(string fe, string ti, uint fo)
        {
            this.Fecha = fe;
            this.Folio = fo;
            this.Tipo = ti;
        }
        [BsonElement("fecha")]
        public string Fecha { get; set; }
        [BsonElement("tipo")]
        public string Tipo { get; set; }
        [BsonElement("folio")]
        public uint Folio { get; set; }
    }

}
