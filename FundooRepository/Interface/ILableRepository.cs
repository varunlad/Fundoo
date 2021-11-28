using FundooModel;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooRepository.Interface
{
    public interface ILableRepository
    {
        IConfiguration Configuration { get; }

        Task<string> Lable(LableModel lable);
        Task<string> RemoveLabel(int labelId);
        Task<string> DeleteLabel(int userId, string labelName);
        Task<string> LableNote(LableModel lable);
        Task<string> UpdateLabel(LableModel lableModel);
        IEnumerable<LableModel> GetLabelByNote(int notesId);
        IEnumerable<LableModel> GetLabelByUserId(int userId);
    }
}