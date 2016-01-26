using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using system_oceny.Models;

namespace system_oceny.Controllers
{
    public class ImageController : Controller
    {
        private FirmaDBCtxt db = new FirmaDBCtxt();
        //
        // GET: /Image/
        public ActionResult Index(int id)
        {
        var zdjecia = from i in db.Zdjecia
                    where i.FirmaId==id
                    select i;

        ViewBag.FirmaId = id;
        return View(zdjecia.ToList());
        }

        //GET:
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Zdjecie/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "zdjecieId, opis, FirmaId")] Zdjecie zdjecie)
        {
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    zdjecie.Image = fileName;
                    file.SaveAs(path);
                }
            }
            if (ModelState.IsValid)
            {
                db.Zdjecia.Add(zdjecie);
                db.SaveChanges();
                return RedirectToAction("Index", "Image", new { id = zdjecie.FirmaId });
            }
            return View(zdjecie);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zdjecie zdjecie = db.Zdjecia.Find(id);
            if (zdjecie == null)
            {
                return HttpNotFound();
            }
            return View(zdjecie);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zdjecie zdjecie = db.Zdjecia.Find(id);
            if (zdjecie == null)
            {
                return HttpNotFound();
            }
            return View(zdjecie);
        }

        // POST: /Firmy/Delete/X
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Zdjecie zdjecie = db.Zdjecia.Find(id);
            db.Zdjecia.Remove(zdjecie);
            db.SaveChanges();
            return RedirectToAction("Index", "Image", new { id = zdjecie.FirmaId });
        }

	}
}