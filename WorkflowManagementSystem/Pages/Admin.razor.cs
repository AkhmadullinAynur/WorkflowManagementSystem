using Microsoft.AspNetCore.Components;
using WorkflowManagementSystem.Data;

namespace WorkflowManagementSystem.Pages
{
    public partial class Admin
    {
        protected override void OnInitialized()
        {
            client.listOfUsers = MongoDataBase.GetUserList();
        }

        private bool _newRegistartion;
        private bool _isEditActiv;
        private bool _isRegisterComplete;
        private bool _isEditComplete;
        private bool _isNotComplete;

        private string _buffer;

        private void RegistrationActive()
        {
            _newRegistartion = !_newRegistartion;
            MessageFalse();
        }
        private void CloseAll()
        {
            _newRegistartion = false;
            _isEditActiv = false;
            Refrash();
            OnInitialized();
        }
        private void MessageFalse()
        {
            _isRegisterComplete = false;
            _isEditComplete = false;
            _isNotComplete = false;
        }
        private void Refrash()
        {
            client.NewName = null;
            client.SurName = null;
            client.Profession = null;
            client.Email = null;
            client.PhoneNumber = null;
            client.Password = null;
            OnInitialized();
        }
        private void DeleteUser(string user)
        {
            MongoDataBase.DeleteUser(user);
            MessageFalse();
            OnInitialized();
        }

        private void ActivateUser(string user)
        {
            bool active = true;
            var users = MongoDataBase.FindUser(user);
            foreach (var item in users)
            {
                string buffer = item.Password;
                MongoDataBase.ReplaceUser(buffer, new User(item.Name, item.SurName, item.Profession, item.Email, item.PhoneNumber, buffer, active));
            }
            MessageFalse();
            OnInitialized();
        }
        private void SelectionProfession(ChangeEventArgs args)
        {
            client.Profession = args.Value.ToString();
        }

        private void isEditActiv(string user)
        {
            _isEditActiv = true;
            _newRegistartion = false;
            var users = MongoDataBase.FindUser(user);
            foreach (var item in users)
            {
                client.NewName = item.Name;
                client.SurName = item.SurName;
                client.Profession = item.Profession;
                client.Email = item.Email;
                client.PhoneNumber = item.PhoneNumber;
                client.Password = item.Password;
            }
            MessageFalse();
        }
        private void RegisterUser()
        {
            bool active = true;
            if (client.NewName == "" || client.SurName == "" || client.Email == "" || client.PhoneNumber == "")
            {
                _isNotComplete = true;
            }
            else
            {
                MongoDataBase.AddUser(new User(client.NewName, client.SurName, client.Profession, client.Email, client.PhoneNumber, client.NewName, active));
                _isRegisterComplete = true;
                _isNotComplete = false;
                _newRegistartion = false;
            }
            CloseAll();
        }
        private void EditUser()
        {
            bool active = true;
            if (client.NewName == "" || client.SurName == "" || client.Email == "" || client.PhoneNumber == "")
            {
                _isNotComplete = true;
            }
            else
            {
                MongoDataBase.ReplaceUser(client.Password, new User(client.NewName, client.SurName, client.Profession, client.Email, client.PhoneNumber, client.Password, active));
                _isEditComplete = true;
                _isNotComplete = false;
                _isEditActiv = false;
            }
            CloseAll();
        }
    }
}