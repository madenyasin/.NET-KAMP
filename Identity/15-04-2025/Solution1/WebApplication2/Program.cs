using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var strConn = builder.Configuration.GetConnectionString("ConnStr");
builder.Services.AddDbContext<UrunDbContext>(x =>
{
    x.UseSqlServer(strConn);
});

//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<UrunDbContext>();

builder.Services.AddIdentity<Uye, Rol>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<UrunDbContext>()
.AddRoles<Rol>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
