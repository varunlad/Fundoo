using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotesDemo.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager manager;
        private readonly ILogger<UsersController> logger;

        public UsersController(IUserManager manager, ILogger<UsersController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }
        [HttpPost]
        [Route("userregister")]//API-Application programming interface
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
        [HttpGet]
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
        [HttpPost]
        [Route("forgotpassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                string result =  this.manager.ForgotPassword(email);
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
