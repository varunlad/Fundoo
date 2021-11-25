using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly UserContext userContext;//UserContext userContext will help me to access UserContext Dbset User which contain data.
        public CollaboratorRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }
        public IConfiguration Configuration { get; }
        public async Task<string> Collaborator(CollaboratorModel collaborator)
        {
            try
            {
                if (collaborator != null)
                {
                    // Add the data to the database
                    this.userContext.Add(collaborator);
                    // Save the change in database
                    await this.userContext.SaveChangesAsync();
                    return "Email is added Successfully";
                }
                return "Email is not added";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> DeleteCollaborator(int collaborator)
        {
            try
            {
                var validCollabID = this.userContext.Collaborator.Where(x => x.CollaboratorID == collaborator).FirstOrDefault();
                if (validCollabID != null)
                {
                    if (collaborator != 0)
                    {
                        // Add the data to the database
                        this.userContext.Remove(validCollabID);
                        // Save the change in database
                        await this.userContext.SaveChangesAsync();
                        return "Email is Deleted";
                    }
                    return "Email is not added";
                }
                return "Collaborator ID Does not Deleted";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<string> GetCollaboratedEmails(int collaborator)
        {
            try
            {

                List<string> listofEmails = new List<string>();
                if (collaborator != 0)
                {
                    IEnumerable<CollaboratorModel> notes = from x in this.userContext.Collaborator where x.NoteID == collaborator select x;
                    foreach (var note in notes)
                    {

                        if (note.NoteID != 0)
                        {
                            string result = note.NoteID + " Email " + note.EmailID;
                            listofEmails.Add(result);
                        }

                    }
                    return listofEmails;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
