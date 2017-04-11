﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Bluebox.Models;
using Bluebox.ViewModels;

namespace Bluebox.Controllers
{
    public class MoviesController : Controller
    {


        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movies
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer 1"},
        //        new Customer { Name = "Customer 2"}
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };


        //    return View(viewModel);
        //    //return Content("Hello");
        //    //return HttpNotFound();
        //   // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
        //}



        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };


                return View("MovieForm", viewModel);

            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);

            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                //TryUpdateModel(customerInDb);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId; 
                movieInDb.StockNum = movie.StockNum;
               
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }



        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres = _context.Genres.ToList()

            };

            return View("MovieForm", viewModel);

        }

        //movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();        
            return View(movies);

        }

        public ActionResult Details(int id)
        {

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
         
            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }



        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}