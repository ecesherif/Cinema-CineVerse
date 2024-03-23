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
    public class Test10
    {
        [TestCase]
        public void ÇannotUpdatedMovieName()
        {
            int movieId = 1;
            string newName = "New Movie Name";

            var mockMovieBusiness = new Mock<MovieBusiness>();          

            // Setup the Get method to return null, simulating that the movie does not exist
            mockMovieBusiness.Setup(mb => mb.Get(movieId)).Returns((Movie)null);

            var updateMovieBusiness = new UpdateMovieBusiness(mockMovieBusiness.Object);

            /* 
            * Ensure that trying to update the movie name does not throw an exception,
            * but it prints "Movie not found!" to the console 
            */
            Assert.DoesNotThrow(() => updateMovieBusiness.UpdateMovieName(movieId, newName));
        }
    }
}
