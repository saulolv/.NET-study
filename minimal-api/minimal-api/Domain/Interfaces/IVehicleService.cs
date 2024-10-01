using minimal_api.Domain.Helpers;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Domain.Interfaces;

public interface IVehicleService
{
    Task<Pagination<Vehicle>> GetAllVehicles(int page = 1, int pageSize = 10, string? name = null, string? brand = null);
    Task<Vehicle?> GetById(int id);
    void Put(Vehicle vehicle);
    void Update(Vehicle vehicle);
    void Delete(Vehicle vehicle);
}