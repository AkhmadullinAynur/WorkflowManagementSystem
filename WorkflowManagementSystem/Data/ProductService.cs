using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.Data
{
    public class ProductService
    {
        public ObjectId _id;
        public List<Product> merchandises { get; set; }
        [BsonIgnoreIfDefault]
        public string Name { get; set; }
        [BsonIgnoreIfDefault]
        public string TypeProduct { get; set; }
        [BsonIgnoreIfDefault]
        public string Manufacturer { get; set; }
        [BsonIgnoreIfDefault]
        public int Article { get; set; }
        [BsonIgnoreIfDefault]
        public int Quantity { get; set; }
        [BsonIgnoreIfDefault]
        public int Count { get; set; }

        //public static void Replace(int article, int count)
        //{
        //    var list = MongoDataBase.GetProductList();
        //    if (list.Exists(x => x.Article == article))
        //    {
        //        var current = list.Find(x => x.Article == article);
        //        current.Quantity = count;
        //        MongoDataBase.ReplaceProduct(article, current);
        //    }
        //}
        [BsonIgnoreIfDefault]
        public List<Product> newProductList { get; set; } = new List<Product>();
    }
}
