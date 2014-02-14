using Administracao.Core.Abstract.Controllers;
using Administracao.Models;
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
    }
}
