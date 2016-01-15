using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace system_oceny.Models
{
    public class Firma
    {
        public int Id { get; set; }
        public string Branza { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public float ocena { get; set; }
        public int ilosc_ocen {get;set;}
    }

    public class DefaultConnection : DbContext
    {
        public DbSet<Firma> Firmy { get; set; }
    }
}