using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotesDemo.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesManager manager;
        public NotesController(INotesManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("addnotes")]//API-Application programming interface
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
        [Route("updatenotes")]//API-Application programming interface
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
        [Route("updatecolor")]//API-Application programming interface
        public async Task<IActionResult> UpdateColor(int noteId, string colour)
        {
            try
            {
                string result = await this.manager.Updatecolor(noteId, colour);

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
        [Route("notearchive")]//API-Application programming interface
        public async Task<IActionResult> NoteArchive(int notes)
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
        [Route("notepin")]//API-Application programming interface
        public async Task<IActionResult> Pinned(int noteId)
        {
            try
            {
                string result = await this.manager.Pinned(noteId);

                if (result.Equals("Note removed from Trashed and pinned"))
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
                else if (result.Equals("Note Pinned"))
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
        [Route("notetrash")]//API-Application programming interface
        public async Task<IActionResult> Trash(int notes)
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
        [Route("noteremainder")]//API-Application programming interface
        public async Task<IActionResult> Remainder(int noteId, string remainder)
        {
            try
            {
                string result = await this.manager.Remainder(noteId, remainder);

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
        [HttpDelete]
        [Route("permananttrashnotes")]//API-Application programming interface
        public async Task<IActionResult> PermanantRemove(int notesId)
        {
            try
            {
                string result = await this.manager.PermanantRemove(notesId);

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
        [HttpGet]
        [Route("getnotes")]//API-Application programming interface
        public IActionResult GetUserNotes(int userid)
        {
            try
            {
                IEnumerable<NotesModel> result = this.manager.GetUserNotes(userid);

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
        [HttpGet]
        [Route("getarchievenotes")]//API-Application programming interface
        public IActionResult GetArchieveNotes(int userid)
        {
            try
            {
                IEnumerable<NotesModel> result = this.manager.GetArchieveNotes(userid);

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
        [HttpGet]
        [Route("gettrashnotes")]//API-Application programming interface
        public IActionResult GetTrashNotes(int userid)
        {
            try
            {
                IEnumerable<NotesModel> result = this.manager.GetTrashNotes(userid);

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
        [HttpGet]
        [Route("getremainder")]//API-Application programming interface
        public IActionResult GetRemainder(int userid)
        {
            try
            {
                IEnumerable<NotesModel> result = this.manager.GetRemainder(userid);

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
        [HttpPut]
        [Route("addimage")]
        public async Task<IActionResult> AddImage(int notesId, IFormFile image)
        {
            try
            {
                string result = await this.manager.AddImage(notesId, image);
                if (result == "Image added Successfully")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = true, Message = ex.Message });
            }
        }
    }
}
