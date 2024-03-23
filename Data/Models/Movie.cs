using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /* These are the properties of the Movie table */
    public class Movie
    {
        public Movie() { }
        public Movie(string name, string director, int duration, int genreId, int hallId, string projectionDay)
        {
            this.Name = name;
            this.Director = director;
            this.Duration = duration;
            this.GenreId = genreId;
            this.HallId = hallId;
            this.ProjectionDay = projectionDay;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; } /* In minutes */
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public string ProjectionDay { get; set; } /* Days of the week */
    }
}