using GameAppTaskBusiness.Interfaces;
using GameAppTaskBusiness.Mappers;
using GameAppTaskBusiness.Services;
using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Data.DataSeeders;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Implementations;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

// controllers and views
builder.Services.AddControllersWithViews();

// db context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// auth
builder.Services.AddIdentity<UserModel, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// di
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBoardGameRepository, BoardGameRepository>();
builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBoardGameService, BoardGameService>();
builder.Services.AddScoped<IFavouriteService, FavouriteService>();
builder.Services.AddScoped<RoleDataSeeder>();

// mappers
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(BoardGameProfile));
builder.Services.AddAutoMapper(typeof(FavouriteProfile));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// seed user roles
using (var scope = app.Services.CreateScope())
{
    var roleSeeder = scope.ServiceProvider.GetRequiredService<RoleDataSeeder>();
    await roleSeeder.SeedData();
}

app.Run();
