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
    /* This is the display for Hall table */
    public class HallMenu : IDisplayable
    {
        CineVerseContext _cineVerseContext;
        private readonly HallBusiness hallBusiness;
        public HallMenu(CineVerseContext cineVerseContext) : this()
        {
            this._cineVerseContext = cineVerseContext;
            Show();
        }
        public HallMenu()
        {
            this._cineVerseContext = new CineVerseContext();
            this.hallBusiness = new HallBusiness(_cineVerseContext);
        }
        private void ShowHallMenu()
        {
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string('~', 17) + " Hall " + new string('~', 17));
            Console.WriteLine(new string('~', 40) + "\n");
            Console.WriteLine("1. List all halls");
            Console.WriteLine("2. Find hall");
            Console.WriteLine("3. Add hall");
            Console.WriteLine("4. Update hall");
            Console.WriteLine("5. Delete hall");
            Console.WriteLine("6. Back");
            Console.WriteLine(new string('~', 40));
        }

        public void Show()
        {
            int operation;
            int closeOperationId = 6;
            do
            {
                ShowHallMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ListAllHalls(); break;
                    case 2: FindHall(); break;
                    case 3: AddHall(); break;
                    case 4: UpdateHall(); break;
                    case 5: DeleteHall(); break;
                    default: break;
                }
            } while (operation != closeOperationId);
            if (operation == closeOperationId)
                Console.Clear();
        }
        /* This method delete's a specified hall*/
        private void DeleteHall()
        {
            Console.Write("Enter id to delete data: ");
            int id = int.Parse(Console.ReadLine());
            Hall hall = hallBusiness.Get(id);
            if (hall != null)
            {
                hallBusiness.Delete(id);
                Console.WriteLine("Done!");
            }
            else
                Console.WriteLine("Hall not found!");
        }
        /* Returns every hall in the database*/
        private void ListAllHalls()
        {
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string('~', 16) + " Halls " + new string('~', 17));
            Console.WriteLine(new string('~', 40));
            var halls = hallBusiness.GetAll();
            foreach (var hall in halls)
            {
                Console.WriteLine($"Hall id: {hall.Id} is with {hall.Capacity} capacity");
            }
        }
        /* Finds a hall by it's id */
        private void FindHall()
        {
            Console.Write("Enter hall id: ");
            int id = int.Parse(Console.ReadLine());
            Hall hall = hallBusiness.Get(id);
            if (hall != null)
            {
                Console.WriteLine($"Hall with id: {hall.Id} is with {hall.Capacity} capacity");
            }
            else
                Console.WriteLine("Hall not found!");
        }
        /* Adds hall to the database*/
        private void AddHall()
        {
            Hall hall = new Hall();
            Console.Write("Enter hall id: ");
            hall.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter hall capacity: ");
            hall.Capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Done!");
        }
        /* Updates the capacity of the hall */
        private void UpdateHall()
        {
            Console.Write("Enter id to update: ");
            int id = int.Parse(Console.ReadLine());
            Hall hall = hallBusiness.Get(id);
            if (hall != null)
            {
                Console.Write("Enter new capacity: ");
                hall.Capacity = int.Parse(Console.ReadLine());
                hallBusiness.Update(hall);
                Console.WriteLine("Done!");
            }
            else
                Console.WriteLine("Hall not found!");
        }
    }
}
