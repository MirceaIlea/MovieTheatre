using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace MovieTheatre.Models
{
    public class Movie
    {
        [Key] // pentru a fi primary key
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public double Price { get; set; }
        
        [Display(Name = "Poster")]
        public string ImageURL { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int ProducerID { get; set; }
        public Producer Producer { get; set; }

        public ICollection<MovieCategory> MovieCategories { get; set; }

    }
}
