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
    public class LableRepository : ILableRepository
    {
        private readonly UserContext userContext;//UserContext userContext will help me to access UserContext Dbset User which contain data.
        public LableRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }
        public IConfiguration Configuration { get; }

        public async Task<string> Lable(LableModel lable)
        {
            try
            {
                var validLabel = this.userContext.LabelsTable.Where(x => x.Lable == lable.Lable && lable.NoteID == null).FirstOrDefault();
                if (validLabel == null)
                {
                    // Add the data to the database
                    this.userContext.Add(lable);
                    // Save the change in database
                    await this.userContext.SaveChangesAsync();
                    return "Lable is added Successfully";
                }
                else
                    return "Label name already Exits";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
