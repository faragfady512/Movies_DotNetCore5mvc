using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Netcore5CRUD.Models
{
    public class Movies
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required, MaxLength(250)]
        public string Title { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }


        [Required, MaxLength(2500)]
        public string Storyline { get; set; }

        public byte[] Poster { get; set; }

        public byte generesId { get; set; }

        public Genres Genres { get; set; }



    }
}
