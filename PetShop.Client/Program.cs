using Microsoft.EntityFrameworkCore;
using PetShop.Client.Services;
using PetShop.Data.Contexts;
using PetShop.Data.Repositories;
using PetShot.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PetShopDbContext>(options =>
options.UseLazyLoadingProxies().UseSqlServer(
builder.Configuration.GetConnectionString("PetShopDataConnection")));

builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICommentRepository,CommentRepository>();



builder.Services.AddControllersWithViews();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
