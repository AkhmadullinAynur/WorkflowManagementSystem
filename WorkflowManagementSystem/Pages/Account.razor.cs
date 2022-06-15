using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using WorkflowManagementSystem.Data;

namespace WorkflowManagementSystem.Pages
{
    public partial class Account
    {
        private bool _editName;
        private bool _editSurName;
        private bool _editProfession;
        private bool _editEmail;
        private bool _editPhonenumber;
        private bool _editPassword;
        List<User> professions = User.GetListOfProfessions();

        private void EditName()
        {
            _editName = true;
            _editSurName = false;
            _editProfession = false;
            _editEmail = false;
            _editPhonenumber = false;
            _editPassword = false;
        }
        private void EditSurName()
        {
            _editName = false;
            _editSurName = true;
            _editProfession = false;
            _editEmail = false;
            _editPhonenumber = false;
            _editPassword = false;
        }
        private void EditProfession()
        {
            _editName = false;
            _editSurName = false;
            _editProfession = true;
            _editEmail = false;
            _editPhonenumber = false;
            _editPassword = false;
        }
        private void EditEmail()
        {
            _editName = false;
            _editSurName = false;
            _editProfession = false;
            _editEmail = true;
            _editPhonenumber = false;
            _editPassword = false;
        }
        private void EditPhonenumber()
        {
            _editName = false;
            _editSurName = false;
            _editProfession = false;
            _editEmail = false;
            _editPhonenumber = true;
            _editPassword = false;
        }
        private void EditPassword()
        {
            _editName = false;
            _editSurName = false;
            _editProfession = false;
            _editEmail = false;
            _editPhonenumber = false;
            _editPassword = true;
        }
        private void Cancel()
        {
            _editName = false;
            _editSurName = false;
            _editProfession = false;
            _editEmail = false;
            _editPhonenumber = false;
            _editPassword = false;
        }
        private void SelectionProfession(ChangeEventArgs args)
        {
            client.Profession = args.Value.ToString();
        }
        private void EditUser()
        {
            bool active = true;
            if (client.Name == "" || client.SurName == "" || client.Email == "" || client.PhoneNumber == "" || client.Password == "")
            {

            }
            else
            {
                string buffer = MongoDataBase.FindUserPassword(client.Name);
                MongoDataBase.ReplaceUser(buffer, new User(client.Name, client.SurName, client.Profession, client.Email, client.PhoneNumber, client.Password, active));
                Cancel();
            }
            OnInitialized();
        }
    }
}
