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
    public class Test13
    {
        [TestCase]
        public void SuccessfullyUpdatedMovieDuration()
        {
            int id = 1;
            int newDuration = 130;

            var mockMovieBusiness = new Mock<MovieBusiness>();
            mockMovieBusiness.Setup(mb => mb.Get(id)).Returns(new Movie { Id = id, Duration = 120 });

            var updateMovieBusiness = new UpdateMovieBusiness(mockMovieBusiness.Object);

            // Update movie's duration with the new one
            updateMovieBusiness.UpdateMovieDuration(id, newDuration);

            mockMovieBusiness.Verify(mb => mb.Update(It.Is<Movie>(m => m.Id == id && m.Duration == newDuration)), Times.Once);

        }
    }
}
