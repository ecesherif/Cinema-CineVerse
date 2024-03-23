using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /* These are the properties of the Genre table */
    public class Genre
    {
        public Genre() { }
        public Genre(string genreName)
        {
            this.GenreName = genreName;
        }
        public int Id { get; set; }
        public string GenreName { get; set; }
    }
}
