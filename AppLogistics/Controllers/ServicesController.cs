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
    public class ServicesController : Controller
    {
        private AppLogisticsDBEntities db = new AppLogisticsDBEntities();

        // GET: Services
        public async Task<ActionResult> Index()
        {
            var service = db.Service.Include(s => s.Activity).Include(s => s.Carrier).Include(s => s.Client).Include(s => s.Product).Include(s => s.VehicleType);
            return View(await service.ToListAsync());
        }

        // GET: Services/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = await db.Service.FindAsync(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            ViewBag.ActivityId = new SelectList(db.Activity, "Id", "Name");
            ViewBag.CarrierId = new SelectList(db.Carrier, "Id", "Name");
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Product, "Id", "Name");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "Name");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ExecutionDate,ClientId,ClientAreaId,ActivityId,ProductId,ProductQuantity,VehicleTypeId,VehicleNumber,CarrierId,ExternalId,Comments,CreationDate,FullPrice,HoldingPrice")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Service.Add(service);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityId = new SelectList(db.Activity, "Id", "Name", service.ActivityId);
            ViewBag.CarrierId = new SelectList(db.Carrier, "Id", "Name", service.CarrierId);
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", service.ClientId);
            ViewBag.ProductId = new SelectList(db.Product, "Id", "Name", service.ProductId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "Name", service.VehicleTypeId);
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = await db.Service.FindAsync(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityId = new SelectList(db.Activity, "Id", "Name", service.ActivityId);
            ViewBag.CarrierId = new SelectList(db.Carrier, "Id", "Name", service.CarrierId);
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", service.ClientId);
            ViewBag.ProductId = new SelectList(db.Product, "Id", "Name", service.ProductId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "Name", service.VehicleTypeId);
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ExecutionDate,ClientId,ClientAreaId,ActivityId,ProductId,ProductQuantity,VehicleTypeId,VehicleNumber,CarrierId,ExternalId,Comments,CreationDate,FullPrice,HoldingPrice")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityId = new SelectList(db.Activity, "Id", "Name", service.ActivityId);
            ViewBag.CarrierId = new SelectList(db.Carrier, "Id", "Name", service.CarrierId);
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", service.ClientId);
            ViewBag.ProductId = new SelectList(db.Product, "Id", "Name", service.ProductId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "Name", service.VehicleTypeId);
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = await db.Service.FindAsync(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Service service = await db.Service.FindAsync(id);
            db.Service.Remove(service);
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
