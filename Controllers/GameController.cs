using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using goblin_cheese.Data;
using goblin_cheese.Models.Game;
using goblin_cheese.API;
using IGDBGame = IGDB.Models.Game;
using IGDBGenre = IGDB.Models.Genre;
using IGDBScreenshot = IGDB.Models.Screenshot;
using Microsoft.AspNetCore.Authorization;
using goblin_cheese.Areas.Identity.Data;

namespace goblin_cheese.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<GoblinUser> _userManager;
        private readonly GameApi _api;

        public GameController(ApplicationDbContext context, IConfiguration config, UserManager<GoblinUser> userManager)
        {   
            _context = context;
            _config = config;
            _userManager = userManager;
            _api = new GameApi(clientId: _config["IGDB:ClientId"], clientSecret: _config["IGDB:ClientSecret"]);
        }

        // GET: Game
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
              return _context.Game != null ? 
                          View(await _context.Game.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Game'  is null.");
        }

        // GET: Game/Details/5
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Genre)
                .Include(g => g.Screenshots)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // GET: Game/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Opinion")] Game game)
        {
            if (ModelState.IsValid)
            {
                IGDBGame igdbGame = await _api.GetGame(game.Id);

                game.Summary = igdbGame.Summary;
                game.CoverUrl = IGDB.ImageHelper.GetImageUrl(igdbGame.Cover.Value.ImageId, IGDB.ImageSize.HD1080);
                game.Title = igdbGame.Name;

                DateTimeOffset? releaseDate = igdbGame.FirstReleaseDate;
                if (releaseDate.HasValue) {
                    game.ReleaseDate = new DateOnly(releaseDate.Value.Year, releaseDate.Value.Month, releaseDate.Value.Day);
                }
                foreach (IGDBGenre g in igdbGame.Genres.Values) {
                    if (g.Id != null){
                        if (_context.Genre.Any(genre => genre.Id == g.Id)) {
                            if (game.Genre != null && !game.Genre.Any(genre => genre.Id == g.Id)) {
                                game.Genre.Add(_context.Genre.Where(x => x.Id == g.Id).First());
                            }
                        } else {
                            Genre genre = new Genre();
                            
                            genre.Id = (int)g.Id;
                            genre.Name = g.Name;
                            if (genre.Games != null) {
                                genre.Games.Add(game);
                                game.Genre?.Add(genre);
                            }
                            _context.Add(genre);
                        }
                    }
                }
                foreach (IGDBScreenshot screenshot in igdbGame.Screenshots.Values) {
                    if (screenshot.Id != null){
                        Screenshot screenshotDb = new Screenshot();
                        screenshotDb.Id = (int)screenshot.Id;
                        screenshotDb.ImageUrl = IGDB.ImageHelper.GetImageUrl(screenshot.ImageId, IGDB.ImageSize.HD1080);
                        screenshotDb.Game = game;
                        _context.Add(screenshotDb);
                    }
                }
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new {Id = game.Id});
            }
            return View(game);
        }

        // GET: Game/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Opinion,ReleaseDate,Title,Summary,CoverUrl")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                // Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\");
                // Console.WriteLine(favouriteGame);
                // Console.WriteLine();
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { Id = game.Id });
            }
            return View(game);
        }

        // GET: Game/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Game == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Game'  is null.");
            }
            var game = await _context.Game.FindAsync(id);
            if (game != null)
            {
                if (game.Screenshots != null) {
                    game.Screenshots.Clear();
                    await _context.Screenshot.Where(x => x.Game == game).ExecuteDeleteAsync();
                }
                _context.Game.Remove(game);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
          return (_context.Game?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
