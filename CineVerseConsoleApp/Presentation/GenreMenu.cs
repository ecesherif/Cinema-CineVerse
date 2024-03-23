using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Data.Models;
using Data;
using Data.Models.Interfaces;

namespace CineVerseConsoleApp.Presentation
{
    /* This is the menu for the Genre table */
    public class GenreMenu : IDisplayable
    {
        CineVerseContext _cineVerseContext;
        private readonly GenreBusiness genreBusiness;
        public GenreMenu(CineVerseContext cineVerseContext) : this()
        {
            this._cineVerseContext = cineVerseContext;
            Show();
        }
        public GenreMenu()
        {
            this._cineVerseContext = new CineVerseContext();
            this.genreBusiness = new GenreBusiness(_cineVerseContext);
        }
        private void ShowGenreMenu()
        {
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string('~', 16) + " Genre " + new string('~', 17));
            Console.WriteLine(new string('~', 40) + "\n");
            Console.WriteLine("1. List all genres");
            Console.WriteLine("2. Find genre");
            Console.WriteLine("3. Add genre");
            Console.WriteLine("4. Update genre");
            Console.WriteLine("5. Delete genre");
            Console.WriteLine("6. Back");
            Console.WriteLine(new string('~', 40));
        }
        public void Show()
        {
            int operation;
            int closeOperationId = 6;
            do
            {
                ShowGenreMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ListAllGenres(); break;
                    case 2: FindGenre(); break;
                    case 3: AddGenre(); break;
                    case 4: UpdateGenre(); break;
                    case 5: DeleteGenre(); break;
                    default: break;
                }
            } while (operation != closeOperationId);
            if (operation == closeOperationId)
                Console.Clear();
        }
        /* This method returns every genre in the database. */
        private void ListAllGenres()
        {
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string('~', 16) + " Genres " + new string('~', 16));
            Console.WriteLine(new string('~', 40));
            var genres = genreBusiness.GetAll();
            foreach (var genre in genres)
            {
                Console.WriteLine($"Genre id: {genre.Id}, genre name: {genre.GenreName}");
            }
        }
        /* This method returns a genre based on it's id number*/
        private void FindGenre()
        {
            Console.Write("Enter genre id: ");
            int id = int.Parse(Console.ReadLine());
            Genre genre = genreBusiness.Get(id);
            if (genre != null)
            {
                Console.WriteLine($"Genre with id: {genre.Id} is {genre.GenreName}");
            }
            else
                Console.WriteLine("Genre not found!");
        }
        /* This method is for adding a new genre in the database*/
        private void AddGenre()
        {
            Genre genre = new Genre();
            Console.Write("Enter genre id: ");
            genre.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter genre name: ");
            genre.GenreName = Console.ReadLine();
            Console.WriteLine("Done!");
        }
        /* In this method we change a genre's name */
        private void UpdateGenre()
        {
            Console.Write("Enter genre id: ");
            int id = int.Parse(Console.ReadLine());
            Genre genre = genreBusiness.Get(id);
            if (genre != null)
            {
                Console.Write("Enter genre name: ");
                genre.GenreName = Console.ReadLine();
                Console.WriteLine("Done!");
            }
            else
                Console.WriteLine("Genre not found");
        }
        /* This method delete's a genre based on it's id number */
        private void DeleteGenre()
        {
            Console.Write("Enter genre id: ");
            int id = int.Parse(Console.ReadLine());
            Genre genre = genreBusiness.Get(id);
            if (genre != null)
            {
                genreBusiness.Delete(id);
                Console.WriteLine("Done!");
            }
            else
                Console.WriteLine("Genre not found!");
        }
    }
}
