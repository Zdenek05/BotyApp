using BotyApp.Models.Repositories;
using Context = BotyApp.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context.AppContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("AppContext"));



});

builder.Services.AddScoped<ISneakerRepository, SneakerRepository>();



builder.Services.AddScoped<IModelRepository, ModelRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");


}
app.UseStaticFiles();

app.UseRouting();




app.MapControllerRoute(
    name: "sneaker_list",
    pattern: "seznam-bot",
    defaults: new { controller = "Sneaker", action = "Index" });




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
