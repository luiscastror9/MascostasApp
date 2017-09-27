using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMascotas.Controllers
{
    public class PaginaController : Controller
    {
<<<<<<< HEAD
        private mascotasEntities1 db = new mascotasEntities1();
        //
        // GET: /Pagina/
        public ActionResult Pagina(Usuario us)
        {
            //Usuario us = db.Usuario.FirstOrDefault(l => l.Nombre_de_Usuario == Response.Cookies["Nombre_de_Usuario"].Value);
            ViewBag.usu = us;
=======
        //
        // GET: /Pagina/
        public ActionResult Pagina()
        {
>>>>>>> master
            return View();
        }
	}
}