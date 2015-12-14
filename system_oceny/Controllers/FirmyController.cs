using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using system_oceny.Models;

namespace system_oceny.Controllers
{
    public class FirmyController : Controller
    {
        private FirmaDBCtxt baza = new FirmaDBCtxt();
        //Stara metoda//
        // GET: /Firmy/ 
       /* public ActionResult Index()
        {
            //tworzymy obiekt klasy Firma
            Firma obiekt = new Firma();

            //przypisujemy wartość dla pola ID
            obiekt.Id = 1;
            obiekt.Branza = "Spozywcza";
            obiekt.Nazwa = "Jadłodajnia Martwy Pies";
            obiekt.Opis = "Najlepsze psie mięso w kraju";

            //zwracamy obiekt klasy Car do widoku
            return View(obiekt);
        } */
        public ActionResult Index()
        {
            return View(baza.Firmy.ToList());
        }
	}
}