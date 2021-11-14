using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictionFactoryExample2.Interface
{
    public interface IDrawingstore
    {
        IMongoCollection<Models.DrawingsEntity> drawingscollection { get; }
        IEnumerable<Models.DrawingsEntity> GetAllDrawings();
        Models.DrawingsEntity GetDrawingDevDetails(string Name);

        void Create(Models.DrawingsEntity drawingsData);

        void Update(string _id, Models.DrawingsEntity drawingsData);

        void Delete(string Name);
       // IMongoCollection<T> GetCollection<T>(string v);
    }
}
