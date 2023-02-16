using KatmanliBlogSitesi.Entities;
using Microsoft.EntityFrameworkCore;

namespace KatmanliBlogSitesi.Data
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=KatmanliBlogSitesi; integrated security=true"); 
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    Email = "admin@blogsitesi.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name = "admin",
                    SurName = "admin",
                    Password = "123"
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
