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
        public ActionResult Create(string Email, string Nombre_de_Usuario, string DNI, [Bind(Include = "Id,Empresa,Nombre,Apellido,Nombre_de_Usuario,Pass,Localidad,Fecha_de_nacimiento,DNI,Tipo_de_usuario,Email,CPass")] Usuario usuario)
        {
            Usuario us = db.Usuario.FirstOrDefault(d => d.Email == Email);
            Usuario es = db.Usuario.FirstOrDefault(d => d.Nombre_de_Usuario == Nombre_de_Usuario);
            Usuario ds = db.Usuario.FirstOrDefault(d => d.DNI == DNI);

            if (us != null){
                ModelState.AddModelError("", "Email en uso");
                if (es != null)
                {
                    ModelState.AddModelError("", "Usuario en uso"); 
                }
                if (ds != null)
                {
                    ModelState.AddModelError("", "N° de Identificacion en uso");
                }

                return View();

            }else             if (es != null){
                ModelState.AddModelError("", "Usuario en uso");
                if (ds != null)
                {
                    ModelState.AddModelError("", "N° de Identificacion en uso");
                }
                return View();
            }
            else if (ds != null)
            {
                ModelState.AddModelError("", "N° de Identificacion en uso");
                return View();
            }



            else
            {

                if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

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
        public ActionResult Validar(string Nombre_de_Usuario, string Pass, string ID, Usuario usuario)
        {
            Usuario us = db.Usuario.FirstOrDefault(d => d.Nombre_de_Usuario == Nombre_de_Usuario & d.Pass == Pass);
            Usuario numeroid = db.Usuario.FirstOrDefault(d => d.ID == d.ID & d.Nombre_de_Usuario == Nombre_de_Usuario);
            if (us != null)
            {
                Session["Username"] = new Usuario  { Nombre_de_Usuario= us.Nombre_de_Usuario };
                Session["ID"] = new Usuario { ID = numeroid.ID };
                return RedirectToAction("Index", "Home");
            }
            else
            {
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
