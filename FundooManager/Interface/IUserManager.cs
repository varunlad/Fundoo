using FundooModel;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
    public interface IUserManager
    {
        Task<string> Register(RegisterModel userData);
        object LogIn(LoginModel logIn);
        Task<string> ResetPassword(ResetPasswordModel reset);
        string ForgotPassword(string email);
    }
}