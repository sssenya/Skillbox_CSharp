using Microsoft.EntityFrameworkCore;
using Practice_19_ASP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Practice_19_ASP.Authentication;

namespace Practice_19_ASP.Context {
    public class DataContext : IdentityDbContext<User> {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                DataBase=_contactsTest;
                Trusted_Connection=True;"
                );
        }
    }
}
