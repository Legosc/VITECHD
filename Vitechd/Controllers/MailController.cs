using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vitechd.Models;

namespace Vitechd.Controllers
{
    public class MailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mail
        public ActionResult Index()
        {
            return View(db.MailModels.ToList());
        }

        // GET: Mail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailModels mailModels = db.MailModels.Find(id);
            if (mailModels == null)
            {
                return HttpNotFound();
            }
            return View(mailModels);
        }

        // GET: Mail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mail/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Telephone,Message")] MailModels mailModels)
        {
            if (ModelState.IsValid)
            {
                db.MailModels.Add(mailModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mailModels);
        }

        // GET: Mail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailModels mailModels = db.MailModels.Find(id);
            if (mailModels == null)
            {
                return HttpNotFound();
            }
            return View(mailModels);
        }

        // POST: Mail/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Telephone,Message")] MailModels mailModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mailModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mailModels);
        }

        // GET: Mail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailModels mailModels = db.MailModels.Find(id);
            if (mailModels == null)
            {
                return HttpNotFound();
            }
            return View(mailModels);
        }

        // POST: Mail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MailModels mailModels = db.MailModels.Find(id);
            db.MailModels.Remove(mailModels);
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
