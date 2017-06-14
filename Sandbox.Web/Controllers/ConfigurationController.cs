using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sandbox.Web.Controllers
{
    public class ConfigurationController : BaseController
    {
        // GET: Configuration
        public ActionResult Index()
        {
            return View();
        }
    }
}