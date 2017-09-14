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
    public class AFPsController : Controller
    {
        private AppLogisticsDBEntities db = new AppLogisticsDBEntities();

        // GET: AFPs
        public async Task<ActionResult> Index()
        {
            return View(await db.AFP.ToListAsync());
        }

        // GET: AFPs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AFP aFP = await db.AFP.FindAsync(id);
            if (aFP == null)
            {
                return HttpNotFound();
            }
            return View(aFP);
        }

        // GET: AFPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AFPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,NIT,Id")] AFP aFP)
        {
            if (ModelState.IsValid)
            {
                db.AFP.Add(aFP);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aFP);
        }

        // GET: AFPs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AFP aFP = await db.AFP.FindAsync(id);
            if (aFP == null)
            {
                return HttpNotFound();
            }
            return View(aFP);
        }

        // POST: AFPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,NIT,Id")] AFP aFP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aFP).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aFP);
        }

        // GET: AFPs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AFP aFP = await db.AFP.FindAsync(id);
            if (aFP == null)
            {
                return HttpNotFound();
            }
            return View(aFP);
        }

        // POST: AFPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AFP aFP = await db.AFP.FindAsync(id);
            try
            {
                db.AFP.Remove(aFP);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No es posible borrar la AFP. Valide que no existan empleados con esta AFP asociada.");
                return View(aFP);
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
