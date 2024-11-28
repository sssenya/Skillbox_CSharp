using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Practice_19_ASP.Authentication;
using Practice_19_ASP.Context;
using System;
using static System.Formats.Asn1.AsnWriter;

public class Program {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<DataContext>()
        .AddDefaultTokenProviders();

        builder.Services.ConfigureApplicationCookie(options => {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.SlidingExpiration = true;
        });

        builder.Services.AddAuthorization(options => {
            options.AddPolicy("RequireLoggedIn", policy => policy.RequireAuthenticatedUser());
        });

        builder.Services.AddControllersWithViews();

        var app = builder.Build();


        app.UseAuthentication();
        app.UseAuthorization();

        app.UseHttpsRedirection();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=StartView}/{action=Index}/{id?}");

        app.Run();
    }
}
