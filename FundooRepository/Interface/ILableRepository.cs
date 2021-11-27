using FundooModel;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FundooRepository.Interface
{
    public interface ILableRepository
    {
        IConfiguration Configuration { get; }

        Task<string> Lable(LableModel lable);
    }
}