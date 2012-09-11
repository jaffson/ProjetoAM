using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendaMedica.Apresentacao.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Da Pra Encaixar?";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
