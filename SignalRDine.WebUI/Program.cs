using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalRDine.DataAccessLayer.Concrete;
using SignalRDine.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

var requireAuthorizePolicy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<SignalRDineContext>();
//builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<SignalRDineContext>();
builder.Services.AddIdentity<AppUser, AppRole>(options => {
    options.SignIn.RequireConfirmedEmail = false; // Bunu false yap
}).AddEntityFrameworkStores<SignalRDineContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index/"; // Süre dolunca buraya yönlendirir
    options.Cookie.HttpOnly = true;      // Güvenlik için XSS engeller
    //options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Test için 60 dk idealdir
    options.ExpireTimeSpan = TimeSpan.FromDays(10); // Test için 60 dk idealdir
});

// Add services to the container.
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));

}); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
