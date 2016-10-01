using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrganizerMVC.App_Data;
using OrganizerMVC.Models;

namespace OrganizerMVC.Controllers
{
    public class ContactsController : Controller
    {
        private DbEntities db = new DbEntities();

        private Contacts FindOrRandom(int? id = null)
        {
            if (id == null)
            {
                int random = (new Random()).Next(db.Contacts.Count());
                return db.Contacts.OrderBy(x => x.Id).Skip(random).FirstOrDefault();
            }
            else
            {
                return db.Contacts.Find(id);
            }
        }

        // GET: Contacts
        public ActionResult Index(int? id)
        {
            return View(new FullContacts { Focus = FindOrRandom(id), Contacts = db.Contacts.OrderBy(x=>x.Surname).ToArray() });
        }

        // GET: Contacts/Details/5
        public PartialViewResult Details(int? id)
        {
            Contacts contact = FindOrRandom(id);
            if (contact == null)
            {
                //return HttpNotFound();
            }
            return PartialView("Details", contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public ActionResult Create([Bind(Include = "Id,Surname,Name,Patronymic,Birthday,Organization,Position")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contacts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contacts);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: Contacts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public ActionResult Edit([Bind(Include = "Id,Surname,Name,Patronymic,Birthday,Organization,Position")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contacts);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacts contacts = db.Contacts.Find(id);
            db.Contacts.Remove(contacts);
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
