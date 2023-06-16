using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Concreate;
using Tasaryeri.Core.Abstract;
using Tasaryeri.Core.Helpers;
using Tasaryeri.Core.Interfaces;
using Tasaryeri.DAL.Contexts;
using Tasaryeri.DAL.EntityFramework;
using Tasaryeri.DAL.EntityFramework.Abstract;
using Tasaryeri.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));
builder.Services.AddScoped(typeof(ICryptoBase), typeof(CryptoBase));
builder.Services.AddScoped(typeof(IEfAdminDAL), typeof(EfAdminDAL));
builder.Services.AddScoped(typeof(IAdminTransactions), typeof(AdminTransactions));
builder.Services.AddScoped(typeof(IEfSlideDAL), typeof(EfSlideDAL));
builder.Services.AddScoped(typeof(ISlideTransactions), typeof(SlideTransactions));
builder.Services.AddScoped(typeof(IEfCategoryDAL), typeof(EfCategoryDAL));
builder.Services.AddScoped(typeof(ICategoryTransactions), typeof(CategoryTransactions));
builder.Services.AddScoped(typeof(IEfFooterDAL), typeof(EfFooterDAL));
builder.Services.AddScoped(typeof(IFooterTransactions), typeof(FooterTransactions));
builder.Services.AddScoped(typeof(IEfSalerLoginDAL), typeof(EfSalerLoginDAL));
builder.Services.AddScoped(typeof(ISalerLoginTransactions), typeof(SalerLoginTransactions));
builder.Services.AddScoped(typeof(IEfMemberLoginDAL), typeof(EfMemberLoginDAL));
builder.Services.AddScoped(typeof(IMemberLoginTransactions), typeof(MemberLoginTransactions));
builder.Services.AddScoped(typeof(IEfProductDAL), typeof(EfProductDAL));
builder.Services.AddScoped(typeof(IProductTransactions), typeof(ProductTransactions));
builder.Services.AddScoped(typeof(IEfProductPictureDAL), typeof(EfProductPictureDAL));
builder.Services.AddScoped(typeof(IProductPictureTransactions), typeof(ProductPictureTransactions));
builder.Services.AddScoped(typeof(IEfProductUIDAL), typeof(EfProductUIDAL));
builder.Services.AddScoped(typeof(IProductTransactionsUI), typeof(ProductTransactionsUI));

builder.Services.AddDbContext<SqlContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("CS1")));

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
//{
//    opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
//    opt.LoginPath = "/admin";
//    opt.LogoutPath = "/admin/logout";
//});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "TasaryeriAdminAuth";
    options.DefaultSignInScheme = "TasaryeriAdminAuth";
    options.DefaultChallengeScheme = "TasaryeriAdminAuth";
})
    .AddCookie("TasaryeriAdminAuth", opt =>
    {
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        opt.LoginPath = "/admin";
        opt.LogoutPath = "/admin/logout";
    });


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "TasaryeriSalerAuth";
    options.DefaultSignInScheme = "TasaryeriSalerAuth";
    options.DefaultChallengeScheme = "TasaryeriSalerAuth";
})
    .AddCookie("TasaryeriSalerAuth", opt =>
    {
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        opt.LoginPath = "/satici";
        opt.LogoutPath = "/satici/logout";
    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "TasaryeriMemberAuth";
    options.DefaultSignInScheme = "TasaryeriMemberAuth";
    options.DefaultChallengeScheme = "TasaryeriMemberAuth";
})
    .AddCookie("TasaryeriMemberAuth", opt =>
    {
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        opt.LoginPath = "/uye";
        opt.LogoutPath = "/uye/logout";
    });







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
