using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddMvc();

builder.Services.AddDbContext<AppDbContext>(x => 
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});



//builder.Services.AddScoped<IRepository<MasterMenu>, dbMasterMenuRepository>();


builder.Services.Configure<IdentityOptions>(x => {
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireDigit = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireUppercase = false;
});
var app = builder.Build();
app.UseRouting();
app.UseStaticFiles();
//app.UseAuthentication();
//app.UseAuthorization();






//app.MapControllerRoute(
//  name: "areas",
//  pattern: "{area=exists}/{controller=Home}/{action=Index}/{id?}");



app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();