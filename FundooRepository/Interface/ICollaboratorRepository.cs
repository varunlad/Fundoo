//// --------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooRepository.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooModel;

    /// <summary>
    /// ICollaboratorRepository is an Interface class of CollaboratorRepository created to give reference to Manager .
    /// </summary>
    public interface ICollaboratorRepository
    {
        /// <summary>
        /// Collaborator Method is Created to add a collaborator Email for that note.
        /// </summary>
        /// <param name="collaborator"> Collaborator Model is passed as parameter</param>
        /// <returns> string message as Collaborator is Added or not</returns>
        Task<string> Collaborator(CollaboratorModel collaborator);

        /// <summary>
        /// Delete Collaborator Method is Created to Delete a collaborator Email for that note.
        /// </summary>
        /// <param name="collaborator"> Collaborator Id is Passed as a parameter</param>
        /// <returns>string message as Collaborator is Deleted or not</returns>
        Task<string> DeleteCollaborator(int collaborator);

        /// <summary>
        /// Get Collaborated Emails method is created to get all Collaborator Email.
        /// </summary>
        /// <param name="noteId">note Id is passed as parameter.</param>
        /// <returns>Get all the emails of that Note Id</returns>
        IEnumerable<CollaboratorModel> GetCollaboratedEmails(int noteId);
    }
}