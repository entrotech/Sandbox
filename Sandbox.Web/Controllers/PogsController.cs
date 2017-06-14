using Sandbox.Web.Models.Requests;
using Sandbox.Web.Services;
using System.Web.Mvc;

namespace Sandbox.Web.Controllers
{
    public class PogsController : Controller
    {

        public ActionResult Index()
        {
            var searchCriteria = new PogSearchRequest
            {
                ItemsPerPage = 10000
            };
            int rowCount = 0;
            var pogs = PogService.Search(searchCriteria, out rowCount);
            return View(pogs);
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult MatchHeight()
        {
            return View();
        }
    }
}