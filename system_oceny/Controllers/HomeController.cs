using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace system_oceny.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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