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
    public class HomeController : Controller
    {
        private mascotasEntities1 db = new mascotasEntities1();

        public ActionResult Index()
        {
            if(Session["Username"] != null)
            {
            ViewBag.Titulo = "AppMascotas";
            return View();
            }else
            {
                return RedirectToAction("Validar", "Usuarios");
            }
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

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Validar", "Usuarios");
        }

        public ActionResult Adopta()
        {
            if (Session["Username"] != null)
            {
                ViewBag.Titulo = "AppMascotas";
                ViewBag.Message = "ACA VA LA PAGINA PARA ADOPTAR UN PERRO";
                return View();
            }
            else
            {
                return RedirectToAction("Validar", "Usuarios");
            }
        }

        public ActionResult Carteleraperdidos()
        {
            if (Session["Username"] != null)
            {

                ViewBag.Titulo = "AppMascotas";
                ViewBag.Message = "ACA VA LA PAGINA CARTELERA DE PERROS PERDIDOS Y AGREGAR UN PERRO A LA CARTELERA";
                return View();

            }
            else
            {
                return RedirectToAction("Validar", "Usuarios");
            }

                       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Carteleraperdidos([Bind(Include = "Id,Animal,Raza,Ubicacion,Sexo,Descripcion,Vacunas,Edad,Status")] Mascotas mascotas)
        {
            if (ModelState.IsValid)
            {
                db.Mascotas.Add(mascotas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mascotas);
        }

        public ActionResult Cartelera()
        {
            return PartialView(db.Mascotas.ToList());
        }


        public ActionResult Daenadopcion()
        {
            if (Session["Username"] != null)
            {
                ViewBag.Titulo = "AppMascotas";
                ViewBag.Message = "ACA VA LA PAGINA DE DAR EN ADOPCION TU MASCOTA";
                return View();
            }
            else
            {
                return RedirectToAction("Validar", "Usuarios");
            }

            
        }

        public ActionResult Quiensomos()
        {
            if (Session["Username"] != null)
            {
                ViewBag.Titulo = "AppMascotas";
                ViewBag.Message = "ACA VA LA PAGINA QUIENES SOMOS";
                return View();
            }
            else
            {
                return RedirectToAction("Validar", "Usuarios");
            }

        }


        }

    }