using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UGym_F;

namespace UGym_F.Controllers
{
    public class AdministradoresController : Controller
    {
        private UGymEntities db = new UGymEntities();

        // GET: Administradores
        public ActionResult Index()
        {
            var administradores = db.Administradores.Include(a => a.Roles);
            return View(administradores.ToList());
        }

        // GET: Administradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administradores administradores = db.Administradores.Find(id);
            if (administradores == null)
            {
                return HttpNotFound();
            }
            return View(administradores);
        }

        // GET: Administradores/Create
        public ActionResult Create()
        {
            ViewBag.RolId = new SelectList(db.Roles, "RolesId", "Nombre");
            return View();
        }

        // POST: Administradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminId,NombreCompleto,CorreoElectronico,RolId")] Administradores administradores)
        {
            if (ModelState.IsValid)
            {
                db.Administradores.Add(administradores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RolId = new SelectList(db.Roles, "RolesId", "Nombre", administradores.RolId);
            return View(administradores);
        }

        // GET: Administradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administradores administradores = db.Administradores.Find(id);
            if (administradores == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolId = new SelectList(db.Roles, "RolesId", "Nombre", administradores.RolId);
            return View(administradores);
        }

        // POST: Administradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminId,NombreCompleto,CorreoElectronico,RolId")] Administradores administradores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administradores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolId = new SelectList(db.Roles, "RolesId", "Nombre", administradores.RolId);
            return View(administradores);
        }

        // GET: Administradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administradores administradores = db.Administradores.Find(id);
            if (administradores == null)
            {
                return HttpNotFound();
            }
            return View(administradores);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administradores administradores = db.Administradores.Find(id);
            db.Administradores.Remove(administradores);
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
