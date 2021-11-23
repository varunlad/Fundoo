using Experimental.System.Messaging;
using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<string> Register(RegisterModel userData)
        {
            try
            {
                var validEmail = this.userContext.UsersTable.Where(x => x.Email == userData.Email).FirstOrDefault();//Performing Linque Query
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
                        await this.userContext.SaveChangesAsync();
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
        public object LogIn(LoginModel logIn)//here class is used as datatype and its parameter
        {
            try
            {
                var existEmail = this.userContext.UsersTable.Where(x => x.Email == logIn.Email).SingleOrDefault();
                if (existEmail != null)
                {
                    logIn.Password = this.EncryptPassword(logIn.Password);
                    var existingPassword = this.userContext.UsersTable.Where(x => x.Password == logIn.Password).SingleOrDefault();
                    if (existingPassword == null)
                    {
                        return new { message = "Login Unsuccessful" };
                    }
                    //Call generate token method
                    string token = JWTTokenGeneration(existingPassword.Email);
                    existingPassword.Password = null;
                    return new { message = "Login Successful", Token = token, Data = existingPassword };
                }
                return new { message = "Email Id not Exist,Please Register first" };
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string JWTTokenGeneration(string email)
        {
            byte[] key = Encoding.UTF8.GetBytes(this.Configuration["SecretKey"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, email)
            }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
        public async Task<string> ResetPassword(ResetPasswordModel reset)
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
                    await this.userContext.SaveChangesAsync();

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
            //var encrypPassword = Encoding.UTF8.GetBytes(password);//Encodes the charaters in specified string object into sequence of bytes.
            //return Convert.ToBase64String(encrypPassword);//dought (convert subset of an array of 8-bit unsigned integer to its equivalent string representation)

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
                mail.From = new MailAddress(this.Configuration["Credentials:Email"]);
                mail.To.Add(email);
                mail.Subject = "Test Mail";
                SendMSMQ();
                mail.Body = ReceiveMSMQ();
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(this.Configuration["Credentials:Email"], this.Configuration["Credentials:Password"]);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return "Email send";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SendMSMQ()
        {
            MessageQueue messageQueue;
            if (MessageQueue.Exists(@".\Private$\Fundoo"))
            {
                messageQueue = new MessageQueue(@".\Private$\Fundoo");
            }
            else
            {
                messageQueue = MessageQueue.Create(@".\Private$\Fundoo");
            }
            string body = "This is for Testing SMTP mail from GMAIL";
            messageQueue.Label = "Mail Body";
            messageQueue.Send(body);
        }
        public string ReceiveMSMQ()
        {
            MessageQueue messageQueue = new MessageQueue(@".\Private$\Fundoo");
            var receivemsg = messageQueue.Receive();
            return receivemsg.ToString();
        }
    }
}
