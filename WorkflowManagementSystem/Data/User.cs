using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.Data
{
    public class User
    {

        [BsonIgnoreIfDefault]
        ObjectId _id;
        public User(string name, string surName, string profession, string email, string phoneNumber, string password, bool active)
        {
            Name = name;
            SurName = surName;
            Profession = profession;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Active = active;
        }
        public User(string name, string surName, string profession, string email, string phoneNumber, bool active)
        {
            Name = name;
            SurName = surName;
            Profession = profession;
            Email = email;
            PhoneNumber = phoneNumber;
            Active = active;
        }
        public User(string name, string surName, string profession, string email, string phoneNumber)
        {
            Name = name;
            SurName = surName;
            Profession = profession;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public User(bool active)
        {
            Active = active;
        }
        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public User(string name, string surName, string profession, string email, string phoneNumber, string password)
        {
            Name = name;
            SurName = surName;
            Profession = profession;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Active = false;
        }

        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        public string Profession { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        [EmailAddress(ErrorMessage = "Недопустимый формат электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        public string Password { get; set; }

        public bool Active { get; set; }
        [BsonIgnoreIfDefault]
        public List<User> user { get; set; }

        [BsonIgnoreIfDefault]
        public Project project = new Project();

        public User()
        {
        }
    }
}
