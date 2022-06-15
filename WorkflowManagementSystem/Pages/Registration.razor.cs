using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using WorkflowManagementSystem.Data;

namespace WorkflowManagementSystem.Pages
{
    public partial class Registration
    {
        User user = new User();
        private string _buffer;
        string inHome = "/";

        [Parameter] public string Login { get; set; }
        [Parameter] public string Surname { get; set; }
        [Parameter] public string Profession { get; set; }
        [Parameter] public string Email { get; set; }
        [Parameter] public string PhoneNumber { get; set; }
        [Parameter] public bool _edit { get; set; }
        [Parameter] public bool _adminRegistartion { get; set; }
        [Parameter] public bool _Registartion { get; set; }

        private bool _isComplete;
        private bool _isNotComplete;

        public List<User> users { get; set; }
        List<User> professions = User.GetListOfProfessions();

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

        private void AdminRegistered()
        {
            bool active = true;
            if (Login == null || Surname == null || Email == null || PhoneNumber == null)
            {
                _isNotComplete = true;
            }
            else
            {
                _isComplete = true;
                _isNotComplete = false;
                MongoDataBase.AddUser(new User(Login, Surname, Profession, Email, PhoneNumber, Login, active));
                _adminRegistartion = false;
            }
            OnInitialized();
        }

        private void EditUser()
        {
            bool active = true;
            if (Login == "" || Surname == "" || Email == "" || PhoneNumber == "")
            {
                _isNotComplete = true;
            }
            else
            {
                MongoDataBase.ReplaceUser(_buffer, new User(Login, Surname, Profession, Email, PhoneNumber, _buffer, active));
                _isComplete = true;
                _isNotComplete = false;
                userService.listOfUsers = MongoDataBase.GetUserList();
            }
            OnInitialized();
        }

        protected override void OnInitialized()
        {
            users = MongoDataBase.FindUser(Login);
            foreach (var item in users)
            {
                _buffer = item.Password;
            }
        }
        private void SelectionProfession(ChangeEventArgs args)
        {
            Profession = args.Value.ToString();
        }
    }
}
