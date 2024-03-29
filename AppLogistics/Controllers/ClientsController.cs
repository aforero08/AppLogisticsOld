﻿using System;
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
    public class ClientsController : Controller
    {
        private AppLogisticsDBEntities db = new AppLogisticsDBEntities();

        // GET: Clients
        public async Task<ActionResult> Index()
        {
            var client = db.Client.Include(c => c.BranchOffice);
            return View(await client.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Client.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.BranchOfficeId = new SelectList(db.BranchOffice, "Id", "Name");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NIT,Name,Address,Phone,Contact,BranchOfficeId")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Client.Add(client);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BranchOfficeId = new SelectList(db.BranchOffice, "Id", "Name", client.BranchOfficeId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Client.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchOfficeId = new SelectList(db.BranchOffice, "Id", "Name", client.BranchOfficeId);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NIT,Name,Address,Phone,Contact,BranchOfficeId")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BranchOfficeId = new SelectList(db.BranchOffice, "Id", "Name", client.BranchOfficeId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Client.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Client client = await db.Client.FindAsync(id);
            try
            {
                db.Client.Remove(client);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No es posible borrar el cliente. Valide que no existan Servicios o Áreas de Cliente con este Cliente asociado.");
                return View(client);
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


    #region AJAX

        /// <summary>
        /// Permite obtener las áreas configuradas de un cliente a partir de su ID
        /// </summary>
        /// <param name="clientId">Id del cliente</param>
        /// <returns>JSON con las áreas de un cliente</returns>
        public JsonResult GetClientAreas(int clientId)
        {
            List<ClientArea> clientAreas = new List<ClientArea>();

            var areas = db.ClientArea.Where(ca => ca.ClientId.Equals(clientId));
            foreach (var area in areas)
            {
                ClientArea ca = new ClientArea(area.Id, area.Name);
                clientAreas.Add(ca);
            }

            return Json(clientAreas, JsonRequestBehavior.AllowGet);
        }

        private class ClientArea
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public ClientArea(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }

    #endregion

    }
}
