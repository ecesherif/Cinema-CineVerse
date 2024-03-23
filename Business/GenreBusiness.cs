using System;
using Data;
using Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    /* In this class we create methods for the Genre table */
    public class GenreBusiness
    {
        private readonly CineVerseContext _cineVerseContext;

        public GenreBusiness(CineVerseContext cineVerseContext)
        {
            _cineVerseContext = cineVerseContext;
        }

        public List<Genre> GetAll()
        {
            return _cineVerseContext.Genres.ToList();
        }

        public Genre Get(int id)
        {
            return _cineVerseContext.Genres.Find(id);
        }

        public void Add(Genre genre)
        {
            _cineVerseContext.Genres.Add(genre);
            _cineVerseContext.SaveChanges();
        }

        public void Update(Genre genre)
        {
            var item = _cineVerseContext.Genres.Find(genre.Id);
            if (item != null)
            {
                _cineVerseContext.Entry(item).CurrentValues.SetValues(genre);
                _cineVerseContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var genre = _cineVerseContext.Genres.Find(id);
            if (genre != null)
            {
                _cineVerseContext.Genres.Remove(genre);
                _cineVerseContext.SaveChanges();
            }
        }
    }
}
