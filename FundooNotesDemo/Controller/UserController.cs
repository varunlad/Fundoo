using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotesDemo.Controller
{
    public class UsersController : ControllerBase
    {
        private readonly IUserManager manager;

        public UsersController(IUserManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("api/register")]//API-Application programming interface
        public IActionResult Register([FromBody] RegisterModel userData)
        {
            try
            {
                string result = this.manager.Register(userData);

                if (result.Equals("Registration Successfull"))
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
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/Login")]
        public IActionResult LogIn([FromBody] LoginModel login)
        {
            try
            {
                string result = this.manager.LogIn(login);

                if (result.Equals("Login Successful "))
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
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
