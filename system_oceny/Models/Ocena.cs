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

        public int ocena_czas;
        public int ocena_jakosc;
        public int ocena_cena;

        public virtual Firma Firma { get; set; }
        public virtual Uzytkownik Uzytkownik { get; set; }
    }
}