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
    public class Test04
    {
        [TestCase]
        public void TestDeleteMovie()
        { 
            var testData = new List<Movie>
            {
                new Movie("testMovieName1", "testMovieDirector1", 120, 1, 1, "Monday") { Id = 1 },
                new Movie("testMovieName2", "testMovieDirector2", 130, 2, 2, "Tuesday") { Id = 2 },
                new Movie("testMovieName3", "testMovieDirector3", 140, 3, 3, "Wednesday") { Id = 3 }
            };

            var mockSet = new Mock<DbSet<Movie>>();
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(testData.AsQueryable().Provider);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(testData.AsQueryable().Expression);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(testData.AsQueryable().ElementType);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(testData.AsQueryable().GetEnumerator());

            var mockContext = new Mock<CineVerseContext>();
            mockContext.Setup(c => c.Movies).Returns(mockSet.Object);


            // Mock the Find method of DbSet<Movie> to return the movie to be deleted
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns((object[] ids) => testData.FirstOrDefault(m => m.Id == (int)ids[0]));

            var movieBusiness = new MovieBusiness(mockContext.Object);

            // Delete the movie
            movieBusiness.Delete(2);

            // Verify that the context's Remove method was called with the correct movie
            mockSet.Verify(m => m.Remove(It.IsAny<Movie>()), Times.Once);
            // Verify that SaveChanges was called
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
