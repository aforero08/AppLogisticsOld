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
    public class ClientAreasController : Controller
    {
        private AppLogisticsDBEntities db = new AppLogisticsDBEntities();

        // GET: ClientAreas
        public async Task<ActionResult> Index()
        {
            var clientArea = db.ClientArea.Include(c => c.Client);
            return View(await clientArea.ToListAsync());
        }

        // GET: ClientAreas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientArea clientArea = await db.ClientArea.FindAsync(id);
            if (clientArea == null)
            {
                return HttpNotFound();
            }
            return View(clientArea);
        }

        // GET: ClientAreas/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name");
            return View();
        }

        // POST: ClientAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ClientId,Name")] ClientArea clientArea)
        {
            if (ModelState.IsValid)
            {
                db.ClientArea.Add(clientArea);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", clientArea.ClientId);
            return View(clientArea);
        }

        // GET: ClientAreas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientArea clientArea = await db.ClientArea.FindAsync(id);
            if (clientArea == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", clientArea.ClientId);
            return View(clientArea);
        }

        // POST: ClientAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ClientId,Name")] ClientArea clientArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientArea).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", clientArea.ClientId);
            return View(clientArea);
        }

        // GET: ClientAreas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientArea clientArea = await db.ClientArea.FindAsync(id);
            if (clientArea == null)
            {
                return HttpNotFound();
            }
            return View(clientArea);
        }

        // POST: ClientAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ClientArea clientArea = await db.ClientArea.FindAsync(id);
            db.ClientArea.Remove(clientArea);
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
        }
    }
}
