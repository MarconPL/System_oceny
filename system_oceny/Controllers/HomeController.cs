using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using system_oceny.Models;

namespace system_oceny.Controllers
{
    public class HomeController : Controller
    {
        private FirmaDBCtxt db = new FirmaDBCtxt();
        public ActionResult Index()
        {
            var firmy = from i in db.Firmy
                        select i;
            var komentarze = from i in db.Komentarze
                             select i;
            ViewBag.najlepsze = firmy.ToList().OrderByDescending(v => v.ocena).Take(5);
            ViewBag.najnowsze = komentarze.ToList().OrderByDescending(i => i.komentarzID).Take(5);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "System oceny jakości usług";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Autorzy:";

            return View();
        }
    }
}