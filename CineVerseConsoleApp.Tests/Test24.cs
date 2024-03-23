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
    public class Test24
    {

        [TestCase]
        public void TestDeleteGenre()
        {
            var testData = new List<Genre>
            {
                new Genre("Genre1") { Id = 1 },
                new Genre("Genre2") { Id = 2 },
                new Genre("Genre3") { Id = 3 }
            };

            var mockSet = new Mock<DbSet<Genre>>();
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Provider).Returns(testData.AsQueryable().Provider);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Expression).Returns(testData.AsQueryable().Expression);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.ElementType).Returns(testData.AsQueryable().ElementType);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.GetEnumerator()).Returns(testData.AsQueryable().GetEnumerator());

            var mockContext = new Mock<CineVerseContext>();
            mockContext.Setup(c => c.Genres).Returns(mockSet.Object);


            // Mock the Find method of DbSet<Genre> to return the Genre to be deleted
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns((object[] ids) => testData.FirstOrDefault(m => m.Id == (int)ids[0]));

            var GenreBusiness = new GenreBusiness(mockContext.Object);

            // Delete the Genre
            GenreBusiness.Delete(2);

            // Verify that the context's Remove method was called with the correct Genre
            mockSet.Verify(m => m.Remove(It.IsAny<Genre>()), Times.Once);
            // Verify that SaveChanges was called
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
