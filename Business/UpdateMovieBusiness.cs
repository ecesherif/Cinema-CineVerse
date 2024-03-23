using System;
using Business;
using Data;
using Data.Models;

namespace Business
{
    public class UpdateMovieBusiness
    {
        private readonly MovieBusiness _movieBusiness;

        public UpdateMovieBusiness(MovieBusiness movieBusiness)
        {
            _movieBusiness = movieBusiness;
        }

        public void UpdateMovieName(int id, string newName)
        {
            Movie movie = _movieBusiness.Get(id);
            if (movie != null)
            {
                movie.Name = newName;
                _movieBusiness.Update(movie);
            }
            else
            {
                Console.WriteLine("Movie not found!");
            }
        }

        public void UpdateMovieDirector(int id, string newDirector)
        {
            Movie movie = _movieBusiness.Get(id);
            if (movie != null)
            {
                movie.Director = newDirector;
                _movieBusiness.Update(movie);
            }
            else
            {
                Console.WriteLine("Movie not found!");
            }
        }

        public void UpdateMovieDuration(int id, int newDuration)
        {
            Movie movie = _movieBusiness.Get(id);
            if (movie != null)
            {
                movie.Duration = newDuration;
                _movieBusiness.Update(movie);
            }
            else
            {
                Console.WriteLine("Movie not found!");
            }
        }

        public void UpdateMovieGenreId(int id, int newGenreId)
        {
            Movie movie = _movieBusiness.Get(id);
            if (movie != null)
            {
                movie.GenreId = newGenreId;
                _movieBusiness.Update(movie);
            }
            else
            {
                Console.WriteLine("Movie not found!");
            }
        }

        public void UpdateMovieHallId(int id, int newHallId)
        {
            Movie movie = _movieBusiness.Get(id);
            if (movie != null)
            {
                movie.HallId = newHallId;
                _movieBusiness.Update(movie);
            }
            else
            {
                Console.WriteLine("Movie not found!");
            }
        }

        public void UpdateMovieProjectionDay(int id, string newProjectionDay)
        {
            Movie movie = _movieBusiness.Get(id);
            if (movie != null)
            {
                movie.ProjectionDay = newProjectionDay;
                _movieBusiness.Update(movie);
            }
            else
            {
                Console.WriteLine("Movie not found!");
            }
        }
    }
}
