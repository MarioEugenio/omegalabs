using Administracao.Core.Abstract.Controllers;
using Administracao.Models;
using OmegaLabsZero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administracao.Controllers
{
    public class SubstanciaController : ControllerAbstract
    {
        private SubstanciaModel _model = new SubstanciaModel();
        //
        // GET: /Substancia/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pesquisa()
        {
            return View();
        }

        public ActionResult Substancia()
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

        public JsonResult GetAllStatus()
        {
            return this.retornarJson(_model.GetAllStatus());
        }

        public JsonResult Save(SUB_SUBSTANCIA entity)
        {
            try
            {
                var message = "";
                if (entity.SUB_ID > 0)
                {
                    message = "Alteracao realizada com sucesso";
                }
                else
                {
                    message = "Cadastro realizado com sucesso";
                }

                _model.Save(entity);
               
                return this.retornaMensagem(true, message);
            } catch(Exception ex) {

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
