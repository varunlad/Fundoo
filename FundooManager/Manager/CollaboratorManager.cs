//// --------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooManager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModel;
    using FundooRepository.Interface;

    /// <summary>
    /// Collaborator Manager class is created as it is the Business Logic Layer and takes the return statement from Repository. 
    /// </summary>
    public class CollaboratorManager : ICollaboratorManager
    {
        /// <summary>
        /// ICollaboratorRepository will help me to access the Methods of Repository Class.
        /// </summary>
        private readonly ICollaboratorRepository repository;

        /// <summary>
        ///  Initializes a new instance of the <see cref="CollaboratorManager"/> class created the instance of repository.
        /// </summary>
        /// <param name="repository">passing the object of ICollaboratorRepository</param>
        public CollaboratorManager(ICollaboratorRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Collaborator method is created to access and interact with the Collaborator Repository
        /// </summary>
        /// <param name="collaborator"> CollaboratorModel is passed as a parameter</param>
        /// <returns> string message as Collaborator is Added or not</returns>
        public async Task<string> Collaborator(CollaboratorModel collaborator)
        {
            try
            {
                return await this.repository.Collaborator(collaborator);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Delete Collaborator method is created to access and interact with the Delete Collaborator Repository
        /// </summary>
        /// <param name="collaboratorid"> collaborator id is taken as parameter</param>
        /// <returns> string message as Collaborator is Deleted or not</returns>
        public async Task<string> DeleteCollaborator(int collaboratorid)
        {
            try
            {
                return await this.repository.DeleteCollaborator(collaboratorid);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get Collaborated Emails method is created to access and interact with the Get Collaborator Repository
        /// </summary>
        /// <param name="noteId">note Id is taken as parameter</param>
        /// <returns>string message as Collaborator is Displayed or not</returns>
        public IEnumerable<CollaboratorModel> GetCollaboratedEmails(int noteId)
        {
            try
            {
                return this.repository.GetCollaboratedEmails(noteId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
