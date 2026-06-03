using MoviesMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MoviesMVC.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieContext db = new MovieContext();

        public List<Movie> GetAll()
        {
            return db.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Insert(Movie movie)
        {
            db.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}