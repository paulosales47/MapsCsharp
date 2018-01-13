using Maps.Entidade;
using Maps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maps.Controllers
{
    public class HomeController : Controller
    {

        public List<PibEntidade> ListaPib()
        {
            PibModels model = new PibModels();

            return model.SelecionarPib(new PibEntidade());
        }


        public ActionResult Index()
        {
            return View();


        }

        public ActionResult GeoCode()
        {
            return View();
        }

        public JsonResult ListaPibJson()
        {
            List<PibEntidade> lPib = new List<PibEntidade>();

            lPib = this.ListaPib();

            return Json(lPib);

        }



    }
}