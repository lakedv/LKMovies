using LKMovies.Models;
using LKMovies.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKMovies.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorService _directorService;
        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService ?? throw new ArgumentNullException(nameof(directorService));
        }
        // GET: DirectorController
        public async Task<ActionResult> Index()
        {
            return View(await _directorService.GetAll());
        }

        // GET: DirectorController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _directorService.GetById(id));
        }

        // GET: DirectorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DirectorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Director director)
        {
            try
            {   
                await _directorService.Add(director);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(director);
            }
        }

        // GET: DirectorController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _directorService.GetById(id));
        }

        // POST: DirectorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Director director)
        {
            try
            {
                await _directorService.Update(id, director);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DirectorController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _directorService.GetById(id));
        }

        // POST: DirectorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DoDelete(int id)
        {
            try
            {
                await _directorService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
