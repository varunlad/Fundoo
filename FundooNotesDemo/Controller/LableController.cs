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
    }
}
