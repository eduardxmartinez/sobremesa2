using Microsoft.EntityFrameworkCore;
// using Sobremesa.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add Session Support
builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();


// Configure the HTTP request pipeline.
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();