using KatmanliBlogSitesi.Data;
using KatmanliBlogSitesi.Service.Abstract;
using KatmanliBlogSitesi.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddSession();
builder.Services.AddHttpClient(); 
builder.Services.AddSingleton<IHttpContextAccessor , HttpContextAccessor>();

// Authentication : Oturum açma servisi
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login"; // giriþ yapma sayfasý
    x.AccessDeniedPath = "/AccessDenied"; // giriþ yapan kullanýcýnýn admin yetkisi yoksa AccessDenied sayfasýna yönlendir
    x.LogoutPath = "/Admin/Login/Logout"; // çýkýþ sayfasý
    x.Cookie.Name = "Administrator"; // oluþacak kukinin adý
    x.Cookie.MaxAge = TimeSpan.FromDays(1); // oluþacak kukinin yaþam süresi
});
// Authorization : Yetkilendirme
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Role", "Admin"));
    x.AddPolicy("UserPolicy", policy => policy.RequireClaim("Role", "User"));
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
app.UseSession();

app.UseAuthentication();    

app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
