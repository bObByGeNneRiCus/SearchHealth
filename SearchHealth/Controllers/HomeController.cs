﻿using System;
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

        [HttpPost]
        public JsonResult GetListUnidadeSaude(string latitudeOrigem, string longitudeOrigem)
        {
            var lstUnidadeSaude = db.UnidadeSaude.SqlQuery(string.Format(@"
                select
                    * 
                from
                    UnidadeSaude 
                order by
                    geography:: Point({0}, {1}, 4326).STDistance(Geolocalizacao)", latitudeOrigem, longitudeOrigem)).ToList<Models.UnidadeSaude>();

            return new JsonResult { Data = lstUnidadeSaude, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}