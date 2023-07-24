using Netcore5CRUD.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace Netcore5CRUD.ViewsModel
{
    public class MoviesFormViewModel
    {
        public int Id { get; set; }


        [Required, StringLength(250)]
        public string Title { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }


        [Required, StringLength(2500)]
        public string Storyline { get; set; }


        [Display(Name = "Select poster...")]
        public byte[] Poster { get; set; }

        [DisplayName("Generes")]
        public byte generesId { get; set; }

        public IEnumerable< Genres > Genres{ get; set; }

    }
}
