using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using StudentApp.Utils.Student;
using StudentApp.Repository.Student;
using StudentApp.Repository.Cartier;
using StudentApp.Middlewares;
using StudentApp.Services;
using StudentApp.Repository.Abonnement;
using StudentApp.middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<U669885128UZsNtContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnectionMySQL"),
        new MySqlServerVersion(new Version(8, 0, 21))));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentMapper , StudentMapper>();
builder.Services.AddScoped<ICartierRepository, CartierRepository>();
builder.Services.AddScoped<IAbonnementRepository, AbonnementRepository>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddTransient<SmsService>();
builder.Services.Configure<TwilioSetting>(builder.Configuration.GetSection("Twilio"));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<ResponseVerificationMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles(); 

//configuration du session
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ads}/{action=AjouterAd}/{id?}");

app.Run();
