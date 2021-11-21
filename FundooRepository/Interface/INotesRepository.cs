using FundooModel;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Repository
{
    public interface INotesRepository
    {
        IConfiguration Configuration { get; }

        string Notes(NotesModel notes);
    }
}