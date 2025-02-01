using LKMovies.Models;
using LKMovies.Services;
using LKMovies.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKMovies.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
        }
        // GET: GenreController
        public async Task<ActionResult> Index()
        {
            return View(await _genreService.GetAll());
        }

        // GET: GenreController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _genreService.GetById(id));
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Genre genre)
        {
            try
            {
                await _genreService.Add(genre);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(genre);
            }
        }

        // GET: GenreController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _genreService.GetById(id));
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Genre genre)
        {
            try
            {
                await _genreService.Update(id, genre);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _genreService.GetById(id));
        }

        // POST: GenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DoDelete(int id)
        {
            try
            {
                await _genreService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
