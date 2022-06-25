using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowManagementSystem.MSSQL
{
    public class SQLDB : DbContext
    {
        public SQLDB(DbContextOptions<SQLDB> options) : base(options) { }

        public DbSet<Message> UsersMessage { get; set; }
    }
}
