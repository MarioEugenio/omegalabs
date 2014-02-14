using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OmegaLabsZero.Models;

namespace Administracao.Models
{
    public class SubstanciaModel
    {
        private OmegaModelContainer db = new OmegaModelContainer();

        public IOrderedQueryable<PesquisaViewModel> GetAll()
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
            
            return retorno;
        }

        // Get
        public PesquisaViewModel Get(int id)
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
            return retorno;
        }
    }

        //public void Create(SUB_SUBSTANCIA sub_substancia)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SUB_SUBSTANCIA.Add(sub_substancia);
        //        db.SaveChanges();
        
        //    }
        //}

        //// GET: /Substancia/Edit/5
        //public void Edit(SUB_SUBSTANCIA sub_substancia)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sub_substancia).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }


        //}

        //public void DeleteConfirmed(int id)
        //{
        //    SUB_SUBSTANCIA sub_substancia = db.SUB_SUBSTANCIA.Find(id);
        //    db.SUB_SUBSTANCIA.Remove(sub_substancia);
        //    db.SaveChanges();
        //}
}