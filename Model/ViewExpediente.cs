using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFclinica.Model
{
    internal class ViewExpediente
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Telefonos { get; set; }

        public List<ViewExpediente> ConvertElement(List<Expediente> e)
        {
            var list2 = e.Select(x => new ViewExpediente() 
            { Id = x.Id.ToString(), Nombre = x.Nombre, Telefonos = String.Join("  ",x.Telefonos)}).ToList();
            return list2;
        }
    }
}
