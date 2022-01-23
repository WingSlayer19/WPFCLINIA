using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFclinica.Model;

namespace WPFclinica.Database
{
    internal class MongoConnection
    {
        private readonly IMongoCollection<Expediente> _expediente;
        public MongoConnection()
        {
            MongoClient client = new MongoClient("mongodb+srv://Erickff:Test12345.@cluster0.plls6.mongodb.net");
            IMongoDatabase database = client.GetDatabase("test");
            _expediente = database.GetCollection<Expediente>("expediente");
        }

        public List<Expediente> GetAllExpe()
        {
            List<Expediente> list = _expediente.AsQueryable().ToList(); 
            return list;
        }

        public Expediente GetExpeByid(string Id)
        { 
            ObjectId id = ObjectId.Parse(Id);
            Expediente exp = _expediente.Find(x => x.Id == id).First();

            return exp;
        }

        public List<Expediente> GetPacientes(string Nombre)
        {
            return _expediente.Find(x => x.Nombre.Contains(Nombre)).ToList();
        }

        public void SaveExpe(Expediente e)
        {
            _expediente.InsertOne(e);
        }

        public void UpdateExpInsertHistorial(string Id, Expediente e)
        {
            // Insertar un historial actualizando el expedientel
        }
    }
}
