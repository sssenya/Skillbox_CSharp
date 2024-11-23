using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Practice_19_ASP.Models;
using System;
using Practice_19_ASP.Authentication;

namespace Practice_19_ASP.Context {
    public class DataContext : IdentityDbContext<User> {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
