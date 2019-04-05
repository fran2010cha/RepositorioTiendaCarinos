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
    public class CalificarsController : Controller
    {
        private TiendaMascotasCariñosContext db = new TiendaMascotasCariñosContext();

        // GET: Calificars
        public ActionResult Index()
        {
            var calificars = db.Calificars.Include(c => c.Adoptar).Include(c => c.Comprar);
            return View(calificars.ToList());
        }

        // GET: Calificars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificar calificar = db.Calificars.Find(id);
            if (calificar == null)
            {
                return HttpNotFound();
            }
            return View(calificar);
        }

        // GET: Calificars/Create
        public ActionResult Create()
        {
            ViewBag.AdoptarID = new SelectList(db.Adoptars, "AdoptarID", "AdoptarID");
            ViewBag.ComprarID = new SelectList(db.Comprars, "ComprarID", "MedioPago");
            return View();
        }

        // POST: Calificars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CalificarID,calificacion,Comentario,ComprarID,AdoptarID")] Calificar calificar)
        {
            if (ModelState.IsValid)
            {
                db.Calificars.Add(calificar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdoptarID = new SelectList(db.Adoptars, "AdoptarID", "AdoptarID", calificar.AdoptarID);
            ViewBag.ComprarID = new SelectList(db.Comprars, "ComprarID", "MedioPago", calificar.ComprarID);
            return View(calificar);
        }

        // GET: Calificars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificar calificar = db.Calificars.Find(id);
            if (calificar == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdoptarID = new SelectList(db.Adoptars, "AdoptarID", "AdoptarID", calificar.AdoptarID);
            ViewBag.ComprarID = new SelectList(db.Comprars, "ComprarID", "MedioPago", calificar.ComprarID);
            return View(calificar);
        }

        // POST: Calificars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalificarID,calificacion,Comentario,ComprarID,AdoptarID")] Calificar calificar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdoptarID = new SelectList(db.Adoptars, "AdoptarID", "AdoptarID", calificar.AdoptarID);
            ViewBag.ComprarID = new SelectList(db.Comprars, "ComprarID", "MedioPago", calificar.ComprarID);
            return View(calificar);
        }

        // GET: Calificars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificar calificar = db.Calificars.Find(id);
            if (calificar == null)
            {
                return HttpNotFound();
            }
            return View(calificar);
        }

        // POST: Calificars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calificar calificar = db.Calificars.Find(id);
            db.Calificars.Remove(calificar);
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
