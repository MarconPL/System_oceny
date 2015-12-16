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

        // GET: /Firmy/
        public ActionResult Index()
        {
            var firms = from i in db.Firmy
                       select i; 
            firms = firms.OrderByDescending(s => s.ocena);
            return View(firms.ToList());
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

        //Powinno się wywoływać po wywołaniu oceny
        [HttpPost]
        public ActionResult Details(int? id, string FirmaOcen)
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
            db.Entry(firma).State = EntityState.Modified;  
            firma.ocena = (firma.ocena*firma.ilosc_ocen+Single.Parse(FirmaOcen))/(firma.ilosc_ocen+1);
            firma.ilosc_ocen++;
            db.SaveChanges();
            return View(firma);
        }

        // GET: /Firmy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Firmy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Branza,Nazwa,Opis,ocena")] Firma firma)
        {
            firma.ocena = 0;
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
        public ActionResult Edit([Bind(Include="Id,Branza,Nazwa,Opis")] Firma firma)
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
        [HttpPost]
        public ActionResult Index(string FirmaZnajdz)
        {
           var firmy = from i in db.Firmy
                      select i;
           firmy = firmy.OrderByDescending(s => s.ocena);
           //jeśli coś przesłano, to wyszukaj po tym
           if (!String.IsNullOrEmpty(FirmaZnajdz))
           {
                firmy = from i in db.Firmy
                     where i.Nazwa.Contains(FirmaZnajdz)
                     select i;
           }
           return View(firmy.ToList());
        }
    }
}
