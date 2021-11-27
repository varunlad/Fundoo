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
    }
}
