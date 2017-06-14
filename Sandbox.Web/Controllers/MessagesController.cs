using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sandbox.Web.Controllers
{
    public class MessagesController : Controller
    {
        [HttpGet]
        public ActionResult Email()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Sms()
        {
            return View();
        }
    }
}