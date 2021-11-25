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
                var validUserID = this.userContext.UsersTable.Where(x => x.UserId == notes.UserID).FirstOrDefault();
                if (validUserID != null)
                {
                    if (notes != null)
                    {
                        // Add the data to the database
                        this.userContext.Add(notes);
                        // Save the change in database
                        await this.userContext.SaveChangesAsync();
                        return "Notes are added Successfully";
                    }
                    return "Notes are not added";
                }
                return "No such UserId Present in the Database";
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
        public async Task<string> NoteArchive(NotesModel noteId)
        {
            try
            {
                var archivedNote = this.userContext.Notes.Where(x => x.NoteID == noteId.NoteID).FirstOrDefault();
                if (archivedNote != null)
                {
                    if (archivedNote.Archieve == false)
                    {
                        archivedNote.Archieve = true;
                        if (archivedNote.Pin == true)
                        {
                            archivedNote.Pin = false;
                            this.userContext.Notes.Update(archivedNote);
                            await this.userContext.SaveChangesAsync();
                            return "Notes unpinned and moved to Archived";
                        }
                        else
                        {
                            this.userContext.Notes.Update(archivedNote);
                            await this.userContext.SaveChangesAsync();
                            return "Note archived";
                        }
                    }
                    else
                    {
                        archivedNote.Archieve = false;
                        this.userContext.Notes.Update(archivedNote);
                        await this.userContext.SaveChangesAsync();
                        return "Note unarchived";
                    }
                }
                else
                {
                    return "This note does not exist";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> Updatecolor(NotesModel colorupdate)
        {
            try
            {
                var validNotesID = this.userContext.Notes.Where(x => x.NoteID == colorupdate.NoteID).FirstOrDefault();
                if (validNotesID != null)
                {
                    if (colorupdate != null)
                    {
                        validNotesID.Color = colorupdate.Color;
                        // Add the data to the database
                        this.userContext.Update(validNotesID);
                        // Save the change in database
                        await this.userContext.SaveChangesAsync();

                        return "color has Updated";
                    }
                    return "color are not updated";
                }
                return "NoteID Does Not Exits";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> Pinned(NotesModel notesId)
        {
            try
            {
                var ValidNoteId = this.userContext.Notes.Where(x => x.NoteID == notesId.NoteID).FirstOrDefault();
                if (ValidNoteId != null)
                {
                    if (ValidNoteId.Pin == false)
                    {
                        ValidNoteId.Pin = true;
                        if (ValidNoteId.Archieve == true)
                        {
                            ValidNoteId.Archieve = false;
                            this.userContext.Notes.Update(ValidNoteId);
                            await this.userContext.SaveChangesAsync();
                            return "Notes unarchieved and pinned";
                        }
                        else if(ValidNoteId.Trash == true)
                        {
                            ValidNoteId.Trash = false;
                            this.userContext.Notes.Update(ValidNoteId);
                            await this.userContext.SaveChangesAsync();
                            return "Note pinned";
                        }
                    }
                    else
                    {
                        ValidNoteId.Pin = false;
                        this.userContext.Notes.Update(ValidNoteId);
                        await this.userContext.SaveChangesAsync();
                        return "Note unpinned";
                    }
                }
                return "This note does not exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> Trash(NotesModel notesId)
        {
            try
            {
                var ValidNoteId = this.userContext.Notes.Where(x => x.NoteID == notesId.NoteID).FirstOrDefault();
                if (ValidNoteId != null)
                {
                    if (ValidNoteId.Trash == false)
                    {
                        ValidNoteId.Trash = true;
                        if (ValidNoteId.Archieve == true)
                        {
                            ValidNoteId.Archieve = false;
                            this.userContext.Notes.Update(ValidNoteId);
                            await this.userContext.SaveChangesAsync();
                            return "Notes unarchieved and Trash";
                        }
                        else if (ValidNoteId.Pin == true)
                        {
                            ValidNoteId.Pin = false;
                            this.userContext.Notes.Update(ValidNoteId);
                            await this.userContext.SaveChangesAsync();
                            return "Notes unpined and Trash";
                        }
                        else
                        {
                            this.userContext.Notes.Update(ValidNoteId);
                            await this.userContext.SaveChangesAsync();
                            return "Note Trash";
                        }
                    }
                    else
                    {
                        ValidNoteId.Trash = false;
                        this.userContext.Notes.Update(ValidNoteId);
                        await this.userContext.SaveChangesAsync();
                        return "Note Remove from Trash";
                    }
                }
                return "This note does not exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> PermanantRemove(NotesModel notesId)
        {
            try
            {
                var ValidNoteId = this.userContext.Notes.Where(x => x.NoteID == notesId.NoteID).FirstOrDefault();
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
        public async Task<string> Remainder(NotesModel notes)
        {
            try
            {
                var validNotesID = this.userContext.Notes.Where(x => x.NoteID == notes.NoteID).FirstOrDefault();
                if (validNotesID != null)
                {
                    if (notes != null)
                    {
                        validNotesID.Remainder = notes.Remainder;
                        // Add the data to the database
                        this.userContext.Update(validNotesID);
                        // Save the change in database
                        await this.userContext.SaveChangesAsync();

                        return "Remainder is Set";
                    }
                    return "Remainder is not Set";
                }
                return "NoteID Does Not Exits";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<string> GetUserNotes(int userid)
        {
            try
            {

                List<string> listofnotes = new List<string>();
                if (userid != 0)
                {
                    IEnumerable<NotesModel> notes = from x in this.userContext.Notes where x.UserID == userid select x;
                    foreach (var note in notes)
                    {

                        if (note.Trash != true && note.Archieve != true)
                        {
                            string result = note.NoteID + " Tilte: " + note.Title + "  AddNotes: " + note.AddNotes + "  Archieve: " + note.Archieve + "  Trash : " + note.Trash + "  Note Pined: " + note.Pin +
                              "  Remainder: " + note.Remainder + "  Color: " + note.Color;
                            listofnotes.Add(result);
                        }

                    }
                    return listofnotes;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<string> GetArchieveNotes(int userid)
        {
            try
            {

                List<string> listofnotes = new List<string>();
                if (userid != 0)
                {
                    IEnumerable<NotesModel> notes = from x in this.userContext.Notes where x.UserID == userid select x;
                    foreach (var note in notes)
                    {

                        if (note.Archieve == true)
                        {
                            string result = note.NoteID + " Tilte: " + note.Title + "  AddNotes: " + note.AddNotes + "  Archieve: " + note.Archieve + "  Trash : " + note.Trash + "  Note Pined: " + note.Pin +
                                 "  Remainder: " + note.Remainder + "  Color: " + note.Color;
                            listofnotes.Add(result);
                        }

                    }
                    return listofnotes;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<string> GetTrashNotes(int userid)
        {
            try
            {

                List<string> listofnotes = new List<string>();
                if (userid != 0)
                {
                    IEnumerable<NotesModel> notes = from x in this.userContext.Notes where x.UserID == userid select x;
                    foreach (var note in notes)
                    {

                        if (note.Trash == true)
                        {
                            string result = note.NoteID + " Tilte: " + note.Title + "  AddNotes: " + note.AddNotes + "  Archieve: " + note.Archieve + "  Trash : " + note.Trash + "  Note Pined: " + note.Pin +
                                 "  Remainder: " + note.Remainder + "  Color: " + note.Color;
                            listofnotes.Add(result);
                        }

                    }
                    return listofnotes;
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
