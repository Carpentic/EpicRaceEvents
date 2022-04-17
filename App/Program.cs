using App.Data;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped(typeof(IRepository), typeof(EFRepository));
        builder.Services.AddDbContext<AppDbContext>(
            dbContextOptions => dbContextOptions
            .UseMySql(builder.Configuration["mysql-con"], new MySqlServerVersion(new Version(8, 0, 27)))
            .LogTo(Console.Write, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .UseLazyLoadingProxies()
            );

        WebApplication app = builder.Build();
        ConfigureDeveloppementOptions(app);

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );

        using (var scope = app.Services.CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureCreated();
        }

        app.Run();
    }

    private static void ConfigureDeveloppementOptions(WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
    }
}
