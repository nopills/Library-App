using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Models
{
    public class DatabaseContext: IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(b => b.Books).WithMany(u => u.ReadedByUser);
            base.OnModelCreating(modelBuilder);
        }
    }
}
