using Sandbox.Web.Data;
using Sandbox.Web.Models.Requests;
using Sandbox.Web.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Sandbox.Web.Controllers
{
    [HandleError()]
    public class MvcController : Controller
    {
        private IEmailService _emailService;
        private ISmsService _smsService;
        private ISandboxRepository _sandboxRepo;

        public MvcController(IEmailService emailService, ISmsService smsService, ISandboxRepository sandboxRepo)
        {
            _emailService = emailService;
            _smsService = smsService;
            _sandboxRepo = sandboxRepo;
        }

        public ActionResult Index()
        {
            return View(_sandboxRepo.GetPogs());
        }

        [HttpGet]
        public ActionResult Email()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Email(EmailPostRequest model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Model State is invalid: " + model.ToString());
            }

            string message = "<div>From: " + model.Name + " (" + model.Email + ")</div>"
                + "<div><em>" + model.Website + "<em></div>"
                + "<div>" + model.Message + "</div>";
            
            bool isSuccessful = await _emailService.SendToSiteAdminAsync(model.Email, message);
            if (isSuccessful)
            {
                return RedirectToAction("EmailConfirm");
            }
            return View();
        }

        public ActionResult EmailConfirm()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Sms()
        {
            ViewBag.Message = "Send SMS Message to Site Admin";

            return View();
        }

        [HttpPost]
        public ActionResult Sms(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("To send a text to the site admin a message must be provided","message");
            }
            _smsService.SendToSiteAdmin(message);
            return RedirectToAction("SmsConfirm");
        }

        public ActionResult SmsConfirm()
        {
            return View();
        }
    }
}