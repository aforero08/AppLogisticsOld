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
    public class EPSController : Controller
    {
        private AppLogisticsDBEntities db = new AppLogisticsDBEntities();

        // GET: EPS
        public async Task<ActionResult> Index()
        {
            return View(await db.EPS.ToListAsync());
        }

        // GET: EPS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPS ePS = await db.EPS.FindAsync(id);
            if (ePS == null)
            {
                return HttpNotFound();
            }
            return View(ePS);
        }

        // GET: EPS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EPS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,NIT,Id")] EPS ePS)
        {
            if (ModelState.IsValid)
            {
                db.EPS.Add(ePS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ePS);
        }

        // GET: EPS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPS ePS = await db.EPS.FindAsync(id);
            if (ePS == null)
            {
                return HttpNotFound();
            }
            return View(ePS);
        }

        // POST: EPS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,NIT,Id")] EPS ePS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ePS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ePS);
        }

        // GET: EPS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPS ePS = await db.EPS.FindAsync(id);
            if (ePS == null)
            {
                return HttpNotFound();
            }
            return View(ePS);
        }

        // POST: EPS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EPS ePS = await db.EPS.FindAsync(id);
            db.EPS.Remove(ePS);
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
