using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMascotas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Titulo = "hay 3 cocodrilos";
            return View();
        }
       [HttpPost]
        public ActionResult Index2()
        {
            ViewBag.Titulo = "hay 3 caimanes ";
//            return View("Index");
            return Content("kk");
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
    }
}