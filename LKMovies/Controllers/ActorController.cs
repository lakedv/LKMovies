using LKMovies.Models;
using LKMovies.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKMovies.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService _actorService;
        public ActorController(IActorService actorService)
        {
            _actorService = actorService ?? throw new ArgumentNullException(nameof(actorService));
        }
        // GET: ActorController
        public async Task<ActionResult> Index()
        {
            return View(await _actorService.GetAll());
        }

        // GET: ActorController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _actorService.GetById(id));
        }

        // GET: ActorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Actor actor)
        {
            try
            {
                await _actorService.Add(actor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(actor);
            }
        }

        // GET: ActorController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _actorService.GetById(id));
        }

        // POST: ActorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Actor actor)
        {
            try
            {   
                await _actorService.Update(id, actor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ActorController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _actorService.GetById(id));
        }

        // POST: ActorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DoDelete(int id)
        {
            try
            {
                await _actorService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
