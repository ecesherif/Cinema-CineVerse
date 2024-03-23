using System;
using Data;
using CineVerseConsoleApp.Presentation;

namespace CineVerseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CineVerseContext cineVerseContext = new CineVerseContext();
            HomeMenu display = new HomeMenu(cineVerseContext);
        }
    }
}