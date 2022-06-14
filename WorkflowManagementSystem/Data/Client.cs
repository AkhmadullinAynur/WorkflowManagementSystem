﻿using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;


namespace WorkflowManagementSystem.Data
{
    public class Client
    {
        public ObjectId id { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить это поле")]
        public string Password { get; set; }
    }
}
