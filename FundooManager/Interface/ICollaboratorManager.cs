using FundooModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
    public interface ICollaboratorManager
    {
        Task<string> Collaborator(CollaboratorModel collaborator);
        Task<string> DeleteCollaborator(int collaborator);
        IEnumerable<CollaboratorModel> GetCollaboratedEmails(int noteId);
    }
}