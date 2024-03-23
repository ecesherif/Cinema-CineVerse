using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /* These are the properties of the Hall table */
    public class Hall
    {
        public Hall() { }
        public Hall(int capacity, int reserved)
        {
            this.Capacity = capacity;
            this.Reserved = reserved;
        }
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int Reserved { get; set; }
    }
}
