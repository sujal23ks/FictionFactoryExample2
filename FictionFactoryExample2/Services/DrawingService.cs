using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FictionFactoryExample2.Models;

namespace FictionFactoryExample2.Services
{
    public class DrawingService
    {

        private readonly IMongoCollection<DrawingsEntity> _drawingsEntity; 

        public DrawingService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("test");

            _drawingsEntity = database.GetCollection<DrawingsEntity>("fictionFactory");
        }

        public DrawingsEntity Get(string id) =>
            _drawingsEntity.Find<DrawingsEntity>(drawingsEntity => drawingsEntity._id == id).FirstOrDefault();

        public DrawingsEntity Create(DrawingsEntity drawingEntity)
        {
            _drawingsEntity.InsertOne(drawingEntity);
            return drawingEntity;
        }
    }
}
