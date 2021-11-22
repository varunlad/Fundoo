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
    public class NotesRepository : INotesRepository
    {
        private readonly UserContext userContext;//UserContext userContext will help me to access UserContext Dbset User which contain data.
        public NotesRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }
        public IConfiguration Configuration { get; }

        public async Task<string> Notes(NotesModel notes)
        {
            try
            {
                var validUserID = this.userContext.UsersTable.Where(x => x.UserId == notes.UserID).FirstOrDefault();
                if (validUserID != null)
                {
                    if (notes != null)
                    {
                        // Add the data to the database
                        this.userContext.Add(notes);
                        // Save the change in database
                        await this.userContext.SaveChangesAsync();
                        return "Notes are added Successfully";
                    }
                    return "Notes are not added";
                }
                return "No such UserId Present in the Database";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
