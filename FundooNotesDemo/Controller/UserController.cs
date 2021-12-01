//// --------------------------------------------------------------------------------------------------------
// <copyright file="UsersController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FunDooNote.Controller
{
    using System;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModel;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using StackExchange.Redis;

    /// <summary>
    /// UsersController method is created in order to take the HTTP request from Swagger or Postman and to test the API. 
    /// </summary>
    [ApiController]
    [Route("api/[Controller]")]
    public class UsersController : ControllerBase ////ControllerBase : A base class for an MVC controller without view support. 
                                                  ////It add Support for View to controller Class
    {
        /// <summary>
        /// IUserManager will help me to access the Methods of Manager Class.
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// ILogger will help to get status of User Action at every stage.
        /// </summary>
        private readonly ILogger<UsersController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class created the instance of Manager.
        /// </summary>
        /// <param name="manager">passing the object of IUserManager</param>
        /// <param name="logger">passing the object of ILogger</param>
        public UsersController(IUserManager manager, ILogger<UsersController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        /// <summary>
        /// Register Method is created to access and interact with the Label Manager.
        /// </summary>
        /// <param name="userData">RegistrationModel is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPost]
        [Route("userregister")]
        public async Task<IActionResult> Register([FromBody] RegisterModel userData)
        {
            try
            {
                string result = await this.manager.Register(userData);
                logger.LogInformation("A new User Registration for " + userData.FirstName + " " + userData.LastName);

                if (result.Equals("Registration Successful"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning("Exception cought while adding new user" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// LogIn Method is created to access and interact with the LogIn Manager.
        /// </summary>
        /// <param name="login">LoginModel is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPost]
        [Route("userLogin")]
        public IActionResult LogIn([FromBody] LoginModel login)
        {
            try
            {
                string result = this.manager.LogIn(login);
                logger.LogInformation("A new User Login with email " + login.Email);

                if (result.Equals("Login Successful"))
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    string firstName = database.StringGet("First Name");
                    string lastName = database.StringGet("Last Name");
                    HttpContext.Session.SetString("userID", login.Email);
                    RegisterModel data = new RegisterModel { FirstName = firstName, LastName = lastName, Email = login.Email };
                    string token = this.manager.JWTToken(login.Email);
                    return this.Ok(new { Status = true, Message = result, Data = data, Token = token });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning("Exception cought while Logging  user" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// ResetPassword Method is created to access and interact with the ResetPassword Manager.
        /// </summary>
        /// <param name="reset">ResetPasswordModel is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPut]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel reset)
        {
            try
            {
                string result = await this.manager.ResetPassword(reset);
                logger.LogInformation("A new User reset password with email " + reset.Email);

                if (result.Equals("Reset Password Successful"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning("Exception cought while Reset password" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// ForgotPassword Method is created to access and interact with the ForgotPassword Manager.
        /// </summary>
        /// <param name="email">email is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPost]
        [Route("forgotpassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                string result = this.manager.ForgotPassword(email);
                logger.LogInformation("A new User forgot password with email " + email);

                if (result.Equals("Email send"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning("Exception cought while Forgot password" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
