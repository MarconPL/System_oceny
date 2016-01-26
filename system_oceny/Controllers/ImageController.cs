using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
	}
}