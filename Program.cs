// Student nr      : 224079871;225044710;224092435;225016174;223020311;224020707
// Programmer name : M Dyantyi;W Khoza;U Theku;SG Thela;LS Maroga;B Mtimkulu;
// Assignment nr   : Practical Assessment 2
// Purpose         : Application entry point. Configures the services (database context,
//                   database initializer and board repository) and the HTTP request
//                   pipeline for the BoardAppDB web application and starts the host

using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the database context with the SQLite provider and the DefaultConnection connection string
builder.Services.AddDbContext<BoardContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the interfaces together with the repositories that implement them
builder.Services.AddScoped<IDBInitializer, DBInitializerRepo>();
builder.Services.AddScoped<IBoard, BoardRepo>();

var app = builder.Build();

// Create the database and seed it once at start-up. The services are scoped, so a scope
// must be created before they can be requested from the service provider.
using (var scope = app.Services.CreateScope())
{
    IDBInitializer dbInitializer = scope.ServiceProvider.GetRequiredService<IDBInitializer>();
    dbInitializer.Initialize();
} // end using

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} // end if

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
