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
    public class Test03
    {
        [TestCase]
        public void TestGetMovieById()
        {
            var testData = new List<Movie>
            {
                new Movie("testMovieName1", "testMovieDirector1", 120, 1, 1, "Monday") {Id = 1},
                new Movie("testMovieName2", "testMovieDirector2", 130, 2, 2, "Tuesday") {Id = 2},
                new Movie("testMovieName3", "testMovieDirector3", 140, 3, 3, "Wednesday") {Id = 3}
            };

            var mockSet = new Mock<DbSet<Movie>>();
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(testData.AsQueryable().Provider);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(testData.AsQueryable().Expression);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(testData.AsQueryable().ElementType);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(testData.AsQueryable().GetEnumerator());

            var mockContext = new Mock<CineVerseContext>();
            mockContext.Setup(c => c.Movies.Find(It.IsAny<object[]>())).Returns((object[] id) => testData.FirstOrDefault(m => m.Id == (int)id[0]));

            var movieBusiness = new MovieBusiness(mockContext.Object);

            // Return a movie by its id
            var result = movieBusiness.Get(2);

            Assert.IsNotNull(result); // Check if the returned movie is not null
            Assert.AreEqual("testMovieName2", result.Name); // Check if the retrieved movie's name matches
            Assert.AreEqual("testMovieDirector2", result.Director); // Check if the retrieved movie's director matches
            Assert.AreEqual(130, result.Duration); // Check if the retrieved movie's duration matches
            Assert.AreEqual(2, result.GenreId); // Check if the retrieved movie's genre ID matches
            Assert.AreEqual(2, result.HallId); // Check if the retrieved movie's hall ID matches
            Assert.AreEqual("Tuesday", result.ProjectionDay); // Check if the retrieved movie's projection day matches
        }
    }
}
