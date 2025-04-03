using Microsoft.EntityFrameworkCore;
using System;

namespace SmallApplicationEF
{
    public class DBContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=people.db");
        }
    }
}
