using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository repository;
        public NotesManager(INotesRepository repository)
        {
            this.repository = repository;
        }
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
        public async Task<string> Update(NotesModel Title)
        {
            try
            {
                return await this.repository.Update(Title);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> NoteArchive(int notes)
        {
            try
            {
                return await this.repository.NoteArchive(notes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
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
