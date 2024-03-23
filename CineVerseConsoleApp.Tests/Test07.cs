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
    public class Test07
    {
        [TestCase]
        public void TestGetHallById()
        {

            var testData = new List<Hall>
            {
                new Hall(35,20) {Id = 1},
                new Hall(30,15) {Id = 2},
                new Hall(25,10) {Id = 3}
            };

            var mockSet = new Mock<DbSet<Hall>>();
            mockSet.As<IQueryable<Hall>>().Setup(m => m.Provider).Returns(testData.AsQueryable().Provider);
            mockSet.As<IQueryable<Hall>>().Setup(m => m.Expression).Returns(testData.AsQueryable().Expression);
            mockSet.As<IQueryable<Hall>>().Setup(m => m.ElementType).Returns(testData.AsQueryable().ElementType);
            mockSet.As<IQueryable<Hall>>().Setup(m => m.GetEnumerator()).Returns(testData.AsQueryable().GetEnumerator());

            var mockContext = new Mock<CineVerseContext>();
            mockContext.Setup(c => c.Halls.Find(It.IsAny<object[]>())).Returns((object[] id) => testData.FirstOrDefault(m => m.Id == (int)id[0]));

            var hallBusiness = new HallBusiness(mockContext.Object);

            // Return a Hall by its id
            var result = hallBusiness.Get(2);

            Assert.IsNotNull(result); // Check if the returned Hall is not null
            Assert.AreEqual(30, result.Capacity); // Check if the retrieved Hall's capacity matches
            Assert.AreEqual(15, result.Reserved); // Check if the retrieved Hall's reserved matches
        }
    }
}
