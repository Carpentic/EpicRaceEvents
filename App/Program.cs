using App.CustomTokensProvider;
using App.Data;
using App.Models.DatabaseModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        ConfigureBuilder(builder);

        WebApplication app = builder.Build();
        ConfigureDeveloppementOptions(app);

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseAuthentication();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );

        using (var scope = app.Services.CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureCreated();
            new EFRepository(scope.ServiceProvider.GetRequiredService<AppDbContext>()).Seed();
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

    private static void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(typeof(IRepository), typeof(EFRepository));
        builder.Services.AddDbContext<AppDbContext>(
            dbContextOptions => dbContextOptions
            .UseMySql(builder.Configuration["mysql-con"], new MySqlServerVersion(new Version(8, 0, 27)))
            .LogTo(Console.Write, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .UseLazyLoadingProxies()
        );
        builder.Services.AddDefaultIdentity<Driver>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<EmailConfirmationTokenProvider<Driver>>("EmailConfirmation");
        builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
            opt.TokenLifespan = TimeSpan.FromHours(2)
        );
        builder.Services.Configure<EmailConfirmationTokenProviderOptions>(opt =>
            opt.TokenLifespan = TimeSpan.FromDays(3)
        );
        builder.Services.AddSingleton(builder.Configuration
            .GetSection("EmailConfiguration")
            .Get<EmailService.Config>()
        );
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
            options.AccessDeniedPath = "/Account/Error";
            options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
        });
        builder.Services.AddMvc(options =>
        {
            options.Filters.Add(new AuthorizeFilter());
        });
        builder.Services.AddScoped<EmailService.ISender, EmailService.Sender>();
        builder.Services.AddControllersWithViews();
    }
}
