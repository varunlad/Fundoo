using FundooModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
    public interface INotesManager
    {
        Task<string> Notes(NotesModel notes);
        Task<string> Update(NotesModel Title);
        Task<string> NoteArchive(NotesModel notes);
        Task<string> UpdateColor(NotesModel notes);
        Task<string> Pinned(NotesModel notesId);
        Task<string> Trash(NotesModel notes);
        Task<string> PermanantRemove(NotesModel notes);
        Task<string> Remainder(NotesModel notes);
        List<string> GetUserNotes(int userid);
        List<string> GetArchieveNotes(int userid);
        List<string> GetTrashNotes(int userid);
        Task<string> AddImage(int noteId, IFormFile form);
    }
}