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
    public class CommentController : Controller
    {
        private FirmaDBCtxt db = new FirmaDBCtxt();
        //GET:
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Firmy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "komentarzID, tresc, data, autor, FirmaId")] Komentarz komentarz)
        {
            komentarz.data = DateTime.Today;
            if (ModelState.IsValid)
            {
                db.Komentarze.Add(komentarz);
                db.SaveChanges();

                return RedirectToAction("Details", "Firmy", new { id = komentarz.FirmaId });
            }

            return View(komentarz);
        }

        // GET: /Comment/Edit/X
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentarz komentarz = db.Komentarze.Find(id);
            if (komentarz == null)
            {
                return HttpNotFound();
            }
            return View(komentarz);
        }

        // POST: /Comment/Edit/X
        [HttpPost]
        [Authorize]
        public ActionResult Edit([Bind(Include = "komentarzID, tresc, data, autor, FirmaId")] Komentarz komentarz)
        {
            // komentarz.data = DateTime.Today;
            if (ModelState.IsValid)
            {
                db.Entry(komentarz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Firmy", new { id = komentarz.FirmaId });
            }
            return View(komentarz);
        }

        // GET: /Firmy/Delete/X
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentarz komentarz = db.Komentarze.Find(id);
            if (komentarz == null)
            {
                return HttpNotFound();
            }
            return View(komentarz);
        }

        // POST: /Firmy/Delete/X
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Komentarz komentarz = db.Komentarze.Find(id);
            db.Komentarze.Remove(komentarz);
            db.SaveChanges();
            return RedirectToAction("Details", "Firmy", new { id = komentarz.FirmaId });
        }
    }
}