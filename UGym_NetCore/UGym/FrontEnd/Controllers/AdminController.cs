using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrontEnd.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile() 
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

       public ActionResult Clients() 
        {
            return View();
        }

        public ActionResult Staff()
        {
            return View();
        }

        public ActionResult Reports()
        {
            return View();
        }
    }
}