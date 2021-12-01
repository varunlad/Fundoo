//// --------------------------------------------------------------------------------------------------------
// <copyright file="LableController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FunDooNote.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModel;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// LabelController method is created in order to take the HTTP request from Swagger or Postman and to test the API. 
    /// </summary>
    [ApiController]
    [Route("api/[Controller]")]
    public class LableController : ControllerBase
    {
        /// <summary>
        /// ILabelManager will help me to access the Methods of Manager Class.
        /// </summary>
        private readonly ILableManager manager;

        /// <summary>
        ///  Initializes a new instance of the <see cref="LableController"/> class created the instance of Manager.
        /// </summary>
        /// <param name="manager">passing the object of ILabelManager</param>
        public LableController(ILableManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Label method is created to access and interact with the Label Manager.
        /// </summary>
        /// <param name="lable">LabelModel is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPost]
        [Route("lableuser")]
        public async Task<IActionResult> Lable([FromBody] LableModel lable)
        {
            try
            {
                string result = await this.manager.Lable(lable);

                if (result.Equals("Lable is added Successfully"))
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

        /// <summary>
        /// LabelNote method is created to access and interact with the LabelNote Manager.
        /// </summary>
        /// <param name="lable">LabelModel is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPost]
        [Route("lablenote")]
        public async Task<IActionResult> LableNote([FromBody] LableModel lable)
        {
            try
            {
                string result = await this.manager.LableNote(lable);

                if (result.Equals("Lable is added Successfully"))
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

        /// <summary>
        /// UpdateLabel method is created to access and interact with the UpdateLabel Manager.
        /// </summary>
        /// <param name="lableModel">LabelModel is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPut]
        [Route("updatelabel")]
        public async Task<IActionResult> UpdateLabel([FromBody] LableModel lableModel)
        {
            try
            {
                string result = await this.manager.UpdateLabel(lableModel);

                if (result.Equals("Update Successful"))
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

        /// <summary>
        /// RemoveLabel method is created to access and interact with the RemoveLabel Manager.
        /// </summary>
        /// <param name="labelId">Label Id is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpDelete]
        [Route("removelabelbylableId")]
        public async Task<IActionResult> RemoveLabel(int labelId)
        {
            try
            {
                string result = await this.manager.RemoveLabel(labelId);

                if (result.Equals("Deleted Label From Note"))
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

        /// <summary>
        /// DeleteLabel method is created to access and interact with the DeleteLabel Manager.
        /// </summary>
        /// <param name="userId">User Id is taken as a parameter</param>
        /// <param name="labelName">labelName is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpDelete]
        [Route("deletelabel")]
        public async Task<IActionResult> DeleteLabel(int userId, string labelName)
        {
            try
            {
                string result = await this.manager.DeleteLabel(userId, labelName);

                if (result.Equals("Label Deleted"))
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

        /// <summary>
        /// GetLabelByNote method is created to access and interact with the GetLabelByNote Manager.
        /// </summary>
        /// <param name="notesId">Note Id is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpGet]
        [Route("getlableodnoteid")]
        public IActionResult GetLabelByNote(int notesId)
        {
            try
            {
                IEnumerable<LableModel> result = this.manager.GetLabelByNote(notesId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }
                else
                {
                    return this.Ok(new { Status = true, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// GetLabelByUserId method is created to access and interact with the GetLabelByUserId Manager.
        /// </summary>
        /// <param name="userId">User Id is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpGet]
        [Route("getlablebyuserId")]
        public IActionResult GetLabelByUserId(int userId)
        {
            try
            {
                IEnumerable<LableModel> result = this.manager.GetLabelByUserId(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }
                else
                {
                    return this.Ok(new { Status = true, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}
