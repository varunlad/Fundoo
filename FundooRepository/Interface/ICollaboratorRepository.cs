using FundooModel;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FundooRepository.Interface
{
    public interface ICollaboratorRepository
    {
        IConfiguration Configuration { get; }

        Task<string> Collaborator(CollaboratorModel collaborator);
    }
}