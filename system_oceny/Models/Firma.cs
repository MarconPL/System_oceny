using System;
using System.Collections.Generic;
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
        public int ocena { get; set; } //nie działa na razie
    }

    public class FirmaDBCtxt : DbContext
    {
        public DbSet<Firma> Firmy { get; set; }
    }
}