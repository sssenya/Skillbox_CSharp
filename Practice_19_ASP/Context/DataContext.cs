using Microsoft.EntityFrameworkCore;
using Practice_19_ASP.Models;

namespace Practice_19_ASP.Context {
    public class DataContext : DbContext {
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
