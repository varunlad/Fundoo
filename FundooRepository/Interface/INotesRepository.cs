using FundooModel;
using Microsoft.Extensions.Configuration;
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
    }
}