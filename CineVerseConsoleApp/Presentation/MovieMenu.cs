using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Business;
using Data;
using Data.Models.Interfaces;

namespace CineVerseConsoleApp.Presentation
{
    /* This is the menu for the Movie table */
    public class MovieMenu : IDisplayable
    {
        UpdateMovieBusiness _updateMovieBusiness;
        CineVerseContext _cineVerseContext;
        HallBusiness hallBusiness;
        private readonly MovieBusiness _movieBusiness;
        public MovieMenu(CineVerseContext cineVerseContext) : this()
        {
            this._cineVerseContext = cineVerseContext;
            Show();
        }

        public MovieMenu()
        {
            this._cineVerseContext = new CineVerseContext();
            this.hallBusiness = new HallBusiness(_cineVerseContext);
            this._movieBusiness = new MovieBusiness(_cineVerseContext);
        }

        private void ShowMovieMenu()
        {
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string('~', 16) + " Movie " + new string('~', 17));
            Console.WriteLine(new string('~', 40) + "\n");
            Console.WriteLine("1. List all movies");
            Console.WriteLine("2. Find movie");
            Console.WriteLine("3. Add movie");
            Console.WriteLine("4. Update movie");
            Console.WriteLine("5. Delete movie");
            Console.WriteLine("6. Find place in movie hall");
            Console.WriteLine("7. Daily movies");
            Console.WriteLine("8. Back");
            Console.WriteLine(new string('~', 40));
        }
        public void Show()
        {
            int operation;
            int closeOperationId = 8;
            do
            {
                ShowMovieMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ListAllMovies(); break;
                    case 2: FindMovie(); break;
                    case 3: AddMovie(); break;
                    case 4: UpdateMovie(); break;
                    case 5: DeleteMovie(); break;
                    case 6: FindPlaceInMovieHall(); break;
                    case 7: DailyMovies(); break;
                    default: break;
                }

            } while (operation != closeOperationId);
            if (operation == closeOperationId)
                Console.Clear();
        }
        /* This method is for reserving tickets for a specified movie */
        private void FindPlaceInMovieHall()
        {
            Console.Write("Enter movie id: ");
            int movieId = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of tickets: ");
            int numTickets = int.Parse(Console.ReadLine());
            _movieBusiness.FindPlaceInMovieHall(movieId, numTickets);
        }
        /* This method delete's a movie by the given id */
        private void DeleteMovie()
        {
            Console.Write("Enter id to delete data: ");
            int id = int.Parse(Console.ReadLine());
            Movie movie = _movieBusiness.Get(id);
            if (movie != null)
            {
                _movieBusiness.Delete(id);
                Console.WriteLine("Done!");
            }
            else
                Console.WriteLine("Movie not found!");
        }
        /* This method returns every movie in the database */
        private void ListAllMovies()
        {
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string('~', 16) + " Movies " + new string('~', 16));
            Console.WriteLine(new string('~', 40));
            var movies = _movieBusiness.GetAll();
            Console.WriteLine("Movie id, name, director, duration (minutes), genre, hall number, projection day.");
            foreach (var movie in movies)
            {
               
                Console.WriteLine($"\n{movie.Id}, {movie.Name}, {movie.Director}, {movie.Duration}, {movie.GenreId}, {movie.HallId}, {movie.ProjectionDay}");
            }
        }
        /* This method is for looking for a movie in the database */
        private void FindMovie()
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());
            Movie movie = _movieBusiness.Get(id);
            if (movie != null)
            {
                Console.WriteLine("Id: " + movie.Id);
                Console.WriteLine("Name: " + movie.Name);
                Console.WriteLine("Director: " + movie.Director);
                Console.WriteLine("Duration: " + movie.Duration);
                Console.WriteLine("GenreId: " + movie.GenreId);
                Console.WriteLine("HallId: " + movie.HallId);
                Console.WriteLine("Projection day: " + movie.ProjectionDay);
            }
            else
                Console.WriteLine("Movie not found!");
        }
        /* In this method we add a new movie to the database */
        private void AddMovie()
        {
            Movie movie = new Movie();
            Console.Write("Enter movie name: ");
            movie.Name = Console.ReadLine();
            Console.Write("Enter director name: ");
            movie.Director = Console.ReadLine();
            Console.Write("Enter duration in minutes: ");
            movie.Duration = int.Parse(Console.ReadLine());
            Console.Write("Enter genre id: ");
            movie.GenreId = int.Parse(Console.ReadLine());
            Console.Write("Enter hall id: ");
            movie.HallId = int.Parse(Console.ReadLine());
            Console.Write("Enter projection day: ");
            movie.ProjectionDay = Console.ReadLine();
            _movieBusiness.Add(movie);
            Console.WriteLine("Done!");
        }
        /* This method creates a new display for Update Movie menu */
        private void UpdateMovie()
        {
            UpdateMovieMenu updateMovieMenu = new UpdateMovieMenu(_movieBusiness);
            updateMovieMenu.Show();
        }
        /* This method returns every movie in the specified day of the week */
        private void DailyMovies()
        {
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string('~', 13) + " Daily movies " + new string('~', 13));
            Console.WriteLine(new string('~', 40));
            Console.Write("Enter a day of the week: ");
            string day = Console.ReadLine();
            var movies = _movieBusiness.DailyMovies(day);
            Console.WriteLine("Movie id, name, director, duration (minutes), genre, hall number, projection day.");
            foreach (var movie in movies)
            {
                Console.WriteLine($"\n{movie.Id}, {movie.Name}, {movie.Director}, {movie.Duration}, {movie.GenreId}, {movie.HallId}, {movie.ProjectionDay}");
            }
        }
    }
}
