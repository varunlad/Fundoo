using FundooModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
    public interface ILableManager
    {
        Task<string> Lable(LableModel lable);
        Task<string> LableNote(LableModel lable);
        Task<string> RemoveLabel(int labelId);
        Task<string> DeleteLabel(int userId, string labelName);
        Task<string> UpdateLabel(LableModel lableModel);
        IEnumerable<LableModel> GetLabelByNote(int notesId);
        IEnumerable<LableModel> GetLabelByUserId(int userId);
    }
}