//// --------------------------------------------------------------------------------------------------------
// <copyright file="RegisterModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooModel
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// RegisterModel class is created to add Register API with following parameters
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Gets or sets FirstName as parameter to enter any FirstName.
        /// </summary>
        [Required]
            public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName as parameter to enter any LastName.
        /// </summary>
        [Required]
            public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Email as parameter to enter any Email.
        /// </summary>
        [Required]
            public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password as parameter to enter any Password.
        /// </summary>
        [Required]
            public string Password { get; set; }

        /// <summary>
        /// Gets or sets NoteID  as Primary key
        /// </summary>
        [Key]
            public int UserId { get; set; }
    }
}
