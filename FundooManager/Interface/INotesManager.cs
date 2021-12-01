//// --------------------------------------------------------------------------------------------------------
// <copyright file="INotesManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooManager.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooModel;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// INotesManager is an Interface class of NotesManager created to give reference to Controller .
    /// </summary>
    public interface INotesManager
    {
        /// <summary>
        /// Notes method is created to access and interact with the Notes Repository
        /// </summary>
        /// <param name="notes">NotesModel is taken as parameter</param>
        /// <returns>string message as Note is Added or not</returns>
        Task<string> Notes(NotesModel notes);

        /// <summary>
        /// NotesUpdate method is created to access and interact with the NotesUpdate Repository
        /// </summary>
        /// <param name="title">NotesModel is taken as parameter</param>
        /// <returns>string message as Note is Updated or not</returns>
        Task<string> Update(NotesModel title);

        /// <summary>
        /// Update color method is created to access and interact with the Update color Repository
        /// </summary>
        /// <param name="noteId">note Id is taken as parameter</param>
        /// <param name="colour">color is taken as parameter</param>
        /// <returns>string message as color is Updated or not</returns>
        Task<string> Updatecolor(int noteId, string colour);

        /// <summary>
        /// NotesUpdate method is created to access and interact with the NotesUpdate Repository
        /// </summary>
        /// <param name="noteId">note id is taken as parameter</param>
        /// <returns>string message as Note is Archive or not</returns>
        Task<string> NoteArchive(int noteId);

        /// <summary>
        /// Pinned method is created to access and interact with the Pinned Repository
        /// </summary>
        /// <param name="noteId">note Id is taken as parameter</param>
        /// <returns>string message as Note is Pinned or not</returns>
        Task<string> Pinned(int noteId);

        /// <summary>
        /// Trash method is created to access and interact with the Trash Repository
        /// </summary>
        /// <param name="notesId">notes Id is taken as parameter</param>
        /// <returns>string message as Note is Trash or not</returns>
        Task<string> Trash(int notesId);

        /// <summary>
        /// PermanentRemove method is created to access and interact with the PermanentRemove Repository
        /// </summary>
        /// <param name="notesId">notes Id is taken as parameter</param>
        /// <returns>string message as Note is Permanent Removed or not</returns>
        Task<string> PermanantRemove(int notesId);

        /// <summary>
        /// Remainder method is created to access and interact with the Remainder Repository
        /// </summary>
        /// <param name="noteId">note Id is taken as parameter</param>
        /// <param name="remainder">remainder is taken as parameter</param>
        /// <returns>string message as Notes is Permanent Remove or not</returns>
        Task<string> Remainder(int noteId, string remainder);

        /// <summary>
        /// GetUserNotes method is created to access and interact with the GetUserNotes of Repository
        /// </summary>
        /// <param name="userid">user id is taken as parameter</param>
        /// <returns>string message as Notes is Displayed or not</returns>
        IEnumerable<NotesModel> GetUserNotes(int userid);

        /// <summary>
        /// GetArchiveNotes method is created to access and interact with the GetArchiveNotes of Repository
        /// </summary>
        /// <param name="userid">user id is taken as parameter</param>
        /// <returns>string message as Archive Notes is Displayed or not</returns>
        IEnumerable<NotesModel> GetArchieveNotes(int userid);

        /// <summary>
        /// GetTrashNotes method is created to access and interact with the GetTrashNotes of Repository
        /// </summary>
        /// <param name="userid">user id is taken as parameter</param>
        /// <returns>string message as Trash Notes is Displayed or not</returns>
        IEnumerable<NotesModel> GetTrashNotes(int userid);

        /// <summary>
        /// GetRemainder method is created to access and interact with the GetRemainder of Repository
        /// </summary>
        /// <param name="userid">user id is taken as parameter</param>
        /// <returns>string message as Remainder Notes is Displayed or not</returns>
        IEnumerable<NotesModel> GetRemainder(int userid);

        /// <summary>
        /// AddImage Method is created to access and interact with the AddImage of Repository
        /// </summary>
        /// <param name="noteId">note Id to specify the Note</param>
        /// <param name="form"> form to make it in string form</param>
        /// <returns>String message informing weather the Image is Added or not.</returns>
        Task<string> AddImage(int noteId, IFormFile form);
    }
}