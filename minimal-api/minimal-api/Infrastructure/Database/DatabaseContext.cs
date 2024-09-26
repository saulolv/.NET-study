using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Infraestructure.Database;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configurartion;

    public DatabaseContext(IConfiguration configuration)
    {
        _configurartion = configuration;
    }
    public DbSet<Admin> Admins { get; set; } = default!;

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