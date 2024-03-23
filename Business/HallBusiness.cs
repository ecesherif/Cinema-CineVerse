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
    /* In this class we create methods for the Hall table */
    public class HallBusiness
    {
        private readonly CineVerseContext _cineVerseContext;

        public HallBusiness(CineVerseContext cineVerseContext)
        {
            _cineVerseContext = cineVerseContext;
        }

        public List<Hall> GetAll()
        {
            return _cineVerseContext.Halls.ToList();
        }

        public Hall Get(int id)
        {
            return _cineVerseContext.Halls.Find(id);
        }

        public void Add(Hall hall)
        {
            _cineVerseContext.Halls.Add(hall);
            _cineVerseContext.SaveChanges();
        }

        public void Update(Hall hall)
        {
            var item = _cineVerseContext.Halls.Find(hall.Id);
            if (item != null)
            {
                _cineVerseContext.Entry(item).CurrentValues.SetValues(hall);
                _cineVerseContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var hall = _cineVerseContext.Halls.Find(id);
            if (hall != null)
            {
                _cineVerseContext.Halls.Remove(hall);
                _cineVerseContext.SaveChanges();
            }
        }
    }
}
