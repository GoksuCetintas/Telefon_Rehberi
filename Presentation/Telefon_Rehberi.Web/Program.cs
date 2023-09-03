using Microsoft.EntityFrameworkCore;
using Telefon_Rehberi.Application.Interfaces.Repositories;
using Telefon_Rehberi.Application.Interfaces.Services;
using Telefon_Rehberi.Application.Mapper;
using Telefon_Rehberi.Persistance.Data.Context;
using Telefon_Rehberi.Persistance.Repositories.EntityFramework;
using Telefon_Rehberi.Persistance.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("cs");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IContactRepository, EfContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

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
