using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.Data
{
    public class TaskListService
    {
        [BsonIgnoreIfDefault]
        ObjectId _id;
        public string NameTask { get; set; }
        [BsonIgnoreIfDefault]
        public List<TaskList> newTaskList { get; set; } = new List<TaskList>();
    }
}
