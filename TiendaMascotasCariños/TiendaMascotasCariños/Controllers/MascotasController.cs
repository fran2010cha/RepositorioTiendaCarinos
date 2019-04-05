using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaMascotasCariños.Models;

namespace TiendaMascotasCariños.Controllers
{
    public class MascotasController : Controller
    {
        private TiendaMascotasCariñosContext db = new TiendaMascotasCariñosContext();

        // GET: Mascotas
        public ActionResult Index()
        {
            var mascotas = db.Mascotas.Include(m => m.Raza).Include(m => m.Tienda);
            return View(mascotas.ToList());
        }
        public ActionResult convertirImagen(int MascotaID)
        {
            var imagenMascota = db.Mascotas.Where(x => x.MascotaID == MascotaID).FirstOrDefault();

            return File(imagenMascota.imagenMascota, "image/jpeg");
        }
        // GET: Mascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // GET: Mascotas/Create
        public ActionResult Create()
        {
            ViewBag.RazaID = new SelectList(db.Razas, "RazaID", "Nombre");
            ViewBag.TiendaID = new SelectList(db.Tiendas, "TiendaID", "Nombre");
            return View();
        }

        // POST: Mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MascotaID,Nombre,FechaNacimiento,Color,Genero,HistorialMascota,Estado,Precio,TiendaID,RazaID")] Mascota mascota, HttpPostedFileBase ImagenMascota)
        {
            if (ImagenMascota != null && ImagenMascota.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(ImagenMascota.InputStream))
                {
                    imageData = binaryReader.ReadBytes(ImagenMascota.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                mascota.imagenMascota = imageData;
            }
            if (ModelState.IsValid)
            {
                db.Mascotas.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RazaID = new SelectList(db.Razas, "RazaID", "Nombre", mascota.RazaID);
            ViewBag.TiendaID = new SelectList(db.Tiendas, "TiendaID", "Nombre", mascota.TiendaID);
            return View(mascota);
        }

        // GET: Mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.RazaID = new SelectList(db.Razas, "RazaID", "Nombre", mascota.RazaID);
            ViewBag.TiendaID = new SelectList(db.Tiendas, "TiendaID", "Nombre", mascota.TiendaID);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MascotaID,Nombre,FechaNacimiento,Color,Genero,HistorialMascota,Estado,Precio,TiendaID,RazaID")] Mascota mascota, HttpPostedFileBase ImagenMascota)
        {
            if (ImagenMascota != null && ImagenMascota.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(ImagenMascota.InputStream))
                {
                    imageData = binaryReader.ReadBytes(ImagenMascota.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                mascota.imagenMascota = imageData;
            }
            if (ModelState.IsValid)
            {
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RazaID = new SelectList(db.Razas, "RazaID", "Nombre", mascota.RazaID);
            ViewBag.TiendaID = new SelectList(db.Tiendas, "TiendaID", "Nombre", mascota.TiendaID);
            return View(mascota);
        }

        // GET: Mascotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascota mascota = db.Mascotas.Find(id);
            db.Mascotas.Remove(mascota);
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
