using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MCard40.Web.Data;
using MCard40.Web.Areas.Identity.Data;
using MCard40.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using MCard40.Web.Controllers;
using MCard40.Model.Interfaces;
using MCard40.Model.Entity;
using MCard40.Infrastucture.Services.Interfaces;
using MCard40.Infrastucture.Services.Implementations;
using MCard40.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MCard40WebContextConnection") ?? throw new InvalidOperationException("Connection string 'MCard40WebContextConnection' not found.");

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<CopyUserController>();
builder.Services.AddTransient<IRepository<Doctor, int>, Repository<Doctor, int>>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IRepository<Patient, int>, Repository<Patient, int>>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IRepository<CardPage, int>, Repository<CardPage, int>>();
builder.Services.AddTransient<ICardPageService, CardPageService>();


builder.Services.AddDbContext<MCard40DbContext>(options => options.UseLazyLoadingProxies());
builder.Services.AddRazorPages();

builder.Services.AddDbContext<MCard40WebContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<MCardUser, IdentityRole>()
            .AddEntityFrameworkStores<MCard40WebContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
