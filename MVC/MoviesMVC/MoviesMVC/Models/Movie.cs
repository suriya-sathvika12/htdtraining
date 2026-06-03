using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesMVC.Models
{
    public class Movie
    {
        [Key]
        public int Mid { get; set; }

        public string MovieName { get; set; }

        public string DirectorName { get; set; }

        public DateTime DateOfRelease { get; set; }
    }
}