using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaMascotasCariños.Models;

namespace TiendaMascotasCariños.Controllers
{
    public class ComprarsController : Controller
    {
        private TiendaMascotasCariñosContext db = new TiendaMascotasCariñosContext();

        // GET: Comprars
        public ActionResult Index()
        {
            var comprars = db.Comprars.Include(c => c.Mascota).Include(c => c.Usuario);
            return View(comprars.ToList());
        }

        // GET: Comprars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprar comprar = db.Comprars.Find(id);
            if (comprar == null)
            {
                return HttpNotFound();
            }
            return View(comprar);
        }

        // GET: Comprars/Create
        public ActionResult Create()
        {
            ViewBag.MascotaID = new SelectList(db.Mascotas, "MascotaID", "Nombre");
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre");
            return View();
        }

        // POST: Comprars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComprarID,MedioPago,MascotaID,UsuarioID")] Comprar comprar)
        {
            if (ModelState.IsValid)
            {
                db.Comprars.Add(comprar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MascotaID = new SelectList(db.Mascotas, "MascotaID", "Nombre", comprar.MascotaID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", comprar.UsuarioID);
            return View(comprar);
        }

        // GET: Comprars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprar comprar = db.Comprars.Find(id);
            if (comprar == null)
            {
                return HttpNotFound();
            }
            ViewBag.MascotaID = new SelectList(db.Mascotas, "MascotaID", "Nombre", comprar.MascotaID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", comprar.UsuarioID);
            return View(comprar);
        }

        // POST: Comprars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComprarID,MedioPago,MascotaID,UsuarioID")] Comprar comprar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comprar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MascotaID = new SelectList(db.Mascotas, "MascotaID", "Nombre", comprar.MascotaID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", comprar.UsuarioID);
            return View(comprar);
        }

        // GET: Comprars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprar comprar = db.Comprars.Find(id);
            if (comprar == null)
            {
                return HttpNotFound();
            }
            return View(comprar);
        }

        // POST: Comprars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comprar comprar = db.Comprars.Find(id);
            db.Comprars.Remove(comprar);
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
