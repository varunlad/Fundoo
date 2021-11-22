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
    }
}