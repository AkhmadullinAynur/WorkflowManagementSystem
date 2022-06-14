using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.Data
{
    public class TaskList
    {
        [BsonIgnoreIfDefault]
        ObjectId _id;
        public TaskList(string nameTask)
        {
            NameTask = nameTask;
        }

        public string NameTask { get; set; }

    }
}
