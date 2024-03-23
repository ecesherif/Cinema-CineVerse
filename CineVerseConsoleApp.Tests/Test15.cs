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
    public class Test15
    {
        [TestCase]
        public void SuccessfullyUpdatedMovieGenreId()
        {
            int id = 1;
            int newGenreId = 3;
            var mockMovieBusiness = new Mock<MovieBusiness>();
            mockMovieBusiness.Setup(mb => mb.Get(id)).Returns(new Movie { Id = id, GenreId = 1 });

            var updateMovieBusiness = new UpdateMovieBusiness(mockMovieBusiness.Object);

            // Update movie's genre id with the new one
            updateMovieBusiness.UpdateMovieGenreId(id, newGenreId);

            mockMovieBusiness.Verify(mb => mb.Update(It.Is<Movie>(m => m.Id == id && m.GenreId == newGenreId)), Times.Once);

        }
    }
}
