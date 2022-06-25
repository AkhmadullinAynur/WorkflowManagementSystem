using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using WorkflowManagementSystem.Data;
using WorkflowManagementSystem.MSSQL;

namespace WorkflowManagementSystem.Pages
{
    public partial class Messenger
    {
        private bool _newMessage;
        private bool _unreadMessages;
        private bool _readMessages;
        private bool _sentMessages;
        private bool _newMessagesComplete;
        private bool _newMessagesNotComplete;
        private string _surName;
        private string _message;
        private List<Message> unreadMessages = new List<Message>();
        private List<Message> readMessages = new List<Message>();
        private List<Message> sentMessages = new List<Message>();

        protected override void OnInitialized()
        {
            client.listOfUsers = MongoDataBase.GetUserList();
            string name = client.Name + " " + client.SurName;
            unreadMessages = repository.GetUnreadMessages(name);
            readMessages = repository.GetReadMessages(name);
            sentMessages = repository.GetSentMessages(name);
        }
        private void NewMessage()
        {
            _newMessage = true;
            _unreadMessages = true;
            _readMessages = false;
            _sentMessages = false;
        }
        private void UnreadMessage()
        {
            _newMessage = false;
            _unreadMessages = false;
            _readMessages = false;
            _sentMessages = false;
            _newMessagesComplete = false;
            _newMessagesNotComplete = false;
        }
        private void ReadMessage()
        {
            _newMessage = false;
            _unreadMessages = true;
            _readMessages = true;
            _sentMessages = false;
            _newMessagesComplete = false;
            _newMessagesNotComplete = false;
        }
        private void SentMessage()
        {
            _newMessage = false;
            _unreadMessages = true;
            _readMessages = false;
            _sentMessages = true;
            _newMessagesComplete = false;
            _newMessagesNotComplete = false;
        }
        private void SelectionUser(ChangeEventArgs args)
        {
            client.NewName = args.Value.ToString();
            var user = MongoDataBase.FindUser(client.NewName);
            foreach (var item in user)
            {
                _surName = item.SurName;
            }
            _newMessagesComplete = false;
            _newMessagesNotComplete = false;
        }
        private void SendAMessage()
        {
            string recipient = client.NewName + " " + _surName;
            string sender = client.Name + " " + client.SurName;
            if (recipient != null && recipient != " " && _message != null && _message != "")
            {
                repository.AddMessage(sender, recipient, _message);
                _message = string.Empty;
                _newMessagesComplete = true;
                _newMessagesNotComplete = false;
            }
            else
            {
                _newMessagesNotComplete = true;
            }
            OnInitialized();
        }
        private void ReadMessege(int id)
        {
            repository.ValueChanged(id);
            OnInitialized();
        }
        private void DeleteMessege(int id)
        {
            repository.DeleteMessage(id);
            OnInitialized();
        }
    }
}