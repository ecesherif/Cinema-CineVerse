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
    public class Test11
    {

        [TestCase]
        public void SuccessfullyUpdatedMovieDirector()
        {
            int id = 1;
            string newDirector = "New Movie Director";

            var mockMovieBusiness = new Mock<MovieBusiness>();
            mockMovieBusiness.Setup(mb => mb.Get(id)).Returns(new Movie { Id = id, Director = "Old Movie Director" });

            var updateMovieBusiness = new UpdateMovieBusiness(mockMovieBusiness.Object);

            // Update movie's director with the new one
            updateMovieBusiness.UpdateMovieDirector(id, newDirector);

            mockMovieBusiness.Verify(mb => mb.Update(It.Is<Movie>(m => m.Id == id && m.Director == newDirector)), Times.Once);
        }
    }
}
