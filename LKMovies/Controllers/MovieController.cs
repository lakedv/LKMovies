using LKMovies.Models;
using LKMovies.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKMovies.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }
        // GET: MovieController
        public async Task<ActionResult> Index()
        {
            return View(await _movieService.GetAll());
        }

        // GET: MovieController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _movieService.GetById(id));
        }

        // GET: MovieController/Create
        public async Task<ActionResult> Create()
        {
           await _movieService.GetViewBagData(ViewBag);
           return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Movie movie)
        {
            try
            {
                await _movieService.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                await _movieService.GetViewBagData(ViewBag);
                return View(movie);
            }
        }

        // GET: MovieController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _movieService.GetById(id));
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Movie movie)
        {
            try
            {
                await _movieService.Update(id, movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _movieService.GetById(id));
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DoDelete(int id)
        {
            try
            {
                await _movieService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
