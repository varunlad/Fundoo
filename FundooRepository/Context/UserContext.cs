using FundooModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace FundooRepository.Context
{
        public class UserContext : DbContext //Db Context-connection within the database(it is important to connect to a table in the data base and execute query     
        {
            public UserContext(DbContextOptions<UserContext> options) : base(options)
            {

            }
            public DbSet<RegisterModel> UsersTable { get; set; } //DataSet- it is used to represent table
            public DbSet<NotesModel> Notes { get; set; }
            public DbSet<CollaboratorModel> Collaborator { get; set; }
            public DbSet<LableModel> LabelsTable { get; set; }

    }
}
