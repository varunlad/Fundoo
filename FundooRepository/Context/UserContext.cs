//// --------------------------------------------------------------------------------------------------------
// <copyright file="UserContext.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooRepository.Context
{
    using FundooModel;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Db Context-connection within the database(it is important to connect to a table in the data base and execute query
    /// </summary>
    public class UserContext : DbContext      
        {
            public UserContext(DbContextOptions<UserContext> options) : base(options)
            {

            }

        /// <summary>
        /// With Dbset we can Create new table with name UsersTable
        /// </summary>
        public DbSet<RegisterModel> UsersTable { get; set; }

        /// <summary>
        /// With Dbset we can Create new table with name Notes
        /// </summary>  
        public DbSet<NotesModel> Notes { get; set; }

        /// <summary>
        /// With Dbset we can Create new table with name Collaborator
        /// </summary>
        public DbSet<CollaboratorModel> Collaborator { get; set; }

        /// <summary>
        /// With Dbset we can Create new table with name LabelsTable
        /// </summary>
        public DbSet<LableModel> LabelsTable { get; set; }
    }
}
