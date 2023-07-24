using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using Netcore5CRUD.Models;
using Netcore5CRUD.ViewsModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Netcore5CRUD.Controllers
{
    public class MoviesController : Controller
    {
        private readonly crudoperationsDbContext _DbContext;
        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576;


        public MoviesController(crudoperationsDbContext Context)
        {
            _DbContext = Context;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _DbContext.Movies.OrderByDescending(m => m.Rate).ToListAsync();
            return View(movies);
        }


        public async Task<IActionResult> Create()
        {
            var viewModel = new MoviesFormViewModel
            {

                Genres = await _DbContext.Genres.OrderBy(n => n.Name).ToListAsync()
            };

            return View("Create", viewModel);
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create(MoviesFormViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Genres = await _DbContext.Genres.OrderBy(n => n.Name).ToListAsync();
                return View(model);

            }
            var files = Request.Form.Files;

            if (!files.Any())
            {
                model.Genres = await _DbContext.Genres.OrderBy(n => n.Name).ToListAsync();
                ModelState.AddModelError("Poster", "Please select movie poster");
                return View(model);

            }
            var poster = files.FirstOrDefault();


            if (!_allowedExtenstions.Contains(Path.GetExtension(poster.FileName).ToLower()))
            {
                model.Genres = await _DbContext.Genres.OrderBy(n => n.Name).ToListAsync();
                ModelState.AddModelError("Poster", "Please select jpg or png");
                return View(model);

            }


            if (poster.Length > _maxAllowedPosterSize)
            {
                model.Genres = await _DbContext.Genres.OrderBy(m => m.Name).ToListAsync();
                ModelState.AddModelError("Poster", "Poster cannot be more than 1 MB!");
                return View("MovieForm", model);
            }
            using var dataStream = new MemoryStream();

            await poster.CopyToAsync(dataStream);

            var movies = new Movies
            {
                Title = model.Title,
                generesId = model.generesId,
                Year = model.Year,
                Rate = model.Rate,
                Storyline = model.Storyline,
                Poster = dataStream.ToArray()
            };

            _DbContext.Movies.Add(movies);
            _DbContext.SaveChanges();

            //_toastNotification.AddSuccessToastMessage("Movie created successfully");
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }


            var movies = await _DbContext.Movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }

            var viewmodel = new MoviesFormViewModel
            {
                Title = movies.Title,
                generesId = movies.generesId,
                Year = movies.Year,
                Rate = movies.Rate,
                Storyline = movies.Storyline,
                Poster = movies.Poster,
                Genres = await _DbContext.Genres.OrderBy(m => m.Name).ToListAsync()
            };

            return View("Edit", viewmodel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MoviesFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = await _DbContext.Genres.OrderBy(m => m.Name).ToListAsync();
                return View("MovieForm", model);
            }

            var movie = await _DbContext.Movies.FindAsync(model.Id);

            if (movie == null)
                return NotFound();

            var files = Request.Form.Files;

            if (files.Any())
            {
                var poster = files.FirstOrDefault();

                using var dataStream = new MemoryStream();

                await poster.CopyToAsync(dataStream);

                model.Poster = dataStream.ToArray();

                if (!_allowedExtenstions.Contains(Path.GetExtension(poster.FileName).ToLower()))
                {
                    model.Genres = await _DbContext.Genres.OrderBy(m => m.Name).ToListAsync();
                    ModelState.AddModelError("Poster", "Only .PNG, .JPG images are allowed!");
                    return View("MovieForm", model);
                }

                if (poster.Length > _maxAllowedPosterSize)
                {
                    model.Genres = await _DbContext.Genres.OrderBy(m => m.Name).ToListAsync();
                    ModelState.AddModelError("Poster", "Poster cannot be more than 1 MB!");
                    return View("MovieForm", model);
                }

                movie.Poster = model.Poster;
            }

            movie.Title = model.Title;
            movie.generesId = model.generesId;
            movie.Year = model.Year;
            movie.Rate = model.Rate;
            movie.Storyline = model.Storyline;

            _DbContext.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }


            var movies = await _DbContext.Movies.FindAsync(id);

            if (movies == null)
            {
                return NotFound();
            }



            return View("Details", movies);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var movie = await _DbContext.Movies.FindAsync(id);

            if (movie == null)
                return NotFound();

            _DbContext.Movies.Remove(movie);
            _DbContext.SaveChanges();

            return Ok();
        }


    }


}

