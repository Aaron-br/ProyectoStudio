using StudioLab.Models;
using StudioLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudioLab.Controllers
{
    public class HomeController : Controller
    {


        private StudioLabDBEntities myDB;

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
        public ActionResult Helpers()
        {
            ViewBag.Message = "Page for Helpers.";

            HelpersViewModel vm = new HelpersViewModel();
            myDB = new StudioLabDBEntities();
            vm.listRoles = new List<SelectListItem>();
         
            //Obtenemos los objetos de rol de la BD y rellenamos el viewModel
            foreach (var rol in myDB.Roles) {

                vm.listRoles.Add(new SelectListItem
                {
                    Text = rol.nombreRol,
                    Value = rol.idRol.ToString()
                });
            }

            return View(vm);
        }

        public ActionResult Buscador()
        {
            ViewBag.Message = "Buscar por terminos.";

            return View();
        }



    }
}