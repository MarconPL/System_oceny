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
        [DataType(DataType.MultilineText)]
        public string tresc;

        [DataType(DataType.Date)]
        public DateTime data;

        [Key]
        [ForeignKey("Ocena")]
        public int ocenaId { get; set; }
        public virtual Ocena Ocena { get; set; }
    }
}