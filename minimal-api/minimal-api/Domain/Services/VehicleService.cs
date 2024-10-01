using minimal_api.Domain.Helpers;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Interfaces;

namespace MinimalApi.Domain.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _repository;
    
    public VehicleService(IVehicleRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Pagination<Vehicle>> GetAllVehicles(int page = 1, int pageSize = 10, string? name = null, string? brand = null)
    {
        var (items, totalItems) = await _repository.GetPaginatedVehicles(page, pageSize, name, brand);
        return new Pagination<Vehicle>
        {
            Page = page,
            PageSize = pageSize,
            Items = items,
            TotalItems = totalItems
        };
    }

    public async Task<Vehicle?> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public void Put(Vehicle vehicle)
    {
        _repository.Add(vehicle);
    }

    public void Update(Vehicle vehicle)
    {
        _repository.Update(vehicle);
    }

    public void Delete(Vehicle vehicle)
    {
        _repository.Remove(vehicle);
    }
}