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
        public int komentarzID { get; set; }
        [DataType(DataType.MultilineText)]
        public string tresc;

        [DataType(DataType.Date)]
        public DateTime data;

        public virtual Firma Firma { get; set; }
        public virtual Uzytkownik User { get; set; }
    }
}