using LKMovies.Models;
using LKMovies.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKMovies.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        // GET: CategoriesController
        public async Task<ActionResult> Index()
        {
            //ViewBag.Name = "Nombrecualquiera";
            return View(await _categoryService.GetAll());
        }

        // GET: CategoriesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _categoryService.GetById(id));
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {

            try
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        // GET: CategoriesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _categoryService.GetById(id));
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Category category)
        {
            try
            {
                await _categoryService.Update(id, category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        // GET: CategoriesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _categoryService.GetById(id));
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DoDelete(int id)
        {
            try
            {
                await _categoryService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(await _categoryService.GetById(id));
            }
        }
    }
}
