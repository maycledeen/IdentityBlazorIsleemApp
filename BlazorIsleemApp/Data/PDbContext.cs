using BlazorIsleemApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlazorIsleemApp.Data
{
    public class PDbContext : DbContext
    {
        public PDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> persons { get; set; }
        public DbSet<NewsCategory> newsCategories { get; set; }
        public DbSet<News> news { get; set; }
        public DbSet<User> users { get; set; }
    }
}




