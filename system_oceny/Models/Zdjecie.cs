using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace system_oceny.Models
{
    public class Zdjecie
    {
        [Key]
        public int zdjecieId { get; set; }

        [DataType(DataType.MultilineText)]
        public string opis { get; set; }

        public string Image { get; set; }

        [ForeignKey("Firma")]
        public int FirmaId { get; set; }
        public virtual Firma Firma { get; set; }
    }
}