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
    /* This is the display special for updating the movie data */
    public class UpdateMovieMenu : IDisplayable
    {
        private readonly UpdateMovieBusiness _updateMovieBusiness;
        CineVerseContext _cineVerseContext;
        HallBusiness hallBusiness;
        UpdateMovieBusiness updateMovieBusiness;
        public UpdateMovieMenu()
        {
            this._cineVerseContext = new CineVerseContext();
            this.hallBusiness = new HallBusiness(_cineVerseContext);
            this._movieBusiness = new MovieBusiness(_cineVerseContext);
            this.updateMovieBusiness = new UpdateMovieBusiness(_movieBusiness);
            _updateMovieBusiness = updateMovieBusiness;
        }
        
        private readonly MovieBusiness _movieBusiness;

        public UpdateMovieMenu(MovieBusiness movieBusiness) : this()
        {
            this._movieBusiness = movieBusiness;
            Show();
        }
        private void UpdateMovie()
        {
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string('~', 13) + " Update movie " + new string('~', 13));
            Console.WriteLine(new string('~', 40) + "\n");
            Console.WriteLine("1. Update name");
            Console.WriteLine("2. Update director");
            Console.WriteLine("3. Update duration");
            Console.WriteLine("4. Update genre id");
            Console.WriteLine("5. Update hall id");
            Console.WriteLine("6. Update projection day");
            Console.WriteLine("7. Back");
            Console.WriteLine(new string('~', 40));
        }
        public void Show()
        {
            int operation;
            int closeOperationId = 7;
            do
            {
                UpdateMovie();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: UpdateMovieName(); break;
                    case 2: UpdateDirector(); break;
                    case 3: UpdateDuration(); break;
                    case 4: UpdateGenreId(); break;
                    case 5: UpdateHallId(); break;
                    case 6: UpdateProjectionDay(); break;
                    default: break;
                }
            } while (operation != closeOperationId);
            if (operation == closeOperationId)
                Console.Clear();
        }
        private void UpdateMovieName()
        {
            Console.Write("Enter Id to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter name: ");
            string newName = Console.ReadLine();
            _updateMovieBusiness.UpdateMovieName(id, newName);
            Console.WriteLine("Done!");
        }

        private void UpdateDirector()
        {
            Console.Write("Enter Id to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter director name: ");
            string newDirector = Console.ReadLine();
            _updateMovieBusiness.UpdateMovieDirector(id, newDirector);
            Console.WriteLine("Done!");
        }

        private void UpdateDuration()
        {
            Console.Write("Enter id to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter movie duration: ");
            int newDuration = int.Parse(Console.ReadLine());
            _updateMovieBusiness.UpdateMovieDuration(id, newDuration);
            Console.WriteLine("Done!");
        }

        private void UpdateGenreId()
        {
            Console.Write("Enter id to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter genre id: ");
            int newGenreId = int.Parse(Console.ReadLine());
            _updateMovieBusiness.UpdateMovieGenreId(id, newGenreId);
            Console.WriteLine("Done!");
        }

        private void UpdateHallId()
        {
            Console.Write("Enter id to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter hall id: ");
            int newHallId = int.Parse(Console.ReadLine());
            _updateMovieBusiness.UpdateMovieHallId(id, newHallId);
            Console.WriteLine("Done!");
        }

        private void UpdateProjectionDay()
        {
            Console.Write("Enter id to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter projection day: ");
            string newProjectionDay = Console.ReadLine();
            _updateMovieBusiness.UpdateMovieProjectionDay(id, newProjectionDay);
            Console.WriteLine("Done!");
        }
    }
}
