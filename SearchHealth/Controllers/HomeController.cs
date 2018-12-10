using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchHealth.Controllers
{
    public class HomeController : Controller
    {
        Models.SearchHealthEntities db = new Models.SearchHealthEntities();
            
        public ActionResult Index()
        {
            var lstUnidadeSaude = new List<Models.UnidadeSaude>();
            lstUnidadeSaude = db.UnidadeSaude.ToList();

            return View(lstUnidadeSaude);       
        }

        public JsonResult GetListUnidadeSaude()
        {
            var lstUnidadeSaude = new List<Models.UnidadeSaude>();
            lstUnidadeSaude = db.UnidadeSaude.ToList();

            return new JsonResult { Data = lstUnidadeSaude, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}