﻿using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class LabsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
