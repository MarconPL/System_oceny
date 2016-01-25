using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using system_oceny.Models;

namespace system_oceny.Controllers
{
    public class OcenaController : Controller
    {
        private FirmaDBCtxt db = new FirmaDBCtxt();

        //GET:
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ocena/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ocenaId, ocenaG, ocena_czas, ocena_jakosc, ocena_cena, login, FirmaId")] Ocena ocena)
        {
            if (ModelState.IsValid)
            {
                db.Oceny.Add(ocena);
                db.SaveChanges();
                ranking(ocena.FirmaId);
                return RedirectToAction("Details", "Firmy", new { id = ocena.FirmaId });
            }
            return View(ocena);
        }

        // GET: /Comment/Edit/X
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocena ocena = db.Oceny.Find(id);
            if (ocena == null)
            {
                return HttpNotFound();
            }
            return View(ocena);
        }

        // POST: /Comment/Edit/X
        [HttpPost]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ocenaId, ocenaG, ocena_czas, ocena_jakosc, ocena_cena, login, FirmaId")] Ocena ocena)
        {
            // komentarz.data = DateTime.Today;
            if (ModelState.IsValid)
            {
                db.Entry(ocena).State = EntityState.Modified;
                db.SaveChanges();
                ranking(ocena.FirmaId);
                return RedirectToAction("Details", "Firmy", new { id = ocena.FirmaId });
            }
            return View(ocena);
        }

        //Statystyki firmy upgrade
        private void ranking(int id)
        {
            Firma firma = db.Firmy.Find(id);
            db.Entry(firma).State = EntityState.Modified;
            firma.ilosc_ocen = 0;
            firma.ocena = 0;
            firma.ocena_ce = 0;
            firma.ocena_cz = 0;
            firma.ocena_j = 0;
            foreach (Ocena ocena in db.Oceny)
            {
                if (ocena.FirmaId == id)
                {
                    firma.ocena += ocena.ocenaG;
                    firma.ocena_ce += ocena.ocena_cena;
                    firma.ocena_cz += ocena.ocena_czas;
                    firma.ocena_j += ocena.ocena_jakosc;
                    firma.ilosc_ocen++;
                }
            }

            firma.ocena /= firma.ilosc_ocen;
            firma.ocena_ce /= firma.ilosc_ocen;
            firma.ocena_cz /= firma.ilosc_ocen;
            firma.ocena_j /= firma.ilosc_ocen;
            db.SaveChanges();
        }
	}
}