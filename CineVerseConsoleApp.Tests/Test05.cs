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
    public class Test05
    {
        [TestCase]
        public void TestAddHall()
        {

            var testData = new List<Hall>();
            var mockSet = new Mock<DbSet<Hall>>();


            mockSet.Setup(m => m.Add(It.IsAny<Hall>())).Callback<Hall>(hall => testData.Add(hall));

            var mockContext = new Mock<CineVerseContext>();
            mockContext.Setup(c => c.Halls).Returns(mockSet.Object);

            var hallBusiness = new HallBusiness(mockContext.Object);

            // Add a hall
            hallBusiness.Add(new Hall(35, 20));

            // Verify that the hall was added
            Assert.AreEqual(1, testData.Count); // Check if the hall was added to the in-memory data store
            Assert.AreEqual(35, testData[0].Capacity); // Check if the added hall has the same capacity
            Assert.AreEqual(20, testData[0].Reserved); // Check if the added hall has the same capacity
        }
    }
}