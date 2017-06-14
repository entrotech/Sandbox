using Sandbox.Web.Data;
using Sandbox.Web.Models.Requests;
using Sandbox.Web.Services;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sandbox.Web.Controllers
{

    public class HomeController : Controller
    {

        private ISandboxRepository _sandboxRepo;

        public HomeController(ISandboxRepository sandboxRepo)
        {
            _sandboxRepo = sandboxRepo;
        }

        public ActionResult Index()
        {
            return View(_sandboxRepo.GetPogs());
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Sms()
        {
            return View();
        }

        public ActionResult InternalServerError()
        {
            throw new ApplicationException("Ouch!");
        }



    }
}