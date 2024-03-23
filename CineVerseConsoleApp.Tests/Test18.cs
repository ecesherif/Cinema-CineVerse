﻿using System;
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
    public class Test18
    {
        [TestCase]
        public void CannotUpdatedMovieHallId()
        {
            int id = 1;
            int newHallId = 3;
            var mockMovieBusiness = new Mock<MovieBusiness>();
            // Setup the Get method to return null, simulating that the movie does not exist
            mockMovieBusiness.Setup(mb => mb.Get(id)).Returns((Movie)null);

            var updateMovieBusiness = new UpdateMovieBusiness(mockMovieBusiness.Object);

            /* 
            * Ensure that trying to update the movie hall id does not throw an exception,
            * but it prints "Movie not found!" to the console 
            */
            Assert.DoesNotThrow(() => updateMovieBusiness.UpdateMovieDuration(id, newHallId));
        }
    }
}
