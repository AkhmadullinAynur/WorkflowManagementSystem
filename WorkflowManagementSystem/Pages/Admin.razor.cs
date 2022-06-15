using System.Collections.Generic;
using WorkflowManagementSystem.Data;

namespace WorkflowManagementSystem.Pages
{
    public partial class Admin
    {
        public List<User> users { get; set; }

        protected override void OnInitialized()
        {
            userService.listOfUsers = MongoDataBase.GetUserList();
        }

        private bool _newRegistartion;
        private bool _isEditActiv;

        private void RegistrationActive()
        {
            _newRegistartion = !_newRegistartion;
            OnInitialized();
        }
        private void CloseAll()
        {
            _newRegistartion = false;
            _isEditActiv = false;
            OnInitialized();
        }
        private void DeleteUser(string user)
        {
            MongoDataBase.DeleteUser(user);
            OnInitialized();
        }

        private void ActivateUser(string user)
        {
            bool active = true;
            users = MongoDataBase.FindUser(user);
            foreach (var item in users)
            {
                string buffer = item.Password;
                MongoDataBase.ReplaceUser(buffer, new User(item.Name, item.SurName, item.Profession, item.Email, item.PhoneNumber, buffer, active));
            }
            OnInitialized();
        }

        private void isEditActiv(string user)
        {
            _isEditActiv = true;
            _newRegistartion = false;
            users = MongoDataBase.FindUser(user);
        }
    }
}
