using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using PcBuildingSite.Data.Entities;
using PcBuildingSite.Services;
using PcBuildingSite.Data.Models.Component;

namespace PcBuildingSite.Controllers
{
    public class ComputerController : Controller
    {
        private readonly AppDbContext _context;
        private ComponentService componentService;
        public ComputerController(AppDbContext context)
        {
            _context = context;
            componentService = new ComponentService(_context);
        }

        public async Task<IActionResult> ComputerList()
        {
            return View(await _context.Computer.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer
                .FirstOrDefaultAsync(m => m.id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,cpuModel,gpuModel,ramModel,motherboardModel,storageModel,psuModel,pcCaseModel")] ComputerDto computer)
        {
            if (ModelState.IsValid)
            {
                if (componentService.PartsInStorage(componentService.OfComputerDto(computer)))
                {
                    if (!componentService.SocketIsCompadable(computer.cpuModel, computer.motherboardModel))
                    {
                        return NotFound("Cpu and Motherboard sockets are not the same");
                    }
                    if (!componentService.FormFactorIsCompadable(computer.pcCaseModel, computer.motherboardModel))
                    {
                        return NotFound("The motherboard can't fit in the case");
                    }
                    if (!componentService.IsPowerEnough(computer.psuModel, computer.cpuModel, computer.gpuModel, 1))
                    {
                        return NotFound("Your system needs better psu");
                    }
                    if (!componentService.GenerationIsCompadable(computer.cpuModel, computer.motherboardModel))
                    {
                        return NotFound("Your motherboard dose not support this cpu");
                    }
                    componentService.CreateComputer(computer);                    
                    await _context.SaveChangesAsync();
                    return RedirectToAction("UserPanel", "Home");


                }
                else
                {
                    return NotFound("One or more from the components in this pc are not avalable");
                }
            }
            return View(computer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer.FindAsync(id);
            
            if (computer == null)
            {
                return NotFound();
            }
            return View(computer);           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,cpuModel,gpuModel,ramModel,motherboardModel,storageModel,psuModel,pcCaseModel")] Computer computer)
        {
            if (id != computer.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (componentService.PartsInStorage(computer))
                {
                    if (!componentService.SocketIsCompadable(computer.cpuModel, computer.motherboardModel))
                    {
                        return NotFound("Cpu and Motherboard sockets are not the same");
                    }
                    if (!componentService.FormFactorIsCompadable(computer.pcCaseModel, computer.motherboardModel))
                    {
                        return NotFound("The motherboard can't fit in the case");
                    }
                    if (!componentService.IsPowerEnough(computer.psuModel, computer.cpuModel, computer.gpuModel, 1))
                    {
                        return NotFound("Your system needs better psu");
                    }
                    if (!componentService.GenerationIsCompadable(computer.cpuModel, computer.motherboardModel))
                    {
                        return NotFound("Your motherboard dose not support this cpu");
                    }
                    //if (componentService.HasTheSameIdInBase(computer.id.ToString()))
                    //{
                    //    return NotFound("The Pc already exists");
                    //}
                    try
                    {
                        if (componentService.PartsInStorage(computer))
                        {
                            _context.Update(computer);
                           computer.price =  componentService.GetPrice(computer.cpuModel, computer.gpuModel, computer.ramModel, computer.storageModel, computer.psuModel, computer.pcCaseModel, computer.motherboardModel);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            return NotFound("Component not avalable");
                        }

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ComputerExists(computer.id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(ComputerList));
                }
            }
            return View(computer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer
                .FirstOrDefaultAsync(m => m.id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computer = await _context.Computer.FindAsync(id);
            _context.Computer.Remove(computer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ComputerList));
        }

        [HttpGet]
        public async Task<IActionResult> CalculateFPS(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer.FindAsync(id);
            CalculateFPSViewModel viewModel = new CalculateFPSViewModel();
            viewModel.performance = componentService.GetPerformance(computer.cpuModel, computer.gpuModel, computer.ramModel);
            if (computer == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CalculateFPS(int id, Computer computer)
        {
            if (id != computer.id)
            {
                return NotFound();
            }
            return View();
        }



        private bool ComputerExists(int id)
        {
            return _context.Computer.Any(e => e.id == id);
        }
    }
}
