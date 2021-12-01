//// --------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooManager.Manager
{
    using System;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModel;
    using FundooRepository.Interface;

    /// <summary>
    ///  UserManager class is created as it is the Business Logic Layer and takes the return statement from Repository. 
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// IUserRepository will help me to access the Methods of Repository Class.
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        ///  Initializes a new instance of the <see cref="UserManager"/> class created the instance of repository.
        /// </summary>
        /// <param name="repository">passing the object of IUserRepository</param>
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Register method is created to access and interact with the Register Repository
        /// </summary>
        /// <param name="userData">RegistrationModel is taken as parameter</param>
        /// <returns>string message as User is Register or not</returns>
        public async Task<string> Register(RegisterModel userData)
        {
            try
            {
                return await this.repository.Register(userData);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// LogIn method is created to access and interact with the LogIn Repository
        /// </summary>
        /// <param name="login">LoginModel is passed as a parameter</param>
        /// <returns>string message as User has LogIn or not</returns>
        public string LogIn(LoginModel login)
        {
            try
            {
                return this.repository.LogIn(login);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// JWTToken method is created to access and interact with the JWTToken Repository
        /// </summary>
        /// <param name="email">email is taken as a parameter</param>
        /// <returns>string message as JWT token is generated or not</returns>
        public string JWTToken(string email)
        {
            try
            {
                return this.repository.JWTToken(email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// ResetPassword method is created to access and interact with the ResetPassword Repository
        /// </summary>
        /// <param name="reset">ResetPasswordModel is taken as parameter</param>
        /// <returns>string message as User Password has Reset or not</returns>
        public async Task<string> ResetPassword(ResetPasswordModel reset)
        {
            try
            {
                return await this.repository.ResetPassword(reset);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// ForgotPassword method is created to access and interact with the ForgotPassword Repository
        /// </summary>
        /// <param name="email">email is taken as a parameter</param>
        /// <returns>string message as email send or not</returns>
        public string ForgotPassword(string email)
        {
            try
            {
                return this.repository.ForgotPassword(email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
