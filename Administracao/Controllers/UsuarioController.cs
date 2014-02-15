using Administracao.Core.Abstract.Controllers;
using Administracao.Models;
using OmegaLabsZero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Administracao.Controllers
{
    public class UsuarioController : ControllerAbstract
    {
        private UsuarioModel _model = new UsuarioModel();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            return this.retornarJson(_model.GetAll());
        }

        public JsonResult Get(int id)
        {
            return this.retornarJson(_model.Get(id));
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult Autenticacao(USR_USUARIO entity)
        {
            try
            {
                if (this.ModelState.IsValid && _model.AuthenticateUser(entity))
                {
                    FormsAuthentication.SetAuthCookie(entity.USR_NOME, true);

                    return this.retornaMensagem(true, "Autenticado com sucesso");
                } 

                return this.retornaMensagem(false, "Acesso negado");
            }
            catch (Exception ex)
            {

                return this.retornaMensagem(false, ex.Message);
            }
        }

        [HttpPost]
        public JsonResult LogOff()
        {
            FormsAuthentication.SignOut();

            return this.retornaMensagem(true, "processo realizado com sucesso");
        }


        public JsonResult Save(USR_USUARIO entity)
        {
            try
            {
                var message = "";
                if (entity.USR_ID > 0)
                {
                    message = "Alteracao realizada com sucesso";
                }
                else
                {
                    message = "Cadastro realizado com sucesso";
                }

                _model.Save(entity);

                return this.retornaMensagem(true, message);
            }
            catch (Exception ex)
            {

                return this.retornaMensagem(false, ex.Message);
            }
        }

        public JsonResult Remover(int id)
        {
            try
            {
                _model.DeleteConfirmed(id);

                return this.retornaMensagem(true, "Registro removido com sucesso");
            }
            catch (Exception ex)
            {

                return this.retornaMensagem(false, ex.Message);
            }
        }

    }
}
