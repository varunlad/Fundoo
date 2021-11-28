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
        public async Task<string> LableNote(LableModel lable)
        {
            try
            {
                var validLabel = this.userContext.LabelsTable.Where(x => x.UserID == lable.UserID && lable.NoteID != null).FirstOrDefault();
                if (validLabel != null)
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
        public async Task<string> RemoveLabel(int labelId)
        {
            try
            {
                var validLabel = this.userContext.LabelsTable.Where(x => x.LableId == labelId).SingleOrDefault();
                if (validLabel != null)
                {
                    this.userContext.LabelsTable.Remove(validLabel);
                    await this.userContext.SaveChangesAsync();
                    return "Deleted Label From Note";
                }

                return "No label present";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> DeleteLabel(int userId, string labelName)
        {
            try
            {
                var validLabel = this.userContext.LabelsTable.Where(x => x.Lable == labelName && x.UserID == userId).ToList();
                if (validLabel != null)
                {
                    this.userContext.LabelsTable.RemoveRange(validLabel);
                    await this.userContext.SaveChangesAsync();
                    return "Label Deleted";
                }

                return "Label not exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<LableModel> GetLabelByNote(int notesId)
        {
            try
            {
                IEnumerable<LableModel> validLabel = this.userContext.LabelsTable.Where(x => x.NoteID == notesId);
                if (validLabel != null)
                {
                    return validLabel;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> UpdateLabel(LableModel lableModel)
        {
            try
            {
                var validLabel = this.userContext.LabelsTable.Where(x => x.LableId == lableModel.LableId).Select(x => x.Lable).SingleOrDefault();
                var oldLabelname = this.userContext.LabelsTable.Where(x => x.Lable == validLabel).ToList();
                oldLabelname.ForEach(x => x.Lable = lableModel.Lable);
                this.userContext.LabelsTable.UpdateRange(oldLabelname);
                await this.userContext.SaveChangesAsync();
                return "Update Successful";
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
        public IEnumerable<LableModel> GetLabelByUserId(int userId)
        {
            try
            {
                IEnumerable<LableModel> validLabel = this.userContext.LabelsTable.Where(x => x.UserID == userId);
                if (validLabel != null)
                {
                    return validLabel;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
