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
        Task<string> Update(NotesModel Title);
        Task<string> Updatecolor(int noteId, string colour);
        Task<string> NoteArchive(int noteId);
        Task<string> Pinned(int notesId);
        Task<string> Trash(int notesId);
        Task<string> PermanantRemove(int notesId);
        Task<string> Remainder(int noteId, string remainder);
        IEnumerable<NotesModel> GetUserNotes(int userid);
        IEnumerable<NotesModel> GetArchieveNotes(int userid);
        IEnumerable<NotesModel> GetTrashNotes(int userid);
        Task<string> AddImage(int noteId, IFormFile form);
        IEnumerable<NotesModel> GetRemainder(int userid);
    }
}