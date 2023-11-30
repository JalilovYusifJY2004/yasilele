﻿using Microsoft.AspNetCore.Mvc;
using PraktikaPreskit.DAL;

namespace PraktikaPreskit.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
