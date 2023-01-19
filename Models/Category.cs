﻿namespace MovieTheatre.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<MovieCategory>? MovieCategories { get; set; }
    }
}
