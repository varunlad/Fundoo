using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static FundooModel.RegisterModel;

namespace FundooRepository.Context
{
        public class UserContext : DbContext //Db Context-connection within the database(it is important to connect to a table in the data base and execute query     
        {
            public UserContext(DbContextOptions<UserContext> options) : base(options)
            {

            }
            public DbSet<RegistrationModel> Users { get; set; } //DataSet- it is used to represent table
        }
}
