using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly UserContext userContext;//UserContext userContext will help me to access UserContext Dbset User which contain data.
        public NotesRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }
        public IConfiguration Configuration { get; }

        public async Task<string> Notes(NotesModel notes)
        {
            try
            {
                // Add the data to the database
                this.userContext.Add(notes);
                // Save the change in database
                await this.userContext.SaveChangesAsync();
                return "Notes are added Successfully";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> Update(NotesModel update)
        {
            try
            {
                var validNotesID = this.userContext.Notes.Where(x => x.NoteID == update.NoteID).FirstOrDefault();
                if (update != null)
                {
                    validNotesID.Title = update.Title;
                    validNotesID.AddNotes = update.AddNotes;
                    // Add the data to the database
                    this.userContext.Update(validNotesID);
                    // Save the change in database
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
        public async Task<string> Updatecolor(int noteId, string colour)//int
        {
            try
            {
                var validNotesID = this.userContext.Notes.Where(x => x.NoteID == noteId).FirstOrDefault();
                if (validNotesID != null)
                {
                    validNotesID.Color = colour;
                    // Add the data to the database
                    this.userContext.Update(validNotesID);
                    // Save the change in database
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
        public async Task<string> Pinned(int notesId)
        {
            try
            {
                string result;
                var ValidNoteId = this.userContext.Notes.Where(x => x.NoteID == notesId).FirstOrDefault();
                if (ValidNoteId != null)
                {
                    if (ValidNoteId.Pin == false)
                    {
                        ValidNoteId.Pin = true;
                        if (ValidNoteId.Archieve == true)
                        {
                            ValidNoteId.Archieve = false;
                            result = "Notes unarchieved and pinned";
                        }
                        else if (ValidNoteId.Trash == true)
                        {
                            ValidNoteId.Trash = false;
                            result = "Note removed from Trashed and pinned";
                        }
                        else
                        {
                            result = "Note Pinned";
                        }

                    }
                    else
                    {
                        ValidNoteId.Pin = false;
                        result = "Note unpinned";
                    }
                    this.userContext.Notes.Update(ValidNoteId);
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
        public async Task<string> Trash(int notesId)
        {
            try
            {
                string result;
                var ValidNoteId = this.userContext.Notes.Where(x => x.NoteID == notesId).FirstOrDefault();
                if (ValidNoteId != null)
                {
                    if (ValidNoteId.Trash == false)
                    {
                        ValidNoteId.Trash = true;
                        if (ValidNoteId.Archieve == true)
                        {
                            ValidNoteId.Archieve = false;
                            result = "Notes unarchieved and Trash";
                        }
                        else if (ValidNoteId.Pin == true)
                        {
                            ValidNoteId.Pin = false;
                            result = "Notes unpined and Trash";
                        }
                        else
                        {
                            result = "Note Trash";
                        }
                    }
                    else
                    {
                        ValidNoteId.Trash = false;

                        result = "Note Remove from Trash";
                    }
                    this.userContext.Notes.Update(ValidNoteId);
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
        public async Task<string> PermanantRemove(int notesId)
        {
            try
            {
                var ValidNoteId = this.userContext.Notes.Where(x => x.NoteID == notesId).FirstOrDefault();
                if (ValidNoteId != null)
                {
                    if (ValidNoteId.Trash == true)
                    {
                        this.userContext.Notes.Remove(ValidNoteId);
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
        public async Task<string> Remainder(int noteId, string remainder)//int ,string
        {
            try
            {
                var validNotesID = this.userContext.Notes.Where(x => x.NoteID == noteId).FirstOrDefault();
                if (validNotesID != null)
                {
                    validNotesID.Remainder = remainder;
                    // Add the data to the database
                    this.userContext.Update(validNotesID);
                    // Save the change in database
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
                    return "This note doesn't Exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
