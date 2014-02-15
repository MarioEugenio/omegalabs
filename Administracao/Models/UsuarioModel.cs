using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OmegaLabsZero.Models;
using Administracao.Core.Abstract.Business;

namespace Administracao.Models
{
    public class UsuarioModel : BusinessAbstract
    {
        private OmegaModelContainer db = new OmegaModelContainer();

        public IOrderedQueryable<UsuarioViewModel> GetAll()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var retorno = (from USR in db.USR_USUARIO
                           let derivado = (
                                from DER in db.USR_USUARIO
                                select DER.USR_NOME
                            ).FirstOrDefault()
                           select new UsuarioViewModel
                           {
                               USR_ID = USR.USR_ID,
                               USR_NOME = USR.USR_NOME,
                               USR_EMAIL = USR.USR_EMAIL,
                               USR_SENHA = USR.USR_SENHA,
                               STA_ID = USR.STA_STATUS.STA_ID,
                               STA_NOME = USR.STA_STATUS.STA_NOME
                           }).OrderBy(x => x.USR_NOME);

            return retorno;
        }

        public UsuarioViewModel Get(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var retorno = (from USR in db.USR_USUARIO
                           where USR.USR_ID.Equals(id)
                           let derivado = (
                                from DER in db.USR_USUARIO
                                select DER.USR_NOME
                            ).FirstOrDefault()
                           select new UsuarioViewModel
                           {
                               USR_ID = USR.USR_ID,
                               USR_NOME = USR.USR_NOME,
                               USR_EMAIL = USR.USR_EMAIL,
                               USR_SENHA = USR.USR_SENHA,
                               STA_ID = USR.STA_STATUS.STA_ID,
                               STA_NOME = USR.STA_STATUS.STA_NOME
                           }).FirstOrDefault();

            return retorno;
        }

        public bool AuthenticateUser(USR_USUARIO entity)
        {
            db.Configuration.ProxyCreationEnabled = false;

            entity.USR_SENHA = this.convertMD5(entity.USR_SENHA);

            var retorno = (from USR in db.USR_USUARIO
                           where USR.USR_EMAIL.Equals(entity.USR_EMAIL)
                           where USR.USR_SENHA.Equals(entity.USR_SENHA)
                           let derivado = (
                                from DER in db.USR_USUARIO
                                select DER.USR_NOME
                            ).FirstOrDefault()
                           select new UsuarioViewModel
                           {
                               USR_ID = USR.USR_ID,
                               USR_NOME = USR.USR_NOME,
                               USR_EMAIL = USR.USR_EMAIL,
                               USR_SENHA = USR.USR_SENHA,
                               STA_ID = USR.STA_STATUS.STA_ID,
                               STA_NOME = USR.STA_STATUS.STA_NOME
                           }).FirstOrDefault();

            if (retorno == null) {
                return false;
            }

            entity.USR_NOME = retorno.USR_NOME;

            return true;
        }

        public void Save(USR_USUARIO entity)
        {
            entity.USR_SENHA = this.convertMD5(entity.USR_SENHA);

            if (entity.USR_ID > 0)
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                db.USR_USUARIO.Add(entity);
            }

            db.SaveChanges();
        }

        public void DeleteConfirmed(int id)
        {
            USR_USUARIO entity = db.USR_USUARIO.Find(id);
            db.USR_USUARIO.Remove(entity);
            db.SaveChanges();
        }
    }
}