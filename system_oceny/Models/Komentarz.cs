using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace system_oceny.Models
{
    public class Komentarz
    {
        [Key]
        public int id { get; set; }

        public string tresc;
        public DateTime data;

        public virtual Firma Firma { get; set; }
        public virtual Uzytkownik Uzytkownik { get; set; }
        //Ewentualnie dać komentarz pod ocene
    }
}