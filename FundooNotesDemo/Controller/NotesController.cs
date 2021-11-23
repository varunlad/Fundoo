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
        [HttpPut]
        [Route("api/updatecolor")]//API-Application programming interface
        public async Task<IActionResult> UpdateColor([FromBody] NotesModel notes)
        {
            try
            {
                string result = await this.manager.UpdateColor(notes);

                if (result.Equals("color has Updated"))
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
        [Route("api/notepin")]//API-Application programming interface
        public async Task<IActionResult> Pinned(NotesModel notes)
        {
            try
            {
                string result = await this.manager.Pinned(notes);

                if (result.Equals("Note pinned"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else if (result.Equals("Notes unarchieved and pinned"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else if (result.Equals("Note unpinned"))
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
        [Route("api/notetrash")]//API-Application programming interface
        public async Task<IActionResult> Trash(NotesModel notes)
        {
            try
            {
                string result = await this.manager.Trash(notes);

                if (result.Equals("Note Trash"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else if (result.Equals("Notes unarchieved and Trash"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else if (result.Equals("Note Remove from Trash"))
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
        [Route("api/permanantnotetrash")]//API-Application programming interface
        public async Task<IActionResult> PermanantRemove(NotesModel notes)
        {
            try
            {
                string result = await this.manager.PermanantRemove(notes);

                if (result.Equals("Notes is Permanant Removed"))
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
        [Route("api/remainder")]//API-Application programming interface
        public async Task<IActionResult> Remainder([FromBody] NotesModel notes)
        {
            try
            {
                string result = await this.manager.Remainder(notes);

                if (result.Equals("Remainder is Set"))
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
