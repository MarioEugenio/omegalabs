using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OmegaLabsZero.Models;

namespace OmegaLabsZero.Controllers
{
    public class PesquisaController : Controller
    {

        private OmegaModelContainer db = new OmegaModelContainer();

        public JsonResult retornarJson<T>(T result)
        {
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        // GetAll
        public JsonResult GetAll()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var retorno = (from SUB in db.SUB_SUBSTANCIA
                                  let derivado = (
                                       from DER in db.SUB_SUBSTANCIA
                                       where DER.SUB_ID == (SUB.DER_ID.HasValue ? SUB.DER_ID : 0)
                                       select DER.SUB_NOME
                                   ).FirstOrDefault() 
                                  select new PesquisaViewModel
                                  {
                                      SUB_ID = SUB.SUB_ID,
                                      SUB_NOME = SUB.SUB_NOME,
                                      STA_ID = SUB.STA_ID,
                                      STA_NOME = SUB.STA_STATUS.STA_NOME,
                                      DER_ID = SUB.DER_ID,
                                      DER_NOME = derivado,
                                      SUB_DETALHES = SUB.SUB_DETALHES
                                  }).OrderBy(x => x.SUB_NOME);
            return retornarJson(retorno);
        }

        // Get
        public JsonResult Get(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var retorno = (from SUB in db.SUB_SUBSTANCIA
                           where SUB.SUB_ID.Equals(id)
                           let derivado = (
                                from DER in db.SUB_SUBSTANCIA
                                where DER.SUB_ID == (SUB.DER_ID.HasValue ? SUB.DER_ID : 0)
                                select DER.SUB_NOME
                            ).FirstOrDefault()
                           select new PesquisaViewModel
                           {
                               SUB_ID = SUB.SUB_ID,
                               SUB_NOME = SUB.SUB_NOME,
                               STA_ID = SUB.STA_ID,
                               STA_NOME = SUB.STA_STATUS.STA_NOME,
                               DER_ID = SUB.DER_ID,
                               DER_NOME = derivado,
                               SUB_DETALHES = SUB.SUB_DETALHES
                           }).FirstOrDefault();
            return retornarJson(retorno);

        }

       

        // GET: /Substancia/Create
        public ActionResult Create()
        {
            ViewBag.STA_STA_ID = new SelectList(db.STA_STATUS, "STA_ID", "STA_STATUS1");
            return View();
        }

        // POST: /Substancia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SUB_ID,STA_STA_ID,SUB_NOME,STA_ID,DER_ID,SUB_DETALHES")] SUB_SUBSTANCIA sub_substancia)
        {
            if (ModelState.IsValid)
            {
                db.SUB_SUBSTANCIA.Add(sub_substancia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.STA_STA_ID = new SelectList(db.STA_STATUS, "STA_ID", "STA_STATUS1", sub_substancia.STA_ID);
            return View(sub_substancia);
        }

        // GET: /Substancia/Edit/5
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
            ViewBag.STA_STA_ID = new SelectList(db.STA_STATUS, "STA_ID", "STA_STATUS1", sub_substancia.STA_ID);
            return View(sub_substancia);
        }

        // POST: /Substancia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SUB_ID,STA_STA_ID,SUB_NOME,STA_ID,DER_ID,SUB_DETALHES")] SUB_SUBSTANCIA sub_substancia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sub_substancia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.STA_STA_ID = new SelectList(db.STA_STATUS, "STA_ID", "STA_STATUS1", sub_substancia.STA_ID);
            return View(sub_substancia);
        }

        // GET: /Substancia/Delete/5
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

        // POST: /Substancia/Delete/5
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