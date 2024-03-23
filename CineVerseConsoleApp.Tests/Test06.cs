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
    public class Test06
    {
        [TestCase]
        public void TestListAllHalls()
        {
            var testData = new List<Hall>
            {
                new Hall(35, 20),
                new Hall(30, 15),
                new Hall(25, 10)
            };
            var mockSet = new Mock<DbSet<Hall>>();
            mockSet.As<IQueryable<Hall>>().Setup(m => m.Provider).Returns(testData.AsQueryable().Provider);
            mockSet.As<IQueryable<Hall>>().Setup(m => m.Expression).Returns(testData.AsQueryable().Expression);
            mockSet.As<IQueryable<Hall>>().Setup(m => m.ElementType).Returns(testData.AsQueryable().ElementType);
            mockSet.As<IQueryable<Hall>>().Setup(m => m.GetEnumerator()).Returns(testData.AsQueryable().GetEnumerator());

            var mockContext = new Mock<CineVerseContext>();
            mockContext.Setup(c => c.Halls).Returns(mockSet.Object);

            var hallBusiness = new HallBusiness(mockContext.Object);

            // Return every Hall in the database
            var result = hallBusiness.GetAll();

            Assert.AreEqual(3, result.Count); // Check if all Halls are retrieved
            Assert.AreEqual(35, result[0].Capacity); // Check if the first Hall's name matches
            Assert.AreEqual(30, result[1].Capacity); // Check if the second Hall's name matches
            Assert.AreEqual(25, result[2].Capacity); // Check if the third Hall's name matches

        }
    }
}
