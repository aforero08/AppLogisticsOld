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
    public class RatesController : Controller
    {
        private AppLogisticsDBEntities db = new AppLogisticsDBEntities();

        // GET: Rates
        public async Task<ActionResult> Index()
        {
            var rate = db.Rate.Include(r => r.Activity).Include(r => r.Client).Include(r => r.VehicleType);
            return View(await rate.ToListAsync());
        }

        // GET: Rates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = await db.Rate.FindAsync(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // GET: Rates/Create
        public ActionResult Create()
        {
            ViewBag.ActivityId = new SelectList(db.Activity, "Id", "Name");
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "Name");
            return View();
        }

        // POST: Rates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ClientId,ActivityId,VehicleTypeId,Price,PercentCost")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                db.Rate.Add(rate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityId = new SelectList(db.Activity, "Id", "Name", rate.ActivityId);
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", rate.ClientId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "Name", rate.VehicleTypeId);
            return View(rate);
        }

        // GET: Rates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = await db.Rate.FindAsync(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityId = new SelectList(db.Activity, "Id", "Name", rate.ActivityId);
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", rate.ClientId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "Name", rate.VehicleTypeId);
            return View(rate);
        }

        // POST: Rates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ClientId,ActivityId,VehicleTypeId,Price,PercentCost")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityId = new SelectList(db.Activity, "Id", "Name", rate.ActivityId);
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", rate.ClientId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "Name", rate.VehicleTypeId);
            return View(rate);
        }

        // GET: Rates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = await db.Rate.FindAsync(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rate rate = await db.Rate.FindAsync(id);
            db.Rate.Remove(rate);
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
