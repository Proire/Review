using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Review
{
    internal class MovieTheater
    {
        public List<Movie> Movies { get; set; } = [];
        public int numMovies;

        public MovieTheater()
        {
            this.numMovies = Movies.Count;
        }

        public string AddMovie(Movie movie)
        {
            if(movie != null)
            {
                Movies.Add(movie);
                return "Movie Added Successfully";
            }
            return "Movie Not Added Successfully";

        }

        public Movie? RemoveMovie(string moviename)
        {
            Movie? Presentmovie = Movies.FirstOrDefault(movie => movie.Title == moviename);
            if(Presentmovie != null)
            {
                Movies.Remove(Presentmovie);
            }
            return Presentmovie;
        }

        public Movie? GetMovieByTitle(string title)
        {
            Movie? movie = null;
            if (title != null)
            {
                movie = Movies.Find(movie => movie.Title.Equals(title));
            }
            return movie;
        }

        public IEnumerable<Movie> SortByRatingDesc()
        {
            return Movies.OrderByDescending(movie => movie.Rating);
        }

        public decimal GetAverageRatingOFAllMovies()
        {
            double average = Movies.Average(movie => movie.Rating);
            return (decimal)average;
        }
    }

    internal class Movie(string title, double rating)
    {
        public string Title { get; set; } = title;

        public double Rating { get; set; } = rating;

        public static int Id { get; set; }  = Id++;

        public override bool Equals(object? obj)
        {
            if (obj is Movie and not null)
            {
                Movie movie = (Movie)obj;
                if (movie.Title == Title && movie.Rating == Rating)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"Title of Movie : {Title}                   Rating : {Rating}";
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }

    // User Defined Exception to validate the User input 
    public class NullInputException(String issue) : ApplicationException
    {
        public string Issue { get; set; } = issue;
    }
}
