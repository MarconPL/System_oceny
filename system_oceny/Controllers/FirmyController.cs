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
        //Stara metoda
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

        // GET: /Firmy/ 
        public ActionResult Index()
        {
            return View(baza.Firmy.ToList());
        }

        // GET: /Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Branza,Nazwa,Opis")] Firma company)
        {
            if (ModelState.IsValid)
            {
                baza.Firmy.Add(company);
                baza.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }
	}
}