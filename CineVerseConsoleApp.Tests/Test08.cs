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
    public class Test08
    {
        [TestCase]
        public void TestDeleteHall()
        {
            var testData = new List<Hall>
            {
                new Hall(35, 20) { Id = 1 },
                new Hall(30, 15) { Id = 2 },
                new Hall(25, 10) { Id = 3 }
            };

            var mockSet = new Mock<DbSet<Hall>>();
            mockSet.As<IQueryable<Hall>>().Setup(m => m.Provider).Returns(testData.AsQueryable().Provider);
            mockSet.As<IQueryable<Hall>>().Setup(m => m.Expression).Returns(testData.AsQueryable().Expression);
            mockSet.As<IQueryable<Hall>>().Setup(m => m.ElementType).Returns(testData.AsQueryable().ElementType);
            mockSet.As<IQueryable<Hall>>().Setup(m => m.GetEnumerator()).Returns(testData.AsQueryable().GetEnumerator());

            var mockContext = new Mock<CineVerseContext>();
            mockContext.Setup(c => c.Halls).Returns(mockSet.Object);


            // Mock the Find method of DbSet<Hall> to return the Hall to be deleted
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns((object[] ids) => testData.FirstOrDefault(m => m.Id == (int)ids[0]));

            var hallBusiness = new HallBusiness(mockContext.Object);

            // Delete the Hall
            hallBusiness.Delete(2);

            // Verify that the context's Remove method was called with the correct Hall
            mockSet.Verify(m => m.Remove(It.IsAny<Hall>()), Times.Once);
            // Verify that SaveChanges was called
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}