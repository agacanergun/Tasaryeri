using Microsoft.EntityFrameworkCore;
using Tasaryeri.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SqlContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("CS1")));












var app = builder.Build();
app.Run();
