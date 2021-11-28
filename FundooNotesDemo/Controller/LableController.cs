using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotesDemo.Controller
{
    public class LableController : ControllerBase
    {
        private readonly ILableManager manager;
        public LableController(ILableManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("api/lableuser")]//API-Application programming interface
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
        [HttpPost]
        [Route("api/lablenote")]//API-Application programming interface
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
        [HttpPut]
        [Route("api/updatelabel")]//API-Application programming interface
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
        [HttpDelete]
        [Route("api/removelabelbylableId")]//API-Application programming interface
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
        [HttpDelete]
        [Route("api/deletelabel")]//API-Application programming interface
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
        [HttpGet]
        [Route("api/getlableodnoteid")]//API-Application programming interface
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

        [HttpGet]
        [Route("api/getlablebyuserId")]//API-Application programming interface
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
