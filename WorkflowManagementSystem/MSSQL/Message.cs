using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.MSSQL
{
    public class Message
    {
        public Message(string sender, string recipient, string messages)
        {
            Sender = sender;
            Recipient = recipient;
            Messages = messages;
        }

        public Message(int id, string sender, string recipient, string messages)
        {
            Id = id;
            Sender = sender;
            Recipient = recipient;
            Messages = messages;
        }

        public int Id { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Messages { get; set; }
        public bool ReadMessage { get; set; }
    }
}
