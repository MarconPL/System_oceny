using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace system_oceny.Models
{
    public class Komentarz
    {
        [Key]
        [ForeignKey("Ocena")]
        public int ocenaId { get; set; }
        public virtual Ocena Ocena { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]

        [Display(Name = "Tresc")]
        public string tresc;

        [Display(Name = "Data")]
        public DateTime data;
    }
}