using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace UGym_F.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Login(string returnUrl, string username, string password)
        {
            var userValue = username;
            Console.WriteLine("User Value: " + userValue);


            switch (userValue)
            {
                case "1":
                    return RedirectToAction("Index","Cliente");
                case "2":
                    return RedirectToAction("Vista2");
                case "3":
                    return RedirectToAction("Vista3");
                case "4":
                    return RedirectToAction("Vista4");
                case "5":
                    return RedirectToAction("Vista5");
                case "6":
                    return RedirectToAction("Vista6");
                default:
                   
                    return RedirectToAction("Login");
            }
          
        }

        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult MedicalHistory() 
        {
            return View();
        }
        public ActionResult Evaluation()
        {
            return View();
        }

        public ActionResult QRCode()
        {
            return View("Index", "Cliente");
        }
    }
}