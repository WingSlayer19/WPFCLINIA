﻿using MongoDB.Bson;
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
        private readonly IMongoCollection<Archivo> _archivos;
        public MongoConnection()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("clinica_paiz");
            _expediente = database.GetCollection<Expediente>("expediente");
            _archivos = database.GetCollection<Archivo>("archivos");
        }

        public List<Expediente> GetAllExpe()
        {
            List<Expediente> list = _expediente.AsQueryable().ToList(); 
            return list;
        }

        public List<Archivo> GetAllExpeAndFiles(string idExpe)
        {
            //return _expediente.AsQueryable().GroupJoin(_archivos.AsQueryable(), p => p.Id, o => o.ExpedienteId, (p, o) => new { p.Id, p.Nombre, other = o }).ToList();
            ObjectId Id = new ObjectId(idExpe);
            return _archivos.Find(x => x.ExpedienteId == Id).ToList(); 
        }

        public Expediente GetExpeByid(string id)
        {
            ObjectId Id = new ObjectId(id);
            Expediente exp = _expediente.Find(x => x.Id == Id).First();

            return exp;
        }

        public void SaveExpe(Expediente e)
        {
            _expediente.InsertOne(e);
        }

        public void UpdateExpInsertHistorial(string id, Expediente e)
        {
            ObjectId Id = new ObjectId(id);
            _expediente.ReplaceOne(x => x.Id == Id, e);
        }

        public void SaveFiles(List<Archivo> archivos)
        {
           _archivos.InsertManyAsync(archivos);
        }

        public void NewProfilePhoto(byte[] img, Expediente e)
        {
            e.Image = img;
            _expediente.ReplaceOne(x => x.Id == e.Id, e);
        }

        public void DeleteFile(Archivo e)
        {
            _archivos.DeleteOneAsync(x => x.Id == e.Id);
        }

        public void UpdateExpecientePaciente(Expediente e, string id)
        { 
            ObjectId Id = new ObjectId(id);
            _expediente.ReplaceOneAsync(x => x.Id == Id, e);
        }

        public void DeleteExpediente(string id)
        {
            ObjectId Id = new ObjectId(id);
            _expediente.DeleteOneAsync(x => x.Id == Id);
        }

        public void DeletePacienteByExp(string id)
        {
            ObjectId Id = new ObjectId(id);
            _archivos.DeleteOneAsync(x => x.ExpedienteId == Id);
        }
    }
}
