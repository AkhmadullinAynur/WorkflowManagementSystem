using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.Data
{
    public class Product
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;

        public Product(string name, string typeProduct, string manufacturer, int article, int quantity)
        {
            Name = name;
            TypeProduct = typeProduct;
            Manufacturer = manufacturer;
            Article = article;
            Quantity = quantity;
        }

        public Product(string typeProduct)
        {
            TypeProduct = typeProduct;
        }

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

        [BsonIgnoreIfDefault]
        public List<Product> newProductList { get; set; }
    }
}
