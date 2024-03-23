using System;
using System.Collections.Generic;
using Data.Models;
using Data;
using Moq;
using NUnit.Framework;
using Business;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineVerseConsoleApp.Tests
{
    public class Test17
    {
        [TestCase]
        public void SuccessfullyUpdatedMovieHallId()
        {
            int id = 1;
            int newHallId = 3;
            var mockMovieBusiness = new Mock<MovieBusiness>();
            mockMovieBusiness.Setup(mb => mb.Get(id)).Returns(new Movie { Id = id, HallId = 1 });

            var updateMovieBusiness = new UpdateMovieBusiness(mockMovieBusiness.Object);

            // Update movie's hall id with the new one
            updateMovieBusiness.UpdateMovieHallId(id, newHallId);

            mockMovieBusiness.Verify(mb => mb.Update(It.Is<Movie>(m => m.Id == id && m.HallId == newHallId)), Times.Once);
        }
    }
}
