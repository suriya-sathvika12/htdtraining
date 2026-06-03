using System.Collections.Generic;
using MoviesMVC.Models;

namespace MoviesMVC.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        void Insert(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        void Save();
    }
}