using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OmegaLabsZero.Models;

namespace OmegaLabsZero.Controllers.Nimda
{
    public class TesteController : Controller
    {
        private OmegaModelContainer db = new OmegaModelContainer();

        // GET: /Teste/
        public ActionResult Index()
        {
            var sub_substancia = db.SUB_SUBSTANCIA.Include(s => s.STA_STATUS);
            return View(sub_substancia.ToList());
        }

        // GET: /Teste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUB_SUBSTANCIA sub_substancia = db.SUB_SUBSTANCIA.Find(id);
            if (sub_substancia == null)
            {
                return HttpNotFound();
            }
            return View(sub_substancia);
        }

        // GET: /Teste/Create
        public ActionResult Create()
        {
            ViewBag.STA_ID = new SelectList(db.STA_STATUS, "STA_ID", "STA_NOME");
            return View();
        }

        // POST: /Teste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SUB_ID,STA_ID,SUB_NOME,DER_ID,SUB_DETALHES")] SUB_SUBSTANCIA sub_substancia)
        {
            if (ModelState.IsValid)
            {
                db.SUB_SUBSTANCIA.Add(sub_substancia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.STA_ID = new SelectList(db.STA_STATUS, "STA_ID", "STA_NOME", sub_substancia.STA_ID);
            return View(sub_substancia);
        }

        // GET: /Teste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUB_SUBSTANCIA sub_substancia = db.SUB_SUBSTANCIA.Find(id);
            if (sub_substancia == null)
            {
                return HttpNotFound();
            }
            ViewBag.STA_ID = new SelectList(db.STA_STATUS, "STA_ID", "STA_NOME", sub_substancia.STA_ID);
            return View(sub_substancia);
        }

        // POST: /Teste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SUB_ID,STA_ID,SUB_NOME,DER_ID,SUB_DETALHES")] SUB_SUBSTANCIA sub_substancia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sub_substancia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.STA_ID = new SelectList(db.STA_STATUS, "STA_ID", "STA_NOME", sub_substancia.STA_ID);
            return View(sub_substancia);
        }

        // GET: /Teste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUB_SUBSTANCIA sub_substancia = db.SUB_SUBSTANCIA.Find(id);
            if (sub_substancia == null)
            {
                return HttpNotFound();
            }
            return View(sub_substancia);
        }

        // POST: /Teste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUB_SUBSTANCIA sub_substancia = db.SUB_SUBSTANCIA.Find(id);
            db.SUB_SUBSTANCIA.Remove(sub_substancia);
            db.SaveChanges();
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
