using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModel
{
    public class NotesModel
    {
        [Key]
        public int NoteID { get; set; }
        // Foreign key to UserID

        [ForeignKey("RegisterModel")]
        public int UserID { get; set; }
        public virtual RegisterModel RegisterModel { get; set; }
        public string Title { get; set; }
        public string AddNotes { get; set; }
        public string Remainder { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }

        [DefaultValue(false)]
        public bool Pin { get; set; }

        [DefaultValue(false)]
        public bool Archieve { get; set; }

        [DefaultValue(false)]
        public bool Trash { get; set; }
    }
}
