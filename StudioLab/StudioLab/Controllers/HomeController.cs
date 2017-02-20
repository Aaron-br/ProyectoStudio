using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudioLab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Jqueryui()
        {
            ViewBag.Message = "Page for Jquery UI examples.";

            return View();
        }

        public ActionResult Crud()
        {
            ViewBag.Message = "Page for Crud opertations.";

            return View();
        }


    }
}