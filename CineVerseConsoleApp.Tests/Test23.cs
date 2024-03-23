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
    public class Test23
    {
        [TestCase]
        public void TestGetGenreById()
        {

            var testData = new List<Genre>
            {
                new Genre("Genre1") {Id = 1},
                new Genre("Genre2") {Id = 2},
                new Genre("Genre3") {Id = 3}
            };

            var mockSet = new Mock<DbSet<Genre>>();
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Provider).Returns(testData.AsQueryable().Provider);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Expression).Returns(testData.AsQueryable().Expression);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.ElementType).Returns(testData.AsQueryable().ElementType);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.GetEnumerator()).Returns(testData.AsQueryable().GetEnumerator());

            var mockContext = new Mock<CineVerseContext>();
            mockContext.Setup(c => c.Genres.Find(It.IsAny<object[]>())).Returns((object[] id) => testData.FirstOrDefault(m => m.Id == (int)id[0]));

            var GenreBusiness = new GenreBusiness(mockContext.Object);

            // Return a Genre by its id
            var result = GenreBusiness.Get(2);

            Assert.IsNotNull(result); // Check if the returned Genre is not null
            Assert.AreEqual("Genre2", result.GenreName); // Check if the retrieved Genre's name matches
        }
    }
}
