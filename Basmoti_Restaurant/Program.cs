using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Basmoti_Restaurant.Data;
using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc();

builder.Services.AddDbContext<AppDbContext>(x => 
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});



builder.Services.AddScoped<IRepository<MasterMenu>, dbMasterMenuRepository>();

builder.Services.AddScoped<IRepository<MasterCategoryMenu>, dbMasterCategoryMenuRepository>();

builder.Services.AddScoped<IRepository<MasterItemMenu>, dbMasterItemMenuRepository>();

builder.Services.AddScoped<IRepository<MasterOffer>, dbMasterOfferRepository>();

builder.Services.AddScoped<IRepository<MasterPartner>, dbMasterPartnerRepository>();

builder.Services.AddScoped<IRepository<MasterService>, dbMasterServiceRepository>();

builder.Services.AddScoped<IRepository<MasterSlider>, dbMasterSliderRepository>();

builder.Services.AddScoped<IRepository<MasterWhatPeopleSay>, dbMasterWhatPeopleSayRepository>();

builder.Services.AddScoped<IRepository<MasterWorkingHours>, dbMasterWorkingHoursRepository>();

builder.Services.AddScoped<IRepository<MasterSocialMedia>, dbMasterSocialMediaRepository>();

builder.Services.AddScoped<IRepository<SystemSetting>, dbSystemSettingRepository>();

builder.Services.AddScoped<ITransactionRepository<TransactionBookTable>, dbTransactionBookTableRepository>();

builder.Services.AddScoped<ITransactionRepository<TransactionContactUs>, dbTransactionContactUsRepository>();

builder.Services.AddScoped<ITransactionRepository<TransactionNewsletter>, dbTransactionNewsletterRepository>();








builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    //options here

    options.LoginPath = "/Admin/Account/Login";

    //...
});


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

app.UseAuthentication();
app.UseAuthorization();

 


app.MapControllerRoute(
   name: "areas",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");



app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");





app.Run();