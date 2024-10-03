using AncientCities.Data.DbApplicationContext;
using AncientCities.Data.Repository.Concrete;
using AncientCities.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder
         .WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>())
         .AllowAnyMethod()
         .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Use CORS policy
app.UseCors(builder =>
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader());

// Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

// Map API endpoints
app.MapControllers();

// Serve Angular App
app.MapFallbackToFile("/Client/angular-app/dist/angular-app/index.html");


// Default route for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();