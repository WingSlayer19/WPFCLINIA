using MongoDB.Bson;
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

        public Expediente GetById(string id)
        {
            return mongoConnection.GetExpeByid(id);
        }

        public void SaveExpediente(Expediente e)
        {
            // TODO: Validar el expediente
            /*
             * De ser necesario Adaptar el modelo expeidnete al
             * formulario de la vista Page1. 
             */
            mongoConnection.SaveExpe(e);
        }

        public void SaveHistorial(string Id, Expediente e)
        {
            mongoConnection.UpdateExpInsertHistorial(Id, e);
        }

        public List<Archivo> GetAllExpeAndFiles(string id)
        {
            return mongoConnection.GetAllExpeAndFiles(id);
        }

        public void SaveFiles(List<Archivo> archivos)
        {
            mongoConnection.SaveFiles(archivos);
        }

        public void NewProfilePhoto(byte[] img, Expediente e)
        {
            mongoConnection.NewProfilePhoto(img, e);
        }

        public void DeleteFile(Archivo a)
        {
            mongoConnection.DeleteFile(a);
        }

        public void UpdatePacienteExpe(string id, Expediente e)
        {
            mongoConnection.UpdateExpecientePaciente(e, id);
        }
    }
}
