﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UGym_F.Controllers
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