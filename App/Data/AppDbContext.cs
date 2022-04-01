using App.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace App.Data;

public class AppDbContext : DbContext
{
    public DbSet<Race>? Races { get; set; }
    public DbSet<Driver>? Drivers { get; set; }
    public DbSet<Vehicule>? Vehicules { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    }
}
