global using SportSite6.Database;
global using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DBContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("WebAppDatabase");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.UseExceptionHandler("/error");
app.Use(async (context, next) =>{
  await next();
  if (context.Response.StatusCode == 404){
    context.Request.Path = "/error";
  	await next();
  }
});

app.Run();
