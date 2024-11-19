using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Practice_19_ASP.Context;
using System;

public class Program {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=StartView}/{action=Index}/{id?}");

        app.Run();
    }
}
