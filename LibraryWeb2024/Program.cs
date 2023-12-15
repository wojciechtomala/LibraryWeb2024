using LibraryWeb2024.DataAccess.Data;
using LibraryWeb2024.DataAccess.Repository;
using LibraryWeb2024.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// CONFIGURE DB CONTEXT AND ENTITY FRAMEWORK CORE:
builder.Services.AddDbContext<ApplicationDbContext>(
    // RECEIVE THE CONNECTION STRING FROM APPSETTINGS JSON AND PASS IT INSIDE THE USE SQL SERVER:
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
// REGISTER NEW SERVICE:
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
