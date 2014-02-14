using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administracao.Core.Abstract.Controllers
{
    public abstract class ControllerAbstract : Controller
    {
        protected List<string> getListRouters()
        {
            DirectoryInfo directory = new DirectoryInfo(Server.MapPath(@"~\Src\app"));
            var paths = directory.GetDirectories().ToList();

            var path = new List<string>();

            foreach (DirectoryInfo item in paths)
            {
                path.Add(item.Name);
            }

            return path;
        }

        public JsonResult retornarJson<T>(T result)
        {
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}