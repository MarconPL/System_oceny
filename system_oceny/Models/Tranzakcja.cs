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
        public int id { get; set; }

        public virtual Firma Firma { get; set; }
        public virtual Uzytkownik Uzytkownik { get; set; }
    }
}
