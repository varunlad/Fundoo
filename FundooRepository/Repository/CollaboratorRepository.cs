//// --------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooModel;
    using FundooRepository.Context;
    using FundooRepository.Interface;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Collaborator Repository class is created it is the Data Access Layer and it filter out the required data from the Database 
    /// </summary>
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// UserContext userContext will help me to access UserContext Dbset User which contain data.
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRepository"/> class created the instance of configuration and userContext
        /// </summary>
        /// <param name="configuration">passing the object of IConfiguration</param>
        /// <param name="userContext">passing the object of UserContext</param>
        public CollaboratorRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

        /// <summary>
        /// Gets the Configuration.This is an object for IConfiguration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Collaborator Method is Created to add a collaborator Email for that note.
        /// </summary>
        /// <param name="collaborator"> Collaborator Model is passed as parameter</param>
        /// <returns> string message as Collaborator is Added or not</returns>
        public async Task<string> Collaborator(CollaboratorModel collaborator)
        {
            try
            {
                if (collaborator != null)
                {
                    //// Add the data to the database
                    this.userContext.Add(collaborator);
                    //// Save the change in database
                    await this.userContext.SaveChangesAsync();
                    return "Email is added Successfully";
                }

                return "Email is not added";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete Collaborator Method is Created to Delete a collaborator Email for that note.
        /// </summary>
        /// <param name="collaborator"> Collaborator Id is Passed as a parameter</param>
        /// <returns>string message as Collaborator is Deleted or not</returns>
        public async Task<string> DeleteCollaborator(int collaborator)
        {
            try
            {
                var validCollabID = this.userContext.Collaborator.Where(x => x.CollaboratorID == collaborator).FirstOrDefault();
                if (validCollabID != null)
                {
                    //// Add the data to the database
                    this.userContext.Remove(validCollabID);
                    //// Save the change in database
                    await this.userContext.SaveChangesAsync();
                    return "Email is Deleted";
                }

                return "Email is not Deleted";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Collaborated Emails method is created to get all Collaborator Email.
        /// </summary>
        /// <param name="noteId">note Id is passed as parameter.</param>
        /// <returns>Get all the emails of that Note Id</returns>
        public IEnumerable<CollaboratorModel> GetCollaboratedEmails(int noteId)
        {
            try
            {
                IEnumerable<CollaboratorModel> collaborator = from x in this.userContext.Collaborator where x.NoteID == noteId select x;
                if (collaborator != null)
                {
                    return collaborator;
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
