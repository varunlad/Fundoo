using FundooModel;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooRepository.Interface
{
    public interface ICollaboratorRepository
    {
        IConfiguration Configuration { get; }

        Task<string> Collaborator(CollaboratorModel collaborator);
        Task<string> DeleteCollaborator(int collaborator);
        IEnumerable<CollaboratorModel> GetCollaboratedEmails(int noteId);
    }
}