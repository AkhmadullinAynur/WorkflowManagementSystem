using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.Data
{
    public class MongoDataBase
    {
        public static void AddUser(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(user);
        }

        public static List<User> GetUserList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<User>("Users");
            return collection.Find(x => true).ToList();
        }

        public static User Authorization(string name, string password)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<User>("Users");
            var item = collection.Find(x => x.Name == name && x.Password == password).FirstOrDefault();
            return item;
        }

        public static string FindUserName(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<User>("Users");
            var foundedUser = collection.Find(x => x.Name == name).FirstOrDefault();
            if (foundedUser == null)
            {
                return null;
            }
            else
            {
                string foundedName = foundedUser.Name;
                return foundedName;
            }
        }

        public static string FindUserPassword(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<User>("Users");
            var item = collection.Find(x => x.Name == name).FirstOrDefault();
            if (item == null)
            {
                return null;
            }
            else
            {
                string foundedPassword = item.Password;
                return foundedPassword;
            }
        }

        public static string FindUserProfession(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<User>("Users");
            var item = collection.Find(x => x.Name == name).FirstOrDefault();
            if (item == null)
            {
                return null;
            }
            else
            {
                string foundedPassword = item.Profession;
                return foundedPassword;
            }
        }

        public static void DeleteUser(string deleteUser)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<User>("Users");
            collection.DeleteOne(x => x.Name == deleteUser);
        }

        public static List<User> FindUser(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<User>("Users");
            var item = collection.Find(x => x.Name == name).ToList();
            return item;
        }

        public static void ReplaceUser(string password, User users)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<User>("Users");
            collection.ReplaceOne(x => x.Password == password, users);
        }
        public static Project ListOfUserProjects(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<User>("Users");
            var user = collection.Find(x => x.Name == name).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            else
                return user.project;
        }

        //Проекты:
        public static void AddProjectToDB(Project project)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Project>("Projects");
            collection.InsertOne(project);
        }

        public static List<Project> GetProjectList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Project>("Projects");
            return collection.Find(x => true).ToList();
        }

        public static void DeleteProject(int deleteProject)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Project>("Projects");
            collection.DeleteOne(x => x.NumberProject == deleteProject);
        }
        public static List<Project> FindProject(int number)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Project>("Projects");
            var item = collection.Find(x => x.NumberProject == number).ToList();
            return item;
        }
        public static void ReplaceProject(int number, Project project)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Project>("Projects");
            collection.ReplaceOne(x => x.NumberProject == number, project);
        }
        public static void AddProjectToUser(string name, Project newProject)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<User>("Users");
            var defenition = Builders<User>.Update.Push(x => x.project.projects, newProject);
            collection.UpdateOne(x => x.Name == name, defenition);
        }

        public static void PerformerOfWork(int number, string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Project>("Projects");
            var update = Builders<Project>.Update.Set(x => x.PerformerOfWorks, name);
            collection.UpdateOne(x => x.NumberProject == number, update);
        }

        public static void StartDate(int number, DateTime startDate)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Project>("Projects");
            var update = Builders<Project>.Update.Set(x => x.StartDate, startDate);
            collection.UpdateOne(x => x.NumberProject == number, update);
        }

        public static void FinishBuild(int number, bool isDone)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Project>("Projects");
            var update = Builders<Project>.Update.Set(x => x.IsDone, isDone);
            collection.UpdateOne(x => x.NumberProject == number, update);
        }

        public static void FinishDate(int number, DateTime finishDate)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Project>("Projects");
            var update = Builders<Project>.Update.Set(x => x.CompletionDate, finishDate);
            collection.UpdateOne(x => x.NumberProject == number, update);
        }

        //Комплектующие:
        public static void AddProductToDB(Product product)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Product>("Product");
            collection.InsertOne(product);
        }
        public static List<Product> GetProductList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Product>("Product");
            return collection.Find(x => true).ToList();
        }
        public static List<Product> FindProduct(int article)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Product>("Product");
            var item = collection.Find(x => x.Article == article).ToList();
            return item;
        }
        public static void DeleteProduct(int deleteProduct)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Product>("Product");
            collection.DeleteOne(x => x.Article == deleteProduct);
        }
        public static void ReplaceProduct(int article, Product product)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Product>("Product");
            collection.ReplaceOne(x => x.Article == article, product);
        }

        public static List<Product> GetComponentList(int number)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Project>("Projects");
            var project = collection.Find(x => x.NumberProject == number).FirstOrDefault();
            if (project == null)
            {
                return null;
            }
            else
                return project.ComponentList;
        }
        //Типы продукта:
        public static void AddTypeToDB(Product type)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Product>("Type of products");
            collection.InsertOne(type);
        }
        public static List<Product> GetTypeList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Product>("Type of products");
            return collection.Find(x => true).ToList();
        }

        //Перечень задании:
        public static void AddTaskToDB(TaskList taskList)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<TaskList>("Tasks");
            collection.InsertOne(taskList);
        }
        public static List<TaskList> GetTaskList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<TaskList>("Tasks");
            return collection.Find(x => true).ToList();
        }
        public static List<TaskList> GetProjectTaskList(int number)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Workflow_Management_System");
            var collection = database.GetCollection<Project>("Projects");
            var project = collection.Find(x => x.NumberProject == number).FirstOrDefault();
            if (project == null)
            {
                return null;
            }
            else
                return project.TaskList;
        }
    }
}
