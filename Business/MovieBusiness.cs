using System;
using Data;
using Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    /* In this class we create methods for the Movie table */
    public class MovieBusiness
    {
        public MovieBusiness() { }
        private readonly CineVerseContext _cineVerseContext;

        public MovieBusiness(CineVerseContext cineVerseContext)
        {
            _cineVerseContext = cineVerseContext;
        }

        public virtual List<Movie> GetAll()
        {
            return _cineVerseContext.Movies.ToList();
        }

        public virtual Movie Get(int id)
        {
            var movie = _cineVerseContext.Movies.Find(id);
            return movie;
        }

        public virtual void Add(Movie movie)
        {
            _cineVerseContext.Movies.Add(movie);
            _cineVerseContext.SaveChanges();
        }


        public virtual void Update(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            var item = _cineVerseContext.Movies.Find(movie.Id);
            if (item != null)
            {
                _cineVerseContext.Entry(item).CurrentValues.SetValues(movie);
                _cineVerseContext.SaveChanges();
            }
        }
        public virtual void Delete(int id)
        {
            var movie = _cineVerseContext.Movies.Find(id);
            if (movie != null)
            {
                _cineVerseContext.Movies.Remove(movie);
                _cineVerseContext.SaveChanges();
            }
        }
        public virtual List<Movie> DailyMovies(string dayOfWeek)
        {          
            string day = dayOfWeek.ToLower();
            var movies = _cineVerseContext.Movies.Where(movie => movie.ProjectionDay.ToLower() == day).ToList();
            return movies;
        }
        public virtual void FindPlaceInMovieHall(int movieId, int numTickets)
        {
            Console.Write("Enter the number of tickets: ");
            int num = int.Parse(Console.ReadLine());
            Movie movie = _cineVerseContext.Movies.Find(movieId);
            if (movie != null)
            {
                Hall hall = _cineVerseContext.Halls.Find(movie.HallId);
                if (hall != null)
                {
                    if (hall.Reserved + num <= hall.Capacity)
                    {
                        Console.WriteLine($"You reserved {num} tickets in hall {hall.Id} for {movie.Name}");
                        // Update the hall's reserved count
                        hall.Reserved += num;
                        _cineVerseContext.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("There are not enough free places in the hall.");
                    }
                }
                else
                {
                    Console.WriteLine("Hall not found!");
                }
            }
            else
            {
                Console.WriteLine("Movie not found!");
            }
        }
    }
}
