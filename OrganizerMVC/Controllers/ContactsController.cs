using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OrganizerMVC.Models;
using System.Diagnostics;

namespace OrganizerMVC.Controllers
{
    public class ContactsController : Controller
    {
        private DbEntities db = new DbEntities();
        
        //private controller helper
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
            return View(new FullContacts { Focus = FindOrRandom(id), Contacts = db.Contacts.OrderBy(x=>x.Surname).ToList() });
        }

        // GET: Contacts/Details/5
        private PartialViewResult Details(int? id)
        {
            Contacts contact = FindOrRandom(id);
            if (contact == null)
            {
                return PartialView("Error");
            }
            return PartialView("_Details", contact);
        }

        // GET: Contacts/Create
        public PartialViewResult Create()
        {
            return PartialView("_Edit");
        }

        // POST: Contacts/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Post()
        {
            var contacts = new Contacts();
            TryUpdateModel(contacts);
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contacts);
                db.SaveChanges();
                return RedirectToAction("Index", new { Id = contacts.Id });
            }

            return RedirectToAction("Index");
        }

        // GET: Scheduler/Edit/5
        public PartialViewResult Edit(int? id)
        {
            if (id == null)
            {
                return PartialView(new HttpStatusCodeResult(HttpStatusCode.BadRequest));
            }
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return PartialView(HttpNotFound());
            }
            return PartialView("_Edit", contacts);
        }

        // POST: Contacts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Post()
        {
            var contacts = new Contacts();
            TryUpdateModel(contacts);
            if (ModelState.IsValid)
            {
                //не очень код, но работает!
                db.Contacts.Remove(db.Contacts.Find(contacts.Id));
                db.SaveChanges();
                db.Contacts.Add(contacts);
                db.SaveChanges();
                return RedirectToAction("Index", new { Id = contacts.Id });
            }
            return RedirectToAction("Index");
        }
        
        // POST: Contacts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Contacts contacts = db.Contacts.Find(id);
            db.Contacts.Remove(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*public ActionResult ContactsPhones()
        {
            Contacts contacts = db.Contacts.Find(id);
            db.Contacts.Remove(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /*
         private DbEntities db = new DbEntities();

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            return View(await db.Contacts.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = await db.Contacts.FindAsync(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Surname,Name,Patronymic,Birthday,Organization,Position,Gender")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contacts);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contacts);
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = await db.Contacts.FindAsync(id);
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Surname,Name,Patronymic,Birthday,Organization,Position,Gender")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacts).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contacts);
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = await db.Contacts.FindAsync(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contacts contacts = await db.Contacts.FindAsync(id);
            db.Contacts.Remove(contacts);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
