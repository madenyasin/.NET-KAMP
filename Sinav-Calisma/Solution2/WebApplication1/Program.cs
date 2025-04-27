using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Abstracts;
using WebApplication1.Data;
using WebApplication1.Mappings;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connStr = builder.Configuration.GetConnectionString("ConnStr");
            builder.Services.AddDbContext<KutuphaneDbContext>(x => x.UseSqlServer(connStr));


            builder.Services.AddTransient<KitapRepository>();

            builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
            {
                x.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<KutuphaneDbContext>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
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
