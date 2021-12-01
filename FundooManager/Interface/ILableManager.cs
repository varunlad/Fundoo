//// --------------------------------------------------------------------------------------------------------
// <copyright file="ILableManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooManager.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooModel;

    /// <summary>
    /// ILabelManager is an Interface class of LabelManager created to give reference to Controller .
    /// </summary>
    public interface ILableManager
    {
        /// <summary>
        /// Label method is created to access and interact with the Label Repository
        /// </summary>
        /// <param name="lable">LabelModel is taken as parameter</param>
        /// <returns>string message as Label is Added or not</returns>
        Task<string> Lable(LableModel lable);

        /// <summary>
        /// LabelNote method is created to access and interact with the LabelNote of Repository
        /// </summary>
        /// <param name="lable">LabelModel is taken as parameter</param>
        /// <returns>string message as Label is Added or not</returns>
        Task<string> LableNote(LableModel lable);

        /// <summary>
        /// RemoveLabel method is created to access and interact with the RemoveLabel of Repository
        /// </summary>
        /// <param name="labelId">labelId is taken as parameter</param>
        /// <returns>string message as Label is Removed or not</returns>
        Task<string> RemoveLabel(int labelId);

        /// <summary>
        /// DeleteLabel method is created to access and interact with the DeleteLabel of Repository
        /// </summary>
        /// <param name="userId">labelId is taken as parameter</param>
        /// <param name="labelName">labelName is taken as parameter</param>
        /// <returns>string message as Label is Delete or not</returns>
        Task<string> DeleteLabel(int userId, string labelName);

        /// <summary>
        /// UpdateLabel method is created to access and interact with the UpdateLabel of Repository
        /// </summary>
        /// <param name="lableModel">LabelModel is taken as parameter</param>
        /// <returns>string message as Label is updated or not</returns>
        Task<string> UpdateLabel(LableModel lableModel);

        /// <summary>
        /// GetLabelByNote method is created to access and interact with the GetLabelByNote of Repository
        /// </summary>
        /// <param name="notesId">notesId is taken as parameter</param>
        /// <returns>string message as Label is Displayed or not</returns>
        IEnumerable<LableModel> GetLabelByNote(int notesId);

        /// <summary>
        /// GetLabelByUserId method is created to access and interact with the GetLabelByUserId of Repository
        /// </summary>
        /// <param name="userId">userId is taken as parameter</param>
        /// <returns>string message as Label is Displayed or not</returns>
        IEnumerable<LableModel> GetLabelByUserId(int userId);
    }
}