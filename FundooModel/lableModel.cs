using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModel
{
    public class LableModel
    {
        [Key]
        public int LableId { get; set; }
        public string Lable { get; set; }

        // Foreign key to LabeId
        [ForeignKey("NotesModel")]
        public int? NoteID { get; set; }
        public virtual NotesModel NotesModel { get; set; }
        // Foreign key to LabeId
        [ForeignKey("RegisterModel")]
        public int UserID { get; set; }
        public virtual RegisterModel RegistrationModel { get; set; }

    }
}
