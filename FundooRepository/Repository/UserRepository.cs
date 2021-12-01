//// -------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Experimental.System.Messaging;
    using FundooModel;
    using FundooRepository.Context;
    using FundooRepository.Interface;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using StackExchange.Redis;

    /// <summary>
    /// UserRepository class is created it is the Data Access Layer and it filter out the required data from the Database 
    /// </summary>
    public class UserRepository : IUserRepository  ////created interface of UserRepository in order to use in manager
    {
        /// <summary>
        /// This is an object for UserContext.
        /// </summary>
        private readonly UserContext userContext; ////UserContext userContext will help me to access UserContext Dbset User which contain data.

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class created the instance of configuration and userContext
        /// </summary>
        /// <param name="configuration">passing the object of IConfiguration</param>
        /// <param name="userContext">passing the object of UserContext</param>
        public UserRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

        /// <summary>
        /// Gets the Configuration.This is an object for IConfiguration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Register Method is created for user registration purpose and parameters taken are First Name,Last Name,Email and Password.
        /// </summary>
        /// <param name="userData"> RegistrationModel is passed as parameter.</param>
        /// <returns>The registration is Successful or not to the manager</returns>
        public async Task<string> Register(RegisterModel userData)
        {
            try
            {
                var validEmail = this.userContext.UsersTable.Where(x => x.Email == userData.Email).FirstOrDefault(); ////Performing Linque Query
                ////FirstOrDefault-FirstOrDefault works same as First() does, FirstOrDefault returns the first element from a sequence, but here there is an advantage over First(), so if there is no record in the collection which matches input criteria then FirstOrDefault() can handle null values and it does not throw an exception.
               ////Here we prevalid if email exits or not we dont want to create simillar emails
                if (validEmail == null)
                {
                    if (userData != null)
                    {
                        //// Encrypting the password
                        userData.Password = this.EncryptPassword(userData.Password);
                        //// Add the data to the database
                        this.userContext.Add(userData);
                        //// Save the change in database
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

        /// <summary>
        /// LogIn Method is created for user Login purpose and parameters taken are Email and Password and JWT Token Verification is also applied.
        /// </summary>
        /// <param name="logIn">LoginModel is passed as parameter</param>
        /// <returns>The Login is Successful or not to the manager</returns>
        public string LogIn(LoginModel logIn) ////here class is used as datatype and its parameter
        {
            try
            {
                var validEmail = this.userContext.UsersTable.Where(x => x.Email == logIn.Email).FirstOrDefault();
                if (validEmail != null)
                {
                    logIn.Password = this.EncryptPassword(logIn.Password);
                    var validPassword = this.userContext.UsersTable.Where(x => x.Password == logIn.Password).FirstOrDefault();
                    if (validPassword != null)
                    {
                        ////connection to redis server
                        ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                        IDatabase database = connectionMultiplexer.GetDatabase();
                        database.StringSet(key: "First Name", validPassword.FirstName);
                        database.StringSet(key: "Last Name", validPassword.LastName);
                        return "Login Successful";
                    }

                    return "Enter Correct Password";
                }

                return "Email Incorrect";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Here the JWT token generation is taken place it is the combination of Header and Payload with Signature.
        /// </summary>
        /// <param name="email"> Passing Users Email as a parameter</param>
        /// <returns>JWT Token</returns>
        public string JWTToken(string email)
        {
            byte[] key = Encoding.UTF8.GetBytes(this.Configuration["SecretKey"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            ////SecurityTokenDescriptor-Contains some information which used to create a security token.
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

        /// <summary>
        /// ResetPassword Method is created for resetting the Users Password purpose and parameters taken are Email and New Password.
        /// </summary>
        /// <param name="reset"> Passing ResetPasswordModel as a parameter</param>
        /// <returns>string message "Reset Password Successful"</returns>
        public async Task<string> ResetPassword(ResetPasswordModel reset)
        {
            try
            {
                var validEmail = this.userContext.UsersTable.Where(x => x.Email == reset.Email).FirstOrDefault();
                if (reset != null)
                {
                    //// Encrypting the password
                    validEmail.Password = this.EncryptPassword(reset.NewPassword);
                    //// Add the data to the database
                    this.userContext.Update(validEmail);
                    //// Save the change in database
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

        /// <summary>
        /// As a Developer for security purpose we have to encrypt the password.In this method we are doing one way  password Encryption.
        /// </summary>
        /// <param name="password">Passing Users password as a parameter</param>
        /// <returns> Encrypted Password</returns>
        public string EncryptPassword(string password)
        {
            SHA384 sha384Hash = SHA384.Create(); ////creating object (it is a abstract class thats why we use create() method)
            // ComputeHash - returns byte array  
            byte[] bytesRepresentation = sha384Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(bytesRepresentation);
        }

        /// <summary>
        /// SMTP (Simple Mail Transfer Protocol) is a part of the application layer of the TCP/IP protocol.
        /// It is an Internet standard for electronic mail (email) transmission. The default TCP port used by SMTP is 25 and the SMTP 
        /// Connections secured by SSL(Security socket layer), known as SMTPS, uses the default to port 465.
        /// </summary>
        /// <param name="email">Passing Users email as a parameter</param>
        /// <returns>Send an email to the respected Email Address</returns>
        public string ForgotPassword(string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(this.Configuration["Credentials:Email"]);
                mail.To.Add(email);
                mail.Subject = "Test Mail";
                this.SendMSMQ();
                mail.Body = this.ReceiveMSMQ();
                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential(this.Configuration["Credentials:Email"], this.Configuration["Credentials:Password"]);
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
                return "Email send";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// With the Help of Message Queue the email is safely send and receive to the Destination.
        /// </summary>
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

        /// <summary>
        /// With the Help of Message Queue the email is safely send and receive to the Destination.
        /// </summary>
        /// <returns>Ensures the message is received to the receive.</returns>
        public string ReceiveMSMQ()
        {
            MessageQueue messageQueue = new MessageQueue(@".\Private$\Fundoo");
            var receivemsg = messageQueue.Receive();
            return receivemsg.ToString();
        }
    }
}
