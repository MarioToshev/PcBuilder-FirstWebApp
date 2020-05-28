using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcBuildingSite.Data.Models.Component;
using PcBuildingSite.Services;

namespace PcBuildingSite.Data.Entities
{
    public class PsuController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ComponentService componentService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public PsuController(AppDbContext context, ComponentService componentService, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.componentService = componentService;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult AddPsu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPsu(PsuDto psu)
        {
            if (ModelState.IsValid)
                if (componentService.HasTheSameIdInBase(psu.model))
                {
                    return NotFound("A power supply with the same model already exits");
                }
            {
                componentService.CreatePsu(psu);
                RedirectToAction(nameof(AddPsu));
            }
            return View();
        }
        public async Task<IActionResult> ShowPsus()
        {
            return View(await _context.psus.ToListAsync());
        }
        [HttpGet]
        public IActionResult DeletePsu(string id)
        {
            PSU psu = componentService.OfPcPsuDto(this.componentService.GetPsuById(id));

            return View(psu);
        }

        [HttpPost]
        public IActionResult DeletePsu(PsuDto psu)
        {
            this.componentService.DeletePSU(psu);

            return RedirectToAction("ShowPsus", "PSU");
        }
    }
}