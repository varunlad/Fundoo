using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModel
{
    public class CollaboratorModel
    {
        [Key]
        public int CollaboratorID { get; set; }

        // Foreign key to UserID
        [ForeignKey("NotesModel")]
        public int NoteID { get; set; }
        public virtual NotesModel NotesModel { get; set; }
        public string EmailID { get; set; }
    }
}
