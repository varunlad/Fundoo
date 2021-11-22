using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotesDemo.Controller
{
    public class NotesController : ControllerBase
    {
        private readonly INotesManager manager;
        public NotesController(INotesManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("api/notes")]//API-Application programming interface
        public async Task<IActionResult> Notes([FromBody] NotesModel notes)
        {
            try
            {
                string result = await this.manager.Notes(notes);

                if (result.Equals("Notes are added Successfully"))
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
        [Route("api/update")]//API-Application programming interface
        public async Task<IActionResult> UpdatedNotes([FromBody] NotesModel notes)
        {
            try
            {
                string result = await this.manager.Update(notes);

                if (result.Equals("Notes has Updated"))
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
        [Route("api/notearchive")]//API-Application programming interface
        public async Task<IActionResult> NoteArchive(NotesModel notes)
        {
            try
            {
                string result = await this.manager.NoteArchive(notes);

                if (result.Equals("Note archived"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else if (result.Equals("Notes unpinned and moved to Archived"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else if (result.Equals("Note unarchived"))
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
