using WorkflowManagementSystem.Data;

namespace WorkflowManagementSystem.Pages
{
    public partial class Authorization
    {
        string inReg = "/registration";

        private bool _authorizationIsActive;

        private bool _isNotComplete;
        private bool _adminMode;
        private bool _active;
        private bool _notActive;

        private static string _login;
        private static string _password;
        private static string _profession;

        private void AuthorizationNow()
        {
            var clientName = MongoDataBase.Authorization(client.Name, client.Password);
            if (client.Name == "Admin" && client.Password == "admin")
            {
                client.Admin = true;
            }
            else
            if (clientName != null)
            {
                var user = MongoDataBase.FindUser(client.Name);
                foreach (var item in user)
                {
                    _active = item.Active;
                }
                if (_active)
                {
                    _login = client.Name;
                    client.GetUserData();
                    _profession = MongoDataBase.FindUserProfession(client.Name);
                    client.Admin = false;
                    client.Active = true;
                    _isNotComplete = false;
                    _authorizationIsActive = !_authorizationIsActive;
                    if (_profession == "Проектировщик")
                    {
                        navigate.NavigateTo("/planner");
                    }
                    if (_profession == "Инженер")
                    {
                        navigate.NavigateTo("/engineer");
                    }
                    if (_profession == "Кладовщик")
                    {
                        navigate.NavigateTo("/warehouseman");
                    }
                }
                else
                {
                    _notActive = !_notActive;
                    ExitOfAccount();
                }
            }
            else
            {
                _isNotComplete = true;
            }
        }

        private void IsNotComplete()
        {
            _isNotComplete = true;
        }
        private void ExitOfAccount()
        {
            client.Active = false;
            client.Admin = false;
            client.Name = null;
            client.SurName = null;
            client.Profession = null;
            client.Email = null;
            client.PhoneNumber = null;
            client.Password = null;
        }
    }
}