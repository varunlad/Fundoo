using FundooModel;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
    public interface INotesManager
    {
        Task<string> Notes(NotesModel notes);
    }
}