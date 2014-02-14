using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmegaLabsZero.Controllers
{
    public class ErroController : Controller
    {
        public ActionResult Erro404(string error)
        {
            ViewBag.Erro = "A página solicitada não foi encontrada";
            return View("Erro");
        }

        public ActionResult Erro500(string error)
        {
            ViewBag.Erro = error;
            return View("Erro");
        }


        public ActionResult ErroGeral(string error)
        {
            ViewBag.Erro = error;
            return View("Erro");
        }
	}
}
        
       