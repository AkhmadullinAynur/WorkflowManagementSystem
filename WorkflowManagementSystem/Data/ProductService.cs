using MongoDB.Bson;
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
    }
}
