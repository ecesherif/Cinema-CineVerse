using System;
using System.Collections.Generic;
using Data.Models;
using Data;
using Moq;
using NUnit.Framework;
using Business;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineVerseConsoleApp.Tests
{
    public class Test02
    {
        [TestCase]
        public void TestListAllMovies()
        {
            var testData = new List<Movie>
            {
                new Movie("testMovieName1", "testMovieDirector1", 90, 1, 1, "Monday"),
                new Movie("testMovieName2", "testMovieDirector2", 100, 2, 2, "Tuesday"),
                new Movie("testMovieName3", "testMovieDirector3", 110, 3, 3, "Wednesday")
            };
            var mockSet = new Mock<DbSet<Movie>>();
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(testData.AsQueryable().Provider);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(testData.AsQueryable().Expression);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(testData.AsQueryable().ElementType);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(testData.AsQueryable().GetEnumerator());

            var mockContext = new Mock<CineVerseContext>();
            mockContext.Setup(c => c.Movies).Returns(mockSet.Object);

            var movieBusiness = new MovieBusiness(mockContext.Object);

            // Return every movie in the database
            var result = movieBusiness.GetAll();
            
            Assert.AreEqual(3, result.Count); // Check if all movies are retrieved
            Assert.AreEqual("testMovieName1", result[0].Name); // Check if the first movie's name matches
            Assert.AreEqual("testMovieName2", result[1].Name); // Check if the second movie's name matches
            Assert.AreEqual("testMovieName3", result[2].Name); // Check if the third movie's name matches
        }
    }
}
