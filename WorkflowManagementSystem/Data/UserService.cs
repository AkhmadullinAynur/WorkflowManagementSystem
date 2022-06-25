using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.Data
{
    public class UserService
    {
        public ObjectId id { get; set; }
        public List<User> listOfUsers;

        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        public string Password { get; set; }

        public string SurName { get; set; }
        public string Profession { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
        public bool Admin { get; set; }
        public string NewName { get; set; }
        public void GetUserData()
        {
            var client = MongoDataBase.FindUser(Name);
            foreach (var item in client)
            {
                SurName = item.SurName;
                Profession = item.Profession;
                Email = item.Email;
                PhoneNumber = item.PhoneNumber;
            }
        }
        public List<User> professions = User.GetListOfProfessions();
    }
}
