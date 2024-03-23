using Business;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CineVerseConsoleApp.Tests
{
    public class Test25
    {
        [TestCase]
        public void DailyMovies_Returns_Movies_ForSpecifiedDay()
        {
            var options = new DbContextOptionsBuilder<CineVerseContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            // Insert test data into the in-memory database
            using (var context = new CineVerseContext(options))
            {
                context.Movies.AddRange(new List<Movie>
                {
                    new Movie { Id = 1, Name = "Movie 1", ProjectionDay = "Monday" },
                    new Movie { Id = 2, Name = "Movie 2", ProjectionDay = "Tuesday" },
                    new Movie { Id = 3, Name = "Movie 3", ProjectionDay = "Monday" },
                    new Movie { Id = 4, Name = "Movie 4", ProjectionDay = "Wednesday" }
                });
                context.SaveChanges();
            }

            // Create an instance of MovieBusiness with the in-memory database context
            using (var context = new CineVerseContext(options))
            {
                var movieBusiness = new MovieBusiness(context);
                var moviesOnMonday = movieBusiness.DailyMovies("Monday");
                var moviesOnTuesday = movieBusiness.DailyMovies("Tuesday");
                var moviesOnWednesday = movieBusiness.DailyMovies("Wednesday");
                var moviesOnThursday = movieBusiness.DailyMovies("Thursday");

                
                Assert.AreEqual(2, moviesOnMonday.Count);
                Assert.AreEqual(1, moviesOnTuesday.Count);
                Assert.AreEqual(1, moviesOnWednesday.Count);
                Assert.AreEqual(0, moviesOnThursday.Count);
                Assert.IsTrue(moviesOnMonday.All(movie => movie.ProjectionDay.ToLower() == "monday"));
                Assert.IsTrue(moviesOnTuesday.All(movie => movie.ProjectionDay.ToLower() == "tuesday"));
                Assert.IsTrue(moviesOnWednesday.All(movie => movie.ProjectionDay.ToLower() == "wednesday"));
            }
        }
    }
}
