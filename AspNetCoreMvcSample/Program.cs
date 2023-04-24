using AspNetCoreMvcSample.Helpers;
using AspNetCoreMvcSample.Identity;
using AspNetCoreMvcSample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();


var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<AppIdentityUser, AppIdentiyRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders(); // Identity

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;

    options.Lockout.MaxFailedAccessAttempts = 5; // Hatalý þifre girince uyarý
    options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(3);  // Hatalý girebileceði kadar girdikten sonra 3 dk izin vermez
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedPhoneNumber = false;
}
);

builder.Services.ConfigureApplicationCookie(options =>  // Cookie konfigürasyonu
{
    options.LoginPath = "/Security/Login";
    options.LogoutPath = "/Security/Logout";
    options.AccessDeniedPath = "/Security/AccessDenied";
    options.SlidingExpiration = true;  // Cookienin aktif kalma süresi 30 dk ise 25. dkda login olunursa yenilenmesi için
    //options.Cookie = new CookieBuilder();

    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = "AspNetCoreMvcSample.Security.Cookie",
        Path = "/",
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.SameAsRequest
    };

});




builder.Services.AddScoped<ICalculate, VatCalculate>(); // çok instance bellekten kaldýrýlýr

builder.Services.AddSession();  // Session ekleme sepetteki ürünleri tutmak için kullanýlabilir cacheleme cookie
builder.Services.AddDistributedMemoryCache();

// builder.Services.AddSingleton<ICalculate, VatCalculate>();  // çok sýklýkla çaðrýlan sýnýflar için kullanabiliriz tek instance bellekte durur

// builder.Services.AddTransient<ICalculate, VatCalculate>();  // ayný interfaceden kaç parametre verilirse o kadar instance AddScoped da tek instance

var app = builder.Build();
app.UseStaticFiles();
// Configure the HTTP request pipeline.

app.Environment.EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName.Production;

if (app.Environment.IsDevelopment())
{

    app.UseDeveloperExceptionPage();
    //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}
else
    app.UseExceptionHandler("/Error");

app.UseSession();

app.UseAuthentication(); // Authentication middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "feyyaz",
    pattern: "Feyyaz/{controller=Home}/{action=Index3}/{id?}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
