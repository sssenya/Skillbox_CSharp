using Microsoft.EntityFrameworkCore;
using Practice_19_ASP.Models;
using System;

namespace Practice_19_ASP.Context {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
