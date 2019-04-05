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
    public class ProgenitorsController : Controller
    {
        private TiendaMascotasCariñosContext db = new TiendaMascotasCariñosContext();

        // GET: Progenitors
        public ActionResult Index()
        {
            var progenitors = db.Progenitors.Include(p => p.Mascota);
            return View(progenitors.ToList());
        }

        // GET: Progenitors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progenitor progenitor = db.Progenitors.Find(id);
            if (progenitor == null)
            {
                return HttpNotFound();
            }
            return View(progenitor);
        }

        // GET: Progenitors/Create
        public ActionResult Create()
        {
            ViewBag.MascotaID = new SelectList(db.Mascotas, "MascotaID", "Nombre");
            return View();
        }

        // POST: Progenitors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgenitorID,NombreProgenitor,Genero,MascotaID")] Progenitor progenitor)
        {
            if (ModelState.IsValid)
            {
                db.Progenitors.Add(progenitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MascotaID = new SelectList(db.Mascotas, "MascotaID", "Nombre", progenitor.MascotaID);
            return View(progenitor);
        }

        // GET: Progenitors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progenitor progenitor = db.Progenitors.Find(id);
            if (progenitor == null)
            {
                return HttpNotFound();
            }
            ViewBag.MascotaID = new SelectList(db.Mascotas, "MascotaID", "Nombre", progenitor.MascotaID);
            return View(progenitor);
        }

        // POST: Progenitors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgenitorID,NombreProgenitor,Genero,MascotaID")] Progenitor progenitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(progenitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MascotaID = new SelectList(db.Mascotas, "MascotaID", "Nombre", progenitor.MascotaID);
            return View(progenitor);
        }

        // GET: Progenitors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progenitor progenitor = db.Progenitors.Find(id);
            if (progenitor == null)
            {
                return HttpNotFound();
            }
            return View(progenitor);
        }

        // POST: Progenitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Progenitor progenitor = db.Progenitors.Find(id);
            db.Progenitors.Remove(progenitor);
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
