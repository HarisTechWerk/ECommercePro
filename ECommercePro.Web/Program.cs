using ECommercePro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Automatically loads appsettings.json, appsettings.Development.json, etc.
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath).
    AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
    AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true).
    AddEnvironmentVariables();

// Add DbContext to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configure Serilog.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Tie Serilog to the Web Host.
builder.Host.UseSerilog();

// Add MVC services to the container.
builder.Services.AddControllersWithViews();

// Build the app.
var app = builder.Build();

// Configure the middleware pipeline to use MVC.
if (!app.Environment.IsDevelopment())
{
    // Customize error handling in non-dev or production environments.
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// No authentication or authorization for now.

// app. UseAuthentication();

// app. UseAuthorization();

//app.MapGet("/", () => "Hello World!");

// Map default controller route.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the app.
app.Run();
