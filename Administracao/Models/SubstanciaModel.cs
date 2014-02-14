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

        public IOrderedQueryable<StatusViewModel> GetAllStatus()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var retorno = (from STA in db.STA_STATUS
                           let derivado = (
                           from DER in db.STA_STATUS
                           select DER.STA_NOME
                            ).FirstOrDefault()
                           select new StatusViewModel
                           {
                               STA_ID = STA.STA_ID,
                               STA_NOME = STA.STA_NOME
                           }).OrderBy(x => x.STA_NOME);

            return retorno;
        }

        public void Save(SUB_SUBSTANCIA sub_substancia)
        {
            if (sub_substancia.SUB_ID > 0)
            {
                db.Entry(sub_substancia).State = System.Data.Entity.EntityState.Modified;
            } else {
                db.SUB_SUBSTANCIA.Add(sub_substancia);
            }
                        
            db.SaveChanges();
        }

        public void DeleteConfirmed(int id)
        {
            SUB_SUBSTANCIA sub_substancia = db.SUB_SUBSTANCIA.Find(id);
            db.SUB_SUBSTANCIA.Remove(sub_substancia);
            db.SaveChanges();
        }
    }
}