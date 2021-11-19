using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interface;
using FundooRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        public string Register(RegisterModel userData)
        {
            try
            {
                return this.repository.Register(userData);
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
        public string ResetPassword(ResetPasswordModel reset)
        {
            try
            {
                return this.repository.ResetPassword(reset);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
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
