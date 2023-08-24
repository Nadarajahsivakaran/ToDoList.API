using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserToDoList> UserToDoList { get; set; }

        public DbSet<Tasks> Tasks { get; set; }

        public DbSet<ToDoLists> ToDoLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    FirstName ="Siva",
                    LastName ="karan",
                    Gender = Models.Enum.Gender.Male,
                    Email = "Karan@gmail.com",
                    Password = "Karan@123",
                });

            modelBuilder.Entity<ToDoLists>().HasData(
                new ToDoLists
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    Name ="Payment Module",
                    Description ="create some payment"
                });
        }


    }
}