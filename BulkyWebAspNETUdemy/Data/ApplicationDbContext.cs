using BulkyWebAspNETUdemy.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebAspNETUdemy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        //Here categories is the table name in Category and the columns will be in the category class 
        public DbSet<Category> Categories { get; set; }

        //Here data is created and put in the table 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Action", DisplayOrder = 1 },
                new Category { ID = 2, Name = "Scifi", DisplayOrder = 2 },
                new Category { ID = 3, Name = "Horro", DisplayOrder = 3 }
                );
        }

    }
}
