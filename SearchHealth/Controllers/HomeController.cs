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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}