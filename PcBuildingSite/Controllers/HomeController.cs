using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using PcBuildingSite.Data.Entities;
using PcBuildingSite.Data.Models.Account;
using PcBuildingSite.Data.Models.Component;
using PcBuildingSite.Models;

namespace PcBuildingSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
       
       

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BuildComputer()
        {
            return View();
        }
        public IActionResult CalculateFPS()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserPanel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserPanel(UserPanelModel adminInput)
        {
            if (ModelState.IsValid)
            {
                if (adminInput.adminPassword == "123456")
                {
                    return RedirectToAction("AdminPanel", "Home");
                }
            }
            return Json("Wrong password!");
        }

        public IActionResult AdminPanel()
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
