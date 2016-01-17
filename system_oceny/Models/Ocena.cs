using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace system_oceny.Models
{
    public class Ocena
    {
        [Key]
        public int ocenaId{ get; set; }

        [Required]
        public int ocena;

        [Display(Name = "Ocena - Czas")]
        public int ocena_czas;
        [Display(Name = "Ocena - Jakość")]
        public int ocena_jakosc;
        [Display(Name = "Ocena - Cena")]
        public int ocena_cena;

        public virtual Firma Firma { get; set; }
        public virtual Uzytkownik Uzytkownik { get; set; }

        public virtual Komentarz Komentarz { get; set; }
    }
}