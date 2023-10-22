using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ReceptionistController : Controller
    {
        // GET: Receptionist
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Ads()
        {
            return View();
        }

        public ActionResult Clients()
        {
            return View();
        }
    }
}
