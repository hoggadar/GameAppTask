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

// swagger support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// db context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// auth
builder.Services.AddIdentity<UserModel, RoleModel>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// di
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBoardGameRepository, BoardGameRepository>();
builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBoardGameService, BoardGameService>();
builder.Services.AddScoped<IFavouriteService, FavouriteService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IFriendRequestService, FriendRequestService>();
builder.Services.AddScoped<RoleDataSeeder>();

// mappers
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(BoardGameProfile));
builder.Services.AddAutoMapper(typeof(FavouriteProfile));
builder.Services.AddAutoMapper(typeof(CommentProfile));
builder.Services.AddAutoMapper(typeof(FriendRequestProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// logs
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// migration and seed user roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
        var roleSeeder = services.GetRequiredService<RoleDataSeeder>();
        await roleSeeder.SeedData();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

app.Run();
