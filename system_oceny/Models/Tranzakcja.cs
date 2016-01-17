using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace system_oceny.Models
{
    public class Tranzakcja
    {
        [Key]
        public int TranzakcjaId { get; set; }

        public int Id { get; set; }
        public virtual Firma Firma { get; set; }

        public string login { get; set; }
        public virtual Uzytkownik Uzytkownik { get; set; }

        [Display(Name = "Data")]
        public DateTime data;
    }
}
