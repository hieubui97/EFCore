using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFCore.Models;
using EFCore.Models.EFCore;
using Microsoft.EntityFrameworkCore;

using EFCore.Models.Entities;

namespace EFCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SchoolDbContext db = new SchoolDbContext();

            var student = db.Students.ToList();

            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student stu)
        {
            if (ModelState.IsValid)
            {
                SchoolDbContext db = new SchoolDbContext();
                db.Students.Add(stu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
