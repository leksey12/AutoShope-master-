﻿using Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUl.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            return View();
        }
    }
}