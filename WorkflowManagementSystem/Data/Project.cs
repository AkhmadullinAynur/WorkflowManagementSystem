using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.Data
{
    public class Project
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        public Project(int numberProject, string nameProject, List<TaskList> taskList, List<Product> componentList, string performerOfWorks, DateTime startDate, DateTime completionDate, bool isDone)
        {
            NumberProject = numberProject;
            NameProject = nameProject;
            TaskList = taskList;
            ComponentList = componentList;
            PerformerOfWorks = performerOfWorks;
            StartDate = startDate;
            CompletionDate = completionDate;
            IsDone = isDone;
        }

        public Project(int numberProject, string nameProject, List<TaskList> taskList, List<Product> componentList)
        {
            NumberProject = numberProject;
            NameProject = nameProject;
            TaskList = taskList;
            ComponentList = componentList;
        }

        public Project(string nameProject, List<TaskList> taskList, List<Product> componentList)
        {
            NameProject = nameProject;
            TaskList = taskList;
            ComponentList = componentList;
        }

        public Project(List<Product> componentList)
        {
            ComponentList = componentList;
        }

        public Project()
        {
        }

        [BsonIgnoreIfDefault]
        public int NumberProject { get; set; }
        [BsonIgnoreIfDefault]
        public string NameProject { get; set; }
        [BsonIgnoreIfDefault]
        public List<TaskList> TaskList { get; set; }
        [BsonIgnoreIfDefault]
        public List<Product> ComponentList { get; set; }
        [BsonIgnoreIfDefault]
        public string PerformerOfWorks { get; set; }
        [BsonIgnoreIfDefault]
        public DateTime StartDate { get; set; }
        [BsonIgnoreIfDefault]
        public DateTime CompletionDate { get; set; }
        [BsonIgnoreIfDefault]
        public bool IsDone { get; set; }


        [BsonIgnoreIfDefault]
        public List<Project> projects { get; set; }
        [BsonIgnoreIfDefault]
        public List<Project> newProjects { get; set; }
    }
}
