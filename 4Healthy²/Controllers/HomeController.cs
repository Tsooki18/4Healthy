using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4Healthy_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.Message = "Saiba mais sobre a iniciativa 4ĦEALTHY !";

            return View();
        }

        public ActionResult Contato()
        {
            ViewBag.Message = "Como nos contatar";

            return View();
        }

        public ActionResult Lista()
        {
            ViewBag.Message = "Lista de Alimentos - Licenciado pela USDA National Nutrient Database for Standard Reference";

            return View();
        }
    }
}