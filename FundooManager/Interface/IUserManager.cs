using FundooModel;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
    public interface IUserManager
    {
        Task<string> Register(RegisterModel userData);
        string LogIn(LoginModel logIn);
        string JWTToken(string email);
        Task<string> ResetPassword(ResetPasswordModel reset);
        string ForgotPassword(string email);
    }
}