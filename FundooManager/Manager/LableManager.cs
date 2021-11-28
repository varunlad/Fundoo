using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public class LableManager : ILableManager
    {
        private readonly ILableRepository repository;
        public LableManager(ILableRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Lable(LableModel lable)
        {
            try
            {
                return await this.repository.Lable(lable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> LableNote(LableModel lable)
        {
            try
            {
                return await this.repository.LableNote(lable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> RemoveLabel(int labelId)
        {
            try
            {
                return await this.repository.RemoveLabel(labelId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> UpdateLabel(LableModel lableModel)
        {
            try
            {
                return await this.repository.UpdateLabel(lableModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> DeleteLabel(int userId, string labelName)
        {
            try
            {
                return await this.repository.DeleteLabel(userId, labelName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IEnumerable<LableModel> GetLabelByNote(int notesId)
        {
            try
            {
                return this.repository.GetLabelByNote(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IEnumerable<LableModel> GetLabelByUserId(int userId)
        {
            try
            {
                return this.repository.GetLabelByUserId(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
