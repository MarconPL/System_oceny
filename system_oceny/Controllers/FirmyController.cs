using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using system_oceny.Models;

namespace system_oceny.Controllers
{
    public class FirmyController : Controller
    {
        private FirmaDBCtxt db = new FirmaDBCtxt();

        public ActionResult Index(string sortowanie, FirmaSzukaj Model)
        {
            ViewBag.SortedBy = sortowanie;
            ViewBag.SortByOcena = sortowanie == null ? "Ocena_Malejaco" : "";
            ViewBag.SortByNazwa = sortowanie == "Nazwa_Malejaco" ? "Nazwa_Rosnaco" : "Nazwa_Malejaco";
            ViewBag.SortByBranza = sortowanie == "Branza_Malejaco" ? "Branza_Rosnaco" : "Branza_Malejaco";
            ViewBag.SortByOcenaJ = sortowanie == "OcenaJ_Malejaco" ? "OcenaJ_Rosnaco" : "OcenaJ_Malejaco";
            ViewBag.SortByOcenaCz = sortowanie == "OcenaCz_Malejaco" ? "OcenaCz_Rosnaco" : "OcenaCz_Malejaco";
            ViewBag.SortByOcenaCe = sortowanie == "OcenaCe_Malejaco" ? "OcenaCe_Rosnaco" : "OcenaCe_Malejaco";
            var firmy = from i in db.Firmy
                        select i;

             //Wyszukiwanie
            if (ModelState.IsValid)
            {
                if (Model.MiastoZnajdz != null && Model.BranzaZnajdz != null && Model.NazwaZnajdz != null)
                {
                    firmy = from i in db.Firmy
                            where i.Nazwa.Contains(Model.NazwaZnajdz) && i.Branza.Contains(Model.BranzaZnajdz) && i.miasto.Contains(Model.MiastoZnajdz)
                            select i;
                }
                else if (Model.BranzaZnajdz != null && Model.NazwaZnajdz != null)
                {
                    firmy = from i in db.Firmy
                            where i.Nazwa.Contains(Model.NazwaZnajdz) && i.Branza.Contains(Model.BranzaZnajdz)
                            select i;
                }
                else if (Model.BranzaZnajdz != null && Model.MiastoZnajdz != null)
                {
                    firmy = from i in db.Firmy
                            where i.miasto.Contains(Model.MiastoZnajdz) && i.Branza.Contains(Model.BranzaZnajdz)
                            select i;
                }
                else if (Model.MiastoZnajdz != null && Model.NazwaZnajdz != null)
                {
                    firmy = from i in db.Firmy
                            where i.Nazwa.Contains(Model.NazwaZnajdz) && i.miasto.Contains(Model.MiastoZnajdz)
                            select i;
                }
                else if (Model.BranzaZnajdz != null)
                {
                    firmy = from i in db.Firmy
                            where i.Branza.Contains(Model.BranzaZnajdz)
                            select i;
                }
                else if (Model.NazwaZnajdz != null)
                {
                    firmy = from i in db.Firmy
                            where i.Nazwa.Contains(Model.NazwaZnajdz)
                            select i;
                }
                else if (Model.MiastoZnajdz != null)
                {
                    firmy = from i in db.Firmy
                            where i.miasto.Contains(Model.MiastoZnajdz)
                            select i;
                }
                ViewBag.BranzaZnajdz = Model.BranzaZnajdz;
                ViewBag.NazwaZnajdz = Model.NazwaZnajdz;
                ViewBag.MiastoZnajdz = Model.MiastoZnajdz;
            }


            //Sortowanie
            switch (sortowanie)
            {
                case "Nazwa_Malejaco":
                    firmy = firmy.OrderByDescending(s => s.Nazwa);
                    break;
                case "Nazwa_Rosnaco":
                    firmy = firmy.OrderBy(s => s.Nazwa);
                    break;
                case "Branza_Malejaco":
                    firmy = firmy.OrderByDescending(s => s.Branza);
                    break;
                case "Branza_Rosnaco":
                    firmy = firmy.OrderBy(s => s.Branza);
                    break;
                case "Ocena_Malejaco":
                    firmy = firmy.OrderBy(s => s.ocena);
                    break;
                case "OcenaJ_Malejaco":
                    firmy = firmy.OrderBy(s => s.ocena_j);
                    break;
                case "OcenaJ_Rosnaco":
                    firmy = firmy.OrderByDescending(s => s.ocena_j);
                    break;
                case "OcenaCe_Malejaco":
                    firmy = firmy.OrderBy(s => s.ocena_ce);
                    break;
                case "OcenaCe_Rosnaco":
                    firmy = firmy.OrderByDescending(s => s.ocena_ce);
                    break;
                case "OcenaCz_Malejaco":
                    firmy = firmy.OrderBy(s => s.ocena_cz);
                    break;
                case "OcenaCz_Rosnaco":
                    firmy = firmy.OrderByDescending(s => s.ocena_cz);
                    break;
                default:
                    firmy = firmy.OrderByDescending(s => s.ocena);
                    break;
            }
            return View(firmy.ToList());
        }

        // GET: /Firmy/Details/X
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firma firma = db.Firmy.Find(id);
            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }

        // GET: /Firmy/Create
        [Authorize]
       public ActionResult Create()
        {
            return View();
        }

        // POST: /Firmy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Branza,Nazwa,Opis,NIP, email, miasto, kod_pocztowy, adres,numer_telefonu")] Firma firma)
        {
            firma.ocena = 0;
            firma.ocena_cz = 0;
            firma.ocena_ce = 0;
            firma.ocena_j = 0;
            firma.ilosc_ocen = 0;
            if (ModelState.IsValid)
            {
                db.Firmy.Add(firma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(firma);
        }

        // GET: /Firmy/Edit/X
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firma firma = db.Firmy.Find(id);
            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }

        // POST: /Firmy/Edit/X
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Branza,Nazwa,Opis,NIP, email, miasto, kod_pocztowy, adres, numer_telefonu, ocena, ocena_cz, ocena_j, ocena_ce")] Firma firma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(firma);
        }

        // GET: /Firmy/Delete/X
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firma firma = db.Firmy.Find(id);
            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }

        // POST: /Firmy/Delete/X
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Firma firma = db.Firmy.Find(id);
            db.Firmy.Remove(firma);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
