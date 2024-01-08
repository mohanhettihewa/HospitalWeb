using Hospitall.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Hospitall.Utitilities;
using Hospitall.Repositories.Implementation;
using Hospitall.Repositories.Interfaces;
using Hospitall.Services;
using Humanizer;
using System.Reflection;
using Microsoft.AspNetCore.Identity.UI.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



#pragma warning disable CS0436 // Type conflicts with imported type
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
#pragma warning restore CS0436 // Type conflicts with imported type
builder.Services.AddControllersWithViews();
#pragma warning disable CS0436 // Type conflicts with imported type
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
#pragma warning restore CS0436 // Type conflicts with imported type

//builder.Services.AddDefaultIdentity<IdentityUser>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IDbInitializer,Dbinitializer>();
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IHospitalInfo, HospitalInfoService>();
builder.Services.AddTransient<IRoomService, RoomService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.MapRazorPages();
app.UseHttpsRedirection();
app.UseStaticFiles();
DataSeeding();
app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "Identity",
    pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{area=admin}/{controller=HospitalInfo}/{action=Index}/{id?}");

app.Run();

void DataSeeding()
{

    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }

}
