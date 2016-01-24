using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace system_oceny.Models
{
    public class Komentarz
    {
        [Key]
        public int komentarzID { get; set; }

        [Display(Name = "Treść")]
        [DataType(DataType.MultilineText)]
        public string tresc { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime data {get;set;}

        [Display(Name = "Autor")]
        public string autor { get; set; }

        [ForeignKey("firma")]
        public int FirmaId { get; set; }

        public virtual Firma firma{get;set;}
    }
}