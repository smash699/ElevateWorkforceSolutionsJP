using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ElevateWorkforceSolutionsJP.Areas.Identity.Data;
using ElevateWorkforceSolutionsJP.EntityModel;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDBcontextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDBcontextConnection' not found.");;

builder.Services.AddDbContext<ApplicationDBcontext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationIDuser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBcontext>();

// Add services to the container.
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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    
app.MapRazorPages();


app.Run();
