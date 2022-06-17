using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using TesteVolvo.Application.DTOs;
using TesteVolvo.Application.Interfaces;

namespace TesteVolvo.WebUi.Controllers
{
    public class TrucksController : Controller
    {
        private readonly ITruckService _truckService;
        private readonly ICategoryService _categoryService;


        public TrucksController(ITruckService truckService, ICategoryService categoryService)
        {
            _truckService = truckService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var trucks = await _truckService.GetTrucksAsync();
            return View(trucks);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId =
                new SelectList(await _categoryService.GetCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TruckDTO truckDTO)
        {
            if (ModelState.IsValid)
            {
                await _truckService.Add(truckDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(truckDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var truckDto = await _truckService.GetByIdAsync(id);

            if (truckDto == null) return NotFound();

            var categories = await _categoryService.GetCategories();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", truckDto.CategoryId);

            return View(truckDto);
        }
        [HttpPost()]
        public async Task<IActionResult> Edit(TruckDTO truckDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _truckService.Update(truckDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(truckDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null) return NotFound();

            var truckDto = await _truckService.GetByIdAsync(id);
            if(truckDto == null) return NotFound();

            return View(truckDto);
        }
        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _truckService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();


            var truckDto = await _truckService.GetByIdAsync(id);

            if (truckDto == null) return NotFound();

            return View(truckDto);
        }

    }
}
