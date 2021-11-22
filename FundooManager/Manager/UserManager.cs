using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interface;
using FundooRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Register(RegisterModel userData)
        {
            try
            {
                return await this.repository.Register(userData);//Registration Successful or Unsuccessful
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
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
        public async Task<string> ForgotPassword(string email)
        {
            try
            {
                return await this.repository.ForgotPassword(email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
