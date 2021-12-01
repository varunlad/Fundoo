//// --------------------------------------------------------------------------------------------------------
// <copyright file="NotesModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooModel
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// NotesModel class is created to add Notes API with following parameters
    /// </summary>
    public class NotesModel
    {
        /// <summary>
        /// Gets or sets NoteID  as Primary key
        /// </summary>
        [Key]
        public int NoteID { get; set; }

        /// <summary>
        /// Gets or sets Foreign key to UserID
        /// </summary>
        [ForeignKey("RegisterModel")]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets Foreign key to UserID as UserID is Primary Key in UserModel.
        /// </summary>
        public virtual RegisterModel RegisterModel { get; set; }

        /// <summary>
        /// Gets or sets Title as parameter to enter any Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets AddNotes as parameter to enter Notes .
        /// </summary>
        public string AddNotes { get; set; }

        /// <summary>
        /// Gets or sets Remainder as parameter to enter Remainder .
        /// </summary>
        public string Remainder { get; set; }

        /// <summary>
        /// Gets or sets Color as parameter to enter Color .
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets Image as parameter to enter Image .
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets Pin as parameter to Pin or Unpin .
        /// </summary>
        [DefaultValue(false)]

        public bool Pin { get; set; }

        /// <summary>
        /// Gets or sets Archieve as parameter to Archive or UnArchive .
        /// </summary>
        [DefaultValue(false)]

        public bool Archieve { get; set; }

        /// <summary>
        /// Gets or sets Trash as parameter to Archieve or UnTrash .
        /// </summary>
        [DefaultValue(false)]

        public bool Trash { get; set; }
    }
}
