using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

using Practice_19_ASP.Authentication;
using Practice_19_ASP.Context;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System;

public class Program {
    public static void Main(string[] args) {

    var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => options.LoginPath = "/Login");
        builder.Services.AddAuthorization();

        var app = builder.Build();


        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=StartView}/{action=Index}/{id?}");

        app.MapGet("/login", async (HttpContext context) =>
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            // html-форма для ввода логина/пароля
            string loginForm = @"<!DOCTYPE html>
                <html>
                <head>
                    <meta charset='utf-8' />
                    <title>METANIT.COM</title>
                </head>
                <body>
                    <h2>Login Form</h2>
                    <form method='post'>
                        <p>
                            <label>Email</label><br />
                            <input name='email' />
                        </p>
                        <p>
                            <label>Password</label><br />
                            <input type='password' name='password' />
                        </p>
                        <input type='submit' value='Login' />
                    </form>
                </body>
                </html>";
            await context.Response.WriteAsync(loginForm);
        });

        app.MapPost("/login", async (string? returnUrl, HttpContext context) =>
        {
            var people = new List<UserLogin> {
                new UserLogin("tom@gmail.com", "12345"),
                new UserLogin("bob@gmail.com", "55555")
            };

            // получаем из формы email и пароль
            var form = context.Request.Form;
            // если email и/или пароль не установлены, посылаем статусный код ошибки 400
            if(!form.ContainsKey("email") || !form.ContainsKey("password"))
                return Results.BadRequest("Email и/или пароль не установлены");

            string email = form["email"];
            string password = form["password"];

            // находим пользователя 
            var person = people.FirstOrDefault(p => p.UserName == email && p.Password == password);
            // если пользователь не найден, отправляем статусный код 401
            if(person is null) return Results.Redirect("/StartView");

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.UserName) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return Results.Redirect(returnUrl ?? "/");
        });

        app.MapGet("/logout", async (HttpContext context) =>
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Results.Redirect("/login");
        });

        app.Run();
    }
}
