using OmegaLabsZero.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmegaLabsZero.Controllers.Admin
{
    public class SubstanciaController : Controller
    {
        private OmegaModelContainer db = new OmegaModelContainer();

        public JsonResult retornarJson<T>(T result)
        {
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View("~/Views/Nimda/Substancia.cshtml");
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


        // POST: /Substancia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SUB_SUBSTANCIA sub_substancia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sub_substancia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("~/Views/Nimda/Substancia.cshtml");
            }

            return View("~/Views/Nimda/Substancia.cshtml");
        }

    }
}
