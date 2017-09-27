using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoMascotas;

namespace ProyectoMascotas.Controllers
{


    public class UsuariosController : Controller
    {
        private mascotasEntities1 db = new mascotasEntities1();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }

        

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Empresa,Nombre,Apellido,Nombre_de_Usuario,Pass,Localidad,Fecha_de_nacimiento,DNI,Tipo_de_usuario,Email,CPass")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Empresa,Nombre,Apellido,Nombre_de_Usuario,Pass,Localidad,Fecha_de_nacimiento,DNI,Tipo_de_usuario,Email,CPass")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
        public ActionResult Validar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Validar(string Nombre_de_Usuario, string Pass, Usuario usuario)
        {
            Usuario us = db.Usuario.FirstOrDefault(d => d.Nombre_de_Usuario == Nombre_de_Usuario & d.Pass == Pass);
            if (us != null)
            {
<<<<<<< HEAD
                                Request.Cookies.Add(new HttpCookie("login", "True"));
                Request.Cookies["login"].Expires = DateTime.Now.AddHours(1);
                Request.Cookies.Add(new HttpCookie("Nombre_de_Usuario", Nombre_de_Usuario));
                Request.Cookies["Nombre_de_Usuario"].Expires = DateTime.Now.AddHours(1);
                Response.Redirect("Pagina/Pagina",false);
                return RedirectToAction("", "", us);
=======
                return RedirectToAction("Index", "Usuarios");
>>>>>>> master
            }
            else
            {
                //return RedirectToAction("Nohallado", "Usuarios");
                //ViewBag.Error = "No se encontro ningun usuario";

                //return View();
                ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                return View();

            }
        }

        public ActionResult Nohallado()
        {
            ViewBag.Error = "No se encontro ningun usuario";
            return View();
        }


    }
}
