//// --------------------------------------------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooModel
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// LoginModel class is created to add Login API with following parameters
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets Email as parameter to enter Email Address.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password as parameter to enter User Password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
