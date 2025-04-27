
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SinavProje.Data;
using SinavProje.Models;
using SinavProje.Repositories.Implementations;

namespace SinavProje
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Connection string
            var connStr = builder.Configuration.GetConnectionString("ConnStr");

            // Add DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connStr);
            });

            // Add Identity
            builder.Services.AddIdentity<AppUser, IdentityRole<int>>(x =>
            {
                x.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<AppDbContext>();


            // Add Repositories
 

            builder.Services.AddTransient<UserRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
