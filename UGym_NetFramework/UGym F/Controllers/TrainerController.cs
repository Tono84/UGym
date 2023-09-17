using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UGym_F.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
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

        public ActionResult Routines()
        {
            return View();
        }

        public ActionResult Evaluations()
        {
            return View();
        }

        public ActionResult Drafts()
        {
            return View();
        }

        public ActionResult Gestion()
        {
            return View();
        }

        public ActionResult Classes()
        {
            return View();
        }

        public ActionResult ModifyClass()
        {
               return View();
        }
    }
}