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
                return RedirectToAction("Details", "Firmy", new { id = ocena.FirmaId });
            }
            return View(ocena);
        }
	}
}