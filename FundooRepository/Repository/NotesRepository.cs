using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interface;
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
                var validNotesID = this.userContext.NotesTable.Where(x => x.NoteID == update.NoteID).FirstOrDefault();
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
                var archivedNote = this.userContext.NotesTable.Where(x => x.NoteID == noteId.NoteID).FirstOrDefault();
                if (archivedNote != null)
                {
                    if (archivedNote.Archieve == false)
                    {
                        archivedNote.Archieve = true;
                        if (archivedNote.Pin == true)
                        {
                            archivedNote.Pin = false;
                            this.userContext.NotesTable.Update(archivedNote);
                            await this.userContext.SaveChangesAsync();
                            return "Notes unpinned and moved to Archived";
                        }
                        else
                        {
                            this.userContext.NotesTable.Update(archivedNote);
                            await this.userContext.SaveChangesAsync();
                            return "Note archived";
                        }
                    }
                    else
                    {
                        archivedNote.Archieve = false;
                        this.userContext.NotesTable.Update(archivedNote);
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
    }
}
