using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using WorkflowManagementSystem.Data;

namespace WorkflowManagementSystem.Pages
{
    public partial class Registration
    {
        User user = new User();
        string inHome = "/";

        private bool _isComplete;
        private bool _isNotComplete;

        public List<User> users { get; set; }

        private void NewRegistration()
        {
            _isComplete = true;
            _isNotComplete = false;
            MongoDataBase.AddUser(new User(user.Name, user.SurName, user.Profession, user.Email, user.PhoneNumber, user.Password));
            user.Name = string.Empty;
            user.SurName = string.Empty;
            user.Email = string.Empty;
            user.PhoneNumber = string.Empty;
            user.Password = string.Empty;
            OnInitialized();
        }
    }
}