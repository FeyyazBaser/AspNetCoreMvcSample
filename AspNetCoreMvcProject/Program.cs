using AspNetCoreMvcSample.Helpers;
using AspNetCoreMvcSample.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();
var connectionString = "Data Source=.;Initial Catalog=School;Integrated Security=True;";
builder.Services.AddDbContext<SchoolContext>(options=>options.UseSqlServer(connectionString));
builder.Services.AddScoped<ICalculate, VatCalculate>(); // �ok instance bellekten kald�r�l�r

// builder.Services.AddSingleton<ICalculate, VatCalculate>();  // �ok s�kl�kla �a�r�lan s�n�flar i�in kullanabiliriz tek instance bellekte durur

// builder.Services.AddTransient<ICalculate, VatCalculate>();  // ayn� interfaceden ka� parametre verilirse o kadar instance AddScoped da tek instance

var app = builder.Build();
app.UseStaticFiles();
// Configure the HTTP request pipeline.

var data = app.Environment.IsDevelopment();

if (!app.Environment.IsDevelopment())
{
    
    app.UseExceptionHandler("/Error");
    //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}
else
app.UseExceptionHandler("/Error");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "feyyaz",
    pattern: "Feyyaz/{controller=Home}/{action=Index3}/{id?}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
