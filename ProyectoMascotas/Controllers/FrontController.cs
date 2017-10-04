using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoMascotas;

namespace ProyectoMascotas.Controllers
{
    public class FrontController : Controller
    {
        private mascotasEntities1 db = new mascotasEntities1();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Nombre_de_Usuario, string Pass, Usuario usuario)
        {
            Usuario us = db.Usuario.FirstOrDefault(d => d.Nombre_de_Usuario == Nombre_de_Usuario & d.Pass == Pass);
            Usuario numeroid = db.Usuario.FirstOrDefault(d => d.ID == d.ID & d.Nombre_de_Usuario == Nombre_de_Usuario);
            if (us != null)
            {
                Session["Username"] = new Usuario { Nombre_de_Usuario = us.Nombre_de_Usuario };
                Session["ID"] = new Usuario { ID = numeroid.ID };
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                return View();

            }
        }
    }

}