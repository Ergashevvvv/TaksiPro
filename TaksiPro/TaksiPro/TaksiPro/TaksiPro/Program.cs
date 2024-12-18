using TaksiPro.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<AppDbContext>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(name: "def",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
