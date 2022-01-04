using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFclinica.Model
{
    internal class Antecedentes
    {
        public MX Mx { get; set; }
        public QX Qx { get; set; }
    }

    public class MX
    {
        public string Fecha { get; set; }
        public string Tipo { get; set; }
        public uint Folio { get; set; }
    }

    public class QX
    {
        public string Fecha { get; set; }
        public string Tipo { get; set; }
        public uint Folio { get; set; }
    }
}
