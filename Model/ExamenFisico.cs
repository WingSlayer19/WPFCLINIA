using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFclinica.Model
{
    internal class ExamenFisico
    {
        public uint Pa { get; set; }
        public uint Mmhg { get; set; }
        public uint Fc { get; set; }
        public uint Fr { get; set; }
        public uint T { get; set; }
        public string W { get; set; }
        public ushort Talla { get; set; }
        public ushort Imc { get; set; }
    }
}
