//// --------------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooManager.Interface
{
    using System.Threading.Tasks;
    using FundooModel;

    /// <summary>
    /// IUserManager is an Interface class of UserManager created to give reference to Controller .
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Register method is created to access and interact with the Register Repository
        /// </summary>
        /// <param name="userData">RegistrationModel is taken as parameter</param>
        /// <returns>string message as User is Register or not</returns>
        Task<string> Register(RegisterModel userData);

        /// <summary>
        /// LogIn method is created to access and interact with the LogIn Repository
        /// </summary>
        /// <param name="login">LoginModel is passed as a parameter</param>
        /// <returns>string message as User has LogIn or not</returns>
        string LogIn(LoginModel login);

        /// <summary>
        /// JWTToken method is created to access and interact with the JWTToken Repository
        /// </summary>
        /// <param name="email">email is taken as a parameter</param>
        /// <returns>string message as JWT token is generated or not</returns>
        string JWTToken(string email);

        /// <summary>
        /// ResetPassword method is created to access and interact with the ResetPassword Repository
        /// </summary>
        /// <param name="reset">ResetPasswordModel is taken as parameter</param>
        /// <returns>string message as User Password has Reset or not</returns>
        Task<string> ResetPassword(ResetPasswordModel reset);

        /// <summary>
        /// ForgotPassword method is created to access and interact with the ForgotPassword Repository
        /// </summary>
        /// <param name="email">email is taken as a parameter</param>
        /// <returns>string message as email send or not</returns>
        string ForgotPassword(string email);
    }
}