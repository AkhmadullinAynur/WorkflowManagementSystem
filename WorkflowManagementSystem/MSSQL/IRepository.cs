using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.MSSQL
{
    public interface IRepository
    {
        List<Message> GetUnreadMessages(string name);
        List<Message> GetReadMessages(string name);
        List<Message> GetSentMessages(string name);
        void AddMessage(string sender, string recipient, string message);
        void ValueChanged(int id);
        void DeleteMessage(int id);
    }
}
