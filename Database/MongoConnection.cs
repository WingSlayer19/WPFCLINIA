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

        public void SaveExpe(Expediente e)
        {
            _expediente.InsertOne(e);
        }
    }
}
