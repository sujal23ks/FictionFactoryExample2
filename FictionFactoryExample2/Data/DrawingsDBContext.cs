using FictionFactoryExample2.Interface;
using FictionFactoryExample2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictionFactoryExample2.Data
{
    public class DrawingsDBContext : IDrawingstore
    {
        public readonly IMongoDatabase _db;

        public DrawingsDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<DrawingsEntity> drawingscollection => _db.GetCollection<DrawingsEntity>("fictionFactory");

        public IEnumerable<DrawingsEntity> GetAllDrawings()
        {
            return drawingscollection.Find(a => true).ToList();
        }

        public DrawingsEntity GetDrawingDevDetails(string Name)
        {
            var drawingsdevdetails = drawingscollection.Find(d => d.Name == Name).FirstOrDefault();
            return drawingsdevdetails;
        }
        public void Create(DrawingsEntity drawingsData)
        {
            drawingscollection.InsertOne(drawingsData);
        }

        public void Update(string _id, DrawingsEntity drawingsData)
        {
            var filter = Builders<DrawingsEntity>.Filter.Eq(c => c._id, _id);
            var update = Builders<DrawingsEntity>.Update
                .Set("Name", drawingsData.Name)
                .Set("Row Count", drawingsData.Box_Hori_Count)
                .Set("Row Width", drawingsData.Width_row)
                .Set("Row Depth", drawingsData.Depth_row)
                .Set("Columns Count", drawingsData.Box_Vert_Count)
                .Set("Column Width", drawingsData.Width_col)
                .Set("Column Depth", drawingsData.Height_Col)
                .Set("Back Count", drawingsData.Box_Back_Count)
                .Set("Width Back", drawingsData.Width_bk)
                .Set("Height Back", drawingsData.Height_bk);

            drawingscollection.UpdateOne(filter, update);
        }

        public void Delete(string Name)
        {
            var filter = Builders<DrawingsEntity>.Filter.Eq(c => c.Name, Name);
            drawingscollection.DeleteOne(filter);
        }

       
        //public IMongoCollection<T> GetCollection<T>(string v)
        //{
        //    throw new NotImplementedException();
        //}


       
    }
}
