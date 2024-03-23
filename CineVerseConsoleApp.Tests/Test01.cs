using System;
using CineVerseConsoleApp;
using Data.Models;
using Data;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Microsoft.EntityFrameworkCore;

namespace CineVerseConsoleApp.Tests
{
    public class Test01
    {
        [TestCase]
        public void TestAddMovie()
        {
            var testData = new List<Movie>(); 
            var mockSet = new Mock<DbSet<Movie>>();
           
            mockSet.Setup(m => m.Add(It.IsAny<Movie>())).Callback<Movie>(movie => testData.Add(movie));

            var mockContext = new Mock<CineVerseContext>();
            mockContext.Setup(c => c.Movies).Returns(mockSet.Object);

            var movieBusiness = new MovieBusiness(mockContext.Object);

            // Add a movie
            movieBusiness.Add(new Movie("testMovieName", "testMovieDirector", 156, 3, 4, "Monday"));

            // Verify that the movie was added
            Assert.AreEqual(1, testData.Count); // Check if the movie was added to the in-memory data store
            Assert.AreEqual("testMovieName", testData[0].Name); // Check if the added movie has the same name
        }
    }
}
