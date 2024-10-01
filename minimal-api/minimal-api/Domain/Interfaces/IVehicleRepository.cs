using minimal_api.Domain.Helpers;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Domain.Interfaces;

public interface IVehicleRepository
{
    Task<Pagination<Vehicle>> GetPaginatedVehicles(int page = 1, int pageSize = 10, string? name = null, string? brand = null);
    Task<Vehicle?> GetById(int id);
    void Add(Vehicle vehicle);
    void Update(Vehicle vehicle);
    void Remove(Vehicle vehicle);
}