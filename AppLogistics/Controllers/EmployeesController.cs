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
    public class EmployeesController : Controller
    {
        private AppLogisticsDBEntities db = new AppLogisticsDBEntities();

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var employee = db.Employee.Include(e => e.AFP).Include(e => e.EPS).Include(e => e.MaritalStatus);
            return View(await employee.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employee.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.AfpId = new SelectList(db.AFP, "Id", "Name");
            ViewBag.EpsId = new SelectList(db.EPS, "Id", "Name");
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DocumentNumber,Name,Surname,BornDate,HireDate,RetirementDate,City,Address,MobilePhone,Phone,Email,EmergencyContact,EmergencyContactPhone,MaritalStatusId,AfpId,EpsId,Comments,CV,DocumentCopy,Photos,MilitaryIdCopy,LaborCertification,PersonalReference,DisciplinaryBackground,KnowledgeTest,AdmissionTest,Contract,InternalRegulations,EndownmentLetter,CriticalPosition")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AfpId = new SelectList(db.AFP, "Id", "Name", employee.AfpId);
            ViewBag.EpsId = new SelectList(db.EPS, "Id", "Name", employee.EpsId);
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "Id", "Name", employee.MaritalStatusId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employee.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.AfpId = new SelectList(db.AFP, "Id", "Name", employee.AfpId);
            ViewBag.EpsId = new SelectList(db.EPS, "Id", "Name", employee.EpsId);
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "Id", "Name", employee.MaritalStatusId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DocumentNumber,Name,Surname,BornDate,HireDate,RetirementDate,City,Address,MobilePhone,Phone,Email,EmergencyContact,EmergencyContactPhone,MaritalStatusId,AfpId,EpsId,Comments,CV,DocumentCopy,Photos,MilitaryIdCopy,LaborCertification,PersonalReference,DisciplinaryBackground,KnowledgeTest,AdmissionTest,Contract,InternalRegulations,EndownmentLetter,CriticalPosition")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AfpId = new SelectList(db.AFP, "Id", "Name", employee.AfpId);
            ViewBag.EpsId = new SelectList(db.EPS, "Id", "Name", employee.EpsId);
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "Id", "Name", employee.MaritalStatusId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employee.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employee.FindAsync(id);
            db.Employee.Remove(employee);
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
