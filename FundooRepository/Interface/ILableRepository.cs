//// --------------------------------------------------------------------------------------------------------
// <copyright file="ILableRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooRepository.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooModel;

    /// <summary>
    /// ILabelRepository is an Interface class of LabelRepository created to give reference to Manager .
    /// </summary>
    public interface ILableRepository
    {
        /// <summary>
        /// Label Method is Created to Add Label for Note or For a User.
        /// </summary>
        /// <param name="lable"> Label Model is passed as parameter. </param>
        /// <returns> string message as Label is Added or not.</returns>
        Task<string> Lable(LableModel lable);

        /// <summary>
        /// Remove Label Method is Created to Delete Label for Note or For a User.
        /// </summary>
        /// <param name="labelId">Label Id is passed as parameter.</param>
        /// <returns>>string message as Label is Removed or not</returns>
        Task<string> RemoveLabel(int labelId);

        /// <summary>
        /// Delete Label Method is Created to Delete Label for Note or For a User.
        /// </summary>
        /// <param name="userId">user Id is passed as parameter.</param>
        /// <param name="labelName">Label Name is passed as parameter.</param>
        /// <returns>string message as Label is Deleted or not</returns>
        Task<string> DeleteLabel(int userId, string labelName);

        /// <summary>
        /// Label Note Method is Created to Add Label for Note or For a User.
        /// </summary>
        /// <param name="lable">Label Model is passed as parameter.</param>
        /// <returns>string message as Label is Added or not</returns>
        Task<string> LableNote(LableModel lable);

        /// <summary>
        ///  Update Label   Method is created to update Label.
        /// </summary>
        /// <param name="lableModel"> Label Model is passed as Parameter</param>
        /// <returns> string message as Label is updated or not</returns>
        Task<string> UpdateLabel(LableModel lableModel);

        /// <summary>
        /// Get Label by Notes Method is created to get Label of that Note Id.
        /// </summary>
        /// <param name="notesId">note Id is passed as parameter.</param>
        /// <returns> Label for that note Id is return</returns>
        IEnumerable<LableModel> GetLabelByNote(int notesId);

        /// <summary>
        /// Get Label by User Id Method is created to get Label of that User Id.
        /// </summary>
        /// <param name="userId">user Id is passed as parameter.</param>
        /// <returns>Label for that user Id is return</returns>
        IEnumerable<LableModel> GetLabelByUserId(int userId);
    }
}