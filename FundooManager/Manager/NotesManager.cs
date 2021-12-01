//// --------------------------------------------------------------------------------------------------------
// <copyright file="NotesManager.cs" company="Bridgelabz">
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
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Notes Manager class is created as it is the Business Logic Layer and takes the return statement from Repository. 
    /// </summary>
    public class NotesManager : INotesManager
    {
        /// <summary>
        /// INotesRepository will help me to access the Methods of Repository Class.
        /// </summary>
        private readonly INotesRepository repository;

        /// <summary>
        ///  Initializes a new instance of the <see cref="NotesManager"/> class created the instance of repository.
        /// </summary>
        /// <param name="repository">>passing the object of INotesRepository</param>
        public NotesManager(INotesRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Notes method is created to access and interact with the Notes Repository
        /// </summary>
        /// <param name="notes">NotesModel is taken as parameter</param>
        /// <returns>string message as Note is Added or not</returns>
        public async Task<string> Notes(NotesModel notes)
        {
            try
            {
                return await this.repository.Notes(notes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// NotesUpdate method is created to access and interact with the NotesUpdate Repository
        /// </summary>
        /// <param name="title">NotesModel is taken as parameter</param>
        /// <returns>string message as Note is Updated or not</returns>
        public async Task<string> Update(NotesModel title)
        {
            try
            {
                return await this.repository.Update(title);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// NotesUpdate method is created to access and interact with the NotesUpdate Repository
        /// </summary>
        /// <param name="noteid">note id is taken as parameter</param>
        /// <returns>string message as Note is Archive or not</returns>
        public async Task<string> NoteArchive(int noteid)
        {
            try
            {
                return await this.repository.NoteArchive(noteid);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Pinned method is created to access and interact with the Pinned Repository
        /// </summary>
        /// <param name="notesId">notes Id is taken as parameter</param>
        /// <returns>string message as Note is Pinned or not</returns>
        public async Task<string> Pinned(int notesId)
        {
            try
            {
                return await this.repository.Pinned(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Update color method is created to access and interact with the Update color Repository
        /// </summary>
        /// <param name="noteId">note Id is taken as parameter</param>
        /// <param name="colour">color is taken as parameter</param>
        /// <returns>string message as color is Updated or not</returns>
        public async Task<string> Updatecolor(int noteId, string colour)
        {
            try
            {
                return await this.repository.Updatecolor(noteId, colour);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// PermanentRemove method is created to access and interact with the PermanentRemove Repository
        /// </summary>
        /// <param name="notesId">notes Id is taken as parameter</param>
        /// <returns>string message as Note is Permanent Removed or not</returns>
        public async Task<string> PermanantRemove(int notesId)
        {
            try
            {
                return await this.repository.PermanantRemove(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Trash method is created to access and interact with the Trash Repository
        /// </summary>
        /// <param name="notesId">notes Id is taken as parameter</param>
        /// <returns>string message as Note is Trash or not</returns>
        public async Task<string> Trash(int notesId)
        {
            try
            {
                return await this.repository.Trash(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Remainder method is created to access and interact with the Remainder Repository
        /// </summary>
        /// <param name="noteId">note Id is taken as parameter</param>
        /// <param name="remainder">remainder is taken as parameter</param>
        /// <returns>string message as Note is set as Remainder or not</returns>
        public async Task<string> Remainder(int noteId, string remainder)
        {
            try
            {
                return await this.repository.Remainder(noteId, remainder);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// GetUserNotes method is created to access and interact with the GetUserNotes of Repository
        /// </summary>
        /// <param name="userid">user id is taken as parameter</param>
        /// <returns>string message as Notes is Displayed or not</returns>
        public IEnumerable<NotesModel> GetUserNotes(int userid)
        {
            try
            {
                return this.repository.GetUserNotes(userid);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// GetArchiveNotes method is created to access and interact with the GetArchiveNotes of Repository
        /// </summary>
        /// <param name="userid">user id is taken as parameter</param>
        /// <returns>string message as Archive Notes is Displayed or not</returns>
        public IEnumerable<NotesModel> GetArchieveNotes(int userid)
        {
            try
            {
                return this.repository.GetArchieveNotes(userid);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// GetTrashNotes method is created to access and interact with the GetTrashNotes of Repository
        /// </summary>
        /// <param name="userid">user id is taken as parameter</param>
        /// <returns>string message as Trash Notes is Displayed or not</returns>
        public IEnumerable<NotesModel> GetTrashNotes(int userid)
        {
            try
            {
                return this.repository.GetTrashNotes(userid);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// GetRemainder method is created to access and interact with the GetRemainder of Repository
        /// </summary>
        /// <param name="userid">user id is taken as parameter</param>
        /// <returns>string message as Remainder Notes is Displayed or not</returns>
        public IEnumerable<NotesModel> GetRemainder(int userid)
        {
            try
            {
                return this.repository.GetRemainder(userid);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// AddImage Method is created to access and interact with the AddImage of Repository
        /// </summary>
        /// <param name="noteId">note Id to specify the Note</param>
        /// <param name="form"> form to make it in string form</param>
        /// <returns>String message informing weather the Image is Added or not.</returns>
        public Task<string> AddImage(int noteId, IFormFile form)
        {
            try
            {
                return this.repository.AddImage(noteId, form);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
