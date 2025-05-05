using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using YasinMadenMVC.Data;
using YasinMadenMVC.Models;
using YasinMadenMVC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Connection string
var connStr = builder.Configuration.GetConnectionString("ConnStr");

// Add DbContext
builder.Services.AddDbContext<MakaleDbContext>(options =>
{
    options.UseSqlServer(connStr);
});

// Add Identity
builder.Services.AddIdentity<AppUser, IdentityRole<int>>(x =>
{
    x.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<MakaleDbContext>();

// Add Repositories
builder.Services.AddTransient<MakaleRepository>();
builder.Services.AddTransient<KategoriRepository>();

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
