using Microsoft.EntityFrameworkCore;
using Observatory.Data;

var builder = WebApplication.CreateBuilder(args);
//Add datebase
builder.Services.AddDbContext<ObservatoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ObservatoryDbContext"),
    x => x.MigrationsAssembly("Observatory")));
// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Observatory}/{action=Index}/{id?}");

app.Run();
