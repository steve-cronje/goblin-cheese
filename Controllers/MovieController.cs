using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using goblin_cheese.Data;
using goblin_cheese.Models.Movie;
using goblin_cheese.Models;
using goblin_cheese.API.Movie;
using TMDbLib.Client;

namespace goblin_cheese
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly TMDbClient _tmdb;
        private readonly MovieApi _movieApi;

        public MovieController(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _tmdb = new TMDbClient(_config["TMDB:ApiKey"]);
            _movieApi = new MovieApi(_tmdb);
        }

        // GET: Movie
        [HttpGet]
        public async Task<IActionResult> Index(string searchQuery, string sortOrder)
        {
            if (_context.Movie != null) 
            {

                var movies = await _context.Movie.Include(m => m.Poster).ToListAsync();
                ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
                ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
                if (!String.IsNullOrEmpty(searchQuery))
                {
                    movies = movies.Where(m => !String.IsNullOrEmpty(m.Title) && m.Title.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
                    ViewBag.searchQuery = searchQuery;
                }
                switch (sortOrder)
                {
                    case "title_desc":
                        movies = movies.OrderByDescending(m => m.Title).ToList();
                        break;
                    case "date_desc":
                        movies = movies.OrderByDescending(m => m.ReleaseDate).ToList();
                        break;
                    case "Date":
                        movies = movies.OrderBy(m => m.ReleaseDate).ToList();
                        break;
                    default:
                        movies = movies.OrderBy(m => m.Title).ToList();
                        break;
                }
                return View(movies);
            }
            return Problem("Entity set 'ApplicationDbContext.Movie'  is null.");
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.Include(m => m.Backdrops).Include(m => m.Poster).Include(m => m.Genres)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> SearchApi(string searchQuery)
        {
            if (!String.IsNullOrEmpty(searchQuery))
            {
                return View(await _movieApi.SearchForMovieRequest(searchQuery));
            } else {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                var apiM = await _movieApi.GetMovieRequestAsync(movie.Id);
                movie = _movieApi.PopulateMovie(movie, apiM);
                if (!_context.MovieBackdrop.Any(b => b.Movie == movie))
                {
                    movie = await _movieApi.PopulateMovieBackdrops(movie, apiM);
                }
                if (!_context.Poster.Any(p => p.Movie == movie))
                {
                    movie = await _movieApi.PopulatePoster(movie, apiM);
                }
                foreach (var apiG in apiM.Genres)
                {
                    TVGenre? genre = await _context.TvGenres.Where(g => g.Id == apiG.Id).FirstOrDefaultAsync();
                    if (genre != null) 
                    {
                        movie.Genres.Add(genre);
                    } else {
                        genre = new TVGenre();
                        genre.Id = apiG.Id;
                        genre.Name = apiG.Name;
                        genre.Movies.Add(movie);
                        _context.Add(genre);
                    }
                }
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { Id = movie.Id });
            }
            return View(movie);
        }


        [HttpPost]
        public async Task<IActionResult> CreateFromSearch(int movieId)
        {
            if (_context.Movie != null && !_context.Movie.Any(m => m.Id == movieId))
            {
                Movie movie = new Movie();
                var apiM = await _movieApi.GetMovieRequestAsync(movieId);
                movie = _movieApi.PopulateMovie(movie, apiM);
                if (!_context.MovieBackdrop.Any(b => b.Movie == movie))
                {
                    movie = await _movieApi.PopulateMovieBackdrops(movie, apiM);
                }
                if (!_context.Poster.Any(p => p.Movie == movie))
                {
                    movie = await _movieApi.PopulatePoster(movie, apiM);
                }
                foreach (var apiG in apiM.Genres)
                {
                    TVGenre? genre = await _context.TvGenres.Where(g => g.Id == apiG.Id).FirstOrDefaultAsync();
                    if (genre != null) 
                    {
                        movie.Genres.Add(genre);
                    } else {
                        genre = new TVGenre();
                        genre.Id = apiG.Id;
                        genre.Name = apiG.Name;
                        genre.Movies.Add(movie);
                        _context.Add(genre);
                    }
                }
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { Id = movie.Id });
            }
            return Problem("Entity set 'ApplicationDbContext.Movie'  is null.");
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Overview,ReleaseDate,Runtime,Budget,Revenue")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movie'  is null.");
            }
            var movie = await _context.Movie
                .Include(m => m.Poster)
                .Include(m => m.Backdrops)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return (_context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
