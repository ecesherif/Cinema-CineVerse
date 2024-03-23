using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public class CineVerseContext : DbContext
	{
		public CineVerseContext() { }
		public CineVerseContext(DbContextOptions options) : base(options) { }
		public virtual DbSet<Movie> Movies { get; set; }
		public virtual DbSet<Genre> Genres { get; set; }
		public virtual DbSet<Hall> Halls { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			if (!optionsBuilder.IsConfigured)
            {
				optionsBuilder.UseSqlServer(@"Server=DESKTOP-7F8EID3\SQLEXPRESS;Database=CineVerse;Integrated security=True;");
            }
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Movie>().HasOne(m => m.Genre).WithMany().HasForeignKey(m => m.GenreId);
			modelBuilder.Entity<Movie>().HasOne(m => m.Hall).WithMany().HasForeignKey(m => m.HallId);
        }
	}
}
