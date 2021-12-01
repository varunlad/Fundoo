//// --------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooManager.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooModel;

    /// <summary>
    /// ICollaboratorManager is an Interface class of CollaboratorManager created to give reference to Controller .
    /// </summary>
    public interface ICollaboratorManager
    {
        /// <summary>
        /// Collaborator method is created to access and interact with the Collaborator Repository
        /// </summary>
        /// <param name="collaborator"> CollaboratorModel is passed as a parameter</param>
        /// <returns> string message as Collaborator is Added or not</returns>
        Task<string> Collaborator(CollaboratorModel collaborator);

        /// <summary>
        /// Delete Collaborator method is created to access and interact with the Delete Collaborator Repository
        /// </summary>
        /// <param name="collaboratorid"> collaborator id is taken as parameter</param>
        /// <returns> string message as Collaborator is Deleted or not</returns>
        Task<string> DeleteCollaborator(int collaboratorid);

        /// <summary>
        /// Get Collaborated Emails method is created to access and interact with the Get Collaborator Repository
        /// </summary>
        /// <param name="noteId">note Id is taken as parameter</param>
        /// <returns>string message as Collaborator is Displayed or not</returns>
        IEnumerable<CollaboratorModel> GetCollaboratedEmails(int noteId);
    }
}