using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFclinica.Database;
using WPFclinica.Model;

namespace WPFclinica.Handler
{
    internal class ExpedienteHandler
    {
        private MongoConnection mongoConnection;
        public ExpedienteHandler()
        {
            mongoConnection = new MongoConnection();
        }

        public List<Expediente> GetAllExpedientes()
        {
            return mongoConnection.GetAllExpe();
        }
    }
}
