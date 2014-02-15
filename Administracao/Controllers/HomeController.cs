﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Administracao.Core.Abstract.Controllers;

namespace Administracao.Controllers
{
    public class HomeController : ControllerAbstract
    {

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Administracao()
        {
            return View();
        }

    }
}