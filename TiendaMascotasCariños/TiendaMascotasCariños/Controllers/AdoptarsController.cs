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
    public class AdoptarsController : Controller
    {
        private TiendaMascotasCariñosContext db = new TiendaMascotasCariñosContext();

        // GET: Adoptars
        public ActionResult Index()
        {
            var adoptars = db.Adoptars.Include(a => a.Mascota).Include(a => a.Usuario);
            return View(adoptars.ToList());
        }

        // GET: Adoptars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adoptar adoptar = db.Adoptars.Find(id);
            if (adoptar == null)
            {
                return HttpNotFound();
            }
            return View(adoptar);
        }

        // GET: Adoptars/Create
        public ActionResult Create()
        {
            ViewBag.MascotaID = new SelectList(db.Mascotas, "MascotaID", "Nombre");
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NombreCompleto");
            return View();
        }

        // POST: Adoptars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdoptarID,TieneMascota,CuantasMascotas,MascotaID,UsuarioID")] Adoptar adoptar)
        {
            if (ModelState.IsValid)
            {
                db.Adoptars.Add(adoptar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MascotaID = new SelectList(db.Mascotas, "MascotaID", "Nombre", adoptar.MascotaID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", adoptar.UsuarioID);
            return View(adoptar);
        }

        // GET: Adoptars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adoptar adoptar = db.Adoptars.Find(id);
            if (adoptar == null)
            {
                return HttpNotFound();
            }
            ViewBag.MascotaID = new SelectList(db.Mascotas, "MascotaID", "Nombre", adoptar.MascotaID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", adoptar.UsuarioID);
            return View(adoptar);
        }

        // POST: Adoptars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdoptarID,TieneMascota,CuantasMascotas,MascotaID,UsuarioID")] Adoptar adoptar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adoptar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MascotaID = new SelectList(db.Mascotas, "MascotaID", "Nombre", adoptar.MascotaID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", adoptar.UsuarioID);
            return View(adoptar);
        }

        // GET: Adoptars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adoptar adoptar = db.Adoptars.Find(id);
            if (adoptar == null)
            {
                return HttpNotFound();
            }
            return View(adoptar);
        }

        // POST: Adoptars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adoptar adoptar = db.Adoptars.Find(id);
            db.Adoptars.Remove(adoptar);
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
