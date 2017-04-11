using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bluebox.Models;

namespace Bluebox.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20)]
        public int? StockNum { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }


        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
           Id = movie.Id;
           Name = movie.Name;
           ReleaseDate = movie.ReleaseDate;
           StockNum = movie.StockNum;
           GenreId = movie.GenreId;
        }


    }
}