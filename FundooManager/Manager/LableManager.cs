//// --------------------------------------------------------------------------------------------------------
// <copyright file="LableManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooManager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModel;
    using FundooRepository.Interface;

    /// <summary>
    /// Label Manager class is created as it is the Business Logic Layer and takes the return statement from Repository. 
    /// </summary>
    public class LableManager : ILableManager
    {
        /// <summary>
        /// ILabelRepository will help me to access the Methods of Repository Class.
        /// </summary>
        private readonly ILableRepository repository;

        /// <summary>
        ///  Initializes a new instance of the <see cref="LableManager"/> class created the instance of repository.
        /// </summary>
        /// <param name="repository">>passing the object of ILabelRepository</param>
        public LableManager(ILableRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Label method is created to access and interact with the Label Repository
        /// </summary>
        /// <param name="lable">LabelModel is taken as parameter</param>
        /// <returns>string message as Label is Added or not</returns>
        public async Task<string> Lable(LableModel lable)
        {
            try
            {
                return await this.repository.Lable(lable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// LabelNote method is created to access and interact with the LabelNote of Repository
        /// </summary>
        /// <param name="lable">LabelModel is taken as parameter</param>
        /// <returns>string message as Label is Added or not</returns>
        public async Task<string> LableNote(LableModel lable)
        {
            try
            {
                return await this.repository.LableNote(lable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// RemoveLabel method is created to access and interact with the RemoveLabel of Repository
        /// </summary>
        /// <param name="labelId">labelId is taken as parameter</param>
        /// <returns>string message as Label is Removed or not</returns>
        public async Task<string> RemoveLabel(int labelId)
        {
            try
            {
                return await this.repository.RemoveLabel(labelId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// DeleteLabel method is created to access and interact with the DeleteLabel of Repository
        /// </summary>
        /// <param name="userId">labelId is taken as parameter</param>
        /// <param name="labelName">labelName is taken as parameter</param>
        /// <returns>string message as Label is Delete or not</returns>
        public async Task<string> DeleteLabel(int userId, string labelName)
        {
            try
            {
                return await this.repository.DeleteLabel(userId, labelName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// UpdateLabel method is created to access and interact with the UpdateLabel of Repository
        /// </summary>
        /// <param name="lableModel">LabelModel is taken as parameter</param>
        /// <returns>string message as Label is updated or not</returns>
        public async Task<string> UpdateLabel(LableModel lableModel)
        {
            try
            {
                return await this.repository.UpdateLabel(lableModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// GetLabelByNote method is created to access and interact with the GetLabelByNote of Repository
        /// </summary>
        /// <param name="notesId">notesId is taken as parameter</param>
        /// <returns>string message as Label is Displayed or not</returns>
        public IEnumerable<LableModel> GetLabelByNote(int notesId)
        {
            try
            {
                return this.repository.GetLabelByNote(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// GetLabelByUserId method is created to access and interact with the GetLabelByUserId of Repository
        /// </summary>
        /// <param name="userId">userId is taken as parameter</param>
        /// <returns>string message as Label is Displayed or not</returns>
        public IEnumerable<LableModel> GetLabelByUserId(int userId)
        {
            try
            {
                return this.repository.GetLabelByUserId(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
