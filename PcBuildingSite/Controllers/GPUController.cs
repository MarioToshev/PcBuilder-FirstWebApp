using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcBuildingSite.Data.Entities;
using PcBuildingSite.Data.Models.Component;
using PcBuildingSite.Services;
using System.Threading.Tasks;

namespace PcBuildingSite.Controllers
{
    public class GPUController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ComponentService componentService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public GPUController(AppDbContext context, ComponentService componentService, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.componentService = componentService;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult AddGPU()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGPU(GpuDto gpu)
        {
            if (ModelState.IsValid)
            {
                if (componentService.HasTheSameIdInBase(gpu.model))
                {
                    return NotFound("A gpu with the same model already exits");
                }
                this.componentService.CreateGPU(gpu);
                return RedirectToAction(nameof(AddGPU));
            }
            return View(gpu);
        }
        public async Task<IActionResult> ShowGpu()
        {
            return View(await _context.gpus.ToListAsync());
        }
        [HttpGet]
        public IActionResult DeleteGpu(string id)
        {
            Gpu gpu = componentService.OfGpuDto(this.componentService.GetGpuById(id));

            return View(gpu);
        }

        [HttpPost]
        public IActionResult DeleteGpu(GpuDto component)
        {
            this.componentService.DeleteComponent(component);

            return RedirectToAction("ShowGpu", "Gpu");
        }
    }
}