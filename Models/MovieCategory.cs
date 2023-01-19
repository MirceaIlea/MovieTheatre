namespace MovieTheatre.Models
{
    public class MovieCategory
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
