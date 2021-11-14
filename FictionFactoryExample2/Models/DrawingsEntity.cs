using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictionFactoryExample2.Models
{
    public class DrawingsEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Name { get; set; }
        public int Box_Hori_Count { get; set; }
        public decimal Width_row { get; set; }
        public decimal Depth_row { get; set; }
        public int Box_Vert_Count { get; set; }
        public decimal Width_col { get; set; }

        public decimal Height_Col { get; set; }

        public int Box_Back_Count { get; set; }

        public decimal Width_bk { get; set; }

        public decimal Height_bk { get; set; }
       
    }
}
