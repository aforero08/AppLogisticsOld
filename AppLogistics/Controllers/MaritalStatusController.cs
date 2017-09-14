using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppLogisticsModel;

namespace AppLogistics.Controllers
{
    public class MaritalStatusController : Controller
    {
        private AppLogisticsDBEntities db = new AppLogisticsDBEntities();

        // GET: MaritalStatus
        public async Task<ActionResult> Index()
        {
            return View(await db.MaritalStatus.ToListAsync());
        }

        // GET: MaritalStatus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalStatus maritalStatus = await db.MaritalStatus.FindAsync(id);
            if (maritalStatus == null)
            {
                return HttpNotFound();
            }
            return View(maritalStatus);
        }

        // GET: MaritalStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaritalStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Id")] MaritalStatus maritalStatus)
        {
            if (ModelState.IsValid)
            {
                db.MaritalStatus.Add(maritalStatus);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(maritalStatus);
        }

        // GET: MaritalStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalStatus maritalStatus = await db.MaritalStatus.FindAsync(id);
            if (maritalStatus == null)
            {
                return HttpNotFound();
            }
            return View(maritalStatus);
        }

        // POST: MaritalStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Id")] MaritalStatus maritalStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maritalStatus).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(maritalStatus);
        }

        // GET: MaritalStatus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalStatus maritalStatus = await db.MaritalStatus.FindAsync(id);
            if (maritalStatus == null)
            {
                return HttpNotFound();
            }
            return View(maritalStatus);
        }

        // POST: MaritalStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MaritalStatus maritalStatus = await db.MaritalStatus.FindAsync(id);
            try
            {
                db.MaritalStatus.Remove(maritalStatus);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No es posible borrar el Estado Civil. Valide que no existan empleados con este Estado Civil asociado.");
                return View(maritalStatus);
            }
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
