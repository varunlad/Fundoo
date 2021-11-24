using FundooModel;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FundooRepository.Interface
{
    public interface IUserRepository
    {
        IConfiguration Configuration { get; }

        Task<string> Register(RegisterModel userData);
        string LogIn(LoginModel logIn);
        string JWTToken(string email);
        Task<string> ResetPassword(ResetPasswordModel reset);
        string ForgotPassword(string email);
    }
}