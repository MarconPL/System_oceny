using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace system_oceny.Models
{
    public class Ocena
    {
        [Key]
        public int ocenaId{ get; set; }

        [Required]
        [Range(1, 10)]
        public int ocena;

        [Display(Name = "Ocena - Czas")]
        [Range(1, 10)]
        public int ocena_czas;

        [Display(Name = "Ocena - Jakość")]
        [Range(1, 10)]
        public int ocena_jakosc;

        [Display(Name = "Ocena - Cena")]
        [Range(1, 10)]
        public int ocena_cena;

        public virtual Firma Firma { get; set; }
       // public virtual Uzytkownik Uzytkownik { get; set; }
    }
}