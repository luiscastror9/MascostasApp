using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMascotas.Controllers
{
    public class FrontController : Controller
    {
        //
        // GET: /Front/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


    }

}