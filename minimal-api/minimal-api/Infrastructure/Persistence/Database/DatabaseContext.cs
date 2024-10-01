using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Infraestructure.Persistence.Database;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configurartion;

    public DatabaseContext(IConfiguration configuration)
    {
        _configurartion = configuration;
    }
    public DbSet<Admin> Admins { get; set; } = default!;
    public DbSet<Vehicle> Vehicles { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>().HasData(
            new Admin
            {
                Id = 1,
                Email = "Administrador@teste.com",
                Password = "12345",
                Role = "Adm"
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        if(!optionsBuilder.IsConfigured)
        {
            var connectionString = _configurartion.GetConnectionString("postgres");
            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}