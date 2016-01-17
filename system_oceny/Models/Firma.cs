using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace system_oceny.Models
{
    public enum Brand
    {
        Komputerowa, Spożywcza, Handlowa, Usługowa, Samochodwa
    }

    public class Firma
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Branża")]
        public string Branza { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        [StringLength(50)]
        public string Nazwa { get; set; }

        [Required]
        [Display(Name = "NIP")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Wpisz numer NIP bez łączników")]
        public int NIP{ get; set; }

        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string Opis { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adres e-mail")]
        public string email { get; set; }

        [Display(Name = "Numer telefonu")]
        [DataType(DataType.PhoneNumber)]
        public string numer_telefonu { get; set; }

        [Display(Name = "Adres")]
        [StringLength(60)]
        public string adres { get; set; }

        [Display(Name = "Kod pocztowy")]
        [DataType(DataType.PostalCode)]
        public string kod_pocztowy { get; set; }

        [Display(Name = "Miasto")]
        [StringLength(30)]
        public string miasto { get; set; }

        public float ocena { get; set; }
        public int ilosc_ocen { get; set; }

        public virtual ICollection<Zdjecie> Zdjecia { get; set; }
        public virtual ICollection<Tranzakcja> Tranzakcje { get; set; }
       // public virtual ICollection<Komentarz> Komentarze { get; set; }
        public virtual ICollection<Ocena> Oceny { get; set; }


    }

    public class DefaultConnection : DbContext
    {
        public DbSet<Firma> Firmy { get; set; }
        public DbSet<Ocena> Oceny { get; set; }
        public DbSet<Komentarz> Komentarze { get; set; }
        public DbSet<Tranzakcja> Tranzakcje { get; set; }
        public DbSet<Zdjecie> Zdjecia { get; set; }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
    }
}