//// --------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// CollaboratorModel class is created to add Collaborator API with following parameters
    /// </summary>
    public class CollaboratorModel
    {
        /// <summary>
        /// Gets or sets CollaboratorID  as Primary key
        /// </summary>
        [Key]
        public int CollaboratorID { get; set; }

        /// <summary>
        /// Gets or sets Foreign key to UserID
        /// </summary>
        [ForeignKey("NotesModel")]
        public int NoteID { get; set; }

        /// <summary>
        /// Gets or sets Foreign key to UserID as UserID is Primary Key in Register Model.
        /// </summary>
        public virtual NotesModel NotesModel { get; set; }

        /// <summary>
        /// Gets or sets EmailID as parameter to enter Email address.
        /// </summary>
        public string EmailID { get; set; }
    }
}
