using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sandbox.Web.Controllers
{
    public class MapsController : Controller
    {
        // GET: Maps
        public ActionResult Index()
        {
            ViewBag.GoogleMapsAPI = System.Configuration.ConfigurationManager.AppSettings["GoogleMapsApiKey"];
            return View();
        }

        public ActionResult Udemy()
        {
            return View();
        }
    }
}