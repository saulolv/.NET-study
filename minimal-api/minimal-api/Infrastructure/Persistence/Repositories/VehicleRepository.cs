using Microsoft.EntityFrameworkCore;
using minimal_api.Domain.Helpers;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Infraestructure.Persistence.Database;

namespace minimal_api.Infrastructure.Persistence.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly DatabaseContext _database;
    
    public VehicleRepository(DatabaseContext database)
    {
        _database = database;
    }

    public async Task<Pagination<Vehicle>> GetPaginatedVehicles(int page, int pageSize, string? name, string? brand)
    {
        var query = _database.Vehicles.AsQueryable();
        
        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(v => EF.Functions.Like(v.Name.ToLower(), $"%{name.ToLower()}%"));
        }

        if (!string.IsNullOrEmpty(brand))
        {
            query = query.Where(v => EF.Functions.Like(v.Brand.ToLower(), $"%{brand.ToLower()}%"));
        }

        var totalItems = await query.CountAsync();

        // Itens paginados
        var items = await query
            .OrderBy(v => v.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new Pagination<Vehicle>
        {
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems,
            Items = items
        };
    }

    public async Task<Vehicle?> GetById(int id)
    {
        return await _database.Vehicles.FindAsync(id);
    }

    public void Add(Vehicle vehicle)
    {
        _database.Vehicles.Add(vehicle);
        SaveChanges();
    }

    public void Update(Vehicle vehicle)
    {
        _database.Vehicles.Update(vehicle);
        SaveChanges(); 
    }

    public void Remove(Vehicle vehicle)
    {
        _database.Vehicles.Remove(vehicle);
        SaveChanges();
    }

    private void SaveChanges()
    {
       _database.SaveChanges();
    }
}