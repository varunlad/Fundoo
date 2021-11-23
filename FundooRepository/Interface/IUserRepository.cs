using FundooModel;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FundooRepository.Interface
{
    public interface IUserRepository
    {
        IConfiguration Configuration { get; }

        Task<string> Register(RegisterModel userData);
        object LogIn(LoginModel logIn);
        Task<string> ResetPassword(ResetPasswordModel reset);
        string ForgotPassword(string email);
    }
}