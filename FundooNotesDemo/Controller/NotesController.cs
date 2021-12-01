//// --------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
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
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// NotesController method is created in order to take the HTTP request from Swagger or Postman and to test the API. 
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// INotesManager will help me to access the Methods of Manager Class.
        /// </summary>
        private readonly INotesManager manager;

        /// <summary>
        ///  Initializes a new instance of the <see cref="NotesController"/> class created the instance of Manager.
        /// </summary>
        /// <param name="manager">passing the object of INotesManager</param>
        public NotesController(INotesManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Notes Method is created to access and interact with the Label Manager.
        /// </summary>
        /// <param name="notes">NotesModel is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPost]
        [Route("addnotes")]
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

        /// <summary>
        /// UpdatedNotes Method is created to access and interact with the UpdatedNotes Manager.
        /// </summary>
        /// <param name="notes">NotesModel is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPut]
        [Route("updatenotes")]
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

        /// <summary>
        /// UpdateColor Method is created to access and interact with the UpdateColor Manager.
        /// </summary>
        /// <param name="noteId">note Id is taken as a parameter</param>
        /// <param name="colour">color is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPut]
        [Route("updatecolor")]
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

        /// <summary>
        /// NoteArchive Method is created to access and interact with the NoteArchive Manager.
        /// </summary>
        /// <param name="notes">Note Id is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPut]
        [Route("notearchive")]
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

        /// <summary>
        /// Pinned Method is created to access and interact with the Pinned Manager.
        /// </summary>
        /// <param name="noteId">Note Id is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPut]
        [Route("notepin")]
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

        /// <summary>
        /// Trash Method is created to access and interact with the Trash Manager.
        /// </summary>
        /// <param name="notes">Note Id is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPut]
        [Route("notetrash")]
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

        /// <summary>
        /// Remainder Method is created to access and interact with the Remainder Manager.
        /// </summary>
        /// <param name="noteId">Note Id is taken as a parameter</param>
        /// <param name="remainder">remainder is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpPut]
        [Route("noteremainder")]
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

        /// <summary>
        /// PermanentRemove Method is created to access and interact with the PermanentRemove Manager.
        /// </summary>
        /// <param name="notesId">Note Id is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpDelete]
        [Route("permananttrashnotes")]
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

        /// <summary>
        /// GetUserNotes Method is created to access and interact with the GetUserNotes Manager.
        /// </summary>
        /// <param name="userid">User Id is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpGet]
        [Route("getnotes")]
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

        /// <summary>
        /// GetArchiveNotes Method is created to access and interact with the GetArchiveNotes Manager.
        /// </summary>
        /// <param name="userid">User Id is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpGet]
        [Route("getarchievenotes")]
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

        /// <summary>
        /// GetTrashNotes Method is created to access and interact with the GetTrashNotes Manager.
        /// </summary>
        /// <param name="userid">User Id is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpGet]
        [Route("gettrashnotes")]
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

        /// <summary>
        /// GetRemainder Method is created to access and interact with the GetRemainder Manager.
        /// </summary>
        /// <param name="userid">User Id is taken as a parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
        [HttpGet]
        [Route("getremainder")]
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

        /// <summary>
        /// AddImage Method is created to access and interact with the AddImage Manager.
        /// </summary>
        /// <param name="notesId">Note Id is taken as parameter</param>
        /// <param name="image">image is taken as parameter</param>
        /// <returns>Return the status of the Request made by user</returns>
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
