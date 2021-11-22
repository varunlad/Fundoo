using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace FundooRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;
        public UserRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }


        public IConfiguration Configuration { get; }
        public string Register(RegisterModel userData)
        {
            try
            {
                var validEmail = this.userContext.UsersTable.Where(x => x.Email == userData.Email).FirstOrDefault();
                //FirstOrDefault-FirstOrDefault works same as First() does, FirstOrDefault returns the first element from a sequence, but here there is an advantage over First(), so if there is no record in the collection which matches input criteria then FirstOrDefault() can handle null values and it does not throw an exception.
                //Here we prevalid if email exits or not we dont want to create simillar emails
                if (validEmail == null)
                {
                    if (userData != null)
                    {
                        // Encrypting the password
                        userData.Password = EncryptPassword(userData.Password);
                        // Add the data to the database
                        this.userContext.Add(userData);
                        // Save the change in database
                        this.userContext.SaveChanges();
                        return "Registration Successful";
                    }
                    return "Registration UnSuccessful";
                }
                return "Email Id Already Exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string LogIn(LoginModel logIn)//here class is used as datatype and its parameter
        {
            try
            {
                var validEmail = this.userContext.UsersTable.Where(x => x.Email == logIn.Email).FirstOrDefault();
                logIn.Password = EncryptPassword(logIn.Password);
                var validPassword = this.userContext.UsersTable.Where(x => x.Password == logIn.Password).FirstOrDefault();
                if (validEmail == null && validPassword == null)
                {
                    return "Login UnSuccessful please type correct Email and Password";
                }
                else if (validEmail == null && validPassword != null)
                {
                    return "Login UnSuccessful Please Enter correct Email ";
                }
                else if (validEmail != null && validPassword == null)
                {
                    return "Login UnSuccessful Please Enter correct Password ";
                }
                else
                {
                    return "Login Successful ";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public string ResetPassword(ResetPasswordModel reset)
        {
            try
            {
                var validEmail = this.userContext.UsersTable.Where(x => x.Email == reset.Email).FirstOrDefault();
                if (reset != null)
                {
                    // Encrypting the password
                    validEmail.Password = EncryptPassword(reset.NewPassword);
                    // Add the data to the database
                    this.userContext.Update(validEmail);
                    // Save the change in database
                    this.userContext.SaveChanges();
                    return "Reset Password Successful";
                }
                return "Reset Password Unsucessful";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EncryptPassword(string password)
        {
            SHA384 sha384Hash = SHA384.Create();//creating object (it is a abstract class thats why we use create() method)
            // ComputeHash - returns byte array  
            byte[] bytesRepresentation = sha384Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(bytesRepresentation);
        }
        //SMTP (Simple Mail Transfer Protocol) is a part of the application layer of the TCP/IP protocol.
        //It is an Internet standard for electronic mail (email) transmission. The default TCP port used by SMTP is 25 and the SMTP
        //connections secured by SSL(Security socket layer), known as SMTPS, uses the default to port 465.
        public string ForgotPassword(string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("varunlad59@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("varunlad59@gmail.com", "varunlad59@123");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return "Email send";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
