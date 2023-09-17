using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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