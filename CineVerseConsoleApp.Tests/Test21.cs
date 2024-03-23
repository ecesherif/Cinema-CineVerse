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
    public class Test21
    {
        [TestCase]
        public void TestAddGenre()
        {

            var testData = new List<Genre>();
            var mockSet = new Mock<DbSet<Genre>>();


            mockSet.Setup(m => m.Add(It.IsAny<Genre>())).Callback<Genre>(genre => testData.Add(genre));

            var mockContext = new Mock<CineVerseContext>();
            mockContext.Setup(c => c.Genres).Returns(mockSet.Object);

            var genreBusiness = new GenreBusiness(mockContext.Object);

            // Add a genre
            genreBusiness.Add(new Genre("newGenre"));

            // Verify that the genre was added
            Assert.AreEqual(1, testData.Count); // Check if the genre was added to the in-memory data store
            Assert.AreEqual("newGenre", testData[0].GenreName); // Check if the added genre has the same name
           
        }
    }
}
