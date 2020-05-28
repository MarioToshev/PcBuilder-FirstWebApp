using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcBuildingSite.Data.Entities;
using PcBuildingSite.Data.Models.Component;
using PcBuildingSite.Services;

namespace PcBuildingSite.Controllers
{
    public class RamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ComponentService componentService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public RamController(AppDbContext context, ComponentService componentService, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.componentService = componentService;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult AddRam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRam(RamDto ram)
        {
            if (ModelState.IsValid)
            {
                if (componentService.HasTheSameIdInBase(ram.model))
                {
                    return NotFound("A ram with the same model already exits");
                }
                componentService.CreateRam(ram);
                return RedirectToAction(nameof(AddRam));
            }
            return View();
        }
        public async Task<IActionResult> ShowRams()
        {
            return View(await _context.rams.ToListAsync());
        }
        [HttpGet]
        public IActionResult DeleteRam(string id)
        {
            RAM ram = componentService.OfRamDto(this.componentService.GetRamById(id));

            return View(ram);
        }

        [HttpPost]
        public IActionResult DeleteRam(RamDto ram)
        {
            this.componentService.DeleteRam(ram);

            return RedirectToAction("ShowRams", "Ram");
        }
    }
}
