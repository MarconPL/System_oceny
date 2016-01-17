using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace system_oceny.Models
{
    public class Uzytkownik
    {
        [Key]
        public int uzytkownikId { get; set; }
    }
}