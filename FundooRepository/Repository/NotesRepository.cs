//// --------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepository.cs" company="Bridgelabz">
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
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using FundooModel;
    using FundooRepository.Context;
    using FundooRepository.Interface;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// NotesRepository class is created it is the Data Access Layer and it filter out the required data from the Database 
    /// </summary>
    public class NotesRepository : INotesRepository
    {
        /// <summary>
        /// UserContext userContext will help me to access UserContext Dbset User which contain data.
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class created the instance of configuration and userContext
        /// </summary>
        /// <param name="configuration">passing the object of IConfiguration</param>
        /// <param name="userContext">passing the object of UserContext</param>
        public NotesRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

        /// <summary>
        /// Gets the Configuration.This is an object for IConfiguration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Notes Method is created to create and add Notes to the particular note ID.
        /// </summary>
        /// <param name="notes">It takes NotesModel as a parameter.</param>
        /// <returns> String informing weather the Notes is added or not.</returns>
        public async Task<string> Notes(NotesModel notes)
        {
            try
            {
                //// Add the data to the database
                this.userContext.Add(notes);
                //// Save the change in databas
                await this.userContext.SaveChangesAsync();
                return "Notes are added Successfully";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update Method is created to update Notes to the particular note ID.
        /// </summary>
        /// <param name="update">It takes NotesModel as a parameter.</param>
        /// <returns>String informing weather the Notes is updated or not.</returns>
        public async Task<string> Update(NotesModel update)
        {
            try
            {
                var validNotesID = this.userContext.Notes.Where(x => x.NoteID == update.NoteID).FirstOrDefault();
                if (update != null)
                {
                    validNotesID.Title = update.Title;
                    validNotesID.AddNotes = update.AddNotes;
                    //// Add the data to the database
                    this.userContext.Update(validNotesID);
                    //// Save the change in database
                    await this.userContext.SaveChangesAsync();

                    return "Notes has Updated";
                }

                return "Notes are not updated";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update color Method is created to update Color to the particular note ID.
        /// </summary>
        /// <param name="noteId"> noteID to specify the Note</param>
        /// <param name="colour"> Color to update it.</param>
        /// <returns>String informing weather the Color is updated or not.</returns>
        public async Task<string> Updatecolor(int noteId, string colour)
        {
            try
            {
                var validNotesID = this.userContext.Notes.Where(x => x.NoteID == noteId).FirstOrDefault();
                if (validNotesID != null)
                {
                    validNotesID.Color = colour;
                    //// Add the data to the database
                    this.userContext.Update(validNotesID);
                    //// Save the change in database
                    await this.userContext.SaveChangesAsync();

                    return "color has Updated";
                }

                return "color are not updated";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Note Archive Method is created to make our Note Archive
        /// </summary>
        /// <param name="noteId"> noteID to specify the Note</param>
        /// <returns>String informing weather the Note is Archive or not.</returns>
        public async Task<string> NoteArchive(int noteId)
        {
            try
            {
                string result;
                var archivedNote = this.userContext.Notes.Where(x => x.NoteID == noteId).FirstOrDefault();
                if (archivedNote != null)
                {
                    if (archivedNote.Archieve == false)
                    {
                        archivedNote.Archieve = true;
                        if (archivedNote.Pin == true)
                        {
                            archivedNote.Pin = false;
                            result = "Notes unpinned and moved to Archived";
                        }
                        else
                        {
                            result = "Note archived";
                        }
                    }
                    else
                    {
                        archivedNote.Archieve = false;
                        result = "Note unarchived";
                    }

                    this.userContext.Notes.Update(archivedNote);
                    await this.userContext.SaveChangesAsync();
                }
                else
                {
                    result = "This note does not exist";
                }

                return result;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///  Pinned Method is created to make our Note Pinned
        /// </summary>
        /// <param name="notesId"> noteID to specify the Note</param>
        /// <returns>String informing weather the Note is Pinned or not.</returns>
        public async Task<string> Pinned(int notesId)
        {
            try
            {
                string result;
                var validNoteId = this.userContext.Notes.Where(x => x.NoteID == notesId).FirstOrDefault();
                if (validNoteId != null)
                {
                    if (validNoteId.Pin == false)
                    {
                        validNoteId.Pin = true;
                        if (validNoteId.Archieve == true)
                        {
                            validNoteId.Archieve = false;
                            result = "Notes unarchieved and pinned";
                        }
                        else if (validNoteId.Trash == true)
                        {
                            validNoteId.Trash = false;
                            result = "Note removed from Trashed and pinned";
                        }
                        else
                        {
                            result = "Note Pinned";
                        }
                    }
                    else
                    {
                        validNoteId.Pin = false;
                        result = "Note unpinned";
                    }

                    this.userContext.Notes.Update(validNoteId);
                    await this.userContext.SaveChangesAsync();
                }
                else
                {
                    result = "This note does not exist";
                }

                return result;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///  Trash Method is created to make our Note Trash
        /// </summary>
        /// <param name="notesId"> noteID to specify the Note</param>
        /// <returns>String informing weather the Note is Trash or not.</returns>
        public async Task<string> Trash(int notesId)
        {
            try
            {
                string result;
                var validNoteId = this.userContext.Notes.Where(x => x.NoteID == notesId).FirstOrDefault();
                if (validNoteId != null)
                {
                    if (validNoteId.Trash == false)
                    {
                        validNoteId.Trash = true;
                        if (validNoteId.Archieve == true)
                        {
                            validNoteId.Archieve = false;
                            result = "Notes unarchieved and Trash";
                        }
                        else if (validNoteId.Pin == true)
                        {
                            validNoteId.Pin = false;
                            result = "Notes unpined and Trash";
                        }
                        else
                        {
                            result = "Note Trash";
                        }
                    }
                    else
                    {
                        validNoteId.Trash = false;

                        result = "Note Remove from Trash";
                    }

                    this.userContext.Notes.Update(validNoteId);
                    await this.userContext.SaveChangesAsync();
                }
                else
                {
                    result = "This note does not exist";
                }

                return result;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// permanent Remove Method is created to make our Note Permanent Trash
        /// </summary>
        /// <param name="notesId">noteID to specify the Note</param>
        /// <returns>String informing weather the Note is permanent Remove or not.</returns>
        public async Task<string> PermanantRemove(int notesId)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteID == notesId).FirstOrDefault();
                if (validNoteId != null)
                {
                    if (validNoteId.Trash == true)
                    {
                        this.userContext.Notes.Remove(validNoteId);
                        await this.userContext.SaveChangesAsync();
                        return "Notes is Permanant Removed";
                    }
                }

                return "This note does not exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remainder Method is created to set Remainder to our Note.
        /// </summary>
        /// <param name="noteId">noteID to specify the Note</param>
        /// <param name="remainder">remainder to set the remainder</param>
        /// <returns>String informing weather the Note is set as Remainder or not </returns>
        public async Task<string> Remainder(int noteId, string remainder)
        {
            try
            {
                var validNotesID = this.userContext.Notes.Where(x => x.NoteID == noteId).FirstOrDefault();
                if (validNotesID != null)
                {
                    validNotesID.Remainder = remainder;
                    //// Add the data to the database
                    this.userContext.Update(validNotesID);
                    //// Save the change in database
                    await this.userContext.SaveChangesAsync();

                    return "Remainder is Set";
                }

                return "Remainder is not Set";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///  Get User Notes Method is created to get notes for that User.
        /// </summary>
        /// <param name="userid">user id to specify the User</param>
        /// <returns>All the Notes for that User Id</returns>
        public IEnumerable<NotesModel> GetUserNotes(int userid)
        {
            try
            {
                IEnumerable<NotesModel> notes = from x in this.userContext.Notes where x.UserID == userid select x;
                if (notes != null)
                {
                    return notes;
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Archive Notes  Method is created to get notes which are Archive.
        /// </summary>
        /// <param name="userid">user Id to specify the Note</param>
        /// <returns>All the Notes which are Archive</returns>
        public IEnumerable<NotesModel> GetArchieveNotes(int userid)
        {
            try
            {
                IEnumerable<NotesModel> notes = from x in this.userContext.Notes where x.UserID == userid && x.Archieve == true select x;
                if (notes != null)
                {
                    return notes;
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Trash Notes Method is created to get notes which are Trash.
        /// </summary>
        /// <param name="userid">user Id to specify the Note</param>
        /// <returns>All the Notes which are Trash</returns>
        public IEnumerable<NotesModel> GetTrashNotes(int userid)
        {
            try
            {
                IEnumerable<NotesModel> notes = from x in this.userContext.Notes where x.UserID == userid && x.Trash == true select x;
                if (notes != null)
                {
                    return notes;
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Remainder Method is created to get notes which have Remainder.
        /// </summary>
        /// <param name="userid">user Id to specify the Note</param>
        /// <returns>All the Notes which have Remainder</returns>
        public IEnumerable<NotesModel> GetRemainder(int userid)
        {
            try
            {
                IEnumerable<NotesModel> notes = from x in this.userContext.Notes where x.UserID == userid && x.Remainder != null select x;
                if (notes != null)
                {
                    return notes;
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add Image Method is to Add Image for that Note.
        /// </summary>
        /// <param name="noteId">note Id to specify the Note</param>
        /// <param name="form"> form to make it in string form</param>
        /// <returns>String message informing weather the Image is Added or not.</returns>
        public async Task<string> AddImage(int noteId, IFormFile form)
        {
            try
            {
                var availNote = this.userContext.Notes.Where(x => x.NoteID == noteId).SingleOrDefault();
                if (availNote != null)
                {
                    var cloudinary = new Cloudinary(
                                                new Account(
                                                "da7pe7kw5",
                                                "241392584866355",
                                                "anHK4tPEJ7LeVV_PVAiuAg3hMuM"));
                    var addingImage = new ImageUploadParams()
                    {
                        File = new FileDescription(form.FileName, form.OpenReadStream()),
                    };

                    var uploadResult = cloudinary.Upload(addingImage);
                    var uploadPath = uploadResult.Url;
                    availNote.Image = uploadPath.ToString();
                    this.userContext.Notes.Update(availNote);
                    await this.userContext.SaveChangesAsync();
                    return "Image added Successfully";
                }
                else
                {
                    return "This note doesn't Exists";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
