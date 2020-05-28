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
    public class PcStorageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ComponentService componentService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public PcStorageController(AppDbContext context, ComponentService componentService, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.componentService = componentService;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult AddPcStorage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPcStorage(PcStorageDto storage)
        {
            if (ModelState.IsValid)
            {
                if (componentService.HasTheSameIdInBase(storage.model))
                {
                    return NotFound("A storage with the same model already exits");
                }
                componentService.CreatePcStorage(storage);
                return RedirectToAction(nameof(AddPcStorage));
            }
            return View(AddPcStorage());
        }
        public async Task<IActionResult> ShowPcStorages()
        {
            return View(await _context.storages.ToListAsync());
        }
        [HttpGet]
        public IActionResult DeletePcStorage(string id)
        {
            PcStorage pcStorage = componentService.OfPcStorageDto(this.componentService.GetPcStorageById(id));

            return View(pcStorage);
        }

        [HttpPost]
        public IActionResult DeletePcStorage(PcStorageDto pcStorag)
        {
            this.componentService.DeletePcStorage(pcStorag);

            return RedirectToAction("ShowPcStorages", "PcStorage");
        }
    }
}