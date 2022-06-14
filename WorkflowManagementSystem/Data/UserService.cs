using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.Data
{
    public class UserService
    {
        public ObjectId _id;
        public List<User> listOfUsers;

        public void AddToList()
        {
            listOfUsers = MongoDataBase.GetUserList();
        }

    }
}
