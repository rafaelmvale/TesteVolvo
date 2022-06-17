using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TesteVolvo.Application.DTOs;
using TesteVolvo.Application.Interfaces;

namespace TesteVolvo.WebUi.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();


            var categoryDto = await _categoryService.GetByID(id);

            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }
    }
}
