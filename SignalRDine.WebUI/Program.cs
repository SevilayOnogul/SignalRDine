using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalRDine.DataAccessLayer.Concrete;
using SignalRDine.EntityLayer.Entities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Yetkilendirme Politikasý
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<SignalRDineContext>();

// Identity Ayarlarý
builder.Services.AddIdentity<AppUser, AppRole>(options => {
    options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<SignalRDineContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
});

// Cookie Ayarlarý
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index/";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(10);
});

// MVC ve Validation Birleþtirilmiþ Yapý
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
})
.AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    fv.DisableDataAnnotationsValidation = true;
});

var app = builder.Build();

// 404 Hata Yönetimi
app.UseStatusCodePages(async x =>
{
    if (x.HttpContext.Response.StatusCode == 404)
    {
        x.HttpContext.Response.Redirect("/Error/NotFound404Page/");
    }
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();