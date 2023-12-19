using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using P06_Authen.Areas.Identity.Data;
using P06_Authen.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthenDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthenDbContextConnection' not found.");

builder.Services.AddDbContext<AuthenDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MyUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
     
}).AddEntityFrameworkStores<AuthenDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//MiddleWare คอยตรวจสอบความถูกต้อง คล้ายๆ ยาม
builder.Services.AddControllersWithViews();

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
app.UseAuthentication(); //ตรวจสอบการล็อคอิน
app.UseAuthorization(); //ยืนยันการล็อคอิน

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints => endpoints.MapRazorPages());
app.MapRazorPages();
app.Run();
