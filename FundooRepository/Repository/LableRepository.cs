//// --------------------------------------------------------------------------------------------------------
// <copyright file="LableRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooModel;
    using FundooRepository.Context;
    using FundooRepository.Interface;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Label Repository class is created it is the Data Access Layer and it filter out the required data from the Database 
    /// </summary>
    public class LableRepository : ILableRepository
    {
        /// <summary>
        ///  UserContext userContext will help me to access UserContext Dbset User which contain data.
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableRepository"/> class created the instance of configuration and userContext
        /// </summary>
        /// <param name="configuration">passing the object of IConfiguration</param>
        /// <param name="userContext">passing the object of UserContext</param>       
        public LableRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

        /// <summary>
        /// Gets the Configuration.This is an object for IConfiguration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Label Method is Created to Add Label for Note or For a User.
        /// </summary>
        /// <param name="lable"> Label Model is passed as parameter. </param>
        /// <returns> string message as Label is Added or not.</returns>
        public async Task<string> Lable(LableModel lable)
        {
            try
            {
                var validLabel = this.userContext.LabelsTable.Where(x => x.Lable == lable.Lable && lable.NoteID == null).FirstOrDefault();
                if (validLabel == null)
                {
                    //// Add the data to the database
                    this.userContext.Add(lable);
                    //// Save the change in database
                    await this.userContext.SaveChangesAsync();
                    return "Lable is added Successfully";
                }
                else
                {
                    return "Label name already Exits";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Label Note Method is Created to Add Label for Note or For a User.
        /// </summary>
        /// <param name="lable">Label Model is passed as parameter.</param>
        /// <returns>string message as Label is Added or not</returns>
        public async Task<string> LableNote(LableModel lable)
        {
            try
            {
                var validLabel = this.userContext.LabelsTable.Where(x => x.UserID == lable.UserID && lable.NoteID != null).FirstOrDefault();
                if (validLabel != null)
                {
                    //// Add the data to the database
                    this.userContext.Add(lable);
                    //// Save the change in database
                    await this.userContext.SaveChangesAsync();
                    return "Lable is added Successfully";
                }
                else
                {
                    return "Label name already Exits";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove Label Method is Created to Delete Label for Note or For a User.
        /// </summary>
        /// <param name="labelId">Label Id is passed as parameter.</param>
        /// <returns>>string message as Label is Removed or not</returns>
        public async Task<string> RemoveLabel(int labelId)
        {
            try
            {
                var validLabel = this.userContext.LabelsTable.Where(x => x.LableId == labelId).SingleOrDefault();
                if (validLabel != null)
                {
                    this.userContext.LabelsTable.Remove(validLabel);
                    await this.userContext.SaveChangesAsync();
                    return "Deleted Label From Note";
                }

                return "No label present";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete Label Method is Created to Delete Label for Note or For a User.
        /// </summary>
        /// <param name="userId">user Id is passed as parameter.</param>
        /// <param name="labelName">Label Name is passed as parameter.</param>
        /// <returns>string message as Label is Deleted or not</returns>
        public async Task<string> DeleteLabel(int userId, string labelName)
        {
            try
            {
                var validLabel = this.userContext.LabelsTable.Where(x => x.Lable == labelName && x.UserID == userId).ToList();
                if (validLabel != null)
                {
                    this.userContext.LabelsTable.RemoveRange(validLabel);
                    await this.userContext.SaveChangesAsync();
                    return "Label Deleted";
                }

                return "Label not exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Label by Notes Method is created to get Label of that Note Id.
        /// </summary>
        /// <param name="notesId">note Id is passed as parameter.</param>
        /// <returns> Label for that note Id is return</returns>
        public IEnumerable<LableModel> GetLabelByNote(int notesId)
        {
            try
            {
                IEnumerable<LableModel> validLabel = this.userContext.LabelsTable.Where(x => x.NoteID == notesId);
                if (validLabel != null)
                {
                    return validLabel;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///  Update Label   Method is created to update Label.
        /// </summary>
        /// <param name="lableModel"> Label Model is passed as Parameter</param>
        /// <returns> string message as Label is updated or not</returns>
        public async Task<string> UpdateLabel(LableModel lableModel)
        {
            try
            {
                var validLabel = this.userContext.LabelsTable.Where(x => x.LableId == lableModel.LableId).Select(x => x.Lable).SingleOrDefault();
                var oldLabelname = this.userContext.LabelsTable.Where(x => x.Lable == validLabel).ToList();
                oldLabelname.ForEach(x => x.Lable = lableModel.Lable);
                this.userContext.LabelsTable.UpdateRange(oldLabelname);
                await this.userContext.SaveChangesAsync();
                return "Update Successful";
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Get Label by User Id Method is created to get Label of that User Id.
        /// </summary>
        /// <param name="userId">user Id is passed as parameter.</param>
        /// <returns>Label for that user Id is return</returns>
        public IEnumerable<LableModel> GetLabelByUserId(int userId)
        {
            try
            {
                IEnumerable<LableModel> validLabel = this.userContext.LabelsTable.Where(x => x.UserID == userId);
                if (validLabel != null)
                {
                    return validLabel;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
