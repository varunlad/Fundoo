//// --------------------------------------------------------------------------------------------------------
// <copyright file="INotesRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooRepository.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooModel;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// INotesRepository is an Interface class of NotesRepository created to give reference to Manager .
    /// </summary>
    public interface INotesRepository
    {
        /// <summary>
        /// Notes Method is created to create and add Notes to the particular note ID.
        /// </summary>
        /// <param name="notes">It takes NotesModel as a parameter.</param>
        /// <returns> String informing weather the Notes is added or not.</returns>
        Task<string> Notes(NotesModel notes);

        /// <summary>
        /// Update Method is created to update Notes to the particular note ID.
        /// </summary>
        /// <param name="update">It takes NotesModel as a parameter.</param>
        /// <returns>String informing weather the Notes is updated or not.</returns>
        Task<string> Update(NotesModel update);

        /// <summary>
        /// Update color Method is created to update Color to the particular note ID.
        /// </summary>
        /// <param name="noteId"> noteID to specify the Note</param>
        /// <param name="colour"> Color to update it.</param>
        /// <returns>String informing weather the Color is updated or not.</returns>
        Task<string> Updatecolor(int noteId, string colour);

        /// <summary>
        /// Note Archive Method is created to make our Note Archive
        /// </summary>
        /// <param name="noteId"> noteID to specify the Note</param>
        /// <returns>String informing weather the Note is Archive or not.</returns>
        Task<string> NoteArchive(int noteId);

        /// <summary>
        ///  Pinned Method is created to make our Note Pinned
        /// </summary>
        /// <param name="notesId"> noteID to specify the Note</param>
        /// <returns>String informing weather the Note is Pinned or not.</returns>
        Task<string> Pinned(int notesId);

        /// <summary>
        ///  Trash Method is created to make our Note Trash
        /// </summary>
        /// <param name="notesId"> noteID to specify the Note</param>
        /// <returns>String informing weather the Note is Trash or not.</returns>
        Task<string> Trash(int notesId);

        /// <summary>
        /// permanent Remove Method is created to make our Note Permanent Trash
        /// </summary>
        /// <param name="notesId">noteID to specify the Note</param>
        /// <returns>String informing weather the Note is permanent Remove or not.</returns>
        Task<string> PermanantRemove(int notesId);

        /// <summary>
        /// Remainder Method is created to set Remainder to our Note.
        /// </summary>
        /// <param name="noteId">noteID to specify the Note</param>
        /// <param name="remainder">remainder to set the remainder</param>
        /// <returns>String informing weather the Note is set as Remainder or not </returns>
        Task<string> Remainder(int noteId, string remainder);

        /// <summary>
        ///  Get User Notes Method is created to get notes for that User.
        /// </summary>
        /// <param name="userid">user id to specify the User</param>
        /// <returns>All the Notes for that User Id</returns>
        IEnumerable<NotesModel> GetUserNotes(int userid);

        /// <summary>
        /// Get Archive Notes  Method is created to get notes which are Archive.
        /// </summary>
        /// <param name="userid">user Id to specify the Note</param>
        /// <returns>All the Notes which are Archive</returns>
        IEnumerable<NotesModel> GetArchieveNotes(int userid);

        /// <summary>
        /// Get Trash Notes Method is created to get notes which are Trash.
        /// </summary>
        /// <param name="userid">user Id to specify the Note</param>
        /// <returns>All the Notes which are Trash</returns>
        IEnumerable<NotesModel> GetTrashNotes(int userid);

        /// <summary>
        /// Add Image Method is to Add Image for that Note.
        /// </summary>
        /// <param name="noteId">note Id to specify the Note</param>
        /// <param name="form"> form to make it in string form</param>
        /// <returns>String message informing weather the Image is Added or not.</returns>
        Task<string> AddImage(int noteId, IFormFile form);

        /// <summary>
        /// Get Remainder Method is created to get notes which have Remainder.
        /// </summary>
        /// <param name="userid">user Id to specify the Note</param>
        /// <returns>All the Notes which have Remainder</returns>
        IEnumerable<NotesModel> GetRemainder(int userid);
    }
}