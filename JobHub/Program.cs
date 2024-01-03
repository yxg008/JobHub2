using ASPProject.EntityFramework;
using JobHub.EntityFramework;
using JobHub.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add lowercase URL routing and controllers with views 
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<MyServiceInterface, MyServiceClass>(); // Replace with your actual service interface and class

// Configuring DbContext with SQLite
builder.Services.AddDbContext<JobHubDbContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("myDB")) // Make sure "myDB" matches your actual connection string key in appsettings.json
);

builder.Services.AddIdentity<JobHubUser, IdentityRole>(
    options =>
    {
        options.SignIn.RequireConfirmedEmail = false;
        options.Password.RequireDigit = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.User.RequireUniqueEmail = true;

    }
    ).AddEntityFrameworkStores<JobHubDbContext>();


var app = builder.Build();

// Only run this in development, never in production
if (app.Environment.IsDevelopment())
{
    var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
    using (var scope = scopeFactory.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<JobHubDbContext>();
      // dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }
}

if (app.Environment.IsDevelopment())
{
    //get detailed error page
    app.UseDeveloperExceptionPage();
}
else
{
    //get friendly error page
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithRedirects("/Home/Error");
}

// Middleware for serving static files
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization(); // Only if using authentication

// Custom routes
app.MapControllerRoute(
    name: "CompanyRoute",
    pattern: "company/{action=Index}/{id?}",
    defaults: new { Controller = "Company", action = "Index" }, // Default action should be valid
    constraints: new { id = @"\d+" }
);

app.MapControllerRoute(
    name: "JobSeekerRoute",
    pattern: "job-seekers/{action=Index}/{id?}",
    defaults: new { Controller = "JobSeeker", action = "Index" }, // Default action should be valid
    constraints: new { id = @"\d+" }
);

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Error handling route
app.MapControllerRoute(
    name: "Error",
    pattern: "error",
    defaults: new { Controller = "Error", Action = "Index" }
);

// Start the application
app.Run();
