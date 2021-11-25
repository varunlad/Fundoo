using FundooModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooRepository.Interface
{
    public interface INotesRepository
    {
        IConfiguration Configuration { get; }

        Task<string> Notes(NotesModel notes);
        Task<string> Update(NotesModel update);
        Task<string> NoteArchive(NotesModel noteId);
        Task<string> Updatecolor(NotesModel colorupdate);
        Task<string> Pinned(NotesModel notesId);
        Task<string> Trash(NotesModel notesId);
        Task<string> PermanantRemove(NotesModel notesId);
        Task<string> Remainder(NotesModel notes);
        List<string> GetUserNotes(int userid);
        List<string> GetArchieveNotes(int userid);
        List<string> GetTrashNotes(int userid);
        Task<string> AddImage(int noteId, IFormFile form);
    }
}