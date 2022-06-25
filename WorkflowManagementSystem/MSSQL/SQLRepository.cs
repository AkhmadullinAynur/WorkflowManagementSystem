using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.MSSQL
{
    public class SQLRepository : IRepository
    {
        private readonly SQLDB _context;

        public SQLRepository(SQLDB context)
        {
            _context = context;
        }
        public void AddMessage(string sender, string recipient, string message)
        {
            Message newUser = new Message(sender, recipient, message);
            _context.UsersMessage.Add(newUser);
            _context.SaveChanges();
        }

        public void DeleteMessage(int id)
        {
            var deleteditem = _context.UsersMessage.Find(id);
            if (deleteditem != null)
            {
                _context.UsersMessage.Remove(deleteditem);
                _context.SaveChanges();
            }
        }
        public List<Message> GetUnreadMessages(string name)
        {
            var list = new List<Message>();
            foreach (var item in _context.UsersMessage)
            {
                if (item.Recipient == name && item.ReadMessage == false)
                {
                    list.Add(new Message(item.Id, item.Sender, name, item.Messages));
                }
            }
            return list;
        }
        public List<Message> GetReadMessages(string name)
        {
            var list = new List<Message>();
            foreach (var item in _context.UsersMessage)
            {
                if (item.Recipient == name && item.ReadMessage == true)
                {
                    list.Add(new Message(item.Id, item.Sender, name, item.Messages));
                }
            }
            return list;
        }
        public List<Message> GetSentMessages(string name)
        {
            var list = new List<Message>();
            foreach (var item in _context.UsersMessage)
            {
                if (item.Sender == name)
                {
                    list.Add(new Message(item.Id, name, item.Recipient, item.Messages));
                }
            }
            return list;
        }
        public void ValueChanged(int id)
        {
            var changedItem = _context.UsersMessage.Find(id);
            changedItem.ReadMessage = true;
            var item = _context.UsersMessage.Attach(changedItem);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
