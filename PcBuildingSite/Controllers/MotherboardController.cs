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
    public class MotherboardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ComponentService componentService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public MotherboardController(AppDbContext context, ComponentService componentService, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.componentService = componentService;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult AddMotherboard()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddMotherboard(MotherboardDto motherboard)
        {
            if (ModelState.IsValid)
            {
                if (componentService.HasTheSameIdInBase(motherboard.model))
                {
                    return NotFound("A motherboard with the same model already exits");
                }
                componentService.CreateMotherboard(motherboard);
                return RedirectToAction(nameof(ShowMotherboards));
            }
            return View();
        }
        public async Task<IActionResult> ShowMotherboards()
        {
            return View(await _context.motherboards.ToListAsync());
        }
        [HttpGet]
        public IActionResult DeleteMotherboard(string id)
        {
            Motherboard motherboard = componentService.OfMotherboardDto(this.componentService.GetMotherboardById(id));

            return View(motherboard);
        }

        [HttpPost]
        public IActionResult DeleteMotherboard(MotherboardDto component)
        {
            this.componentService.DeleteMotherboard(component);

            return RedirectToAction("ShowMotherboards", "Motherboard");
        }
    }
}