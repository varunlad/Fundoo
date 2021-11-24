using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interface;
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
        public async Task<string> NoteArchive(NotesModel notes)
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
        public async Task<string> UpdateColor(NotesModel notes)
        {
            try
            {
                return await this.repository.Updatecolor(notes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> Pinned(NotesModel notes)
        {
            try
            {
                return await this.repository.Pinned(notes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> PermanantRemove(NotesModel notes)
        {
            try
            {
                return await this.repository.PermanantRemove(notes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> Trash(NotesModel notes)
        {
            try
            {
                return await this.repository.Trash(notes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> Remainder(NotesModel notes)
        {
            try
            {
                return await this.repository.Remainder(notes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
