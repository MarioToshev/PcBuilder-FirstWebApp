using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace PcBuildingSite.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AddGPU()
        {
            return View();
        }
    }
}