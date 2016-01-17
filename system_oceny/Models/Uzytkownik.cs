using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace system_oceny.Models
{
    public enum Uprawnienia
    {
        Uzytkownik, Firma, Administrator
    }

    public class Uzytkownik
    {
        [Key]
        [Required]
        [Display(Name = "Login")]
        public string login { get; set; }

        public Uprawnienia uprawnienia { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adres e-mail")]
        public string email { get; set; }

        [Display(Name = "Numer telefonu")]
        [DataType(DataType.PhoneNumber)]
        public string telefon { get; set; }

        [Display(Name = "Imię")]
        [StringLength(30)]
        public string imie { get; set;}
        [Display(Name = "Nazwisko")]
        [StringLength(30)]
        public string nazwisko { get; set; }

        [Display(Name = "Adres")]
        [StringLength(60)]
        public string adres { get; set; }

        [Display(Name = "Kod pocztowy")]
        [DataType(DataType.PostalCode)]
        public string kod_pocztowy { get; set; }

        [Display(Name = "Miasto")]
        [StringLength(30)]
        public string miasto { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public virtual ICollection<Tranzakcja> Tranzakcje { get; set; }
        public virtual ICollection<Ocena> Oceny { get; set; }
    }
}