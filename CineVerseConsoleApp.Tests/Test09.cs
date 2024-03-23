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
    public class Test09
    {
        [TestCase]
        public void SuccessfullyUpdatedMovieName()
        {
            int id = 1;
            string newName = "New Movie Name";

            var mockMovieBusiness = new Mock<MovieBusiness>();
            mockMovieBusiness.Setup(mb => mb.Get(id)).Returns(new Movie { Id = id, Name = "Old Movie Name" });

            var updateMovieBusiness = new UpdateMovieBusiness(mockMovieBusiness.Object);

            // Update movie's name with the new one
            updateMovieBusiness.UpdateMovieName(id, newName);

            
            mockMovieBusiness.Verify(mb => mb.Update(It.Is<Movie>(m => m.Id == id && m.Name == newName)), Times.Once);
        }
    }
}
