using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public class CollaboratorManager : ICollaboratorManager
    {
        private readonly ICollaboratorRepository repository;
        public CollaboratorManager(ICollaboratorRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Collaborator(CollaboratorModel collaborator)
        {
            try
            {
                return await this.repository.Collaborator(collaborator);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> DeleteCollaborator(int collaborator)
        {
            try
            {
                return await this.repository.DeleteCollaborator(collaborator);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IEnumerable<CollaboratorModel> GetCollaboratedEmails(int noteId)
        {
            try
            {
                return this.repository.GetCollaboratedEmails(noteId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
