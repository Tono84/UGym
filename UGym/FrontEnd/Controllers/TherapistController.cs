using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TherapistController : Controller
    {
        // GET: Therapist
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Clients()
        {
            return View();
        }

        public ActionResult Reports()
        {
            return View();
        }
    }
}
