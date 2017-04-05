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
    public class BranchOfficesController : Controller
    {
        private AppLogisticsDBEntities db = new AppLogisticsDBEntities();

        // GET: BranchOffices
        public async Task<ActionResult> Index()
        {
            return View(await db.BranchOffice.ToListAsync());
        }

        // GET: BranchOffices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchOffice branchOffice = await db.BranchOffice.FindAsync(id);
            if (branchOffice == null)
            {
                return HttpNotFound();
            }
            return View(branchOffice);
        }

        // GET: BranchOffices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BranchOffices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Id")] BranchOffice branchOffice)
        {
            if (ModelState.IsValid)
            {
                db.BranchOffice.Add(branchOffice);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(branchOffice);
        }

        // GET: BranchOffices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchOffice branchOffice = await db.BranchOffice.FindAsync(id);
            if (branchOffice == null)
            {
                return HttpNotFound();
            }
            return View(branchOffice);
        }

        // POST: BranchOffices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Id")] BranchOffice branchOffice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branchOffice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(branchOffice);
        }

        // GET: BranchOffices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchOffice branchOffice = await db.BranchOffice.FindAsync(id);
            if (branchOffice == null)
            {
                return HttpNotFound();
            }
            return View(branchOffice);
        }

        // POST: BranchOffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BranchOffice branchOffice = await db.BranchOffice.FindAsync(id);
            db.BranchOffice.Remove(branchOffice);
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
