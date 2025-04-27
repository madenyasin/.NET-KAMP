using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Mapping;
using WebApplication1.Models;
using WebApplication1.Repositories.Implementations;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));


            // Add DbContext
            var connStr = builder.Configuration.GetConnectionString("ConnStr");
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
            builder.Services.AddTransient<KitapRepository>();
            builder.Services.AddTransient<KategoriRepository>();



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

            // Authentication eklendi. sebep: Identity kullanýyoruz.
            app.UseAuthentication();





            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
