using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Ocena Główna")]
        public int ocenaG { get; set; }

        [Required]
        [Display(Name = "Ocena - Czas")]
        [Range(1, 10)]
        public int ocena_czas { get; set; }

        [Required]
        [Display(Name = "Ocena - Jakość")]
        [Range(1, 10)]
        public int ocena_jakosc { get; set; }

        [Required]
        [Display(Name = "Ocena - Cena")]
        [Range(1, 10)]
        public int ocena_cena { get; set; }

        public string login { get; set; }

        [ForeignKey("firma")]
        public int FirmaId { get; set; }
        public virtual Firma firma { get; set; }
       // public virtual Uzytkownik Uzytkownik { get; set; }
    }
}