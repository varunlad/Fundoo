using FundooModel;

namespace FundooManager.Interface
{
    public interface IUserManager
    {
        string Register(RegisterModel userData);
    }
}