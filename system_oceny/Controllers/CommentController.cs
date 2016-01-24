using System;
using System.Collections.Generic;
using System.Linq;
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
                
                return RedirectToAction("Index");
            }

            return View(komentarz);
        }
	}
}