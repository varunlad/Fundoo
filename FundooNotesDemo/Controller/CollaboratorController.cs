﻿using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotesDemo.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorManager manager;
        public CollaboratorController(ICollaboratorManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("addcollaborator")]//API-Application programming interface
        public async Task<IActionResult> Collaborator([FromBody] CollaboratorModel collaborator)
        {
            try
            {
                string result = await this.manager.Collaborator(collaborator);

                if (result.Equals("Email is added Successfully"))
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
        [HttpDelete]
        [Route("deletecollaborator")]//API-Application programming interface
        public async Task<IActionResult> DeleteCollaborator(int collaborator)
        {
            try
            {
                string result = await this.manager.DeleteCollaborator(collaborator);

                if (result.Equals("Email is Deleted"))
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
        [HttpGet]
        [Route("getCollabEmail")]//API-Application programming interface
        public IActionResult GetCollaboratedEmails(int noteid)
        {
            try
            {
                IEnumerable<CollaboratorModel> result = this.manager.GetCollaboratedEmails(noteid);

                if (result.Equals(null))
                {
                    return this.BadRequest(new { Status = false, Data = result });
                }
                else
                {
                    return this.Ok(new { Status = true, Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
