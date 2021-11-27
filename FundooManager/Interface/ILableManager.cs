using FundooModel;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
    public interface ILableManager
    {
        Task<string> Lable(LableModel lable);
    }
}