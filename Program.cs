using GerenciamentoTurismo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GerenciamentoTurismo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AgenciaTurismoContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("AgenciaTurismoContext")));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login";
                    options.AccessDeniedPath = "/AccessDenied";
                });

            //builder.Services.AddRazorPages(options =>
            //{
            //    options.Conventions.AddAreaPageRoute("Pacotes", "/Index", "Pacotes");
            //});

            // Add services to the container.
            //builder.Services.AddRazorPages();
            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/");
            });

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
