//// --------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooRepository.Interface
{
    using System.Threading.Tasks;
    using FundooModel;

    /// <summary>
    /// IUserRepository is an Interface class of UserRepository created to give reference to Manager .
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Register Method is created for user registration purpose and parameters taken are First Name,Last Name,Email and Password.
        /// </summary>
        /// <param name="userData"> RegistrationModel is passed as parameter.</param>
        /// <returns>The registration is Successful or not to the manager</returns>
        Task<string> Register(RegisterModel userData);

        /// <summary>
        /// LogIn Method is created for user Login purpose and parameters taken are Email and Password and JWT Token Verification is also applied.
        /// </summary>
        /// <param name="login">LoginModel is passed as parameter</param>
        /// <returns>The Login is Successful or not to the manager</returns>
        string LogIn(LoginModel login);

        /// <summary>
        /// Here the JWT token generation is taken place it is the combination of Header and Payload with Signature.
        /// </summary>
        /// <param name="email"> Passing Users Email as a parameter</param>
        /// <returns>JWT Token</returns>
        string JWTToken(string email);

        /// <summary>
        /// ResetPassword Method is created for resetting the Users Password purpose and parameters taken are Email and New Password.
        /// </summary>
        /// <param name="reset"> Passing ResetPasswordModel as a parameter</param>
        /// <returns>string message "Reset Password Successful"</returns>
        Task<string> ResetPassword(ResetPasswordModel reset);

        /// <summary>
        /// SMTP (Simple Mail Transfer Protocol) is a part of the application layer of the TCP/IP protocol.
        /// It is an Internet standard for electronic mail (email) transmission. The default TCP port used by SMTP is 25 and the SMTP 
        /// Connections secured by SSL(Security socket layer), known as SMTPS, uses the default to port 465.
        /// </summary>
        /// <param name="email">Passing Users email as a parameter</param>
        /// <returns>Send an email to the respected Email Address</returns>
        string ForgotPassword(string email);
    }
}