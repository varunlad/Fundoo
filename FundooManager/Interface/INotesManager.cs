using FundooModel;
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
    }
}