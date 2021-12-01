//// --------------------------------------------------------------------------------------------------------
// <copyright file="LableModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// LabelModel class is created to add Label API with following parameters
    /// </summary>
    public class LableModel
    {
        /// <summary>
        /// Gets or sets LabelId  as Primary key
        /// </summary>
        [Key]
        public int LableId { get; set; }

        /// <summary>
        /// Gets or sets Label as parameter to enter any Label.
        /// </summary>
        public string Lable { get; set; }

        /// <summary>
        /// Gets or sets Foreign key to NoteID
        /// </summary>
        [ForeignKey("NotesModel")]
        public int? NoteID { get; set; }

        /// <summary>
        /// Gets or sets Foreign key to NoteID as NoteID is Primary Key in Notes Model.
        /// </summary>
        public virtual NotesModel NotesModel { get; set; }

        /// <summary>
        /// Gets or sets Foreign key to UserID
        /// </summary>
        [ForeignKey("RegisterModel")]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets Foreign key to UserID as UserID is Primary Key in Register Model.
        /// </summary>
        public virtual RegisterModel RegistrationModel { get; set; }
    }
}
