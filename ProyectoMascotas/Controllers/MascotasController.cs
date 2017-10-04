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
    public class MascotasController : Controller
    {
        private mascotasEntities1 db = new mascotasEntities1();

        // GET: Mascotas
        public ActionResult Index()
        {
            return View(db.Mascotas.ToList());
        }

        // GET: Mascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascotas mascotas = db.Mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            return View(mascotas);
        }

        // GET: Mascotas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Animal,Raza,Ubicacion,Sexo,Descripcion,Vacunas,Edad,Status")] Mascotas mascotas)
        {
            if (ModelState.IsValid)
            {
                db.Mascotas.Add(mascotas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mascotas);
        }

        // GET: Mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascotas mascotas = db.Mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            return View(mascotas);
        }

        // POST: Mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Animal,Raza,Ubicacion,Sexo,Descripcion,Vacunas,Edad,Status")] Mascotas mascotas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascotas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mascotas);
        }

        // GET: Mascotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascotas mascotas = db.Mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            return View(mascotas);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascotas mascotas = db.Mascotas.Find(id);
            db.Mascotas.Remove(mascotas);
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


    }


}
