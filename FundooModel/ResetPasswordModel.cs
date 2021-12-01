//// --------------------------------------------------------------------------------------------------------
// <copyright file="ResetPasswordModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooModel
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// RegisterModel class is created to add Reset password API with following parameters
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Gets or sets Email as parameter to enter any Email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets NewPassword as parameter to enter any NewPassword.
        /// </summary>
        [Required]
        public string NewPassword { get; set ; }
    }
}
