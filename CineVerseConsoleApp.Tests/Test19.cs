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
    public class Test19
    {
        [TestCase]
        public void SuccessfullyUpdatedMovieProjectionDay()
        {
            int id = 1;
            string newProjectionDay = "Saturday";
            var mockMovieBusiness = new Mock<MovieBusiness>();
            mockMovieBusiness.Setup(mb => mb.Get(id)).Returns(new Movie { Id = id, ProjectionDay = "Monday" });

            var updateMovieBusiness = new UpdateMovieBusiness(mockMovieBusiness.Object);

            // Update movie's projection day with the new one
            updateMovieBusiness.UpdateMovieProjectionDay(id, newProjectionDay);

            mockMovieBusiness.Verify(mb => mb.Update(It.Is<Movie>(m => m.Id == id && m.ProjectionDay == newProjectionDay)), Times.Once);
        }
    }
}
