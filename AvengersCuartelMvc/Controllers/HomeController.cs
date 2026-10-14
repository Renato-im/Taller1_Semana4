using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvengersCuartelMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Cuartel de Héroes MVC con EF y Scaffold";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacto";
            return View();
        }
    }
}