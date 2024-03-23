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
    public class Test22
    {
        [TestCase]
        public void TestListAllGenres()
        {
            var testData = new List<Genre>
            {
                new Genre("newGenre1"),
                new Genre("newGenre2"),
                new Genre("newGenre3")
            };
            var mockSet = new Mock<DbSet<Genre>>();
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Provider).Returns(testData.AsQueryable().Provider);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Expression).Returns(testData.AsQueryable().Expression);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.ElementType).Returns(testData.AsQueryable().ElementType);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.GetEnumerator()).Returns(testData.AsQueryable().GetEnumerator());

            var mockContext = new Mock<CineVerseContext>();
            mockContext.Setup(c => c.Genres).Returns(mockSet.Object);

            var GenreBusiness = new GenreBusiness(mockContext.Object);

            // Return every Genre in the database
            var result = GenreBusiness.GetAll();

            Assert.AreEqual(3, result.Count); // Check if all Genres are retrieved
            Assert.AreEqual("newGenre1", result[0].GenreName); // Check if the first Genre's name matches
            Assert.AreEqual("newGenre2", result[1].GenreName); // Check if the second Genre's name matches
            Assert.AreEqual("newGenre3", result[2].GenreName); // Check if the third Genre's name matches

        }
    }
}
