using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository repository;
        public NotesManager(INotesRepository repository)
        {
            this.repository = repository;
        }
        public string Notes(NotesModel notes)
        {
            try
            {
                return this.repository.Notes(notes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
