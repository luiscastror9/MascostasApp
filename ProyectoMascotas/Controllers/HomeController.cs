using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoMascotas;
using System.IO;
using System.Net.Mail;

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


        public ActionResult Contactar(int? id)
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

        public ActionResult Contactarpart(int rid)
        {
            Usuario m = db.Usuario.FirstOrDefault(d => d.ID == rid);

            return PartialView(m);

        }

        [HttpPost]
        public ActionResult Contactar(string recibeEmail, string asunto, string mensaje)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var enviaMail = new MailAddress("app5rreas@gmail.com", "5rreas");
                    var recibeMail = new MailAddress(recibeEmail,"Recibe");

                    var password = "appmascotas";
                    var asu = asunto;
                    var cuerpo = mensaje;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                    Credentials=new NetworkCredential(enviaMail.Address, password)
                    

                    };

                    using (var men = new MailMessage(enviaMail, recibeMail)
                    {
                        Subject = asu,
                        Body = cuerpo

                    })
                    {
                        smtp.Send(men);
                    }

                    return RedirectToAction("Index", "Home");

                }
            }
            catch (Exception)
            {
                ViewBag.Error = "No se envio el mail";
            }
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
                
                return View();

            }
            else
            {
                return RedirectToAction("Validar", "Usuarios");
            }

                       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Carteleraperdidos(Mascotas mascotas)
        {
            //[Bind(Include = "Id,Animal,Raza,Ubicacion,Sexo,Descripcion,Vacunas,Edad,Status")]
        //,  HttpPostedFileBase image1





        var db = new mascotasEntities1();

            //string fileName = Path.GetFileNameWithoutExtension(mascotas.ImagenFile.FileName);
            string fileName = Path.GetFileNameWithoutExtension(mascotas.ImagenFile.FileName);
            string extension = Path.GetExtension(mascotas.ImagenFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //mascotas.ImagePath = "/Content/Imagenes/" + fileName;
            mascotas.ImagenA = "/Content/Imagenes/Mascotas/" + fileName;
            fileName = Path.Combine(Server.MapPath("/Content/Imagenes/Mascotas/"), fileName);
            mascotas.ImagenFile.SaveAs(fileName);

            //if (image1 != null)
            //{
            //    mascotas.Imagen = new byte[image1.ContentLength];
            //    image1.InputStream.Read(mascotas.Imagen, 0, image1.ContentLength);

            //}

            if (ModelState.IsValid)
            {
                db.Mascotas.Add(mascotas);
                db.SaveChanges();
                ModelState.Clear();
                return View();
            }
            else { 
                           
                return View();
            }
        }


        public ActionResult Cartelerad()
        {

            return PartialView(db.Mascotas.Where(db => db.Status == 2).OrderByDescending(db => db.Id));

        }

        public ActionResult Cartelera()
        {
            return PartialView(db.Mascotas.Where(db => db.Status == 1).OrderByDescending(db => db.Id));
        }

        public ActionResult CarteleraUsuario(int? id)
        {

            return PartialView(db.Mascotas.Where(db => db.RID == id).OrderByDescending(db => db.Id));
        }
        public ActionResult Daenadopcion()
        {
            Mascotas M = new Mascotas();
            return View(M);

        }
            
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Daenadopcion(Mascotas mascotas)
        {
            //[Bind(Include = "Id,Animal,Raza,Ubicacion,Sexo,Descripcion,Vacunas,Edad,Status")]
            //,  HttpPostedFileBase image1





            var db = new mascotasEntities1();

            //string fileName = Path.GetFileNameWithoutExtension(mascotas.ImagenFile.FileName);
            string fileName = Path.GetFileNameWithoutExtension(mascotas.ImagenFile.FileName);
            string extension = Path.GetExtension(mascotas.ImagenFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //mascotas.ImagePath = "/Content/Imagenes/" + fileName;
            mascotas.ImagenA = "/Content/Imagenes/Mascotas/" + fileName;
            fileName = Path.Combine(Server.MapPath("/Content/Imagenes/Mascotas/"), fileName);
            mascotas.ImagenFile.SaveAs(fileName);

            //if (image1 != null)
            //{
            //    mascotas.Imagen = new byte[image1.ContentLength];
            //    image1.InputStream.Read(mascotas.Imagen, 0, image1.ContentLength);

            //}

            if (ModelState.IsValid)
            {
                db.Mascotas.Add(mascotas);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Adopta");
            }
            else
            {

                return View();
            }
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Daenadopcion(Mascotas mascotas)
        //{
        //    //[Bind(Include = "Id,Animal,Raza,Ubicacion,Sexo,Descripcion,Vacunas,Edad,Status")]
        //    //,  HttpPostedFileBase image1





        //    //var db = new mascotasEntities1();

        //    ////string fileName = Path.GetFileNameWithoutExtension(mascotas.ImagenFile.FileName);
        //    //string fileName = Path.GetFileNameWithoutExtension(mascotas.ImagenFile.FileName);
        //    //string extension = Path.GetExtension(mascotas.ImagenFile.FileName);
        //    //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //    ////mascotas.ImagePath = "/Content/Imagenes/" + fileName;
        //    //mascotas.ImagenA = "/Content/Imagenes/Mascotas/" + fileName;
        //    //fileName = Path.Combine(Server.MapPath("/Content/Imagenes/Mascotas/"), fileName);
        //    //mascotas.ImagenFile.SaveAs(fileName);

        //    ////if (image1 != null)
        //    ////{
        //    ////    mascotas.Imagen = new byte[image1.ContentLength];
        //    ////    image1.InputStream.Read(mascotas.Imagen, 0, image1.ContentLength);

        //    ////}

        //    //if (ModelState.IsValid)
        //    //{
        //    //    db.Mascotas.Add(mascotas);
        //    //    db.SaveChanges();
        //    //    ModelState.Clear();
        //    //    return View("Adopta");
        //    //}
        //    //else
        //    //{

        //        return View();
        //    //}
        //}



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




        // POST: Mascotas/Delete/5
        public ActionResult Borrar(int id, int rid)
        {
            Mascotas mascotas = db.Mascotas.Find(id);
            db.Mascotas.Remove(mascotas);
            db.SaveChanges();
            return RedirectToAction("Details", "Usuarios", new { id=rid});
        }

        public ActionResult encontrado(int id, int rid)
        {
            Mascotas mascotas = db.Mascotas.Find(id);
            mascotas.Status = 3;
            db.SaveChanges();
            return RedirectToAction("Details", "Usuarios", new { id = rid });
        }

        public ActionResult adoptado(int id, int rid)
        {
            Mascotas mascotas = db.Mascotas.Find(id);
            mascotas.Status = 4;
            db.SaveChanges();
            return RedirectToAction("Details", "Usuarios", new { id = rid });
        }

    }

    }