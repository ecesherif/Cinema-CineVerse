using System;
using Data;
using Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace CineVerseConsoleApp.Presentation
{
    /* This is the home menu of the program */
    public class HomeMenu
    {
        private readonly MovieBusiness _movieBusiness;
        CineVerseContext _cineVerseContext;
        public HomeMenu(CineVerseContext cineVerseContext)
        {
            _movieBusiness = new MovieBusiness(cineVerseContext);
            Start();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string('~', 11) + " Cinema CineVerse " + new string('~', 11));
            Console.WriteLine(new string('~', 40) + "\n");
            Console.WriteLine("1. Movie menu");
            Console.WriteLine("2. Genre menu");
            Console.WriteLine("3. Hall menu");
            Console.WriteLine("4. Exit");
            Console.WriteLine(new string('~', 40));
        }
        private void Start()
        {
            int operation;
            int closeOperationId = 4;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ShowMovieMenu(); break;
                    case 2: ShowGenreMenu(); break;
                    case 3: ShowHallMenu(); break;
                    default: break;
                }
            } while (operation != closeOperationId);
            if (operation == closeOperationId)
                Console.Clear();
        }
        /* In these methods we create new secondary displays which will be shown in the console */
        private void ShowMovieMenu()
        {
            MovieMenu movieMenu = new MovieMenu(_cineVerseContext);
        }

        private void ShowGenreMenu()
        {
            GenreMenu genreMenu = new GenreMenu(_cineVerseContext);
        }

        private void ShowHallMenu()
        {
            HallMenu hallMenu = new HallMenu(_cineVerseContext);
        }
    }
}