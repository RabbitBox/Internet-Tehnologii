using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldV1.Models
{
    public class Movies
    {
        public List<Movie> movieList { get; set; }

        public Movies()
        {
            movieList = new List<Movie>();
        }
        
        public void AddMovie(int rank, string title, int year)
        {
            Movie movie = new Movie(rank, title, year);
            movieList.Add(movie);
        }
        public void SeedMovies()
        {
            AddMovie(1, "The Shawshank Redemption", 1994);
            AddMovie(2, "The Godfather", 1972);
            AddMovie(3, "The Godfather - Part II", 1974);
            AddMovie(4, "The Dark Knight", 2008);
            AddMovie(5, "Pulp Fiction", 1994);
        }
        public List<Movie> GetMoviesList()
        {
            return movieList;
        }
    }
}