using Microsoft.EntityFrameworkCore;
using Tasaryeri.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SqlContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("CS1")));



var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithRedirects("/hata/{0}");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); //kimlik doðrulama
app.UseAuthorization(); //kimlik yetkilendirme
app.MapControllerRoute(name: "admin", pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");

app.Run();
