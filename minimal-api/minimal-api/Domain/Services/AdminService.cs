using MinimalApi.Domain.Dtos;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Infraestructure.Persistence.Database;

namespace MinimalApi.Domain.Services;

public class AdminService : IAdminService
{
    private readonly DatabaseContext _database;
    public AdminService(DatabaseContext database)
    {
        _database = database;
    }
    
    public Admin? Login(LoginDto loginDto)
    {
        var admin = _database.Admins.FirstOrDefault(a => a.Email == loginDto.Email && a.Password == loginDto.Password);
        return admin;
    }
}